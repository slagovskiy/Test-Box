namespace TUSUR_DBСP_FilmOCritic
{
    partial class frmCommentAllow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCommentAllow));
            this.txtUser = new System.Windows.Forms.Label();
            this.txtFilm = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.Label();
            this.btnPub = new System.Windows.Forms.Button();
            this.btnBad = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.ftnFinish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.AutoSize = true;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtUser.Location = new System.Drawing.Point(12, 43);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(85, 20);
            this.txtUser.TabIndex = 0;
            this.txtUser.Text = "UserName";
            // 
            // txtFilm
            // 
            this.txtFilm.AutoSize = true;
            this.txtFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtFilm.Location = new System.Drawing.Point(12, 9);
            this.txtFilm.Name = "txtFilm";
            this.txtFilm.Size = new System.Drawing.Size(232, 24);
            this.txtFilm.TabIndex = 1;
            this.txtFilm.Text = "Москва слезам не верит";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtComment.Location = new System.Drawing.Point(12, 76);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(417, 153);
            this.txtComment.TabIndex = 2;
            this.txtComment.Text = resources.GetString("txtComment.Text");
            // 
            // btnPub
            // 
            this.btnPub.BackColor = System.Drawing.Color.Green;
            this.btnPub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPub.ForeColor = System.Drawing.Color.Yellow;
            this.btnPub.Location = new System.Drawing.Point(12, 232);
            this.btnPub.Name = "btnPub";
            this.btnPub.Size = new System.Drawing.Size(135, 80);
            this.btnPub.TabIndex = 3;
            this.btnPub.Text = "Опубликовать";
            this.btnPub.UseVisualStyleBackColor = false;
            this.btnPub.Click += new System.EventHandler(this.btnPub_Click);
            // 
            // btnBad
            // 
            this.btnBad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnBad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBad.ForeColor = System.Drawing.Color.White;
            this.btnBad.Location = new System.Drawing.Point(153, 232);
            this.btnBad.Name = "btnBad";
            this.btnBad.Size = new System.Drawing.Size(135, 80);
            this.btnBad.TabIndex = 4;
            this.btnBad.Text = "Плохой";
            this.btnBad.UseVisualStyleBackColor = false;
            this.btnBad.Click += new System.EventHandler(this.btnBad_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Blue;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(294, 232);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(135, 80);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Пропустить";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ftnFinish
            // 
            this.ftnFinish.Location = new System.Drawing.Point(153, 318);
            this.ftnFinish.Name = "ftnFinish";
            this.ftnFinish.Size = new System.Drawing.Size(135, 23);
            this.ftnFinish.TabIndex = 6;
            this.ftnFinish.Text = "Закончть";
            this.ftnFinish.UseVisualStyleBackColor = true;
            this.ftnFinish.Click += new System.EventHandler(this.ftnFinish_Click);
            // 
            // frmCommentAllow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 349);
            this.Controls.Add(this.ftnFinish);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBad);
            this.Controls.Add(this.btnPub);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtFilm);
            this.Controls.Add(this.txtUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCommentAllow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Комментарий";
            this.Load += new System.EventHandler(this.frmCommentAllow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtUser;
        private System.Windows.Forms.Label txtFilm;
        private System.Windows.Forms.Label txtComment;
        private System.Windows.Forms.Button btnPub;
        private System.Windows.Forms.Button btnBad;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button ftnFinish;
    }
}