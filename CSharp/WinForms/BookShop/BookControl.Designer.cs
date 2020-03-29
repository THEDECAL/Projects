namespace BookShop
{
    partial class BookControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmsRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.положитьВКорзинуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbGeneric = new System.Windows.Forms.GroupBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.cmsRightClick.SuspendLayout();
            this.gbGeneric.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsRightClick
            // 
            this.cmsRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.положитьВКорзинуToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.изменитьToolStripMenuItem});
            this.cmsRightClick.Name = "cmsRightClick";
            this.cmsRightClick.Size = new System.Drawing.Size(179, 70);
            // 
            // положитьВКорзинуToolStripMenuItem
            // 
            this.положитьВКорзинуToolStripMenuItem.Name = "положитьВКорзинуToolStripMenuItem";
            this.положитьВКорзинуToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.положитьВКорзинуToolStripMenuItem.Text = "Положить в корзину";
            this.положитьВКорзинуToolStripMenuItem.Click += new System.EventHandler(this.положитьВКорзинуToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // gbGeneric
            // 
            this.gbGeneric.Controls.Add(this.tbPrice);
            this.gbGeneric.Controls.Add(this.tbName);
            this.gbGeneric.Controls.Add(this.pbImage);
            this.gbGeneric.Location = new System.Drawing.Point(3, -2);
            this.gbGeneric.Name = "gbGeneric";
            this.gbGeneric.Size = new System.Drawing.Size(118, 235);
            this.gbGeneric.TabIndex = 7;
            this.gbGeneric.TabStop = false;
            // 
            // tbPrice
            // 
            this.tbPrice.BackColor = System.Drawing.Color.PeachPuff;
            this.tbPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPrice.Enabled = false;
            this.tbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPrice.ForeColor = System.Drawing.Color.SteelBlue;
            this.tbPrice.Location = new System.Drawing.Point(4, 204);
            this.tbPrice.Multiline = true;
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(110, 26);
            this.tbPrice.TabIndex = 9;
            this.tbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbName
            // 
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Enabled = false;
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(2, 7);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(112, 33);
            this.tbName.TabIndex = 8;
            this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.White;
            this.pbImage.Location = new System.Drawing.Point(2, 40);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(112, 162);
            this.pbImage.TabIndex = 7;
            this.pbImage.TabStop = false;
            this.pbImage.MouseLeave += new System.EventHandler(this.pbImage_MouseLeave);
            this.pbImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseMove);
            this.pbImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseUp);
            // 
            // BookControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.gbGeneric);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Name = "BookControl";
            this.Size = new System.Drawing.Size(123, 235);
            this.cmsRightClick.ResumeLayout(false);
            this.gbGeneric.ResumeLayout(false);
            this.gbGeneric.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsRightClick;
        private System.Windows.Forms.ToolStripMenuItem положитьВКорзинуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbGeneric;
        public System.Windows.Forms.PictureBox pbImage;
        public System.Windows.Forms.TextBox tbPrice;
        public System.Windows.Forms.TextBox tbName;
    }
}
