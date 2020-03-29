namespace task2
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
            this.cmbBoxSelect = new System.Windows.Forms.ComboBox();
            this.lblSelect = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.lblSum = new System.Windows.Forms.Label();
            this.txtBoxSum = new System.Windows.Forms.TextBox();
            this.lstBoxCart = new System.Windows.Forms.ListBox();
            this.grpBoxCart = new System.Windows.Forms.GroupBox();
            this.txtBoxDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtBoxPrice = new System.Windows.Forms.TextBox();
            this.grpBoxSum = new System.Windows.Forms.GroupBox();
            this.grpBoxCart.SuspendLayout();
            this.grpBoxSum.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbBoxSelect
            // 
            this.cmbBoxSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxSelect.FormattingEnabled = true;
            this.cmbBoxSelect.Location = new System.Drawing.Point(9, 32);
            this.cmbBoxSelect.Name = "cmbBoxSelect";
            this.cmbBoxSelect.Size = new System.Drawing.Size(211, 21);
            this.cmbBoxSelect.TabIndex = 0;
            this.cmbBoxSelect.DropDown += new System.EventHandler(this.cmbBoxSelect_DropDown);
            this.cmbBoxSelect.SelectedIndexChanged += new System.EventHandler(this.cmbBoxSelect_SelectedIndexChanged);
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSelect.Location = new System.Drawing.Point(6, 16);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(107, 13);
            this.lblSelect.TabIndex = 1;
            this.lblSelect.Text = "Выберите товар:";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.Location = new System.Drawing.Point(164, 105);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(26, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(86, 346);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(75, 27);
            this.btnStock.TabIndex = 3;
            this.btnStock.Text = "Склад";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSum.Location = new System.Drawing.Point(6, 20);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(68, 20);
            this.lblSum.TabIndex = 4;
            this.lblSum.Text = "Сумма:";
            // 
            // txtBoxSum
            // 
            this.txtBoxSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBoxSum.Location = new System.Drawing.Point(93, 13);
            this.txtBoxSum.Multiline = true;
            this.txtBoxSum.Name = "txtBoxSum";
            this.txtBoxSum.ReadOnly = true;
            this.txtBoxSum.Size = new System.Drawing.Size(127, 40);
            this.txtBoxSum.TabIndex = 5;
            this.txtBoxSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lstBoxCart
            // 
            this.lstBoxCart.FormattingEnabled = true;
            this.lstBoxCart.Location = new System.Drawing.Point(9, 137);
            this.lstBoxCart.Name = "lstBoxCart";
            this.lstBoxCart.ScrollAlwaysVisible = true;
            this.lstBoxCart.Size = new System.Drawing.Size(211, 121);
            this.lstBoxCart.TabIndex = 6;
            // 
            // grpBoxCart
            // 
            this.grpBoxCart.Controls.Add(this.txtBoxDesc);
            this.grpBoxCart.Controls.Add(this.lblDesc);
            this.grpBoxCart.Controls.Add(this.btnRemove);
            this.grpBoxCart.Controls.Add(this.lblPrice);
            this.grpBoxCart.Controls.Add(this.txtBoxPrice);
            this.grpBoxCart.Controls.Add(this.lblSelect);
            this.grpBoxCart.Controls.Add(this.lstBoxCart);
            this.grpBoxCart.Controls.Add(this.cmbBoxSelect);
            this.grpBoxCart.Controls.Add(this.btnAdd);
            this.grpBoxCart.Location = new System.Drawing.Point(12, 12);
            this.grpBoxCart.Name = "grpBoxCart";
            this.grpBoxCart.Size = new System.Drawing.Size(230, 263);
            this.grpBoxCart.TabIndex = 7;
            this.grpBoxCart.TabStop = false;
            this.grpBoxCart.Text = "Корзина:";
            // 
            // txtBoxDesc
            // 
            this.txtBoxDesc.Location = new System.Drawing.Point(72, 56);
            this.txtBoxDesc.Multiline = true;
            this.txtBoxDesc.Name = "txtBoxDesc";
            this.txtBoxDesc.ReadOnly = true;
            this.txtBoxDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxDesc.Size = new System.Drawing.Size(148, 43);
            this.txtBoxDesc.TabIndex = 12;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDesc.Location = new System.Drawing.Point(6, 56);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 11;
            this.lblDesc.Text = "Описание:";
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemove.Location = new System.Drawing.Point(194, 105);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(26, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "-";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPrice.Location = new System.Drawing.Point(7, 110);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(41, 13);
            this.lblPrice.TabIndex = 10;
            this.lblPrice.Text = "Цена:";
            // 
            // txtBoxPrice
            // 
            this.txtBoxPrice.Location = new System.Drawing.Point(72, 105);
            this.txtBoxPrice.Name = "txtBoxPrice";
            this.txtBoxPrice.ReadOnly = true;
            this.txtBoxPrice.Size = new System.Drawing.Size(77, 20);
            this.txtBoxPrice.TabIndex = 9;
            // 
            // grpBoxSum
            // 
            this.grpBoxSum.Controls.Add(this.lblSum);
            this.grpBoxSum.Controls.Add(this.txtBoxSum);
            this.grpBoxSum.Location = new System.Drawing.Point(12, 281);
            this.grpBoxSum.Name = "grpBoxSum";
            this.grpBoxSum.Size = new System.Drawing.Size(230, 59);
            this.grpBoxSum.TabIndex = 8;
            this.grpBoxSum.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 385);
            this.Controls.Add(this.grpBoxSum);
            this.Controls.Add(this.grpBoxCart);
            this.Controls.Add(this.btnStock);
            this.MaximumSize = new System.Drawing.Size(260, 412);
            this.MinimumSize = new System.Drawing.Size(260, 412);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Магазин";
            this.grpBoxCart.ResumeLayout(false);
            this.grpBoxCart.PerformLayout();
            this.grpBoxSum.ResumeLayout(false);
            this.grpBoxSum.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBoxSelect;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.TextBox txtBoxSum;
        private System.Windows.Forms.ListBox lstBoxCart;
        private System.Windows.Forms.GroupBox grpBoxCart;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtBoxPrice;
        private System.Windows.Forms.GroupBox grpBoxSum;
        private System.Windows.Forms.TextBox txtBoxDesc;
        private System.Windows.Forms.Label lblDesc;
    }
}

