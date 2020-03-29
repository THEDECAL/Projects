namespace smartfon_catalog
{
    partial class PhoneBriefly : System.Windows.Forms.UserControl
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
            this.components = new System.ComponentModel.Container();
            this.gbGeneric = new System.Windows.Forms.GroupBox();
            this.btPhoneInfo = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.lbBrand = new System.Windows.Forms.Label();
            this.cmsRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbGeneric.SuspendLayout();
            this.cmsRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGeneric
            // 
            this.gbGeneric.BackColor = System.Drawing.SystemColors.Control;
            this.gbGeneric.Controls.Add(this.btPhoneInfo);
            this.gbGeneric.Controls.Add(this.lbName);
            this.gbGeneric.Controls.Add(this.lbBrand);
            this.gbGeneric.Location = new System.Drawing.Point(2, -4);
            this.gbGeneric.Name = "gbGeneric";
            this.gbGeneric.Size = new System.Drawing.Size(178, 258);
            this.gbGeneric.TabIndex = 1;
            this.gbGeneric.TabStop = false;
            // 
            // btPhoneInfo
            // 
            this.btPhoneInfo.BackColor = System.Drawing.SystemColors.Window;
            this.btPhoneInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPhoneInfo.ForeColor = System.Drawing.SystemColors.Window;
            this.btPhoneInfo.Location = new System.Drawing.Point(6, 10);
            this.btPhoneInfo.Name = "btPhoneInfo";
            this.btPhoneInfo.Size = new System.Drawing.Size(166, 180);
            this.btPhoneInfo.TabIndex = 3;
            this.btPhoneInfo.UseVisualStyleBackColor = false;
            this.btPhoneInfo.Click += new System.EventHandler(this.btPhoneInfo_Click);
            this.btPhoneInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btPhoneInfo_MouseUp);
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.SystemColors.Control;
            this.lbName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbName.Location = new System.Drawing.Point(6, 216);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(166, 39);
            this.lbName.TabIndex = 2;
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbBrand
            // 
            this.lbBrand.BackColor = System.Drawing.SystemColors.Control;
            this.lbBrand.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbBrand.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBrand.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbBrand.Location = new System.Drawing.Point(6, 193);
            this.lbBrand.Name = "lbBrand";
            this.lbBrand.Size = new System.Drawing.Size(166, 23);
            this.lbBrand.TabIndex = 1;
            this.lbBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmsRightClick
            // 
            this.cmsRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.cmsRightClick.Name = "cmsRightClick";
            this.cmsRightClick.Size = new System.Drawing.Size(181, 70);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // PhoneBriefly
            // 
            this.Controls.Add(this.gbGeneric);
            this.Name = "PhoneBriefly";
            this.Size = new System.Drawing.Size(184, 258);
            this.gbGeneric.ResumeLayout(false);
            this.cmsRightClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbGeneric;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbBrand;
        private System.Windows.Forms.Button btPhoneInfo;
        private System.Windows.Forms.ContextMenuStrip cmsRightClick;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
    }
}
