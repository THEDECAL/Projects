namespace task3
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.grpBoxShow = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBoxTextShow = new System.Windows.Forms.TextBox();
            this.grpBoxShow.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(73, 214);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(125, 29);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(204, 214);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(125, 29);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // grpBoxShow
            // 
            this.grpBoxShow.Controls.Add(this.btnSave);
            this.grpBoxShow.Controls.Add(this.txtBoxTextShow);
            this.grpBoxShow.Controls.Add(this.btnOpen);
            this.grpBoxShow.Controls.Add(this.btnEdit);
            this.grpBoxShow.Location = new System.Drawing.Point(12, 12);
            this.grpBoxShow.Name = "grpBoxShow";
            this.grpBoxShow.Size = new System.Drawing.Size(532, 249);
            this.grpBoxShow.TabIndex = 2;
            this.grpBoxShow.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(335, 214);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBoxTextShow
            // 
            this.txtBoxTextShow.Location = new System.Drawing.Point(6, 19);
            this.txtBoxTextShow.Multiline = true;
            this.txtBoxTextShow.Name = "txtBoxTextShow";
            this.txtBoxTextShow.ReadOnly = true;
            this.txtBoxTextShow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxTextShow.Size = new System.Drawing.Size(520, 189);
            this.txtBoxTextShow.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 273);
            this.Controls.Add(this.grpBoxShow);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Текстовый редактор";
            this.grpBoxShow.ResumeLayout(false);
            this.grpBoxShow.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.GroupBox grpBoxShow;
        private System.Windows.Forms.TextBox txtBoxTextShow;
        private System.Windows.Forms.Button btnSave;
    }
}

