namespace TestTask
{
    partial class DepartmentMasterForm
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
            this.chkbState = new System.Windows.Forms.CheckBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.cbDep = new System.Windows.Forms.ComboBox();
            this.lbDep = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkbState);
            this.groupBox1.Controls.Add(this.btnAccept);
            this.groupBox1.Controls.Add(this.cbDep);
            this.groupBox1.Controls.Add(this.lbDep);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Location = new System.Drawing.Point(2, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 168);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chkbState
            // 
            this.chkbState.AutoSize = true;
            this.chkbState.Checked = true;
            this.chkbState.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkbState.Location = new System.Drawing.Point(7, 106);
            this.chkbState.Name = "chkbState";
            this.chkbState.Size = new System.Drawing.Size(197, 21);
            this.chkbState.TabIndex = 8;
            this.chkbState.Text = "Состояние активности";
            this.chkbState.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(7, 129);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(80, 33);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Применить";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // cbDep
            // 
            this.cbDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDep.FormattingEnabled = true;
            this.cbDep.Location = new System.Drawing.Point(6, 78);
            this.cbDep.Name = "cbDep";
            this.cbDep.Size = new System.Drawing.Size(189, 21);
            this.cbDep.TabIndex = 6;
            // 
            // lbDep
            // 
            this.lbDep.AutoSize = true;
            this.lbDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDep.Location = new System.Drawing.Point(10, 58);
            this.lbDep.Name = "lbDep";
            this.lbDep.Size = new System.Drawing.Size(131, 17);
            this.lbDep.TabIndex = 5;
            this.lbDep.Text = "Подразделение:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(115, 129);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbName.Location = new System.Drawing.Point(10, 12);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(85, 17);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Название:";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(6, 32);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(189, 23);
            this.tbName.TabIndex = 0;
            // 
            // DepartmentMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 165);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DepartmentMasterForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мастер Департамента";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbDep;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ComboBox cbDep;
        private System.Windows.Forms.CheckBox chkbState;
    }
}