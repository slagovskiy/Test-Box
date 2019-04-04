using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace ImageToSpreadsheet
{
    class Program
    {
        #region Application cancellation support
        /*
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(CancelEventHandler handler, bool add);
        private delegate bool CancelEventHandler(CtrlType sig);
        static CancelEventHandler handler;
        enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }
        
        */
        #endregion 

        static bool exitNow = false;
        static Excel.Application app = null;
        static Excel.Workbook workbook = null;
        static Excel.Worksheet worksheet = null;
        static object missValue = System.Reflection.Missing.Value;

        static List<BackgroundWorker> workers = new List<BackgroundWorker>();

        static double pixelSize = 0.1;
        const string usageHelp = "Usage: ImageToSpreadsheet.exe [pixel_size] pic001.jpg [pic002.jpg ... picNNN.jpg]\n" +
                                 "where [pixel_size] should be in range from 1 to 5. Default value is 1.\n" +
                                 "Example: ImageToSpreadsheet.exe 2 photo.jpg pic007.jpg";

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(usageHelp);
            }
            else
            {
                //handler += new CancelEventHandler(Handler);
                //SetConsoleCtrlHandler(handler, true);

                try
                {
                    List<string> arguments = args.ToList();
                    // Try to get pixel size
                    int ps = 0;
                    if (int.TryParse(arguments[0], out ps))
                    {
                        if (ps < 1 || ps > 5)
                        {
                            Console.WriteLine(usageHelp);
                            Environment.Exit(1);
                        }
                        pixelSize = (double)ps / 10.0;
                        arguments.RemoveAt(0);
                    }

                    var startTime = DateTime.Now;
                    // Start Excel and create a new workbook
                    app = new Excel.Application();
                    app.Visible = true;
                    workbook = app.Workbooks.Add(1);

                    for (int i = 0; i < arguments.Count; i++)
                    {
                        if (File.Exists(arguments[i]) && Path.GetExtension(arguments[i]).ToLower().Equals(".jpg"))
                        {
                            var fileName = Path.GetFileName(arguments[i]);
                            var bmp = new Bitmap(fileName);
                            if (bmp != null)
                            {
                                Console.WriteLine("Processing image " + fileName);
                                Debug.WriteLine("Processing image " + fileName);

                                //ThreadPool.SetMinThreads(bmp.Height, bmp.Height);

                                bmp.RotateFlip(RotateFlipType.Rotate270FlipY);

                                // Copy all bitmap pixels to the array
                                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
                                IntPtr ptr = bmpData.Scan0;
                                int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
                                byte[] rgbValues = new byte[bytes];
                                Marshal.Copy(ptr, rgbValues, 0, bytes);
                                bmp.UnlockBits(bmpData);

                                // Create new worksheet and name it by image file name
                                if (i > 0) app.Sheets.Add();
                                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                                worksheet.Name = fileName;

                                // Resize "picture" first (speed optimization)
                                Excel.Range start = worksheet.Cells[1, 1];
                                Excel.Range end = worksheet.Cells[bmp.Width, bmp.Height];
                                Excel.Range range = worksheet.get_Range(start, end);
                                range.ColumnWidth = pixelSize;
                                range.RowHeight = pixelSize * 9;

                                // Unfortunately I haven't found a way to set cells background in range,
                                // so we'll set colors pixel by pixel

                                // Convert bitmap pixels to cells :)
                                for (int y = 0; y < bmp.Height; y++)
                                {
                                    if (exitNow) break;

                                    // Create thread
                                    var worker = new BackgroundWorker();
                                    worker.WorkerSupportsCancellation = true;
                                    worker.DoWork += (object sender, DoWorkEventArgs e) =>
                                        {
                                            var p = (WorkerParams)e.Argument;
                                            for (int x = 0; x < p.Width; x++)
                                            {
                                                if (exitNow) break;
                                                try
                                                {
                                                    Excel.Range pixel = (Excel.Range) worksheet.Cells[x + 1, p.Y + 1];
                                                    pixel.Interior.Color = p.Pixels[x];
                                                    Marshal.FinalReleaseComObject(pixel);
                                                    pixel = null;
                                                    // Without lines below, you'll have a HUGE memory leak!
                                                }
                                                catch(Exception ex)
                                                {
                                                    Debug.WriteLine("!!! " + ex.Message);
                                                    //exitNow = true;
                                                    break;
                                                }
                                            }
                                        };

                                    // Prepare scan-line 
                                    var pixels = new int[bmp.Width];
                                    for (int x = 0; x < bmp.Width; x++)
                                        pixels[x] = ((int)rgbValues[y * bmpData.Stride + x * 3] << 16) + ((int)rgbValues[y * bmpData.Stride + x * 3 + 1] << 8) + rgbValues[y * bmpData.Stride + x * 3 + 2];

                                    worker.RunWorkerAsync(new WorkerParams(pixels, bmp.Width, y));
                                    workers.Add(worker);
                                    while (workers.Count(w => w.IsBusy) > 20) Thread.Sleep(new Random().Next(100, 500));
                                    pixels = null;
                                    GC.Collect();
                                    GC.WaitForPendingFinalizers();
                                }

                                while (workers.Count(w => w.IsBusy) > 0 && !exitNow) Thread.Sleep(100);
                                workers.Clear();
                            }
                        }
                    }
                    var elapsedTime = string.Format("Elapsed time: {0}", DateTime.Now.Subtract(startTime));
                    Debug.WriteLine(elapsedTime);
                    Console.WriteLine(elapsedTime);
                }
                catch (Exception e)
                {
                    exitNow = true;
                    Debug.WriteLine(e.Message);
                }
                finally
                {
                    if (exitNow)
                    {
                        try
                        {
                            workbook.Close(false, missValue, missValue);
                            Marshal.ReleaseComObject(workbook);
                        }
                        catch { }
                    }
                    try
                    {
                        app.Quit();
                        Marshal.ReleaseComObject(app);
                    }
                    catch { }
                }
            }
        }

        /*
        private static bool Handler(CtrlType sig)
        {
            Console.WriteLine("Application interrupted");
            exitNow = true;
            return true;
        }
        */
        public class WorkerParams
        {
            public int[] Pixels;
            public int Y;
            public int Width;
            public WorkerParams(int[] pixels, int width, int y) { Pixels = pixels; Width = width; Y = y; }
        }
    }
}
