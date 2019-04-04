namespace TUSUR_DBСP_FilmOCritic
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.genreMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.countryMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.typePersonMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.personMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.filmMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.userMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.commentMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ratingMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.reportMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.reportPersonMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.reportFilmMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.reportCommentMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.dataMenu,
            this.reportMenu,
            this.toolMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(48, 20);
            this.fileMenu.Text = "Файл";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dataMenu
            // 
            this.dataMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genreMenu,
            this.countryMenu,
            this.typePersonMenu,
            this.personMenu,
            this.toolStripSeparator1,
            this.filmMenu,
            this.toolStripSeparator2,
            this.userMenu,
            this.commentMenu,
            this.ratingMenu});
            this.dataMenu.Name = "dataMenu";
            this.dataMenu.Size = new System.Drawing.Size(62, 20);
            this.dataMenu.Text = "Данные";
            // 
            // genreMenu
            // 
            this.genreMenu.Name = "genreMenu";
            this.genreMenu.Size = new System.Drawing.Size(152, 22);
            this.genreMenu.Text = "Жанры";
            this.genreMenu.Click += new System.EventHandler(this.genreMenu_Click);
            // 
            // countryMenu
            // 
            this.countryMenu.Name = "countryMenu";
            this.countryMenu.Size = new System.Drawing.Size(152, 22);
            this.countryMenu.Text = "Страны";
            this.countryMenu.Click += new System.EventHandler(this.countryMenu_Click);
            // 
            // typePersonMenu
            // 
            this.typePersonMenu.Name = "typePersonMenu";
            this.typePersonMenu.Size = new System.Drawing.Size(152, 22);
            this.typePersonMenu.Text = "Тип персон";
            this.typePersonMenu.Click += new System.EventHandler(this.typePersonMenu_Click);
            // 
            // personMenu
            // 
            this.personMenu.Name = "personMenu";
            this.personMenu.Size = new System.Drawing.Size(152, 22);
            this.personMenu.Text = "Персоны";
            this.personMenu.Click += new System.EventHandler(this.personMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // filmMenu
            // 
            this.filmMenu.Name = "filmMenu";
            this.filmMenu.Size = new System.Drawing.Size(152, 22);
            this.filmMenu.Text = "Фильмы";
            this.filmMenu.Click += new System.EventHandler(this.filmMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // userMenu
            // 
            this.userMenu.Name = "userMenu";
            this.userMenu.Size = new System.Drawing.Size(152, 22);
            this.userMenu.Text = "Пользователи";
            this.userMenu.Click += new System.EventHandler(this.userMenu_Click);
            // 
            // commentMenu
            // 
            this.commentMenu.Name = "commentMenu";
            this.commentMenu.Size = new System.Drawing.Size(152, 22);
            this.commentMenu.Text = "Комментарии";
            this.commentMenu.Click += new System.EventHandler(this.commentMenu_Click);
            // 
            // ratingMenu
            // 
            this.ratingMenu.Name = "ratingMenu";
            this.ratingMenu.Size = new System.Drawing.Size(152, 22);
            this.ratingMenu.Text = "Оценки";
            this.ratingMenu.Click += new System.EventHandler(this.ratingMenu_Click);
            // 
            // reportMenu
            // 
            this.reportMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportPersonMenu,
            this.reportFilmMenu,
            this.reportCommentMenu});
            this.reportMenu.Name = "reportMenu";
            this.reportMenu.Size = new System.Drawing.Size(60, 20);
            this.reportMenu.Text = "Отчеты";
            // 
            // reportPersonMenu
            // 
            this.reportPersonMenu.Name = "reportPersonMenu";
            this.reportPersonMenu.Size = new System.Drawing.Size(176, 22);
            this.reportPersonMenu.Text = "по Персонам";
            this.reportPersonMenu.Click += new System.EventHandler(this.reportPersonMenu_Click);
            // 
            // reportFilmMenu
            // 
            this.reportFilmMenu.Name = "reportFilmMenu";
            this.reportFilmMenu.Size = new System.Drawing.Size(176, 22);
            this.reportFilmMenu.Text = "по Фильмам";
            this.reportFilmMenu.Click += new System.EventHandler(this.reportFilmMenu_Click);
            // 
            // reportCommentMenu
            // 
            this.reportCommentMenu.Name = "reportCommentMenu";
            this.reportCommentMenu.Size = new System.Drawing.Size(176, 22);
            this.reportCommentMenu.Text = "по Комментариям";
            this.reportCommentMenu.Click += new System.EventHandler(this.reportCommentMenu_Click);
            // 
            // toolMenu
            // 
            this.toolMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenu});
            this.toolMenu.Name = "toolMenu";
            this.toolMenu.Size = new System.Drawing.Size(66, 20);
            this.toolMenu.Text = "Утилиты";
            // 
            // settingsMenu
            // 
            this.settingsMenu.Name = "settingsMenu";
            this.settingsMenu.Size = new System.Drawing.Size(134, 22);
            this.settingsMenu.Text = "Настройки";
            this.settingsMenu.Click += new System.EventHandler(this.settingsMenu_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(68, 20);
            this.helpMenu.Text = "Помощь";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.Text = "ТУСУР - БД - Фильм-о-Критик";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem toolMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsMenu;
        private System.Windows.Forms.ToolStripMenuItem dataMenu;
        private System.Windows.Forms.ToolStripMenuItem genreMenu;
        private System.Windows.Forms.ToolStripMenuItem countryMenu;
        private System.Windows.Forms.ToolStripMenuItem typePersonMenu;
        private System.Windows.Forms.ToolStripMenuItem personMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem filmMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem userMenu;
        private System.Windows.Forms.ToolStripMenuItem commentMenu;
        private System.Windows.Forms.ToolStripMenuItem ratingMenu;
        private System.Windows.Forms.ToolStripMenuItem reportMenu;
        private System.Windows.Forms.ToolStripMenuItem reportPersonMenu;
        private System.Windows.Forms.ToolStripMenuItem reportFilmMenu;
        private System.Windows.Forms.ToolStripMenuItem reportCommentMenu;
    }
}



