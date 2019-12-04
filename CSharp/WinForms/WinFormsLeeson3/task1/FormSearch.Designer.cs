namespace task1
{
    partial class FormSearch
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
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.txtSearchString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBoxParams = new System.Windows.Forms.GroupBox();
            this.chkBoxRecursive = new System.Windows.Forms.CheckBox();
            this.chkBoxMath = new System.Windows.Forms.CheckBox();
            this.chkBoxRegex = new System.Windows.Forms.CheckBox();
            this.chkBoxRegister = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveResults = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.lstBoxResults = new System.Windows.Forms.ListBox();
            this.txtBoxSelectedFolder = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.grpBoxParams.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(6, 58);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(94, 26);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "Выбрать папку";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // txtSearchString
            // 
            this.txtSearchString.Location = new System.Drawing.Point(6, 32);
            this.txtSearchString.Name = "txtSearchString";
            this.txtSearchString.Size = new System.Drawing.Size(154, 20);
            this.txtSearchString.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Строка поиска:";
            // 
            // grpBoxParams
            // 
            this.grpBoxParams.Controls.Add(this.chkBoxRecursive);
            this.grpBoxParams.Controls.Add(this.chkBoxMath);
            this.grpBoxParams.Controls.Add(this.chkBoxRegex);
            this.grpBoxParams.Controls.Add(this.chkBoxRegister);
            this.grpBoxParams.Location = new System.Drawing.Point(12, 138);
            this.grpBoxParams.Name = "grpBoxParams";
            this.grpBoxParams.Size = new System.Drawing.Size(166, 116);
            this.grpBoxParams.TabIndex = 5;
            this.grpBoxParams.TabStop = false;
            this.grpBoxParams.Text = "Параметры поиска:";
            // 
            // chkBoxRecursive
            // 
            this.chkBoxRecursive.AutoSize = true;
            this.chkBoxRecursive.Location = new System.Drawing.Point(7, 21);
            this.chkBoxRecursive.Name = "chkBoxRecursive";
            this.chkBoxRecursive.Size = new System.Drawing.Size(128, 17);
            this.chkBoxRecursive.TabIndex = 9;
            this.chkBoxRecursive.Text = "Искать в подпапках";
            this.chkBoxRecursive.UseVisualStyleBackColor = true;
            // 
            // chkBoxMath
            // 
            this.chkBoxMath.AutoSize = true;
            this.chkBoxMath.Location = new System.Drawing.Point(7, 67);
            this.chkBoxMath.Name = "chkBoxMath";
            this.chkBoxMath.Size = new System.Drawing.Size(125, 17);
            this.chkBoxMath.TabIndex = 9;
            this.chkBoxMath.Text = "Точное совпадение";
            this.chkBoxMath.UseVisualStyleBackColor = true;
            this.chkBoxMath.CheckedChanged += new System.EventHandler(this.chkBoxMath_CheckedChanged);
            // 
            // chkBoxRegex
            // 
            this.chkBoxRegex.AutoSize = true;
            this.chkBoxRegex.Location = new System.Drawing.Point(7, 90);
            this.chkBoxRegex.Name = "chkBoxRegex";
            this.chkBoxRegex.Size = new System.Drawing.Size(148, 17);
            this.chkBoxRegex.TabIndex = 10;
            this.chkBoxRegex.Text = "Регулярные выражения";
            this.chkBoxRegex.UseVisualStyleBackColor = true;
            this.chkBoxRegex.CheckedChanged += new System.EventHandler(this.chkBoxRegex_CheckedChanged);
            // 
            // chkBoxRegister
            // 
            this.chkBoxRegister.AutoSize = true;
            this.chkBoxRegister.Location = new System.Drawing.Point(7, 44);
            this.chkBoxRegister.Name = "chkBoxRegister";
            this.chkBoxRegister.Size = new System.Drawing.Size(124, 17);
            this.chkBoxRegister.TabIndex = 9;
            this.chkBoxRegister.Text = "Учитывать регистр";
            this.chkBoxRegister.UseVisualStyleBackColor = true;
            this.chkBoxRegister.CheckedChanged += new System.EventHandler(this.chkBoxRegister_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveResults);
            this.groupBox2.Controls.Add(this.btnFind);
            this.groupBox2.Controls.Add(this.txtSearchString);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSelectFolder);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 120);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Критерии поиска:";
            // 
            // btnSaveResults
            // 
            this.btnSaveResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveResults.Location = new System.Drawing.Point(7, 90);
            this.btnSaveResults.Name = "btnSaveResults";
            this.btnSaveResults.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSaveResults.Size = new System.Drawing.Size(153, 24);
            this.btnSaveResults.TabIndex = 8;
            this.btnSaveResults.Text = "Сохранить в файл";
            this.btnSaveResults.UseVisualStyleBackColor = true;
            this.btnSaveResults.Click += new System.EventHandler(this.btnSaveResults_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(106, 58);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(54, 26);
            this.btnFind.TabIndex = 9;
            this.btnFind.Text = "Найти";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lstBoxResults
            // 
            this.lstBoxResults.FormattingEnabled = true;
            this.lstBoxResults.HorizontalScrollbar = true;
            this.lstBoxResults.Location = new System.Drawing.Point(184, 30);
            this.lstBoxResults.Name = "lstBoxResults";
            this.lstBoxResults.ScrollAlwaysVisible = true;
            this.lstBoxResults.Size = new System.Drawing.Size(377, 225);
            this.lstBoxResults.TabIndex = 7;
            // 
            // txtBoxSelectedFolder
            // 
            this.txtBoxSelectedFolder.Location = new System.Drawing.Point(215, 4);
            this.txtBoxSelectedFolder.Name = "txtBoxSelectedFolder";
            this.txtBoxSelectedFolder.Size = new System.Drawing.Size(346, 20);
            this.txtBoxSelectedFolder.TabIndex = 8;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(184, 7);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(34, 13);
            this.lblPath.TabIndex = 9;
            this.lblPath.Text = "Путь:";
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 257);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtBoxSelectedFolder);
            this.Controls.Add(this.lstBoxResults);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpBoxParams);
            this.MaximumSize = new System.Drawing.Size(570, 284);
            this.MinimumSize = new System.Drawing.Size(570, 284);
            this.Name = "FormSearch";
            this.ShowIcon = false;
            this.Text = "Диалог выбора папок";
            this.grpBoxParams.ResumeLayout(false);
            this.grpBoxParams.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox txtSearchString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBoxParams;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstBoxResults;
        private System.Windows.Forms.Button btnSaveResults;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.CheckBox chkBoxMath;
        private System.Windows.Forms.CheckBox chkBoxRegex;
        private System.Windows.Forms.CheckBox chkBoxRegister;
        private System.Windows.Forms.TextBox txtBoxSelectedFolder;
        private System.Windows.Forms.CheckBox chkBoxRecursive;
        private System.Windows.Forms.Label lblPath;
    }
}