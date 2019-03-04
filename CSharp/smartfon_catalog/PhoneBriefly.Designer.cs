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
            this.gbGeneric = new System.Windows.Forms.GroupBox();
            this.btPhoneInfo = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.lbBrand = new System.Windows.Forms.Label();
            this.gbGeneric.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGeneric
            // 
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
            this.btPhoneInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPhoneInfo.Location = new System.Drawing.Point(6, 10);
            this.btPhoneInfo.Name = "btPhoneInfo";
            this.btPhoneInfo.Size = new System.Drawing.Size(166, 180);
            this.btPhoneInfo.TabIndex = 3;
            this.btPhoneInfo.UseVisualStyleBackColor = true;
            this.btPhoneInfo.Click += new System.EventHandler(this.btPhoneInfo_Click);
            // 
            // lbName
            // 
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
            this.lbBrand.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbBrand.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBrand.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbBrand.Location = new System.Drawing.Point(6, 193);
            this.lbBrand.Name = "lbBrand";
            this.lbBrand.Size = new System.Drawing.Size(166, 23);
            this.lbBrand.TabIndex = 1;
            this.lbBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PhoneBriefly
            // 
            this.Controls.Add(this.gbGeneric);
            this.Name = "PhoneBriefly";
            this.Size = new System.Drawing.Size(184, 258);
            this.gbGeneric.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbGeneric;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbBrand;
        private System.Windows.Forms.Button btPhoneInfo;
    }
}
