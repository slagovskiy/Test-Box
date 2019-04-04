using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace Pings
{
    class Program
    {
        static bool stop = false;
        static bool subWindow = false;
        static int windowWidth, windowsHeight;
        static int windowWidthOld, windowsHeightOld;
        static int aa = 0;
        static ConsoleColor originalForegroundColor;
        static List<PingResult> addresses = new List<PingResult>();
        // http://www.rapidtables.com/code/text/ascii-table.htm
        static Thread p = new Thread(print);
        static Thread n = new Thread(ping);
        static Thread k = new Thread(key);

        static ConsoleEventDelegate handler;
        private delegate bool ConsoleEventDelegate(int eventType);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);


        static void Main(string[] args)
        {
            handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);

            init();

            drawWindow();
            drawMenu();

            if (File.Exists("pings.conf"))
            {
                using (StreamReader f = new StreamReader("pings.conf"))
                {
                    while(!f.EndOfStream)
                    {
                        string tmp = f.ReadLine();
                        addresses.Add(new PingResult(tmp));
                    }
                }
            }
            else
                addresses.Add(new PingResult("localhost"));

            p.Start();

            n.Start();

            k.Start();
            k.Join();

            clearColor();
        }

        static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                saveConf();
            }
            return false;
        }

        static void init()
        {
            Console.Clear();
            originalForegroundColor = Console.ForegroundColor;
            windowWidth = Console.WindowWidth;
            windowsHeight = Console.WindowHeight;
        }

        static void saveConf()
        {
            using (StreamWriter f = new StreamWriter("pings.conf"))
            {
                foreach (PingResult p in addresses)
                {
                    f.WriteLine(p.address);
                }
            }
        }

        static void clearColor()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = originalForegroundColor;
        }

        static void key()
        {
            ConsoleKeyInfo c;
            do
            {
                c = Console.ReadKey();
                if (c.Key == ConsoleKey.A)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(0, 0);
                    Console.Write('╔');
                    addAddress();
                }
                if (c.Key == ConsoleKey.D)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(0, 0);
                    Console.Write('╔');
                    deleteAddress();
                }
                if (c.Key == ConsoleKey.R)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(0, 0);
                    Console.Write('╔');
                    drawWindow();
                    drawMenu();
                }
                if (c.Key == ConsoleKey.C)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(0, 0);
                    Console.Write('╔');
                    addresses.Clear();
                    drawWindow();
                    drawMenu();
                }
                Thread.Sleep(250);
            } while ((!subWindow) & (c.Key != ConsoleKey.Escape));
            if (c.Key == ConsoleKey.Escape)
                saveConf();
            p.Abort();
            n.Abort();
            stop = true;
        }

        static void addAddress()
        {
            windowWidth = Console.WindowWidth;
            windowsHeight = Console.WindowHeight;

            Console.ForegroundColor = ConsoleColor.Yellow;
            subWindow = true;
            Console.SetCursorPosition(windowWidth / 2 - 15, windowsHeight / 2 - 3);
            Console.Write("╔══════╡ enter address ╞══════╗");
            Console.SetCursorPosition(windowWidth / 2 - 15, windowsHeight / 2 - 2);
            Console.Write("║                             ║");
            Console.SetCursorPosition(windowWidth / 2 - 15, windowsHeight / 2 - 1);
            Console.Write("╚═════════════════════════════╝");
            Console.SetCursorPosition(windowWidth / 2 - 13, windowsHeight / 2 - 2);
            Console.ForegroundColor = ConsoleColor.White;
            string _a = Console.ReadLine();
            if (_a != "")
            {
                addresses.Add(new PingResult(_a));
            }
            drawWindow();
            drawMenu();
            subWindow = false;
        }

        static void deleteAddress()
        {
            windowWidth = Console.WindowWidth;
            windowsHeight = Console.WindowHeight;

            Console.ForegroundColor = ConsoleColor.Yellow;
            subWindow = true;
            Console.SetCursorPosition(windowWidth / 2 - 15, windowsHeight / 2 - 3);
            Console.Write("╔════╡ enter row number ╞═════╗");
            Console.SetCursorPosition(windowWidth / 2 - 15, windowsHeight / 2 - 2);
            Console.Write("║                             ║");
            Console.SetCursorPosition(windowWidth / 2 - 15, windowsHeight / 2 - 1);
            Console.Write("╚═════════════════════════════╝");
            Console.SetCursorPosition(windowWidth / 2 - 13, windowsHeight / 2 - 2);
            Console.ForegroundColor = ConsoleColor.White;
            int _r = int.Parse(Console.ReadLine()) - 1;
            if((_r >= 0 ) & (_r < addresses.Count))
                addresses.RemoveAt(_r);
            drawWindow();
            drawMenu();
            subWindow = false;
        }

        static void ping()
        {
            while (!stop)
            {
                foreach (PingResult _ping in addresses)
                {
                    if (!_ping.wait)
                    {
                        if (_ping.pinger == null)
                        {
                            Ping pingSender = new Ping();
                            pingSender.PingCompleted += new PingCompletedEventHandler(pingCompletedCallback);
                            _ping.pinger = pingSender;
                        }
                        _ping.wait = true;
                        _ping.pinger.SendAsync(
                            _ping.address, 
                            10000,
                            Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"), 
                            new PingOptions(64, true), 
                            _ping
                        );
                    }
                }
                Thread.Sleep(500);
            }
        }

        static void pingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                ((PingResult)e.UserState).wait = false;
                ((PingResult)e.UserState).status = "Canceled";
                ((PingResult)e.UserState).time = "";
            }
            else if (e.Error != null)
            {
                ((PingResult)e.UserState).wait = false;
                ((PingResult)e.UserState).status = "Failed";
                ((PingResult)e.UserState).time = "";
            }
            else
            {
                if (e.Reply != null)
                {
                    foreach(PingResult ping in addresses)
                    {
                        if (ping.address == ((PingResult)e.UserState).address)
                        {
                            ping.wait = false;
                            ping.time = e.Reply.RoundtripTime.ToString() + "ms";
                            ping.status = e.Reply.Status.ToString();
                        }
                    }
                    //((PingResult)e.UserState).wait = false;
                    //((PingResult)e.UserState).time = e.Reply.RoundtripTime.ToString() + "ms";
                    //((PingResult)e.UserState).status = e.Reply.Status.ToString();
                }
            }
        }

        static void print()
        {
            while (!stop)
            {
                if (!subWindow)
                {
                    windowWidth = Console.WindowWidth;
                    windowsHeight = Console.WindowHeight;

                    if ((windowWidth != windowWidthOld) || (windowsHeight != windowsHeightOld))
                    {
                        windowsHeightOld = windowsHeight;
                        windowWidthOld = windowWidth;
                        drawWindow();
                        drawMenu();
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    string d = "╡ " + DateTime.Now.ToLongTimeString() + " ╞";
                    Console.SetCursorPosition(windowWidth - d.Length - 3, 0);
                    Console.Write(d);
                    int row = 1;
                    int _row = 1;
                    int col = 2;
                    int _cols = addresses.Count / (windowsHeight - 5) + ((addresses.Count % (windowWidth - 5))  > 0 ? 1 : 0);
                    foreach (PingResult _ping in addresses)
                    {
                        int _colw = (windowWidth - 2) / _cols;
                        string tmp = "";
                        Console.SetCursorPosition(col, row);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        tmp = _row.ToString("D2") + " ";
                        _colw -= tmp.Length;
                        if (_colw > 0)
                            Console.Write(tmp);
                        else
                            if (_colw + tmp.Length - 1 > 0) Console.Write(tmp.Substring(0, _colw + tmp.Length - 1));

                        Console.ForegroundColor = ConsoleColor.White;
                        tmp = _ping.address;
                        _colw -= tmp.Length;
                        if (_colw > 0)
                            Console.Write(tmp);
                        else
                            if (_colw + tmp.Length - 1 > 0) Console.Write(tmp.Substring(0, _colw + tmp.Length - 1));

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        tmp = " - ";
                        _colw -= tmp.Length;
                        if (_colw > 0)
                            Console.Write(tmp);
                        else
                            if (_colw + tmp.Length - 1 > 0) Console.Write(tmp.Substring(0, _colw + tmp.Length - 1));


                        if (_ping.status == "Success")
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Gray;
                        tmp = (_ping.status != null ? _ping.status : "");
                        _colw -= tmp.Length;
                        if (_colw > 0)
                            Console.Write(tmp);
                        else
                            if (_colw + tmp.Length - 1 > 0) Console.Write(tmp.Substring(0, _colw + tmp.Length - 1));

                        if (_ping.status == "Success")
                        {
                            tmp = " " + _ping.time;
                            _colw -= tmp.Length;
                            if (_colw > 0)
                                Console.Write(tmp);
                            else
                                if (_colw + tmp.Length - 1> 0 ) Console.Write(tmp.Substring(0, _colw + tmp.Length - 1));
                                
                        }
                        else
                            _ping.time = "";
                        Console.Write(new StringBuilder().Append(' ', (_colw < 0 ? 0 : _colw)).ToString());
                        Console.ForegroundColor = originalForegroundColor;
                        row++;
                        _row++;
                        if (row > windowsHeight - 5)
                        {
                            row = 1;
                            col += (windowWidth - 4) / _cols;
                        }
                    }
                    Console.SetCursorPosition(0, 0);
                }
                Thread.Sleep(1000);
            }
        }

        static void drawWindow()
        {
            windowWidth = Console.WindowWidth;
            windowsHeight = Console.WindowHeight;

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.SetCursorPosition(0, 0);
            Console.Write('╔');
            for (int i = 0; i < windowWidth - 2; i++) Console.Write('═');
            Console.Write('╗');
            for (int j = 0; j < windowsHeight - 2; j++)
            {
                Console.SetCursorPosition(0, j + 1);
                Console.Write('║');
                for (int i = 0; i < windowWidth - 2; i++) Console.Write(' ');
                Console.Write('║');
            }
            Console.SetCursorPosition(0, windowsHeight - 1);
            Console.Write('╚');
            for (int i = 0; i < windowWidth - 2; i++) Console.Write('═');
            Console.Write('╝');

            Console.SetCursorPosition(0, windowsHeight - 3);
            Console.Write('╟');
            for (int i = 0; i < windowWidth - 2; i++) Console.Write('─');
            Console.Write('╢');
        }

        static void drawMenu()
        {
            windowWidth = Console.WindowWidth;
            windowsHeight = Console.WindowHeight;

            Console.ForegroundColor = ConsoleColor.DarkGray;

            string[] menuItems = {"A - Add address", "D - delete address", "C - clear", "R - refresh", "Escape - quit" };
            StringBuilder tmp = new StringBuilder();
            Console.SetCursorPosition(2, windowsHeight - 2);
            foreach (string item in menuItems)
            {
                tmp.Append(item);
                tmp.Append(" │ ");
            }
            int pos = ((windowWidth - 4) - (tmp.Length - 3)) / 2;
            int border = 0;
            foreach (string item in menuItems)
            {
                border += item.Length + 3;
                Console.SetCursorPosition(pos + border - 2, windowsHeight - 3);
                Console.Write('┬');
                Console.SetCursorPosition(pos + border - 2, windowsHeight - 1);
                Console.Write('╧');
            }
            Console.SetCursorPosition(pos + border - 2, windowsHeight - 3);
            Console.Write('─');
            Console.SetCursorPosition(pos + border - 2, windowsHeight - 1);
            Console.Write('═');
            Console.SetCursorPosition(pos, windowsHeight - 2);
            Console.Write(tmp.ToString(0, tmp.Length - 3));
        }
    }
}
