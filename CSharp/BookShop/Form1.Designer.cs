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
            this.tsbtnCart = new System.Windows.Forms.ToolStripButton();
            this.tslbSearch = new System.Windows.Forms.ToolStripLabel();
            this.tstbSearch = new System.Windows.Forms.ToolStripTextBox();
            this.tscbSearchType = new System.Windows.Forms.ToolStripComboBox();
            this.flpBooks = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnPrev = new System.Windows.Forms.ToolStripButton();
            this.tslbPageNumber = new System.Windows.Forms.ToolStripLabel();
            this.tscbBooksOnPage = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtnNext = new System.Windows.Forms.ToolStripButton();
            this.tslbOnDisplayText = new System.Windows.Forms.ToolStripLabel();
            this.tslbOnDisplay = new System.Windows.Forms.ToolStripLabel();
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
            this.tslbSearch,
            this.tstbSearch,
            this.tscbSearchType,
            this.tsbtnCart});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(548, 25);
            this.tsMenu.TabIndex = 0;
            // 
            // tslbLogin
            // 
            this.tslbLogin.Name = "tslbLogin";
            this.tslbLogin.Size = new System.Drawing.Size(0, 22);
            // 
            // tsbtnLogInLogOut
            // 
            this.tsbtnLogInLogOut.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLogInLogOut.Image")));
            this.tsbtnLogInLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnLogInLogOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLogInLogOut.Name = "tsbtnLogInLogOut";
            this.tsbtnLogInLogOut.Size = new System.Drawing.Size(55, 22);
            this.tsbtnLogInLogOut.Text = "Вход";
            // 
            // tsbtnRegistration
            // 
            this.tsbtnRegistration.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRegistration.Image")));
            this.tsbtnRegistration.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnRegistration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRegistration.Name = "tsbtnRegistration";
            this.tsbtnRegistration.Size = new System.Drawing.Size(104, 22);
            this.tsbtnRegistration.Text = "Регистрация";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnCart
            // 
            this.tsbtnCart.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnCart.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCart.Image")));
            this.tsbtnCart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnCart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCart.Name = "tsbtnCart";
            this.tsbtnCart.Size = new System.Drawing.Size(76, 22);
            this.tsbtnCart.Text = "Корзина";
            // 
            // tslbSearch
            // 
            this.tslbSearch.Name = "tslbSearch";
            this.tslbSearch.Size = new System.Drawing.Size(49, 22);
            this.tslbSearch.Text = "Поиск:";
            // 
            // tstbSearch
            // 
            this.tstbSearch.Name = "tstbSearch";
            this.tstbSearch.Size = new System.Drawing.Size(117, 25);
            // 
            // tscbSearchType
            // 
            this.tscbSearchType.Name = "tscbSearchType";
            this.tscbSearchType.Size = new System.Drawing.Size(115, 25);
            // 
            // flpBooks
            // 
            this.flpBooks.AutoScroll = true;
            this.flpBooks.Location = new System.Drawing.Point(0, 28);
            this.flpBooks.Name = "flpBooks";
            this.flpBooks.Size = new System.Drawing.Size(548, 592);
            this.flpBooks.TabIndex = 9;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnPrev,
            this.tslbPageNumber,
            this.tscbBooksOnPage,
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
            this.tsbtnPrev.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPrev.Image")));
            this.tsbtnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPrev.Name = "tsbtnPrev";
            this.tsbtnPrev.Size = new System.Drawing.Size(41, 22);
            this.tsbtnPrev.Text = "<<";
            // 
            // tslbPageNumber
            // 
            this.tslbPageNumber.Name = "tslbPageNumber";
            this.tslbPageNumber.Size = new System.Drawing.Size(112, 22);
            this.tslbPageNumber.Text = "toolStripLabel1";
            // 
            // tscbBooksOnPage
            // 
            this.tscbBooksOnPage.Name = "tscbBooksOnPage";
            this.tscbBooksOnPage.Size = new System.Drawing.Size(121, 25);
            // 
            // tsbtnNext
            // 
            this.tsbtnNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNext.Image")));
            this.tsbtnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNext.Name = "tsbtnNext";
            this.tsbtnNext.Size = new System.Drawing.Size(41, 22);
            this.tsbtnNext.Text = ">>";
            // 
            // tslbOnDisplayText
            // 
            this.tslbOnDisplayText.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslbOnDisplayText.Name = "tslbOnDisplayText";
            this.tslbOnDisplayText.Size = new System.Drawing.Size(98, 22);
            this.tslbOnDisplayText.Text = "Выбрано книг:";
            // 
            // tslbOnDisplay
            // 
            this.tslbOnDisplay.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslbOnDisplay.Name = "tslbOnDisplay";
            this.tslbOnDisplay.Size = new System.Drawing.Size(14, 22);
            this.tslbOnDisplay.Text = "_";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 647);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.flpBooks);
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
        private System.Windows.Forms.ToolStripLabel tslbSearch;
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
        private System.Windows.Forms.ToolStripComboBox tscbBooksOnPage;
        private System.Windows.Forms.ToolStripButton tsbtnNext;
        private System.Windows.Forms.ToolStripLabel tslbOnDisplay;
        private System.Windows.Forms.ToolStripLabel tslbOnDisplayText;
    }
}

