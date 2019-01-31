namespace task2
{
    partial class Stock
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
            this.lstBoxStock = new System.Windows.Forms.ListBox();
            this.grpBoxStock = new System.Windows.Forms.GroupBox();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.grpBoxAdd = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtBoxPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtBoxDesc = new System.Windows.Forms.TextBox();
            this.txtBoxSpec = new System.Windows.Forms.TextBox();
            this.lblSpec = new System.Windows.Forms.Label();
            this.grpBoxStock.SuspendLayout();
            this.grpBoxAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstBoxStock
            // 
            this.lstBoxStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstBoxStock.FormattingEnabled = true;
            this.lstBoxStock.Location = new System.Drawing.Point(9, 19);
            this.lstBoxStock.Name = "lstBoxStock";
            this.lstBoxStock.ScrollAlwaysVisible = true;
            this.lstBoxStock.Size = new System.Drawing.Size(211, 121);
            this.lstBoxStock.TabIndex = 0;
            this.lstBoxStock.SelectedIndexChanged += new System.EventHandler(this.lstBoxStock_SelectedIndexChanged);
            // 
            // grpBoxStock
            // 
            this.grpBoxStock.Controls.Add(this.lstBoxStock);
            this.grpBoxStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpBoxStock.Location = new System.Drawing.Point(12, 6);
            this.grpBoxStock.Name = "grpBoxStock";
            this.grpBoxStock.Size = new System.Drawing.Size(229, 149);
            this.grpBoxStock.TabIndex = 1;
            this.grpBoxStock.TabStop = false;
            this.grpBoxStock.Text = "Список товара:";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(109, 16);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(111, 20);
            this.txtBoxName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(6, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Название:";
            // 
            // grpBoxAdd
            // 
            this.grpBoxAdd.Controls.Add(this.btnAdd);
            this.grpBoxAdd.Controls.Add(this.btnRemove);
            this.grpBoxAdd.Controls.Add(this.txtBoxPrice);
            this.grpBoxAdd.Controls.Add(this.lblPrice);
            this.grpBoxAdd.Controls.Add(this.lblDesc);
            this.grpBoxAdd.Controls.Add(this.txtBoxDesc);
            this.grpBoxAdd.Controls.Add(this.txtBoxSpec);
            this.grpBoxAdd.Controls.Add(this.lblSpec);
            this.grpBoxAdd.Controls.Add(this.lblName);
            this.grpBoxAdd.Controls.Add(this.txtBoxName);
            this.grpBoxAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpBoxAdd.Location = new System.Drawing.Point(12, 161);
            this.grpBoxAdd.Name = "grpBoxAdd";
            this.grpBoxAdd.Size = new System.Drawing.Size(229, 134);
            this.grpBoxAdd.TabIndex = 3;
            this.grpBoxAdd.TabStop = false;
            this.grpBoxAdd.Text = "Добавить новый товар:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(161, 101);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(26, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(193, 101);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(26, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "-";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtBoxPrice
            // 
            this.txtBoxPrice.Location = new System.Drawing.Point(72, 103);
            this.txtBoxPrice.Name = "txtBoxPrice";
            this.txtBoxPrice.Size = new System.Drawing.Size(83, 20);
            this.txtBoxPrice.TabIndex = 8;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPrice.Location = new System.Drawing.Point(9, 101);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(57, 20);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "Цена:";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDesc.Location = new System.Drawing.Point(6, 71);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Описание:";
            // 
            // txtBoxDesc
            // 
            this.txtBoxDesc.Location = new System.Drawing.Point(109, 68);
            this.txtBoxDesc.Name = "txtBoxDesc";
            this.txtBoxDesc.Size = new System.Drawing.Size(111, 20);
            this.txtBoxDesc.TabIndex = 5;
            // 
            // txtBoxSpec
            // 
            this.txtBoxSpec.Location = new System.Drawing.Point(109, 42);
            this.txtBoxSpec.Name = "txtBoxSpec";
            this.txtBoxSpec.Size = new System.Drawing.Size(111, 20);
            this.txtBoxSpec.TabIndex = 4;
            // 
            // lblSpec
            // 
            this.lblSpec.AutoSize = true;
            this.lblSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSpec.Location = new System.Drawing.Point(6, 45);
            this.lblSpec.Name = "lblSpec";
            this.lblSpec.Size = new System.Drawing.Size(99, 13);
            this.lblSpec.TabIndex = 3;
            this.lblSpec.Text = "Характеристиски:";
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 303);
            this.Controls.Add(this.grpBoxAdd);
            this.Controls.Add(this.grpBoxStock);
            this.MaximumSize = new System.Drawing.Size(260, 330);
            this.MinimumSize = new System.Drawing.Size(260, 330);
            this.Name = "Stock";
            this.ShowIcon = false;
            this.Text = "Склад";
            this.grpBoxStock.ResumeLayout(false);
            this.grpBoxAdd.ResumeLayout(false);
            this.grpBoxAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxStock;
        private System.Windows.Forms.GroupBox grpBoxStock;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox grpBoxAdd;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtBoxDesc;
        private System.Windows.Forms.TextBox txtBoxSpec;
        private System.Windows.Forms.Label lblSpec;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtBoxPrice;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
    }
}