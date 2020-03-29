namespace practice
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
            this.btnName = new System.Windows.Forms.Button();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtBoxChat = new System.Windows.Forms.TextBox();
            this.txtBoxInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnName
            // 
            this.btnName.Location = new System.Drawing.Point(205, 5);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(75, 23);
            this.btnName.TabIndex = 0;
            this.btnName.Text = "Принять";
            this.btnName.UseVisualStyleBackColor = true;
            this.btnName.Click += new System.EventHandler(this.btnName_Click);
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(93, 7);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(100, 20);
            this.txtBoxName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(75, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Введите имя:";
            // 
            // txtBoxChat
            // 
            this.txtBoxChat.Enabled = false;
            this.txtBoxChat.Location = new System.Drawing.Point(12, 33);
            this.txtBoxChat.Multiline = true;
            this.txtBoxChat.Name = "txtBoxChat";
            this.txtBoxChat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxChat.Size = new System.Drawing.Size(268, 173);
            this.txtBoxChat.TabIndex = 3;
            this.txtBoxChat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxInput
            // 
            this.txtBoxInput.Enabled = false;
            this.txtBoxInput.Location = new System.Drawing.Point(12, 212);
            this.txtBoxInput.Multiline = true;
            this.txtBoxInput.Name = "txtBoxInput";
            this.txtBoxInput.Size = new System.Drawing.Size(268, 38);
            this.txtBoxInput.TabIndex = 4;
            this.txtBoxInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBoxInput_KeyUp);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(93, 256);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 283);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtBoxInput);
            this.Controls.Add(this.txtBoxChat);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.btnName);
            this.MaximumSize = new System.Drawing.Size(300, 310);
            this.MinimumSize = new System.Drawing.Size(300, 310);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Чат";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnName;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtBoxChat;
        private System.Windows.Forms.TextBox txtBoxInput;
        private System.Windows.Forms.Button btnSend;
    }
}

