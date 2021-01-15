namespace TestTask
{
    partial class EmployeMasterForm
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
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.cbPosition = new System.Windows.Forms.ComboBox();
            this.cbDep = new System.Windows.Forms.ComboBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpDateDismiss = new System.Windows.Forms.DateTimePicker();
            this.dtpDateEmp = new System.Windows.Forms.DateTimePicker();
            this.dtpBirthDay = new System.Windows.Forms.DateTimePicker();
            this.tbCause = new System.Windows.Forms.TextBox();
            this.tbPlace = new System.Windows.Forms.TextBox();
            this.lbCause = new System.Windows.Forms.Label();
            this.lbDateEmp = new System.Windows.Forms.Label();
            this.lbDateDismiss = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbPlace = new System.Windows.Forms.Label();
            this.lbDep = new System.Windows.Forms.Label();
            this.lbBirthday = new System.Windows.Forms.Label();
            this.lbGender = new System.Windows.Forms.Label();
            this.tbPN = new System.Windows.Forms.TextBox();
            this.lbSName = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbPName = new System.Windows.Forms.Label();
            this.tbSName = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbPName = new System.Windows.Forms.TextBox();
            this.lbPos = new System.Windows.Forms.Label();
            this.tbTIN = new System.Windows.Forms.TextBox();
            this.lbPN = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbGender);
            this.groupBox1.Controls.Add(this.cbPosition);
            this.groupBox1.Controls.Add(this.cbDep);
            this.groupBox1.Controls.Add(this.btnAccept);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.dtpDateDismiss);
            this.groupBox1.Controls.Add(this.dtpDateEmp);
            this.groupBox1.Controls.Add(this.dtpBirthDay);
            this.groupBox1.Controls.Add(this.tbCause);
            this.groupBox1.Controls.Add(this.tbPlace);
            this.groupBox1.Controls.Add(this.lbCause);
            this.groupBox1.Controls.Add(this.lbDateEmp);
            this.groupBox1.Controls.Add(this.lbDateDismiss);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lbPlace);
            this.groupBox1.Controls.Add(this.lbDep);
            this.groupBox1.Controls.Add(this.lbBirthday);
            this.groupBox1.Controls.Add(this.lbGender);
            this.groupBox1.Controls.Add(this.tbPN);
            this.groupBox1.Controls.Add(this.lbSName);
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Controls.Add(this.lbPName);
            this.groupBox1.Controls.Add(this.tbSName);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.tbPName);
            this.groupBox1.Controls.Add(this.lbPos);
            this.groupBox1.Controls.Add(this.tbTIN);
            this.groupBox1.Controls.Add(this.lbPN);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 253);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cbGender
            // 
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "М",
            "Ж"});
            this.cbGender.Location = new System.Drawing.Point(211, 93);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(41, 21);
            this.cbGender.TabIndex = 65;
            // 
            // cbPosition
            // 
            this.cbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPosition.FormattingEnabled = true;
            this.cbPosition.Location = new System.Drawing.Point(390, 17);
            this.cbPosition.Name = "cbPosition";
            this.cbPosition.Size = new System.Drawing.Size(180, 21);
            this.cbPosition.TabIndex = 64;
            // 
            // cbDep
            // 
            this.cbDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDep.FormattingEnabled = true;
            this.cbDep.Location = new System.Drawing.Point(390, 90);
            this.cbDep.Name = "cbDep";
            this.cbDep.Size = new System.Drawing.Size(180, 21);
            this.cbDep.TabIndex = 63;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(188, 215);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(80, 33);
            this.btnAccept.TabIndex = 62;
            this.btnAccept.Text = "Применить";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(296, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 33);
            this.btnCancel.TabIndex = 61;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtpDateDismiss
            // 
            this.dtpDateDismiss.Location = new System.Drawing.Point(392, 137);
            this.dtpDateDismiss.Name = "dtpDateDismiss";
            this.dtpDateDismiss.Size = new System.Drawing.Size(179, 20);
            this.dtpDateDismiss.TabIndex = 60;
            // 
            // dtpDateEmp
            // 
            this.dtpDateEmp.Location = new System.Drawing.Point(207, 137);
            this.dtpDateEmp.Name = "dtpDateEmp";
            this.dtpDateEmp.Size = new System.Drawing.Size(179, 20);
            this.dtpDateEmp.TabIndex = 59;
            // 
            // dtpBirthDay
            // 
            this.dtpBirthDay.Location = new System.Drawing.Point(6, 114);
            this.dtpBirthDay.Name = "dtpBirthDay";
            this.dtpBirthDay.Size = new System.Drawing.Size(182, 20);
            this.dtpBirthDay.TabIndex = 58;
            // 
            // tbCause
            // 
            this.tbCause.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCause.Location = new System.Drawing.Point(6, 186);
            this.tbCause.Name = "tbCause";
            this.tbCause.Size = new System.Drawing.Size(564, 23);
            this.tbCause.TabIndex = 57;
            // 
            // tbPlace
            // 
            this.tbPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPlace.Location = new System.Drawing.Point(6, 161);
            this.tbPlace.Name = "tbPlace";
            this.tbPlace.Size = new System.Drawing.Size(380, 23);
            this.tbPlace.TabIndex = 55;
            this.tbPlace.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbCause
            // 
            this.lbCause.AutoSize = true;
            this.lbCause.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCause.Location = new System.Drawing.Point(397, 164);
            this.lbCause.Name = "lbCause";
            this.lbCause.Size = new System.Drawing.Size(170, 17);
            this.lbCause.TabIndex = 52;
            this.lbCause.Text = "Причина увольнения:";
            // 
            // lbDateEmp
            // 
            this.lbDateEmp.AutoSize = true;
            this.lbDateEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDateEmp.Location = new System.Drawing.Point(205, 117);
            this.lbDateEmp.Name = "lbDateEmp";
            this.lbDateEmp.Size = new System.Drawing.Size(183, 17);
            this.lbDateEmp.TabIndex = 38;
            this.lbDateEmp.Text = "Дата трудоустройства:";
            // 
            // lbDateDismiss
            // 
            this.lbDateDismiss.AutoSize = true;
            this.lbDateDismiss.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDateDismiss.Location = new System.Drawing.Point(412, 117);
            this.lbDateDismiss.Name = "lbDateDismiss";
            this.lbDateDismiss.Size = new System.Drawing.Size(143, 17);
            this.lbDateDismiss.TabIndex = 37;
            this.lbDateDismiss.Text = "Дата увольнения:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(341, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 17);
            this.label16.TabIndex = 51;
            this.label16.Text = "ИНН:";
            // 
            // lbPlace
            // 
            this.lbPlace.AutoSize = true;
            this.lbPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPlace.Location = new System.Drawing.Point(10, 141);
            this.lbPlace.Name = "lbPlace";
            this.lbPlace.Size = new System.Drawing.Size(137, 17);
            this.lbPlace.TabIndex = 50;
            this.lbPlace.Text = "Место рождения:";
            // 
            // lbDep
            // 
            this.lbDep.AutoSize = true;
            this.lbDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDep.Location = new System.Drawing.Point(256, 92);
            this.lbDep.Name = "lbDep";
            this.lbDep.Size = new System.Drawing.Size(131, 17);
            this.lbDep.TabIndex = 49;
            this.lbDep.Text = "Подразделение:";
            // 
            // lbBirthday
            // 
            this.lbBirthday.AutoSize = true;
            this.lbBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBirthday.Location = new System.Drawing.Point(10, 94);
            this.lbBirthday.Name = "lbBirthday";
            this.lbBirthday.Size = new System.Drawing.Size(129, 17);
            this.lbBirthday.TabIndex = 48;
            this.lbBirthday.Text = "Дата рождения:";
            // 
            // lbGender
            // 
            this.lbGender.AutoSize = true;
            this.lbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbGender.Location = new System.Drawing.Point(162, 94);
            this.lbGender.Name = "lbGender";
            this.lbGender.Size = new System.Drawing.Size(42, 17);
            this.lbGender.TabIndex = 47;
            this.lbGender.Text = "Пол:";
            // 
            // tbPN
            // 
            this.tbPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPN.Location = new System.Drawing.Point(390, 40);
            this.tbPN.Name = "tbPN";
            this.tbPN.Size = new System.Drawing.Size(180, 23);
            this.tbPN.TabIndex = 46;
            this.tbPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbSName
            // 
            this.lbSName.AutoSize = true;
            this.lbSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSName.Location = new System.Drawing.Point(3, 15);
            this.lbSName.Name = "lbSName";
            this.lbSName.Size = new System.Drawing.Size(82, 17);
            this.lbSName.TabIndex = 45;
            this.lbSName.Text = "Фамилия:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbName.Location = new System.Drawing.Point(4, 40);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(43, 17);
            this.lbName.TabIndex = 44;
            this.lbName.Text = "Имя:";
            // 
            // lbPName
            // 
            this.lbPName.AutoSize = true;
            this.lbPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPName.Location = new System.Drawing.Point(4, 66);
            this.lbPName.Name = "lbPName";
            this.lbPName.Size = new System.Drawing.Size(84, 17);
            this.lbPName.TabIndex = 42;
            this.lbPName.Text = "Отчетсво:";
            // 
            // tbSName
            // 
            this.tbSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSName.Location = new System.Drawing.Point(101, 12);
            this.tbSName.Name = "tbSName";
            this.tbSName.Size = new System.Drawing.Size(180, 23);
            this.tbSName.TabIndex = 41;
            this.tbSName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(101, 37);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(180, 23);
            this.tbName.TabIndex = 39;
            this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPName
            // 
            this.tbPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPName.Location = new System.Drawing.Point(101, 63);
            this.tbPName.Name = "tbPName";
            this.tbPName.Size = new System.Drawing.Size(180, 23);
            this.tbPName.TabIndex = 36;
            this.tbPName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbPos
            // 
            this.lbPos.AutoSize = true;
            this.lbPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPos.Location = new System.Drawing.Point(292, 18);
            this.lbPos.Name = "lbPos";
            this.lbPos.Size = new System.Drawing.Size(95, 17);
            this.lbPos.TabIndex = 35;
            this.lbPos.Text = "Должность:";
            // 
            // tbTIN
            // 
            this.tbTIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTIN.Location = new System.Drawing.Point(390, 65);
            this.tbTIN.Name = "tbTIN";
            this.tbTIN.Size = new System.Drawing.Size(180, 23);
            this.tbTIN.TabIndex = 34;
            this.tbTIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbPN
            // 
            this.lbPN.AutoSize = true;
            this.lbPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPN.Location = new System.Drawing.Point(341, 43);
            this.lbPN.Name = "lbPN";
            this.lbPN.Size = new System.Drawing.Size(34, 17);
            this.lbPN.TabIndex = 33;
            this.lbPN.Text = "ТН:";
            // 
            // EmployeMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 253);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeMasterForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мастер Сотрудника";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbCause;
        private System.Windows.Forms.TextBox tbPlace;
        private System.Windows.Forms.Label lbCause;
        private System.Windows.Forms.Label lbDateEmp;
        private System.Windows.Forms.Label lbDateDismiss;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbPlace;
        private System.Windows.Forms.Label lbDep;
        private System.Windows.Forms.Label lbBirthday;
        private System.Windows.Forms.Label lbGender;
        private System.Windows.Forms.TextBox tbPN;
        private System.Windows.Forms.Label lbSName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbPName;
        private System.Windows.Forms.TextBox tbSName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbPName;
        private System.Windows.Forms.Label lbPos;
        private System.Windows.Forms.TextBox tbTIN;
        private System.Windows.Forms.Label lbPN;
        private System.Windows.Forms.DateTimePicker dtpDateEmp;
        private System.Windows.Forms.DateTimePicker dtpBirthDay;
        private System.Windows.Forms.DateTimePicker dtpDateDismiss;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.ComboBox cbPosition;
        private System.Windows.Forms.ComboBox cbDep;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}