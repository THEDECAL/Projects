namespace BookShop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tslbLogin = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnLogInLogOut = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRegistration = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSearch = new System.Windows.Forms.ToolStripButton();
            this.tstbSearch = new System.Windows.Forms.ToolStripTextBox();
            this.tscbSearchType = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtnCart = new System.Windows.Forms.ToolStripButton();
            this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.flpBooks = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnPrev = new System.Windows.Forms.ToolStripButton();
            this.tslbPageNumber = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnNext = new System.Windows.Forms.ToolStripButton();
            this.tslbOnDisplay = new System.Windows.Forms.ToolStripLabel();
            this.tslbOnDisplayText = new System.Windows.Forms.ToolStripLabel();
            this.tsMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbLogin,
            this.tsbtnLogInLogOut,
            this.tsbtnRegistration,
            this.toolStripSeparator4,
            this.tsbtnSearch,
            this.tstbSearch,
            this.tscbSearchType,
            this.tsbtnCart,
            this.tsbtnAdd});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(548, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "Найти";
            // 
            // tslbLogin
            // 
            this.tslbLogin.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tslbLogin.Name = "tslbLogin";
            this.tslbLogin.Size = new System.Drawing.Size(0, 22);
            // 
            // tsbtnLogInLogOut
            // 
            this.tsbtnLogInLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnLogInLogOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLogInLogOut.Name = "tsbtnLogInLogOut";
            this.tsbtnLogInLogOut.Size = new System.Drawing.Size(36, 22);
            this.tsbtnLogInLogOut.Text = "Вход";
            this.tsbtnLogInLogOut.Click += new System.EventHandler(this.tsbtnLogInLogOut_Click);
            // 
            // tsbtnRegistration
            // 
            this.tsbtnRegistration.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnRegistration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRegistration.Name = "tsbtnRegistration";
            this.tsbtnRegistration.Size = new System.Drawing.Size(75, 22);
            this.tsbtnRegistration.Text = "Регистрация";
            this.tsbtnRegistration.Click += new System.EventHandler(this.tsbtnRegistration_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnSearch
            // 
            this.tsbtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSearch.Image")));
            this.tsbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSearch.Name = "tsbtnSearch";
            this.tsbtnSearch.Size = new System.Drawing.Size(41, 22);
            this.tsbtnSearch.Text = "Поиск";
            this.tsbtnSearch.Click += new System.EventHandler(this.tsbtnSearch_Click);
            // 
            // tstbSearch
            // 
            this.tstbSearch.Name = "tstbSearch";
            this.tstbSearch.Size = new System.Drawing.Size(117, 25);
            // 
            // tscbSearchType
            // 
            this.tscbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbSearchType.Name = "tscbSearchType";
            this.tscbSearchType.Size = new System.Drawing.Size(115, 25);
            // 
            // tsbtnCart
            // 
            this.tsbtnCart.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnCart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnCart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCart.Name = "tsbtnCart";
            this.tsbtnCart.Size = new System.Drawing.Size(53, 22);
            this.tsbtnCart.Text = "Корзина";
            this.tsbtnCart.Click += new System.EventHandler(this.tsbtnCart_Click);
            // 
            // tsbtnAdd
            // 
            this.tsbtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAdd.Image")));
            this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAdd.Name = "tsbtnAdd";
            this.tsbtnAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbtnAdd.Text = "+";
            this.tsbtnAdd.ToolTipText = "Добавить новую книгу";
            this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
            // 
            // flpBooks
            // 
            this.flpBooks.AutoScroll = true;
            this.flpBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBooks.Location = new System.Drawing.Point(0, 25);
            this.flpBooks.Name = "flpBooks";
            this.flpBooks.Size = new System.Drawing.Size(548, 597);
            this.flpBooks.TabIndex = 9;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnPrev,
            this.tslbPageNumber,
            this.tsbtnNext,
            this.tslbOnDisplay,
            this.tslbOnDisplayText});
            this.toolStrip1.Location = new System.Drawing.Point(0, 622);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(548, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnPrev
            // 
            this.tsbtnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPrev.Name = "tsbtnPrev";
            this.tsbtnPrev.Size = new System.Drawing.Size(27, 22);
            this.tsbtnPrev.Text = "<<";
            this.tsbtnPrev.ToolTipText = "Предыдущая страница";
            this.tsbtnPrev.Click += new System.EventHandler(this.tsbtnPrev_Click);
            // 
            // tslbPageNumber
            // 
            this.tslbPageNumber.Name = "tslbPageNumber";
            this.tslbPageNumber.Size = new System.Drawing.Size(11, 22);
            this.tslbPageNumber.Text = "/";
            // 
            // tsbtnNext
            // 
            this.tsbtnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNext.Name = "tsbtnNext";
            this.tsbtnNext.Size = new System.Drawing.Size(27, 22);
            this.tsbtnNext.Text = ">>";
            this.tsbtnNext.ToolTipText = "Следующая страница";
            this.tsbtnNext.Click += new System.EventHandler(this.tsbtnNext_Click);
            // 
            // tslbOnDisplay
            // 
            this.tslbOnDisplay.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslbOnDisplay.Name = "tslbOnDisplay";
            this.tslbOnDisplay.Size = new System.Drawing.Size(13, 22);
            this.tslbOnDisplay.Text = "_";
            // 
            // tslbOnDisplayText
            // 
            this.tslbOnDisplayText.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslbOnDisplayText.Name = "tslbOnDisplayText";
            this.tslbOnDisplayText.Size = new System.Drawing.Size(81, 22);
            this.tslbOnDisplayText.Text = "Выбрано книг:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(548, 647);
            this.Controls.Add(this.flpBooks);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tsMenu);
            this.Name = "Form1";
            this.Text = "Магазин Книг";
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbtnLogInLogOut;
        private System.Windows.Forms.ToolStripTextBox tstbSearch;
        private System.Windows.Forms.ToolStripComboBox tscbSearchType;
        private System.Windows.Forms.ToolStripLabel tslbLogin;
        private System.Windows.Forms.ToolStripButton tsbtnRegistration;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbtnCart;
        private System.Windows.Forms.FlowLayoutPanel flpBooks;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnPrev;
        private System.Windows.Forms.ToolStripLabel tslbPageNumber;
        private System.Windows.Forms.ToolStripButton tsbtnNext;
        private System.Windows.Forms.ToolStripLabel tslbOnDisplay;
        private System.Windows.Forms.ToolStripLabel tslbOnDisplayText;
        private System.Windows.Forms.ToolStripButton tsbtnSearch;
        private System.Windows.Forms.ToolStripButton tsbtnAdd;
    }
}

