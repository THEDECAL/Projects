namespace smartfon_catalog
{
    partial class ProgressForm
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
            this.pbDownloads = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // pbDownloads
            // 
            this.pbDownloads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDownloads.Location = new System.Drawing.Point(0, 0);
            this.pbDownloads.Name = "pbDownloads";
            this.pbDownloads.Size = new System.Drawing.Size(554, 29);
            this.pbDownloads.TabIndex = 1;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 29);
            this.Controls.Add(this.pbDownloads);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "ProgressForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Идёт загрузка контента подождите...";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ProgressBar pbDownloads;
    }
}