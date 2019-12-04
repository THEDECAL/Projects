namespace ThreadsExam
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
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbFolders = new System.Windows.Forms.GroupBox();
            this.btnDelFolder = new System.Windows.Forms.Button();
            this.lbFolders = new System.Windows.Forms.ListBox();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.gbDisks = new System.Windows.Forms.GroupBox();
            this.lbDisks = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gbSavePath = new System.Windows.Forms.GroupBox();
            this.cbSaveFileCopy = new System.Windows.Forms.CheckBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.tbCurrentPath = new System.Windows.Forms.TextBox();
            this.gbFindResult = new System.Windows.Forms.GroupBox();
            this.lbFindFiles = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelWord = new System.Windows.Forms.Button();
            this.lblAddWord = new System.Windows.Forms.Label();
            this.btnOpenFileDialog = new System.Windows.Forms.Button();
            this.lbWords = new System.Windows.Forms.ListBox();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.tbWord = new System.Windows.Forms.TextBox();
            this.ssCounts = new System.Windows.Forms.StatusStrip();
            this.lblTextCountWordContains = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCountWordContains = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTextCountFileContains = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCountFileContains = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTextCountViewFolders = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCountViewFolders = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbFolders.SuspendLayout();
            this.gbDisks.SuspendLayout();
            this.gbSavePath.SuspendLayout();
            this.gbFindResult.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ssCounts.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.pbProgress);
            this.gbMain.Controls.Add(this.btnStop);
            this.gbMain.Controls.Add(this.btnPause);
            this.gbMain.Controls.Add(this.btnSearch);
            this.gbMain.Controls.Add(this.groupBox2);
            this.gbMain.Controls.Add(this.gbFindResult);
            this.gbMain.Controls.Add(this.groupBox1);
            this.gbMain.Location = new System.Drawing.Point(5, 0);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(790, 421);
            this.gbMain.TabIndex = 0;
            this.gbMain.TabStop = false;
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(175, 349);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(608, 26);
            this.pbProgress.TabIndex = 10;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStop.Location = new System.Drawing.Point(609, 380);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(175, 34);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Остановить";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPause.Location = new System.Drawing.Point(394, 380);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(175, 34);
            this.btnPause.TabIndex = 9;
            this.btnPause.Text = "Приостановить";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSearch.Location = new System.Drawing.Point(175, 380);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(175, 34);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Искать";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.gbSavePath);
            this.groupBox2.Location = new System.Drawing.Point(175, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 329);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gbFolders);
            this.groupBox3.Controls.Add(this.gbDisks);
            this.groupBox3.Location = new System.Drawing.Point(6, 148);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(270, 175);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Места поиска";
            // 
            // gbFolders
            // 
            this.gbFolders.Controls.Add(this.btnDelFolder);
            this.gbFolders.Controls.Add(this.lbFolders);
            this.gbFolders.Controls.Add(this.btnAddFolder);
            this.gbFolders.Location = new System.Drawing.Point(93, 19);
            this.gbFolders.Name = "gbFolders";
            this.gbFolders.Size = new System.Drawing.Size(171, 151);
            this.gbFolders.TabIndex = 1;
            this.gbFolders.TabStop = false;
            this.gbFolders.Text = "Папки";
            // 
            // btnDelFolder
            // 
            this.btnDelFolder.Location = new System.Drawing.Point(86, 19);
            this.btnDelFolder.Name = "btnDelFolder";
            this.btnDelFolder.Size = new System.Drawing.Size(80, 23);
            this.btnDelFolder.TabIndex = 2;
            this.btnDelFolder.Text = "Удалить";
            this.btnDelFolder.UseVisualStyleBackColor = true;
            this.btnDelFolder.Click += new System.EventHandler(this.btnDelFolder_Click);
            // 
            // lbFolders
            // 
            this.lbFolders.FormattingEnabled = true;
            this.lbFolders.Location = new System.Drawing.Point(7, 48);
            this.lbFolders.Name = "lbFolders";
            this.lbFolders.Size = new System.Drawing.Size(158, 95);
            this.lbFolders.TabIndex = 1;
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(6, 19);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(74, 23);
            this.btnAddFolder.TabIndex = 0;
            this.btnAddFolder.Text = "Добавить";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // gbDisks
            // 
            this.gbDisks.Controls.Add(this.lbDisks);
            this.gbDisks.Controls.Add(this.btnRefresh);
            this.gbDisks.Location = new System.Drawing.Point(6, 19);
            this.gbDisks.Name = "gbDisks";
            this.gbDisks.Size = new System.Drawing.Size(81, 151);
            this.gbDisks.TabIndex = 0;
            this.gbDisks.TabStop = false;
            this.gbDisks.Text = "Диски";
            // 
            // lbDisks
            // 
            this.lbDisks.FormattingEnabled = true;
            this.lbDisks.Location = new System.Drawing.Point(7, 48);
            this.lbDisks.Name = "lbDisks";
            this.lbDisks.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbDisks.Size = new System.Drawing.Size(67, 95);
            this.lbDisks.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(6, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(68, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gbSavePath
            // 
            this.gbSavePath.Controls.Add(this.cbSaveFileCopy);
            this.gbSavePath.Controls.Add(this.btnSelectPath);
            this.gbSavePath.Controls.Add(this.tbCurrentPath);
            this.gbSavePath.Location = new System.Drawing.Point(6, 19);
            this.gbSavePath.Name = "gbSavePath";
            this.gbSavePath.Size = new System.Drawing.Size(270, 123);
            this.gbSavePath.TabIndex = 0;
            this.gbSavePath.TabStop = false;
            this.gbSavePath.Text = "Место сохранения файлов с найдеными словами";
            // 
            // cbSaveFileCopy
            // 
            this.cbSaveFileCopy.AutoSize = true;
            this.cbSaveFileCopy.Checked = true;
            this.cbSaveFileCopy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaveFileCopy.Location = new System.Drawing.Point(7, 91);
            this.cbSaveFileCopy.Name = "cbSaveFileCopy";
            this.cbSaveFileCopy.Size = new System.Drawing.Size(213, 17);
            this.cbSaveFileCopy.TabIndex = 3;
            this.cbSaveFileCopy.Text = "Сохранять копию найденных файлов";
            this.cbSaveFileCopy.UseVisualStyleBackColor = true;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(6, 61);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(258, 23);
            this.btnSelectPath.TabIndex = 2;
            this.btnSelectPath.Text = "Выбрать место сохранения";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // tbCurrentPath
            // 
            this.tbCurrentPath.Enabled = false;
            this.tbCurrentPath.Location = new System.Drawing.Point(6, 35);
            this.tbCurrentPath.Name = "tbCurrentPath";
            this.tbCurrentPath.Size = new System.Drawing.Size(258, 20);
            this.tbCurrentPath.TabIndex = 1;
            // 
            // gbFindResult
            // 
            this.gbFindResult.Controls.Add(this.lbFindFiles);
            this.gbFindResult.Location = new System.Drawing.Point(463, 14);
            this.gbFindResult.Name = "gbFindResult";
            this.gbFindResult.Size = new System.Drawing.Size(320, 329);
            this.gbFindResult.TabIndex = 5;
            this.gbFindResult.TabStop = false;
            this.gbFindResult.Text = "Результат поиска";
            // 
            // lbFindFiles
            // 
            this.lbFindFiles.FormattingEnabled = true;
            this.lbFindFiles.Location = new System.Drawing.Point(6, 19);
            this.lbFindFiles.Name = "lbFindFiles";
            this.lbFindFiles.Size = new System.Drawing.Size(308, 303);
            this.lbFindFiles.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelWord);
            this.groupBox1.Controls.Add(this.lblAddWord);
            this.groupBox1.Controls.Add(this.btnOpenFileDialog);
            this.groupBox1.Controls.Add(this.lbWords);
            this.groupBox1.Controls.Add(this.btnAddWord);
            this.groupBox1.Controls.Add(this.tbWord);
            this.groupBox1.Location = new System.Drawing.Point(6, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 400);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Искомые слова";
            // 
            // btnDelWord
            // 
            this.btnDelWord.Location = new System.Drawing.Point(84, 69);
            this.btnDelWord.Name = "btnDelWord";
            this.btnDelWord.Size = new System.Drawing.Size(72, 20);
            this.btnDelWord.TabIndex = 4;
            this.btnDelWord.Text = "Удалить";
            this.btnDelWord.UseVisualStyleBackColor = true;
            this.btnDelWord.Click += new System.EventHandler(this.btnDelWord_Click);
            // 
            // lblAddWord
            // 
            this.lblAddWord.AutoSize = true;
            this.lblAddWord.Location = new System.Drawing.Point(6, 54);
            this.lblAddWord.Name = "lblAddWord";
            this.lblAddWord.Size = new System.Drawing.Size(93, 13);
            this.lblAddWord.TabIndex = 0;
            this.lblAddWord.Text = "Добавить слово:";
            // 
            // btnOpenFileDialog
            // 
            this.btnOpenFileDialog.Location = new System.Drawing.Point(6, 19);
            this.btnOpenFileDialog.Name = "btnOpenFileDialog";
            this.btnOpenFileDialog.Size = new System.Drawing.Size(150, 32);
            this.btnOpenFileDialog.TabIndex = 3;
            this.btnOpenFileDialog.Text = "Загрузить слова из файла";
            this.btnOpenFileDialog.UseVisualStyleBackColor = true;
            this.btnOpenFileDialog.Click += new System.EventHandler(this.btnOpenFileDialog_Click);
            // 
            // lbWords
            // 
            this.lbWords.FormattingEnabled = true;
            this.lbWords.Location = new System.Drawing.Point(6, 117);
            this.lbWords.Name = "lbWords";
            this.lbWords.Size = new System.Drawing.Size(150, 277);
            this.lbWords.TabIndex = 0;
            // 
            // btnAddWord
            // 
            this.btnAddWord.Location = new System.Drawing.Point(6, 69);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(74, 20);
            this.btnAddWord.TabIndex = 2;
            this.btnAddWord.Text = "Добавить";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // tbWord
            // 
            this.tbWord.Location = new System.Drawing.Point(6, 95);
            this.tbWord.Name = "tbWord";
            this.tbWord.Size = new System.Drawing.Size(150, 20);
            this.tbWord.TabIndex = 1;
            // 
            // ssCounts
            // 
            this.ssCounts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTextCountWordContains,
            this.lblCountWordContains,
            this.lblTextCountFileContains,
            this.lblCountFileContains,
            this.lblTextCountViewFolders,
            this.lblCountViewFolders});
            this.ssCounts.Location = new System.Drawing.Point(0, 426);
            this.ssCounts.Name = "ssCounts";
            this.ssCounts.Size = new System.Drawing.Size(800, 24);
            this.ssCounts.TabIndex = 1;
            this.ssCounts.Text = "statusStrip1";
            // 
            // lblTextCountWordContains
            // 
            this.lblTextCountWordContains.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTextCountWordContains.Name = "lblTextCountWordContains";
            this.lblTextCountWordContains.Size = new System.Drawing.Size(77, 19);
            this.lblTextCountWordContains.Text = "Совпадений:";
            // 
            // lblCountWordContains
            // 
            this.lblCountWordContains.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCountWordContains.Name = "lblCountWordContains";
            this.lblCountWordContains.Size = new System.Drawing.Size(17, 19);
            this.lblCountWordContains.Text = "0";
            // 
            // lblTextCountFileContains
            // 
            this.lblTextCountFileContains.Name = "lblTextCountFileContains";
            this.lblTextCountFileContains.Size = new System.Drawing.Size(52, 19);
            this.lblTextCountFileContains.Text = "Файлов:";
            // 
            // lblCountFileContains
            // 
            this.lblCountFileContains.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCountFileContains.Name = "lblCountFileContains";
            this.lblCountFileContains.Size = new System.Drawing.Size(17, 19);
            this.lblCountFileContains.Text = "0";
            // 
            // lblTextCountViewFolders
            // 
            this.lblTextCountViewFolders.Name = "lblTextCountViewFolders";
            this.lblTextCountViewFolders.Size = new System.Drawing.Size(123, 19);
            this.lblTextCountViewFolders.Text = "Просмотрено папок:";
            // 
            // lblCountViewFolders
            // 
            this.lblCountViewFolders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCountViewFolders.Name = "lblCountViewFolders";
            this.lblCountViewFolders.Size = new System.Drawing.Size(17, 19);
            this.lblCountViewFolders.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ssCounts);
            this.Controls.Add(this.gbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Поиск совпадений";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.gbMain.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.gbFolders.ResumeLayout(false);
            this.gbDisks.ResumeLayout(false);
            this.gbSavePath.ResumeLayout(false);
            this.gbSavePath.PerformLayout();
            this.gbFindResult.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ssCounts.ResumeLayout(false);
            this.ssCounts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.TextBox tbWord;
        private System.Windows.Forms.ListBox lbWords;
        private System.Windows.Forms.Button btnOpenFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox gbFindResult;
        private System.Windows.Forms.Label lblAddWord;
        private System.Windows.Forms.TextBox tbCurrentPath;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbSavePath;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.ListBox lbFindFiles;
        private System.Windows.Forms.GroupBox gbFolders;
        private System.Windows.Forms.ListBox lbFolders;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.GroupBox gbDisks;
        private System.Windows.Forms.ListBox lbDisks;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox cbSaveFileCopy;
        private System.Windows.Forms.StatusStrip ssCounts;
        private System.Windows.Forms.ToolStripStatusLabel lblTextCountWordContains;
        private System.Windows.Forms.ToolStripStatusLabel lblCountWordContains;
        private System.Windows.Forms.ToolStripStatusLabel lblTextCountFileContains;
        private System.Windows.Forms.ToolStripStatusLabel lblCountFileContains;
        private System.Windows.Forms.ToolStripStatusLabel lblTextCountViewFolders;
        private System.Windows.Forms.ToolStripStatusLabel lblCountViewFolders;
        private System.Windows.Forms.Button btnDelFolder;
        private System.Windows.Forms.Button btnDelWord;
    }
}

