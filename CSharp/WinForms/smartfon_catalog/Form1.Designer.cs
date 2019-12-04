namespace smartfon_catalog
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
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbBrand = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbScrDiag = new System.Windows.Forms.ListBox();
            this.lbQualityFrontalCamera = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbMatrixType = new System.Windows.Forms.ListBox();
            this.lbBMEM = new System.Windows.Forms.ListBox();
            this.lbQualityGeneralCamera = new System.Windows.Forms.ListBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.lbRAM = new System.Windows.Forms.ListBox();
            this.lbPage = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.gbCatalog = new System.Windows.Forms.GroupBox();
            this.gbMenu.SuspendLayout();
            this.gbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMenu
            // 
            this.gbMenu.Controls.Add(this.gbFilters);
            this.gbMenu.Controls.Add(this.lbPage);
            this.gbMenu.Controls.Add(this.btnNext);
            this.gbMenu.Controls.Add(this.btnPrev);
            this.gbMenu.Location = new System.Drawing.Point(4, -2);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Size = new System.Drawing.Size(168, 515);
            this.gbMenu.TabIndex = 0;
            this.gbMenu.TabStop = false;
            this.gbMenu.Text = "Меню";
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.label7);
            this.gbFilters.Controls.Add(this.lbBrand);
            this.gbFilters.Controls.Add(this.label6);
            this.gbFilters.Controls.Add(this.label1);
            this.gbFilters.Controls.Add(this.lbScrDiag);
            this.gbFilters.Controls.Add(this.lbQualityFrontalCamera);
            this.gbFilters.Controls.Add(this.label3);
            this.gbFilters.Controls.Add(this.label2);
            this.gbFilters.Controls.Add(this.label5);
            this.gbFilters.Controls.Add(this.lbMatrixType);
            this.gbFilters.Controls.Add(this.lbBMEM);
            this.gbFilters.Controls.Add(this.lbQualityGeneralCamera);
            this.gbFilters.Controls.Add(this.Label4);
            this.gbFilters.Controls.Add(this.lbRAM);
            this.gbFilters.Location = new System.Drawing.Point(6, 45);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(156, 464);
            this.gbFilters.TabIndex = 3;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Фильтры";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Брэнд:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbBrand
            // 
            this.lbBrand.FormattingEnabled = true;
            this.lbBrand.Location = new System.Drawing.Point(6, 32);
            this.lbBrand.Name = "lbBrand";
            this.lbBrand.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbBrand.Size = new System.Drawing.Size(144, 43);
            this.lbBrand.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(5, 388);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Фронтальная камера:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Оперативная память:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbScrDiag
            // 
            this.lbScrDiag.FormattingEnabled = true;
            this.lbScrDiag.Location = new System.Drawing.Point(5, 218);
            this.lbScrDiag.Name = "lbScrDiag";
            this.lbScrDiag.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbScrDiag.Size = new System.Drawing.Size(144, 43);
            this.lbScrDiag.TabIndex = 6;
            // 
            // lbQualityFrontalCamera
            // 
            this.lbQualityFrontalCamera.FormattingEnabled = true;
            this.lbQualityFrontalCamera.Location = new System.Drawing.Point(5, 404);
            this.lbQualityFrontalCamera.Name = "lbQualityFrontalCamera";
            this.lbQualityFrontalCamera.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbQualityFrontalCamera.Size = new System.Drawing.Size(144, 43);
            this.lbQualityFrontalCamera.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Диагональ дисплея:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Встроенная память:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Основная камера:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbMatrixType
            // 
            this.lbMatrixType.FormattingEnabled = true;
            this.lbMatrixType.Location = new System.Drawing.Point(5, 280);
            this.lbMatrixType.Name = "lbMatrixType";
            this.lbMatrixType.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbMatrixType.Size = new System.Drawing.Size(144, 43);
            this.lbMatrixType.TabIndex = 8;
            // 
            // lbBMEM
            // 
            this.lbBMEM.FormattingEnabled = true;
            this.lbBMEM.Location = new System.Drawing.Point(6, 156);
            this.lbBMEM.Name = "lbBMEM";
            this.lbBMEM.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbBMEM.Size = new System.Drawing.Size(143, 43);
            this.lbBMEM.TabIndex = 4;
            // 
            // lbQualityGeneralCamera
            // 
            this.lbQualityGeneralCamera.FormattingEnabled = true;
            this.lbQualityGeneralCamera.Location = new System.Drawing.Point(5, 342);
            this.lbQualityGeneralCamera.Name = "lbQualityGeneralCamera";
            this.lbQualityGeneralCamera.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbQualityGeneralCamera.Size = new System.Drawing.Size(144, 43);
            this.lbQualityGeneralCamera.TabIndex = 10;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(5, 264);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(144, 13);
            this.Label4.TabIndex = 9;
            this.Label4.Text = "Тип матрицы:";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbRAM
            // 
            this.lbRAM.FormattingEnabled = true;
            this.lbRAM.Location = new System.Drawing.Point(5, 94);
            this.lbRAM.Name = "lbRAM";
            this.lbRAM.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbRAM.Size = new System.Drawing.Size(144, 43);
            this.lbRAM.TabIndex = 0;
            // 
            // lbPage
            // 
            this.lbPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPage.Location = new System.Drawing.Point(47, 19);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(77, 23);
            this.lbPage.TabIndex = 2;
            this.lbPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(130, 19);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(33, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(8, 19);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(33, 23);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // gbCatalog
            // 
            this.gbCatalog.Location = new System.Drawing.Point(177, 2);
            this.gbCatalog.Name = "gbCatalog";
            this.gbCatalog.Size = new System.Drawing.Size(545, 389);
            this.gbCatalog.TabIndex = 1;
            this.gbCatalog.TabStop = false;
            this.gbCatalog.Text = "Каталог";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 547);
            this.Controls.Add(this.gbCatalog);
            this.Controls.Add(this.gbMenu);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Каталог смартфонов";
            this.gbMenu.ResumeLayout(false);
            this.gbFilters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMenu;
        private System.Windows.Forms.Label lbPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.GroupBox gbCatalog;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbScrDiag;
        private System.Windows.Forms.ListBox lbQualityFrontalCamera;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbMatrixType;
        private System.Windows.Forms.ListBox lbBMEM;
        private System.Windows.Forms.ListBox lbQualityGeneralCamera;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.ListBox lbRAM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbBrand;
    }
}

