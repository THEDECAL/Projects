namespace task3
{
    partial class EditForm
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
            this.grpBoxEdit = new System.Windows.Forms.GroupBox();
            this.txtBoxTextEdit = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpBoxEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxEdit
            // 
            this.grpBoxEdit.Controls.Add(this.txtBoxTextEdit);
            this.grpBoxEdit.Controls.Add(this.btnAccept);
            this.grpBoxEdit.Controls.Add(this.btnCancel);
            this.grpBoxEdit.Location = new System.Drawing.Point(12, 12);
            this.grpBoxEdit.Name = "grpBoxEdit";
            this.grpBoxEdit.Size = new System.Drawing.Size(532, 249);
            this.grpBoxEdit.TabIndex = 3;
            this.grpBoxEdit.TabStop = false;
            // 
            // txtBoxTextEdit
            // 
            this.txtBoxTextEdit.Location = new System.Drawing.Point(6, 19);
            this.txtBoxTextEdit.Multiline = true;
            this.txtBoxTextEdit.Name = "txtBoxTextEdit";
            this.txtBoxTextEdit.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxTextEdit.Size = new System.Drawing.Size(520, 189);
            this.txtBoxTextEdit.TabIndex = 3;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(138, 214);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(125, 29);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Принять";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(269, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 273);
            this.Controls.Add(this.grpBoxEdit);
            this.MaximumSize = new System.Drawing.Size(564, 300);
            this.MinimumSize = new System.Drawing.Size(564, 300);
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.Text = "Изменение";
            this.grpBoxEdit.ResumeLayout(false);
            this.grpBoxEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxEdit;
        private System.Windows.Forms.TextBox txtBoxTextEdit;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}