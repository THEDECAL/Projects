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
            this.lbName = new System.Windows.Forms.Label();
            this.lbAuthor = new System.Windows.Forms.Label();
            this.btnImage = new System.Windows.Forms.Button();
            this.cmsRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.положитьВКорзинуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbPrice = new System.Windows.Forms.Label();
            this.gbGeneric = new System.Windows.Forms.GroupBox();
            this.cmsRightClick.SuspendLayout();
            this.gbGeneric.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbName.Location = new System.Drawing.Point(6, 210);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(112, 28);
            this.lbName.TabIndex = 2;
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbAuthor
            // 
            this.lbAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAuthor.Location = new System.Drawing.Point(6, 12);
            this.lbAuthor.Name = "lbAuthor";
            this.lbAuthor.Size = new System.Drawing.Size(112, 28);
            this.lbAuthor.TabIndex = 3;
            this.lbAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnImage
            // 
            this.btnImage.ForeColor = System.Drawing.Color.Black;
            this.btnImage.Location = new System.Drawing.Point(6, 43);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(112, 164);
            this.btnImage.TabIndex = 4;
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            this.btnImage.MouseLeave += new System.EventHandler(this.btnImage_MouseLeave);
            this.btnImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnImage_MouseMove);
            this.btnImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnImage_MouseUp);
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
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            // 
            // lbPrice
            // 
            this.lbPrice.BackColor = System.Drawing.Color.PeachPuff;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(69)))));
            this.lbPrice.Location = new System.Drawing.Point(6, 238);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(112, 28);
            this.lbPrice.TabIndex = 6;
            this.lbPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbGeneric
            // 
            this.gbGeneric.Controls.Add(this.btnImage);
            this.gbGeneric.Controls.Add(this.lbName);
            this.gbGeneric.Controls.Add(this.lbPrice);
            this.gbGeneric.Controls.Add(this.lbAuthor);
            this.gbGeneric.Location = new System.Drawing.Point(1, -4);
            this.gbGeneric.Name = "gbGeneric";
            this.gbGeneric.Size = new System.Drawing.Size(124, 273);
            this.gbGeneric.TabIndex = 7;
            this.gbGeneric.TabStop = false;
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
            this.Size = new System.Drawing.Size(126, 269);
            this.cmsRightClick.ResumeLayout(false);
            this.gbGeneric.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbAuthor;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.ContextMenuStrip cmsRightClick;
        private System.Windows.Forms.ToolStripMenuItem положитьВКорзинуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.GroupBox gbGeneric;
    }
}
