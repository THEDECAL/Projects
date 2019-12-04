namespace Testodrom
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
            this.lstBoxTests = new System.Windows.Forms.ListBox();
            this.grpTests = new System.Windows.Forms.GroupBox();
            this.txtBoxAddTest = new System.Windows.Forms.TextBox();
            this.btnRemoveTest = new System.Windows.Forms.Button();
            this.btnChangeTest = new System.Windows.Forms.Button();
            this.btnAddTest = new System.Windows.Forms.Button();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.txtBoxQuestion = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblBarComplete = new System.Windows.Forms.Label();
            this.btnFinishTest = new System.Windows.Forms.Button();
            this.btnNextQuestion = new System.Windows.Forms.Button();
            this.btnPreviousQuestion = new System.Windows.Forms.Button();
            this.grpVariantAnswers = new System.Windows.Forms.GroupBox();
            this.txtBoxVar4 = new System.Windows.Forms.TextBox();
            this.txtBoxVar3 = new System.Windows.Forms.TextBox();
            this.txtBoxVar2 = new System.Windows.Forms.TextBox();
            this.txtBoxVar1 = new System.Windows.Forms.TextBox();
            this.chkBoxVar4 = new System.Windows.Forms.CheckBox();
            this.chkBoxVar3 = new System.Windows.Forms.CheckBox();
            this.chkBoxVar2 = new System.Windows.Forms.CheckBox();
            this.chkBoxVar1 = new System.Windows.Forms.CheckBox();
            this.grpTests.SuspendLayout();
            this.grpAction.SuspendLayout();
            this.grpVariantAnswers.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstBoxTests
            // 
            this.lstBoxTests.FormattingEnabled = true;
            this.lstBoxTests.Location = new System.Drawing.Point(6, 20);
            this.lstBoxTests.Name = "lstBoxTests";
            this.lstBoxTests.Size = new System.Drawing.Size(132, 134);
            this.lstBoxTests.TabIndex = 5;
            // 
            // grpTests
            // 
            this.grpTests.Controls.Add(this.txtBoxAddTest);
            this.grpTests.Controls.Add(this.btnRemoveTest);
            this.grpTests.Controls.Add(this.btnChangeTest);
            this.grpTests.Controls.Add(this.btnAddTest);
            this.grpTests.Controls.Add(this.btnStartTest);
            this.grpTests.Controls.Add(this.lstBoxTests);
            this.grpTests.Location = new System.Drawing.Point(12, 12);
            this.grpTests.Name = "grpTests";
            this.grpTests.Size = new System.Drawing.Size(222, 189);
            this.grpTests.TabIndex = 6;
            this.grpTests.TabStop = false;
            this.grpTests.Text = "Тесты:";
            // 
            // txtBoxAddTest
            // 
            this.txtBoxAddTest.Location = new System.Drawing.Point(6, 160);
            this.txtBoxAddTest.Name = "txtBoxAddTest";
            this.txtBoxAddTest.Size = new System.Drawing.Size(132, 20);
            this.txtBoxAddTest.TabIndex = 10;
            // 
            // btnRemoveTest
            // 
            this.btnRemoveTest.Location = new System.Drawing.Point(144, 98);
            this.btnRemoveTest.Name = "btnRemoveTest";
            this.btnRemoveTest.Size = new System.Drawing.Size(68, 28);
            this.btnRemoveTest.TabIndex = 9;
            this.btnRemoveTest.Tag = "640; 320";
            this.btnRemoveTest.Text = "Удалить";
            this.btnRemoveTest.UseVisualStyleBackColor = true;
            this.btnRemoveTest.Click += new System.EventHandler(this.btnRemoveTest_Click);
            // 
            // btnChangeTest
            // 
            this.btnChangeTest.Location = new System.Drawing.Point(144, 67);
            this.btnChangeTest.Name = "btnChangeTest";
            this.btnChangeTest.Size = new System.Drawing.Size(68, 28);
            this.btnChangeTest.TabIndex = 8;
            this.btnChangeTest.Tag = "640; 320";
            this.btnChangeTest.Text = "Изменить";
            this.btnChangeTest.UseVisualStyleBackColor = true;
            this.btnChangeTest.Click += new System.EventHandler(this.btnChangeTest_Click);
            // 
            // btnAddTest
            // 
            this.btnAddTest.Location = new System.Drawing.Point(144, 155);
            this.btnAddTest.Name = "btnAddTest";
            this.btnAddTest.Size = new System.Drawing.Size(68, 28);
            this.btnAddTest.TabIndex = 7;
            this.btnAddTest.Tag = "640; 320";
            this.btnAddTest.Text = "Добавить";
            this.btnAddTest.UseVisualStyleBackColor = true;
            this.btnAddTest.Click += new System.EventHandler(this.btnAddTest_Click);
            // 
            // btnStartTest
            // 
            this.btnStartTest.Location = new System.Drawing.Point(144, 19);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(68, 28);
            this.btnStartTest.TabIndex = 6;
            this.btnStartTest.Text = "Запустить";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.btnHelp);
            this.grpAction.Controls.Add(this.txtBoxQuestion);
            this.grpAction.Controls.Add(this.lblTime);
            this.grpAction.Controls.Add(this.lblBarComplete);
            this.grpAction.Controls.Add(this.btnFinishTest);
            this.grpAction.Controls.Add(this.btnNextQuestion);
            this.grpAction.Controls.Add(this.btnPreviousQuestion);
            this.grpAction.Controls.Add(this.grpVariantAnswers);
            this.grpAction.Location = new System.Drawing.Point(240, 12);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(380, 189);
            this.grpAction.TabIndex = 7;
            this.grpAction.TabStop = false;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(290, 111);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(84, 33);
            this.btnHelp.TabIndex = 16;
            this.btnHelp.Text = "Справка";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // txtBoxQuestion
            // 
            this.txtBoxQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBoxQuestion.Location = new System.Drawing.Point(6, 16);
            this.txtBoxQuestion.Multiline = true;
            this.txtBoxQuestion.Name = "txtBoxQuestion";
            this.txtBoxQuestion.Size = new System.Drawing.Size(277, 48);
            this.txtBoxQuestion.TabIndex = 15;
            this.txtBoxQuestion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTime
            // 
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.Location = new System.Drawing.Point(289, 16);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(85, 23);
            this.lblTime.TabIndex = 14;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBarComplete
            // 
            this.lblBarComplete.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBarComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBarComplete.Location = new System.Drawing.Point(289, 41);
            this.lblBarComplete.Name = "lblBarComplete";
            this.lblBarComplete.Size = new System.Drawing.Size(85, 23);
            this.lblBarComplete.TabIndex = 13;
            this.lblBarComplete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFinishTest
            // 
            this.btnFinishTest.Enabled = false;
            this.btnFinishTest.Location = new System.Drawing.Point(289, 145);
            this.btnFinishTest.Name = "btnFinishTest";
            this.btnFinishTest.Size = new System.Drawing.Size(85, 34);
            this.btnFinishTest.TabIndex = 12;
            this.btnFinishTest.Tag = "640; 320";
            this.btnFinishTest.Text = "Завершить";
            this.btnFinishTest.UseVisualStyleBackColor = true;
            this.btnFinishTest.Click += new System.EventHandler(this.btnFinishTest_Click);
            // 
            // btnNextQuestion
            // 
            this.btnNextQuestion.Location = new System.Drawing.Point(342, 74);
            this.btnNextQuestion.Name = "btnNextQuestion";
            this.btnNextQuestion.Size = new System.Drawing.Size(32, 34);
            this.btnNextQuestion.TabIndex = 11;
            this.btnNextQuestion.Tag = "640; 320";
            this.btnNextQuestion.Text = ">";
            this.btnNextQuestion.UseVisualStyleBackColor = true;
            this.btnNextQuestion.Click += new System.EventHandler(this.btnNextQuestion_Click);
            // 
            // btnPreviousQuestion
            // 
            this.btnPreviousQuestion.Location = new System.Drawing.Point(289, 74);
            this.btnPreviousQuestion.Name = "btnPreviousQuestion";
            this.btnPreviousQuestion.Size = new System.Drawing.Size(32, 34);
            this.btnPreviousQuestion.TabIndex = 10;
            this.btnPreviousQuestion.Tag = "640; 320";
            this.btnPreviousQuestion.Text = "<";
            this.btnPreviousQuestion.UseVisualStyleBackColor = true;
            this.btnPreviousQuestion.Click += new System.EventHandler(this.btnPreviousQuestion_Click);
            // 
            // grpVariantAnswers
            // 
            this.grpVariantAnswers.Controls.Add(this.txtBoxVar4);
            this.grpVariantAnswers.Controls.Add(this.txtBoxVar3);
            this.grpVariantAnswers.Controls.Add(this.txtBoxVar2);
            this.grpVariantAnswers.Controls.Add(this.txtBoxVar1);
            this.grpVariantAnswers.Controls.Add(this.chkBoxVar4);
            this.grpVariantAnswers.Controls.Add(this.chkBoxVar3);
            this.grpVariantAnswers.Controls.Add(this.chkBoxVar2);
            this.grpVariantAnswers.Controls.Add(this.chkBoxVar1);
            this.grpVariantAnswers.Location = new System.Drawing.Point(6, 67);
            this.grpVariantAnswers.Name = "grpVariantAnswers";
            this.grpVariantAnswers.Size = new System.Drawing.Size(277, 116);
            this.grpVariantAnswers.TabIndex = 9;
            this.grpVariantAnswers.TabStop = false;
            this.grpVariantAnswers.Text = "Варианты ответов:";
            // 
            // txtBoxVar4
            // 
            this.txtBoxVar4.Location = new System.Drawing.Point(27, 90);
            this.txtBoxVar4.Name = "txtBoxVar4";
            this.txtBoxVar4.Size = new System.Drawing.Size(244, 20);
            this.txtBoxVar4.TabIndex = 7;
            // 
            // txtBoxVar3
            // 
            this.txtBoxVar3.Location = new System.Drawing.Point(27, 67);
            this.txtBoxVar3.Name = "txtBoxVar3";
            this.txtBoxVar3.Size = new System.Drawing.Size(244, 20);
            this.txtBoxVar3.TabIndex = 6;
            // 
            // txtBoxVar2
            // 
            this.txtBoxVar2.Location = new System.Drawing.Point(27, 44);
            this.txtBoxVar2.Name = "txtBoxVar2";
            this.txtBoxVar2.Size = new System.Drawing.Size(244, 20);
            this.txtBoxVar2.TabIndex = 5;
            // 
            // txtBoxVar1
            // 
            this.txtBoxVar1.Location = new System.Drawing.Point(27, 21);
            this.txtBoxVar1.Name = "txtBoxVar1";
            this.txtBoxVar1.Size = new System.Drawing.Size(244, 20);
            this.txtBoxVar1.TabIndex = 4;
            // 
            // chkBoxVar4
            // 
            this.chkBoxVar4.AutoSize = true;
            this.chkBoxVar4.Location = new System.Drawing.Point(6, 93);
            this.chkBoxVar4.Name = "chkBoxVar4";
            this.chkBoxVar4.Size = new System.Drawing.Size(15, 14);
            this.chkBoxVar4.TabIndex = 3;
            this.chkBoxVar4.UseVisualStyleBackColor = true;
            // 
            // chkBoxVar3
            // 
            this.chkBoxVar3.AutoSize = true;
            this.chkBoxVar3.Location = new System.Drawing.Point(6, 70);
            this.chkBoxVar3.Name = "chkBoxVar3";
            this.chkBoxVar3.Size = new System.Drawing.Size(15, 14);
            this.chkBoxVar3.TabIndex = 2;
            this.chkBoxVar3.UseVisualStyleBackColor = true;
            // 
            // chkBoxVar2
            // 
            this.chkBoxVar2.AutoSize = true;
            this.chkBoxVar2.Location = new System.Drawing.Point(6, 47);
            this.chkBoxVar2.Name = "chkBoxVar2";
            this.chkBoxVar2.Size = new System.Drawing.Size(15, 14);
            this.chkBoxVar2.TabIndex = 1;
            this.chkBoxVar2.UseVisualStyleBackColor = true;
            // 
            // chkBoxVar1
            // 
            this.chkBoxVar1.AutoSize = true;
            this.chkBoxVar1.Location = new System.Drawing.Point(6, 24);
            this.chkBoxVar1.Name = "chkBoxVar1";
            this.chkBoxVar1.Size = new System.Drawing.Size(15, 14);
            this.chkBoxVar1.TabIndex = 0;
            this.chkBoxVar1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 209);
            this.Controls.Add(this.grpAction);
            this.Controls.Add(this.grpTests);
            this.MaximumSize = new System.Drawing.Size(640, 237);
            this.MinimumSize = new System.Drawing.Size(640, 237);
            this.Name = "Form1";
            this.grpTests.ResumeLayout(false);
            this.grpTests.PerformLayout();
            this.grpAction.ResumeLayout(false);
            this.grpAction.PerformLayout();
            this.grpVariantAnswers.ResumeLayout(false);
            this.grpVariantAnswers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstBoxTests;
        private System.Windows.Forms.GroupBox grpTests;
        private System.Windows.Forms.Button btnAddTest;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.Button btnChangeTest;
        private System.Windows.Forms.Button btnRemoveTest;
        private System.Windows.Forms.GroupBox grpVariantAnswers;
        private System.Windows.Forms.CheckBox chkBoxVar4;
        private System.Windows.Forms.CheckBox chkBoxVar3;
        private System.Windows.Forms.CheckBox chkBoxVar2;
        private System.Windows.Forms.CheckBox chkBoxVar1;
        private System.Windows.Forms.Button btnFinishTest;
        private System.Windows.Forms.Button btnNextQuestion;
        private System.Windows.Forms.Button btnPreviousQuestion;
        private System.Windows.Forms.Label lblBarComplete;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtBoxQuestion;
        private System.Windows.Forms.TextBox txtBoxVar4;
        private System.Windows.Forms.TextBox txtBoxVar3;
        private System.Windows.Forms.TextBox txtBoxVar2;
        private System.Windows.Forms.TextBox txtBoxVar1;
        private System.Windows.Forms.TextBox txtBoxAddTest;
        private System.Windows.Forms.Button btnHelp;
    }
}

