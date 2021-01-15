namespace TestTask
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
            this.components = new System.ComponentModel.Container();
            this.gbDepsAndEmps = new System.Windows.Forms.GroupBox();
            this.btnAddEmp = new System.Windows.Forms.Button();
            this.btnStartSearch = new System.Windows.Forms.Button();
            this.btnAddDep = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearchText = new System.Windows.Forms.TextBox();
            this.tvDepsAndEmps = new System.Windows.Forms.TreeView();
            this.gbDesc = new System.Windows.Forms.GroupBox();
            this.gbEmp = new System.Windows.Forms.GroupBox();
            this.tbCause = new System.Windows.Forms.TextBox();
            this.tbEmpDep = new System.Windows.Forms.TextBox();
            this.tbPlace = new System.Windows.Forms.TextBox();
            this.tbBirthday = new System.Windows.Forms.TextBox();
            this.tbGender = new System.Windows.Forms.TextBox();
            this.tbDateDismiss = new System.Windows.Forms.TextBox();
            this.tbDateEmp = new System.Windows.Forms.TextBox();
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
            this.tbPos = new System.Windows.Forms.TextBox();
            this.gbHistory = new System.Windows.Forms.GroupBox();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.gbDep = new System.Windows.Forms.GroupBox();
            this.tbDateClosed = new System.Windows.Forms.TextBox();
            this.tbDateCreate = new System.Windows.Forms.TextBox();
            this.tbState = new System.Windows.Forms.TextBox();
            this.tbDepDep = new System.Windows.Forms.TextBox();
            this.tbDepName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDepName = new System.Windows.Forms.Label();
            this.ctxDepMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsDepEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxEmpMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsEmpEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPosition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDepartment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsEmpDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDepDel = new System.Windows.Forms.ToolStripMenuItem();
            this.colNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbDepsAndEmps.SuspendLayout();
            this.gbDesc.SuspendLayout();
            this.gbEmp.SuspendLayout();
            this.gbHistory.SuspendLayout();
            this.gbDep.SuspendLayout();
            this.ctxDepMenu.SuspendLayout();
            this.ctxEmpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDepsAndEmps
            // 
            this.gbDepsAndEmps.Controls.Add(this.btnAddEmp);
            this.gbDepsAndEmps.Controls.Add(this.btnStartSearch);
            this.gbDepsAndEmps.Controls.Add(this.btnAddDep);
            this.gbDepsAndEmps.Controls.Add(this.label1);
            this.gbDepsAndEmps.Controls.Add(this.tbSearchText);
            this.gbDepsAndEmps.Controls.Add(this.tvDepsAndEmps);
            this.gbDepsAndEmps.Location = new System.Drawing.Point(7, 2);
            this.gbDepsAndEmps.Name = "gbDepsAndEmps";
            this.gbDepsAndEmps.Size = new System.Drawing.Size(228, 444);
            this.gbDepsAndEmps.TabIndex = 0;
            this.gbDepsAndEmps.TabStop = false;
            this.gbDepsAndEmps.Text = "Подразделения и сотрудники";
            // 
            // btnAddEmp
            // 
            this.btnAddEmp.Location = new System.Drawing.Point(121, 68);
            this.btnAddEmp.Name = "btnAddEmp";
            this.btnAddEmp.Size = new System.Drawing.Size(101, 24);
            this.btnAddEmp.TabIndex = 3;
            this.btnAddEmp.Text = "+ Сотрудник";
            this.btnAddEmp.UseVisualStyleBackColor = true;
            this.btnAddEmp.Click += new System.EventHandler(this.btnAddEmp_Click);
            // 
            // btnStartSearch
            // 
            this.btnStartSearch.Location = new System.Drawing.Point(159, 40);
            this.btnStartSearch.Name = "btnStartSearch";
            this.btnStartSearch.Size = new System.Drawing.Size(62, 24);
            this.btnStartSearch.TabIndex = 1;
            this.btnStartSearch.Text = "Искать";
            this.btnStartSearch.UseVisualStyleBackColor = true;
            this.btnStartSearch.Click += new System.EventHandler(this.btnStartSearch_Click);
            // 
            // btnAddDep
            // 
            this.btnAddDep.Location = new System.Drawing.Point(5, 68);
            this.btnAddDep.Name = "btnAddDep";
            this.btnAddDep.Size = new System.Drawing.Size(110, 24);
            this.btnAddDep.TabIndex = 2;
            this.btnAddDep.Text = "+ Подразделение";
            this.btnAddDep.UseVisualStyleBackColor = true;
            this.btnAddDep.Click += new System.EventHandler(this.btnAddDep_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Поиск по ФИО";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbSearchText
            // 
            this.tbSearchText.Location = new System.Drawing.Point(6, 42);
            this.tbSearchText.Name = "tbSearchText";
            this.tbSearchText.Size = new System.Drawing.Size(151, 20);
            this.tbSearchText.TabIndex = 0;
            // 
            // tvDepsAndEmps
            // 
            this.tvDepsAndEmps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tvDepsAndEmps.Location = new System.Drawing.Point(5, 97);
            this.tvDepsAndEmps.Name = "tvDepsAndEmps";
            this.tvDepsAndEmps.Size = new System.Drawing.Size(217, 339);
            this.tvDepsAndEmps.TabIndex = 4;
            this.tvDepsAndEmps.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDepsAndEmps_AfterSelect);
            this.tvDepsAndEmps.Click += new System.EventHandler(this.tvDepsAndEmps_Click);
            this.tvDepsAndEmps.Leave += new System.EventHandler(this.tvDepsAndEmps_Leave);
            // 
            // gbDesc
            // 
            this.gbDesc.Controls.Add(this.gbEmp);
            this.gbDesc.Controls.Add(this.gbDep);
            this.gbDesc.Location = new System.Drawing.Point(245, 2);
            this.gbDesc.Name = "gbDesc";
            this.gbDesc.Size = new System.Drawing.Size(598, 444);
            this.gbDesc.TabIndex = 1;
            this.gbDesc.TabStop = false;
            this.gbDesc.Text = "Описание";
            // 
            // gbEmp
            // 
            this.gbEmp.Controls.Add(this.tbCause);
            this.gbEmp.Controls.Add(this.tbEmpDep);
            this.gbEmp.Controls.Add(this.tbPlace);
            this.gbEmp.Controls.Add(this.tbBirthday);
            this.gbEmp.Controls.Add(this.tbGender);
            this.gbEmp.Controls.Add(this.tbDateDismiss);
            this.gbEmp.Controls.Add(this.tbDateEmp);
            this.gbEmp.Controls.Add(this.lbCause);
            this.gbEmp.Controls.Add(this.lbDateEmp);
            this.gbEmp.Controls.Add(this.lbDateDismiss);
            this.gbEmp.Controls.Add(this.label16);
            this.gbEmp.Controls.Add(this.lbPlace);
            this.gbEmp.Controls.Add(this.lbDep);
            this.gbEmp.Controls.Add(this.lbBirthday);
            this.gbEmp.Controls.Add(this.lbGender);
            this.gbEmp.Controls.Add(this.tbPN);
            this.gbEmp.Controls.Add(this.lbSName);
            this.gbEmp.Controls.Add(this.lbName);
            this.gbEmp.Controls.Add(this.lbPName);
            this.gbEmp.Controls.Add(this.tbSName);
            this.gbEmp.Controls.Add(this.tbName);
            this.gbEmp.Controls.Add(this.tbPName);
            this.gbEmp.Controls.Add(this.lbPos);
            this.gbEmp.Controls.Add(this.tbTIN);
            this.gbEmp.Controls.Add(this.lbPN);
            this.gbEmp.Controls.Add(this.tbPos);
            this.gbEmp.Controls.Add(this.gbHistory);
            this.gbEmp.Location = new System.Drawing.Point(6, 125);
            this.gbEmp.Name = "gbEmp";
            this.gbEmp.Size = new System.Drawing.Size(582, 311);
            this.gbEmp.TabIndex = 1;
            this.gbEmp.TabStop = false;
            this.gbEmp.Text = "Сотрудник";
            // 
            // tbCause
            // 
            this.tbCause.Location = new System.Drawing.Point(400, 240);
            this.tbCause.Multiline = true;
            this.tbCause.Name = "tbCause";
            this.tbCause.ReadOnly = true;
            this.tbCause.Size = new System.Drawing.Size(174, 64);
            this.tbCause.TabIndex = 30;
            // 
            // tbEmpDep
            // 
            this.tbEmpDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbEmpDep.Location = new System.Drawing.Point(397, 94);
            this.tbEmpDep.Name = "tbEmpDep";
            this.tbEmpDep.ReadOnly = true;
            this.tbEmpDep.Size = new System.Drawing.Size(180, 23);
            this.tbEmpDep.TabIndex = 29;
            this.tbEmpDep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPlace
            // 
            this.tbPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPlace.Location = new System.Drawing.Point(146, 151);
            this.tbPlace.Name = "tbPlace";
            this.tbPlace.ReadOnly = true;
            this.tbPlace.Size = new System.Drawing.Size(248, 23);
            this.tbPlace.TabIndex = 27;
            this.tbPlace.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbBirthday
            // 
            this.tbBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbBirthday.Location = new System.Drawing.Point(108, 120);
            this.tbBirthday.Name = "tbBirthday";
            this.tbBirthday.ReadOnly = true;
            this.tbBirthday.Size = new System.Drawing.Size(142, 23);
            this.tbBirthday.TabIndex = 26;
            this.tbBirthday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbGender
            // 
            this.tbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbGender.Location = new System.Drawing.Point(56, 105);
            this.tbGender.Name = "tbGender";
            this.tbGender.ReadOnly = true;
            this.tbGender.Size = new System.Drawing.Size(25, 23);
            this.tbGender.TabIndex = 25;
            this.tbGender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDateDismiss
            // 
            this.tbDateDismiss.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDateDismiss.Location = new System.Drawing.Point(397, 194);
            this.tbDateDismiss.Name = "tbDateDismiss";
            this.tbDateDismiss.ReadOnly = true;
            this.tbDateDismiss.Size = new System.Drawing.Size(180, 23);
            this.tbDateDismiss.TabIndex = 13;
            this.tbDateDismiss.Text = "-";
            this.tbDateDismiss.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDateEmp
            // 
            this.tbDateEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDateEmp.Location = new System.Drawing.Point(397, 151);
            this.tbDateEmp.Name = "tbDateEmp";
            this.tbDateEmp.ReadOnly = true;
            this.tbDateEmp.Size = new System.Drawing.Size(180, 23);
            this.tbDateEmp.TabIndex = 12;
            this.tbDateEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbCause
            // 
            this.lbCause.AutoSize = true;
            this.lbCause.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCause.Location = new System.Drawing.Point(403, 220);
            this.lbCause.Name = "lbCause";
            this.lbCause.Size = new System.Drawing.Size(170, 17);
            this.lbCause.TabIndex = 24;
            this.lbCause.Text = "Причина увольнения:";
            // 
            // lbDateEmp
            // 
            this.lbDateEmp.AutoSize = true;
            this.lbDateEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDateEmp.Location = new System.Drawing.Point(396, 130);
            this.lbDateEmp.Name = "lbDateEmp";
            this.lbDateEmp.Size = new System.Drawing.Size(183, 17);
            this.lbDateEmp.TabIndex = 11;
            this.lbDateEmp.Text = "Дата трудоустройства:";
            // 
            // lbDateDismiss
            // 
            this.lbDateDismiss.AutoSize = true;
            this.lbDateDismiss.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDateDismiss.Location = new System.Drawing.Point(417, 175);
            this.lbDateDismiss.Name = "lbDateDismiss";
            this.lbDateDismiss.Size = new System.Drawing.Size(143, 17);
            this.lbDateDismiss.TabIndex = 10;
            this.lbDateDismiss.Text = "Дата увольнения:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(348, 72);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 17);
            this.label16.TabIndex = 22;
            this.label16.Text = "ИНН:";
            // 
            // lbPlace
            // 
            this.lbPlace.AutoSize = true;
            this.lbPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPlace.Location = new System.Drawing.Point(9, 154);
            this.lbPlace.Name = "lbPlace";
            this.lbPlace.Size = new System.Drawing.Size(137, 17);
            this.lbPlace.TabIndex = 20;
            this.lbPlace.Text = "Место рождения:";
            // 
            // lbDep
            // 
            this.lbDep.AutoSize = true;
            this.lbDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDep.Location = new System.Drawing.Point(263, 97);
            this.lbDep.Name = "lbDep";
            this.lbDep.Size = new System.Drawing.Size(131, 17);
            this.lbDep.TabIndex = 19;
            this.lbDep.Text = "Подразделение:";
            // 
            // lbBirthday
            // 
            this.lbBirthday.AutoSize = true;
            this.lbBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBirthday.Location = new System.Drawing.Point(115, 100);
            this.lbBirthday.Name = "lbBirthday";
            this.lbBirthday.Size = new System.Drawing.Size(129, 17);
            this.lbBirthday.TabIndex = 18;
            this.lbBirthday.Text = "Дата рождения:";
            // 
            // lbGender
            // 
            this.lbGender.AutoSize = true;
            this.lbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbGender.Location = new System.Drawing.Point(12, 108);
            this.lbGender.Name = "lbGender";
            this.lbGender.Size = new System.Drawing.Size(42, 17);
            this.lbGender.TabIndex = 17;
            this.lbGender.Text = "Пол:";
            // 
            // tbPN
            // 
            this.tbPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPN.Location = new System.Drawing.Point(397, 44);
            this.tbPN.Name = "tbPN";
            this.tbPN.ReadOnly = true;
            this.tbPN.Size = new System.Drawing.Size(180, 23);
            this.tbPN.TabIndex = 16;
            this.tbPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbSName
            // 
            this.lbSName.AutoSize = true;
            this.lbSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSName.Location = new System.Drawing.Point(10, 19);
            this.lbSName.Name = "lbSName";
            this.lbSName.Size = new System.Drawing.Size(82, 17);
            this.lbSName.TabIndex = 15;
            this.lbSName.Text = "Фамилия:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbName.Location = new System.Drawing.Point(11, 44);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(43, 17);
            this.lbName.TabIndex = 14;
            this.lbName.Text = "Имя:";
            // 
            // lbPName
            // 
            this.lbPName.AutoSize = true;
            this.lbPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPName.Location = new System.Drawing.Point(11, 70);
            this.lbPName.Name = "lbPName";
            this.lbPName.Size = new System.Drawing.Size(84, 17);
            this.lbPName.TabIndex = 13;
            this.lbPName.Text = "Отчетсво:";
            // 
            // tbSName
            // 
            this.tbSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSName.Location = new System.Drawing.Point(108, 16);
            this.tbSName.Name = "tbSName";
            this.tbSName.ReadOnly = true;
            this.tbSName.Size = new System.Drawing.Size(180, 23);
            this.tbSName.TabIndex = 12;
            this.tbSName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(108, 41);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(180, 23);
            this.tbName.TabIndex = 11;
            this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPName
            // 
            this.tbPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPName.Location = new System.Drawing.Point(108, 67);
            this.tbPName.Name = "tbPName";
            this.tbPName.ReadOnly = true;
            this.tbPName.Size = new System.Drawing.Size(180, 23);
            this.tbPName.TabIndex = 10;
            this.tbPName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbPos
            // 
            this.lbPos.AutoSize = true;
            this.lbPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPos.Location = new System.Drawing.Point(299, 19);
            this.lbPos.Name = "lbPos";
            this.lbPos.Size = new System.Drawing.Size(95, 17);
            this.lbPos.TabIndex = 9;
            this.lbPos.Text = "Должность:";
            // 
            // tbTIN
            // 
            this.tbTIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTIN.Location = new System.Drawing.Point(397, 69);
            this.tbTIN.Name = "tbTIN";
            this.tbTIN.ReadOnly = true;
            this.tbTIN.Size = new System.Drawing.Size(180, 23);
            this.tbTIN.TabIndex = 8;
            this.tbTIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbPN
            // 
            this.lbPN.AutoSize = true;
            this.lbPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPN.Location = new System.Drawing.Point(348, 47);
            this.lbPN.Name = "lbPN";
            this.lbPN.Size = new System.Drawing.Size(34, 17);
            this.lbPN.TabIndex = 7;
            this.lbPN.Text = "ТН:";
            // 
            // tbPos
            // 
            this.tbPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPos.Location = new System.Drawing.Point(397, 16);
            this.tbPos.Name = "tbPos";
            this.tbPos.ReadOnly = true;
            this.tbPos.Size = new System.Drawing.Size(180, 23);
            this.tbPos.TabIndex = 6;
            this.tbPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbHistory
            // 
            this.gbHistory.Controls.Add(this.lvHistory);
            this.gbHistory.Location = new System.Drawing.Point(6, 180);
            this.gbHistory.Name = "gbHistory";
            this.gbHistory.Size = new System.Drawing.Size(388, 125);
            this.gbHistory.TabIndex = 2;
            this.gbHistory.TabStop = false;
            this.gbHistory.Text = "История переводов";
            // 
            // lvHistory
            // 
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNum,
            this.colDate,
            this.colPosition,
            this.colDepartment});
            this.lvHistory.HideSelection = false;
            this.lvHistory.Location = new System.Drawing.Point(6, 14);
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.Size = new System.Drawing.Size(376, 105);
            this.lvHistory.TabIndex = 0;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            // 
            // gbDep
            // 
            this.gbDep.Controls.Add(this.tbDateClosed);
            this.gbDep.Controls.Add(this.tbDateCreate);
            this.gbDep.Controls.Add(this.tbState);
            this.gbDep.Controls.Add(this.tbDepDep);
            this.gbDep.Controls.Add(this.tbDepName);
            this.gbDep.Controls.Add(this.label5);
            this.gbDep.Controls.Add(this.label4);
            this.gbDep.Controls.Add(this.label3);
            this.gbDep.Controls.Add(this.label2);
            this.gbDep.Controls.Add(this.lbDepName);
            this.gbDep.Location = new System.Drawing.Point(6, 19);
            this.gbDep.Name = "gbDep";
            this.gbDep.Size = new System.Drawing.Size(582, 100);
            this.gbDep.TabIndex = 0;
            this.gbDep.TabStop = false;
            this.gbDep.Text = "Подразделение";
            // 
            // tbDateClosed
            // 
            this.tbDateClosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDateClosed.Location = new System.Drawing.Point(394, 70);
            this.tbDateClosed.Name = "tbDateClosed";
            this.tbDateClosed.ReadOnly = true;
            this.tbDateClosed.Size = new System.Drawing.Size(180, 23);
            this.tbDateClosed.TabIndex = 9;
            this.tbDateClosed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDateCreate
            // 
            this.tbDateCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDateCreate.Location = new System.Drawing.Point(393, 27);
            this.tbDateCreate.Name = "tbDateCreate";
            this.tbDateCreate.ReadOnly = true;
            this.tbDateCreate.Size = new System.Drawing.Size(180, 23);
            this.tbDateCreate.TabIndex = 8;
            this.tbDateCreate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbState
            // 
            this.tbState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbState.Location = new System.Drawing.Point(147, 70);
            this.tbState.Name = "tbState";
            this.tbState.ReadOnly = true;
            this.tbState.Size = new System.Drawing.Size(180, 23);
            this.tbState.TabIndex = 7;
            this.tbState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDepDep
            // 
            this.tbDepDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDepDep.Location = new System.Drawing.Point(147, 41);
            this.tbDepDep.Name = "tbDepDep";
            this.tbDepDep.ReadOnly = true;
            this.tbDepDep.Size = new System.Drawing.Size(180, 23);
            this.tbDepDep.TabIndex = 6;
            this.tbDepDep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDepName
            // 
            this.tbDepName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDepName.Location = new System.Drawing.Point(147, 13);
            this.tbDepName.Name = "tbDepName";
            this.tbDepName.ReadOnly = true;
            this.tbDepName.Size = new System.Drawing.Size(180, 23);
            this.tbDepName.TabIndex = 5;
            this.tbDepName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(11, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Подразделение:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(11, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Активность:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(422, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Дата создания:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(420, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата закрытия:";
            // 
            // lbDepName
            // 
            this.lbDepName.AutoSize = true;
            this.lbDepName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.692307F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDepName.Location = new System.Drawing.Point(11, 16);
            this.lbDepName.Name = "lbDepName";
            this.lbDepName.Size = new System.Drawing.Size(85, 17);
            this.lbDepName.TabIndex = 0;
            this.lbDepName.Text = "Название:";
            // 
            // ctxDepMenu
            // 
            this.ctxDepMenu.ImageScalingSize = new System.Drawing.Size(17, 17);
            this.ctxDepMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDepEdit,
            this.tsDepDel});
            this.ctxDepMenu.Name = "contextMenu";
            this.ctxDepMenu.Size = new System.Drawing.Size(135, 48);
            // 
            // tsDepEdit
            // 
            this.tsDepEdit.Name = "tsDepEdit";
            this.tsDepEdit.Size = new System.Drawing.Size(134, 22);
            this.tsDepEdit.Text = "Изменить";
            this.tsDepEdit.Click += new System.EventHandler(this.tsDepEdit_Click);
            // 
            // ctxEmpMenu
            // 
            this.ctxEmpMenu.ImageScalingSize = new System.Drawing.Size(17, 17);
            this.ctxEmpMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEmpEdit,
            this.tsEmpDel});
            this.ctxEmpMenu.Name = "contextMenu";
            this.ctxEmpMenu.Size = new System.Drawing.Size(135, 48);
            // 
            // tsEmpEdit
            // 
            this.tsEmpEdit.Name = "tsEmpEdit";
            this.tsEmpEdit.Size = new System.Drawing.Size(134, 22);
            this.tsEmpEdit.Text = "Изменить";
            this.tsEmpEdit.Click += new System.EventHandler(this.tsEmpEdit_Click);
            // 
            // colDate
            // 
            this.colDate.Text = "Дата";
            this.colDate.Width = 106;
            // 
            // colPosition
            // 
            this.colPosition.Text = "Должность";
            this.colPosition.Width = 112;
            // 
            // colDepartment
            // 
            this.colDepartment.Text = "Подразделение";
            this.colDepartment.Width = 128;
            // 
            // tsEmpDel
            // 
            this.tsEmpDel.Name = "tsEmpDel";
            this.tsEmpDel.Size = new System.Drawing.Size(134, 22);
            this.tsEmpDel.Text = "Удалить";
            this.tsEmpDel.Click += new System.EventHandler(this.tsEmpDel_Click);
            // 
            // tsDepDel
            // 
            this.tsDepDel.Name = "tsDepDel";
            this.tsDepDel.Size = new System.Drawing.Size(134, 22);
            this.tsDepDel.Text = "Удалить";
            this.tsDepDel.Click += new System.EventHandler(this.tsDepDel_Click);
            // 
            // colNum
            // 
            this.colNum.Text = "№";
            this.colNum.Width = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 450);
            this.Controls.Add(this.gbDesc);
            this.Controls.Add(this.gbDepsAndEmps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тестовое задание";
            this.gbDepsAndEmps.ResumeLayout(false);
            this.gbDepsAndEmps.PerformLayout();
            this.gbDesc.ResumeLayout(false);
            this.gbEmp.ResumeLayout(false);
            this.gbEmp.PerformLayout();
            this.gbHistory.ResumeLayout(false);
            this.gbDep.ResumeLayout(false);
            this.gbDep.PerformLayout();
            this.ctxDepMenu.ResumeLayout(false);
            this.ctxEmpMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDepsAndEmps;
        private System.Windows.Forms.Button btnStartSearch;
        private System.Windows.Forms.Button btnAddDep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearchText;
        private System.Windows.Forms.TreeView tvDepsAndEmps;
        private System.Windows.Forms.GroupBox gbDesc;
        private System.Windows.Forms.Button btnAddEmp;
        private System.Windows.Forms.GroupBox gbEmp;
        private System.Windows.Forms.GroupBox gbHistory;
        private System.Windows.Forms.GroupBox gbDep;
        private System.Windows.Forms.Label lbDepName;
        private System.Windows.Forms.TextBox tbDateClosed;
        private System.Windows.Forms.TextBox tbDateCreate;
        private System.Windows.Forms.TextBox tbState;
        private System.Windows.Forms.TextBox tbDepDep;
        private System.Windows.Forms.TextBox tbDepName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTIN;
        private System.Windows.Forms.Label lbPN;
        private System.Windows.Forms.TextBox tbPos;
        private System.Windows.Forms.Label lbPos;
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
        private System.Windows.Forms.Label lbCause;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbPlace;
        private System.Windows.Forms.TextBox tbBirthday;
        private System.Windows.Forms.TextBox tbGender;
        private System.Windows.Forms.TextBox tbDateDismiss;
        private System.Windows.Forms.TextBox tbDateEmp;
        private System.Windows.Forms.Label lbDateEmp;
        private System.Windows.Forms.Label lbDateDismiss;
        private System.Windows.Forms.ListView lvHistory;
        private System.Windows.Forms.TextBox tbEmpDep;
        private System.Windows.Forms.TextBox tbCause;
        private System.Windows.Forms.ContextMenuStrip ctxDepMenu;
        private System.Windows.Forms.ToolStripMenuItem tsDepEdit;
        private System.Windows.Forms.ContextMenuStrip ctxEmpMenu;
        private System.Windows.Forms.ToolStripMenuItem tsEmpEdit;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colPosition;
        private System.Windows.Forms.ColumnHeader colDepartment;
        private System.Windows.Forms.ToolStripMenuItem tsDepDel;
        private System.Windows.Forms.ToolStripMenuItem tsEmpDel;
        private System.Windows.Forms.ColumnHeader colNum;
    }
}

