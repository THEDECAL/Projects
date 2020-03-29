namespace BookShop
{
    partial class RegistrationForm
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.gbGeneric = new System.Windows.Forms.GroupBox();
            this.btnRegIn = new System.Windows.Forms.Button();
            this.lbLogin = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbPasswordFirst = new System.Windows.Forms.TextBox();
            this.tbPasswordSecond = new System.Windows.Forms.TextBox();
            this.gbGeneric.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(78, 15);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(159, 24);
            this.tbName.TabIndex = 0;
            // 
            // lbName
            // 
            this.lbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbName.Location = new System.Drawing.Point(6, 16);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(66, 23);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Имя:";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbGeneric
            // 
            this.gbGeneric.Controls.Add(this.tbPasswordSecond);
            this.gbGeneric.Controls.Add(this.tbPasswordFirst);
            this.gbGeneric.Controls.Add(this.lbPassword);
            this.gbGeneric.Controls.Add(this.tbLogin);
            this.gbGeneric.Controls.Add(this.lbLogin);
            this.gbGeneric.Controls.Add(this.btnRegIn);
            this.gbGeneric.Controls.Add(this.tbName);
            this.gbGeneric.Controls.Add(this.lbName);
            this.gbGeneric.Location = new System.Drawing.Point(2, -3);
            this.gbGeneric.Name = "gbGeneric";
            this.gbGeneric.Size = new System.Drawing.Size(243, 172);
            this.gbGeneric.TabIndex = 2;
            this.gbGeneric.TabStop = false;
            // 
            // btnRegIn
            // 
            this.btnRegIn.Location = new System.Drawing.Point(58, 143);
            this.btnRegIn.Name = "btnRegIn";
            this.btnRegIn.Size = new System.Drawing.Size(123, 23);
            this.btnRegIn.TabIndex = 0;
            this.btnRegIn.Text = "Зарегистрироваться";
            this.btnRegIn.UseVisualStyleBackColor = true;
            this.btnRegIn.Click += new System.EventHandler(this.btnRegIn_Click);
            // 
            // lbLogin
            // 
            this.lbLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbLogin.Location = new System.Drawing.Point(6, 49);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(66, 23);
            this.lbLogin.TabIndex = 2;
            this.lbLogin.Text = "Логин:";
            this.lbLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(78, 48);
            this.tbLogin.Multiline = true;
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(159, 24);
            this.tbLogin.TabIndex = 3;
            // 
            // lbPassword
            // 
            this.lbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPassword.Location = new System.Drawing.Point(6, 82);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(66, 55);
            this.lbPassword.TabIndex = 4;
            this.lbPassword.Text = "Пароль:";
            this.lbPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPasswordFirst
            // 
            this.tbPasswordFirst.Location = new System.Drawing.Point(78, 81);
            this.tbPasswordFirst.Multiline = true;
            this.tbPasswordFirst.Name = "tbPasswordFirst";
            this.tbPasswordFirst.PasswordChar = '●';
            this.tbPasswordFirst.Size = new System.Drawing.Size(159, 24);
            this.tbPasswordFirst.TabIndex = 5;
            // 
            // tbPasswordSecond
            // 
            this.tbPasswordSecond.Location = new System.Drawing.Point(78, 113);
            this.tbPasswordSecond.Multiline = true;
            this.tbPasswordSecond.Name = "tbPasswordSecond";
            this.tbPasswordSecond.PasswordChar = '●';
            this.tbPasswordSecond.Size = new System.Drawing.Size(159, 24);
            this.tbPasswordSecond.TabIndex = 6;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 171);
            this.Controls.Add(this.gbGeneric);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RegistrationForm";
            this.Text = "Регистрация";
            this.gbGeneric.ResumeLayout(false);
            this.gbGeneric.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.GroupBox gbGeneric;
        private System.Windows.Forms.TextBox tbPasswordFirst;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.Button btnRegIn;
        private System.Windows.Forms.TextBox tbPasswordSecond;
    }
}