namespace ShipsAndThreads
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbSea = new System.Windows.Forms.GroupBox();
            this.lbSea = new System.Windows.Forms.ListBox();
            this.gbChannel = new System.Windows.Forms.GroupBox();
            this.lbChannel = new System.Windows.Forms.ListBox();
            this.gbBread = new System.Windows.Forms.GroupBox();
            this.pbBread = new System.Windows.Forms.ProgressBar();
            this.lblBread = new System.Windows.Forms.Label();
            this.gbClothes = new System.Windows.Forms.GroupBox();
            this.pbClothes = new System.Windows.Forms.ProgressBar();
            this.lblClothes = new System.Windows.Forms.Label();
            this.gbBanana = new System.Windows.Forms.GroupBox();
            this.pbBanana = new System.Windows.Forms.ProgressBar();
            this.lblBanana = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.gbSea.SuspendLayout();
            this.gbChannel.SuspendLayout();
            this.gbBread.SuspendLayout();
            this.gbClothes.SuspendLayout();
            this.gbBanana.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSea
            // 
            this.gbSea.Controls.Add(this.lbSea);
            this.gbSea.Location = new System.Drawing.Point(12, 12);
            this.gbSea.Name = "gbSea";
            this.gbSea.Size = new System.Drawing.Size(185, 426);
            this.gbSea.TabIndex = 0;
            this.gbSea.TabStop = false;
            this.gbSea.Text = "Море";
            // 
            // lbSea
            // 
            this.lbSea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSea.FormattingEnabled = true;
            this.lbSea.ItemHeight = 16;
            this.lbSea.Location = new System.Drawing.Point(6, 19);
            this.lbSea.Name = "lbSea";
            this.lbSea.Size = new System.Drawing.Size(173, 388);
            this.lbSea.TabIndex = 0;
            // 
            // gbChannel
            // 
            this.gbChannel.Controls.Add(this.lbChannel);
            this.gbChannel.Location = new System.Drawing.Point(251, 151);
            this.gbChannel.Name = "gbChannel";
            this.gbChannel.Size = new System.Drawing.Size(230, 156);
            this.gbChannel.TabIndex = 1;
            this.gbChannel.TabStop = false;
            this.gbChannel.Text = "Канал";
            // 
            // lbChannel
            // 
            this.lbChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbChannel.FormattingEnabled = true;
            this.lbChannel.ItemHeight = 16;
            this.lbChannel.Location = new System.Drawing.Point(6, 19);
            this.lbChannel.Name = "lbChannel";
            this.lbChannel.Size = new System.Drawing.Size(218, 116);
            this.lbChannel.TabIndex = 0;
            // 
            // gbBread
            // 
            this.gbBread.Controls.Add(this.pbBread);
            this.gbBread.Controls.Add(this.lblBread);
            this.gbBread.Location = new System.Drawing.Point(588, 12);
            this.gbBread.Name = "gbBread";
            this.gbBread.Size = new System.Drawing.Size(200, 100);
            this.gbBread.TabIndex = 2;
            this.gbBread.TabStop = false;
            this.gbBread.Text = "Пир для хлеба";
            // 
            // pbBread
            // 
            this.pbBread.Location = new System.Drawing.Point(10, 61);
            this.pbBread.Name = "pbBread";
            this.pbBread.Size = new System.Drawing.Size(184, 33);
            this.pbBread.TabIndex = 1;
            // 
            // lblBread
            // 
            this.lblBread.AutoSize = true;
            this.lblBread.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBread.Location = new System.Drawing.Point(6, 16);
            this.lblBread.Name = "lblBread";
            this.lblBread.Size = new System.Drawing.Size(47, 17);
            this.lblBread.TabIndex = 0;
            this.lblBread.Text = "Пусто";
            // 
            // gbClothes
            // 
            this.gbClothes.Controls.Add(this.pbClothes);
            this.gbClothes.Controls.Add(this.lblClothes);
            this.gbClothes.Location = new System.Drawing.Point(588, 338);
            this.gbClothes.Name = "gbClothes";
            this.gbClothes.Size = new System.Drawing.Size(200, 100);
            this.gbClothes.TabIndex = 3;
            this.gbClothes.TabStop = false;
            this.gbClothes.Text = "Пир для одежды";
            // 
            // pbClothes
            // 
            this.pbClothes.Location = new System.Drawing.Point(6, 61);
            this.pbClothes.Name = "pbClothes";
            this.pbClothes.Size = new System.Drawing.Size(184, 33);
            this.pbClothes.TabIndex = 3;
            // 
            // lblClothes
            // 
            this.lblClothes.AutoSize = true;
            this.lblClothes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblClothes.Location = new System.Drawing.Point(6, 16);
            this.lblClothes.Name = "lblClothes";
            this.lblClothes.Size = new System.Drawing.Size(47, 17);
            this.lblClothes.TabIndex = 2;
            this.lblClothes.Text = "Пусто";
            // 
            // gbBanana
            // 
            this.gbBanana.Controls.Add(this.pbBanana);
            this.gbBanana.Controls.Add(this.lblBanana);
            this.gbBanana.Location = new System.Drawing.Point(588, 176);
            this.gbBanana.Name = "gbBanana";
            this.gbBanana.Size = new System.Drawing.Size(200, 100);
            this.gbBanana.TabIndex = 4;
            this.gbBanana.TabStop = false;
            this.gbBanana.Text = "Пир для бананов";
            // 
            // pbBanana
            // 
            this.pbBanana.Location = new System.Drawing.Point(6, 61);
            this.pbBanana.Name = "pbBanana";
            this.pbBanana.Size = new System.Drawing.Size(184, 33);
            this.pbBanana.TabIndex = 2;
            // 
            // lblBanana
            // 
            this.lblBanana.AutoSize = true;
            this.lblBanana.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBanana.Location = new System.Drawing.Point(6, 16);
            this.lblBanana.Name = "lblBanana";
            this.lblBanana.Size = new System.Drawing.Size(47, 17);
            this.lblBanana.TabIndex = 1;
            this.lblBanana.Text = "Пусто";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.Location = new System.Drawing.Point(251, 389);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(230, 49);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gbBanana);
            this.Controls.Add(this.gbClothes);
            this.Controls.Add(this.gbBread);
            this.Controls.Add(this.gbChannel);
            this.Controls.Add(this.gbSea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "ShipsAndThreads";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.gbSea.ResumeLayout(false);
            this.gbChannel.ResumeLayout(false);
            this.gbBread.ResumeLayout(false);
            this.gbBread.PerformLayout();
            this.gbClothes.ResumeLayout(false);
            this.gbClothes.PerformLayout();
            this.gbBanana.ResumeLayout(false);
            this.gbBanana.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSea;
        private System.Windows.Forms.ListBox lbSea;
        private System.Windows.Forms.GroupBox gbChannel;
        private System.Windows.Forms.ListBox lbChannel;
        private System.Windows.Forms.GroupBox gbBread;
        private System.Windows.Forms.ProgressBar pbBread;
        private System.Windows.Forms.Label lblBread;
        private System.Windows.Forms.GroupBox gbClothes;
        private System.Windows.Forms.ProgressBar pbClothes;
        private System.Windows.Forms.Label lblClothes;
        private System.Windows.Forms.GroupBox gbBanana;
        private System.Windows.Forms.ProgressBar pbBanana;
        private System.Windows.Forms.Label lblBanana;
        private System.Windows.Forms.Button btnStart;
    }
}

