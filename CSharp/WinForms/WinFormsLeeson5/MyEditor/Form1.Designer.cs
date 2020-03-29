namespace MyEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьВсёToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.толькоЧтениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выделитьВсёToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шрифтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbEncodingLIst = new System.Windows.Forms.ToolStripComboBox();
            this.кодировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.синтаксисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbSelectSyntax = new System.Windows.Forms.ToolStripComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.видToolStripMenuItem,
            this.tscbEncodingLIst,
            this.кодировкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(590, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.toolStripSeparator1,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.toolStripSeparator2,
            this.закрытьToolStripMenuItem,
            this.закрытьВсёToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 23);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Enabled = false;
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Enabled = false;
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Enabled = false;
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // закрытьВсёToolStripMenuItem
            // 
            this.закрытьВсёToolStripMenuItem.Enabled = false;
            this.закрытьВсёToolStripMenuItem.Name = "закрытьВсёToolStripMenuItem";
            this.закрытьВсёToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.закрытьВсёToolStripMenuItem.Text = "Закрыть всё";
            this.закрытьВсёToolStripMenuItem.Click += new System.EventHandler(this.закрытьВсёToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.толькоЧтениеToolStripMenuItem,
            this.выделитьВсёToolStripMenuItem});
            this.правкаToolStripMenuItem.Enabled = false;
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 23);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // толькоЧтениеToolStripMenuItem
            // 
            this.толькоЧтениеToolStripMenuItem.Name = "толькоЧтениеToolStripMenuItem";
            this.толькоЧтениеToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.толькоЧтениеToolStripMenuItem.Text = "Только чтение";
            this.толькоЧтениеToolStripMenuItem.Click += new System.EventHandler(this.толькоЧтениеToolStripMenuItem_Click);
            // 
            // выделитьВсёToolStripMenuItem
            // 
            this.выделитьВсёToolStripMenuItem.Name = "выделитьВсёToolStripMenuItem";
            this.выделитьВсёToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.выделитьВсёToolStripMenuItem.Text = "Выделить всё";
            this.выделитьВсёToolStripMenuItem.Click += new System.EventHandler(this.выделитьВсёToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шрифтToolStripMenuItem,
            this.синтаксисToolStripMenuItem,
            this.tscbSelectSyntax});
            this.видToolStripMenuItem.Enabled = false;
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 23);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // шрифтToolStripMenuItem
            // 
            this.шрифтToolStripMenuItem.Name = "шрифтToolStripMenuItem";
            this.шрифтToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.шрифтToolStripMenuItem.Text = "Шрифт";
            this.шрифтToolStripMenuItem.Click += new System.EventHandler(this.шрифтToolStripMenuItem_Click);
            // 
            // tscbEncodingLIst
            // 
            this.tscbEncodingLIst.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tscbEncodingLIst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbEncodingLIst.Enabled = false;
            this.tscbEncodingLIst.Name = "tscbEncodingLIst";
            this.tscbEncodingLIst.Size = new System.Drawing.Size(250, 23);
            this.tscbEncodingLIst.SelectedIndexChanged += new System.EventHandler(this.tscbEncodingLIst_SelectedIndexChanged);
            // 
            // кодировкаToolStripMenuItem
            // 
            this.кодировкаToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.кодировкаToolStripMenuItem.Enabled = false;
            this.кодировкаToolStripMenuItem.Name = "кодировкаToolStripMenuItem";
            this.кодировкаToolStripMenuItem.Size = new System.Drawing.Size(81, 23);
            this.кодировкаToolStripMenuItem.Text = "Кодировка:";
            // 
            // синтаксисToolStripMenuItem
            // 
            this.синтаксисToolStripMenuItem.Enabled = false;
            this.синтаксисToolStripMenuItem.Name = "синтаксисToolStripMenuItem";
            this.синтаксисToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.синтаксисToolStripMenuItem.Text = "Синтаксис:";
            // 
            // tscbSelectSyntax
            // 
            this.tscbSelectSyntax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbSelectSyntax.Name = "tscbSelectSyntax";
            this.tscbSelectSyntax.Size = new System.Drawing.Size(121, 23);
            this.tscbSelectSyntax.SelectedIndexChanged += new System.EventHandler(this.tscbSelectSyntax_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 550);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "MyEdtor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem закрытьВсёToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шрифтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem толькоЧтениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выделитьВсёToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кодировкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox tscbEncodingLIst;
        private System.Windows.Forms.ToolStripMenuItem синтаксисToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox tscbSelectSyntax;
    }
}

