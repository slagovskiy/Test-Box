namespace TUSUR_DBСP_FilmOCritic
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDatabaseFile = new System.Windows.Forms.Label();
            this.txtDatabaseFile = new System.Windows.Forms.TextBox();
            this.btnDatabaseFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(322, 133);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(403, 133);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblDatabaseFile
            // 
            this.lblDatabaseFile.AutoSize = true;
            this.lblDatabaseFile.Location = new System.Drawing.Point(12, 15);
            this.lblDatabaseFile.Name = "lblDatabaseFile";
            this.lblDatabaseFile.Size = new System.Drawing.Size(72, 13);
            this.lblDatabaseFile.TabIndex = 2;
            this.lblDatabaseFile.Text = "Database file:";
            // 
            // txtDatabaseFile
            // 
            this.txtDatabaseFile.Location = new System.Drawing.Point(90, 12);
            this.txtDatabaseFile.Name = "txtDatabaseFile";
            this.txtDatabaseFile.Size = new System.Drawing.Size(349, 20);
            this.txtDatabaseFile.TabIndex = 3;
            // 
            // btnDatabaseFile
            // 
            this.btnDatabaseFile.Location = new System.Drawing.Point(445, 10);
            this.btnDatabaseFile.Name = "btnDatabaseFile";
            this.btnDatabaseFile.Size = new System.Drawing.Size(33, 23);
            this.btnDatabaseFile.TabIndex = 4;
            this.btnDatabaseFile.Text = "...";
            this.btnDatabaseFile.UseVisualStyleBackColor = true;
            this.btnDatabaseFile.Click += new System.EventHandler(this.btnDatabaseFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "\"Database files (*.mdb)|*.mdb|All files (*.*)|*.*\"";
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(490, 168);
            this.Controls.Add(this.btnDatabaseFile);
            this.Controls.Add(this.txtDatabaseFile);
            this.Controls.Add(this.lblDatabaseFile);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDatabaseFile;
        private System.Windows.Forms.TextBox txtDatabaseFile;
        private System.Windows.Forms.Button btnDatabaseFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}