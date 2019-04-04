namespace TUSUR_DBСP_FilmOCritic
{
    partial class frmCommentary
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNewComments = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.btnRazbor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(490, 341);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNewComments
            // 
            this.btnNewComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewComments.Location = new System.Drawing.Point(240, 341);
            this.btnNewComments.Name = "btnNewComments";
            this.btnNewComments.Size = new System.Drawing.Size(244, 23);
            this.btnNewComments.TabIndex = 10;
            this.btnNewComments.Text = "Сгенерировать 10 новых комментариев";
            this.btnNewComments.UseVisualStyleBackColor = true;
            this.btnNewComments.Click += new System.EventHandler(this.btnNewComments_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToOrderColumns = true;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(12, 12);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.Size = new System.Drawing.Size(553, 323);
            this.dataGrid.TabIndex = 9;
            this.dataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellDoubleClick);
            // 
            // btnRazbor
            // 
            this.btnRazbor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRazbor.Location = new System.Drawing.Point(41, 341);
            this.btnRazbor.Name = "btnRazbor";
            this.btnRazbor.Size = new System.Drawing.Size(193, 23);
            this.btnRazbor.TabIndex = 12;
            this.btnRazbor.Text = "Разобрать новые комментарии";
            this.btnRazbor.UseVisualStyleBackColor = true;
            this.btnRazbor.Click += new System.EventHandler(this.btnRazbor_Click);
            // 
            // frmCommentary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 376);
            this.Controls.Add(this.btnRazbor);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNewComments);
            this.Controls.Add(this.dataGrid);
            this.Name = "frmCommentary";
            this.Text = "Комментарии";
            this.Load += new System.EventHandler(this.frmCommentary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNewComments;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button btnRazbor;
    }
}