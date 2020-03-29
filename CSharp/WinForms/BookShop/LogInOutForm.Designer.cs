namespace BookShop
{
    partial class LogInOutForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lbLogin = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEnter);
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.tbLogin);
            this.groupBox1.Controls.Add(this.lbLogin);
            this.groupBox1.Controls.Add(this.lbPassword);
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(66, 67);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.Text = "Войти";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(66, 38);
            this.tbPassword.Multiline = true;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '●';
            this.tbPassword.Size = new System.Drawing.Size(124, 23);
            this.tbPassword.TabIndex = 3;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(66, 12);
            this.tbLogin.Multiline = true;
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(124, 23);
            this.tbLogin.TabIndex = 2;
            // 
            // lbLogin
            // 
            this.lbLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbLogin.Location = new System.Drawing.Point(6, 12);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(54, 23);
            this.lbLogin.TabIndex = 1;
            this.lbLogin.Text = "Логин:";
            this.lbLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPassword
            // 
            this.lbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPassword.Location = new System.Drawing.Point(6, 38);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(54, 23);
            this.lbPassword.TabIndex = 0;
            this.lbPassword.Text = "Пароль:";
            this.lbPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogInOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 103);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LogInOutForm";
            this.Text = "Вход";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.Label lbPassword;
    }
}