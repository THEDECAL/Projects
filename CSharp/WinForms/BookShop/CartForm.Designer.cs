namespace BookShop
{
    partial class CartForm
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
            this.gbGeneric = new System.Windows.Forms.GroupBox();
            this.lstbBooks = new System.Windows.Forms.ListBox();
            this.btnSale = new System.Windows.Forms.Button();
            this.lbAllPrice = new System.Windows.Forms.Label();
            this.bcInfo = new BookShop.BookControl();
            this.gbGeneric.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGeneric
            // 
            this.gbGeneric.Controls.Add(this.lbAllPrice);
            this.gbGeneric.Controls.Add(this.btnSale);
            this.gbGeneric.Controls.Add(this.bcInfo);
            this.gbGeneric.Controls.Add(this.lstbBooks);
            this.gbGeneric.Location = new System.Drawing.Point(3, -1);
            this.gbGeneric.Name = "gbGeneric";
            this.gbGeneric.Size = new System.Drawing.Size(261, 254);
            this.gbGeneric.TabIndex = 0;
            this.gbGeneric.TabStop = false;
            // 
            // lstbBooks
            // 
            this.lstbBooks.FormattingEnabled = true;
            this.lstbBooks.Location = new System.Drawing.Point(135, 12);
            this.lstbBooks.Name = "lstbBooks";
            this.lstbBooks.Size = new System.Drawing.Size(120, 147);
            this.lstbBooks.TabIndex = 0;
            this.lstbBooks.SelectedIndexChanged += new System.EventHandler(this.lstbBooks_SelectedIndexChanged);
            // 
            // btnSale
            // 
            this.btnSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSale.Location = new System.Drawing.Point(135, 213);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(120, 34);
            this.btnSale.TabIndex = 2;
            this.btnSale.Text = "Купить";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // lbAllPrice
            // 
            this.lbAllPrice.BackColor = System.Drawing.Color.PeachPuff;
            this.lbAllPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbAllPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAllPrice.Location = new System.Drawing.Point(135, 162);
            this.lbAllPrice.Name = "lbAllPrice";
            this.lbAllPrice.Size = new System.Drawing.Size(120, 48);
            this.lbAllPrice.TabIndex = 3;
            this.lbAllPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bcInfo
            // 
            this.bcInfo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.bcInfo.Book = null;
            this.bcInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bcInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bcInfo.Location = new System.Drawing.Point(6, 12);
            this.bcInfo.MaximumSize = new System.Drawing.Size(123, 235);
            this.bcInfo.MinimumSize = new System.Drawing.Size(123, 235);
            this.bcInfo.Name = "bcInfo";
            this.bcInfo.Size = new System.Drawing.Size(123, 235);
            this.bcInfo.TabIndex = 1;
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 256);
            this.Controls.Add(this.gbGeneric);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CartForm";
            this.Text = "Корзина";
            this.gbGeneric.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGeneric;
        private System.Windows.Forms.Button btnSale;
        private BookControl bcInfo;
        private System.Windows.Forms.ListBox lstbBooks;
        private System.Windows.Forms.Label lbAllPrice;
    }
}