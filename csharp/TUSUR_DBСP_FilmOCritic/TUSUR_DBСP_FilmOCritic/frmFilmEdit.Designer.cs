namespace TUSUR_DBСP_FilmOCritic
{
    partial class frmFilmEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.ComboBox();
            this.txtProducer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listActor = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGenre = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLimit = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.picPoster = new System.Windows.Forms.PictureBox();
            this.btnPoster = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(155, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(385, 20);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Год выхода";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(155, 38);
            this.txtYear.Mask = "0000";
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(47, 20);
            this.txtYear.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Автор сценария";
            // 
            // txtAuthor
            // 
            this.txtAuthor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtAuthor.FormattingEnabled = true;
            this.txtAuthor.Location = new System.Drawing.Point(155, 64);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(187, 21);
            this.txtAuthor.TabIndex = 5;
            // 
            // txtProducer
            // 
            this.txtProducer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtProducer.FormattingEnabled = true;
            this.txtProducer.Location = new System.Drawing.Point(155, 91);
            this.txtProducer.Name = "txtProducer";
            this.txtProducer.Size = new System.Drawing.Size(187, 21);
            this.txtProducer.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Режиссер";
            // 
            // listActor
            // 
            this.listActor.FormattingEnabled = true;
            this.listActor.Location = new System.Drawing.Point(155, 118);
            this.listActor.Name = "listActor";
            this.listActor.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listActor.Size = new System.Drawing.Size(187, 95);
            this.listActor.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Актеры";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Жанр";
            // 
            // txtGenre
            // 
            this.txtGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtGenre.FormattingEnabled = true;
            this.txtGenre.Location = new System.Drawing.Point(155, 219);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(187, 21);
            this.txtGenre.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Страна";
            // 
            // txtCountry
            // 
            this.txtCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCountry.FormattingEnabled = true;
            this.txtCountry.Location = new System.Drawing.Point(155, 250);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(187, 21);
            this.txtCountry.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Ограничение по возрасту";
            // 
            // txtLimit
            // 
            this.txtLimit.Location = new System.Drawing.Point(155, 277);
            this.txtLimit.Mask = "00";
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(29, 20);
            this.txtLimit.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 304);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Описание";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(155, 301);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(385, 206);
            this.txtDescription.TabIndex = 17;
            this.txtDescription.Text = "";
            // 
            // picPoster
            // 
            this.picPoster.Location = new System.Drawing.Point(348, 35);
            this.picPoster.Name = "picPoster";
            this.picPoster.Size = new System.Drawing.Size(192, 205);
            this.picPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPoster.TabIndex = 18;
            this.picPoster.TabStop = false;
            // 
            // btnPoster
            // 
            this.btnPoster.Location = new System.Drawing.Point(348, 248);
            this.btnPoster.Name = "btnPoster";
            this.btnPoster.Size = new System.Drawing.Size(192, 23);
            this.btnPoster.TabIndex = 19;
            this.btnPoster.Text = "Выбрать постер";
            this.btnPoster.UseVisualStyleBackColor = true;
            this.btnPoster.Click += new System.EventHandler(this.btnPoster_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(384, 513);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(465, 513);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // openFile
            // 
            this.openFile.Filter = "Images|*.jpg;*.png;*.gif|All files|*.*";
            // 
            // frmFilmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 548);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPoster);
            this.Controls.Add(this.picPoster);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtLimit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listActor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProducer);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmFilmEdit";
            this.Text = "Фильм";
            this.Load += new System.EventHandler(this.frmFilmEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txtAuthor;
        private System.Windows.Forms.ComboBox txtProducer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listActor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox txtGenre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox txtCountry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txtLimit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.PictureBox picPoster;
        private System.Windows.Forms.Button btnPoster;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.OpenFileDialog openFile;
    }
}