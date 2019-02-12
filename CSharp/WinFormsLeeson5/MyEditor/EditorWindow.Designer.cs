namespace MyEditor
{
    partial class EditorWindow
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
            this.rtbEditor = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCurrLine = new System.Windows.Forms.TextBox();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.lbCurrentChar = new System.Windows.Forms.Label();
            this.tbCurrentChar = new System.Windows.Forms.TextBox();
            this.gbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbEditor
            // 
            this.rtbEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rtbEditor.ForeColor = System.Drawing.Color.Gainsboro;
            this.rtbEditor.Location = new System.Drawing.Point(0, 0);
            this.rtbEditor.Name = "rtbEditor";
            this.rtbEditor.Size = new System.Drawing.Size(422, 440);
            this.rtbEditor.TabIndex = 0;
            this.rtbEditor.Text = "";
            this.rtbEditor.SelectionChanged += new System.EventHandler(this.rtbEditor_SelectionChanged);
            this.rtbEditor.TextChanged += new System.EventHandler(this.rtbEditor_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(137, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Строка:";
            // 
            // tbCurrLine
            // 
            this.tbCurrLine.Location = new System.Drawing.Point(182, 9);
            this.tbCurrLine.Name = "tbCurrLine";
            this.tbCurrLine.ReadOnly = true;
            this.tbCurrLine.Size = new System.Drawing.Size(71, 20);
            this.tbCurrLine.TabIndex = 6;
            this.tbCurrLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.lbCurrentChar);
            this.gbInfo.Controls.Add(this.tbCurrentChar);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Controls.Add(this.tbCurrLine);
            this.gbInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbInfo.Location = new System.Drawing.Point(0, 437);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(422, 29);
            this.gbInfo.TabIndex = 7;
            this.gbInfo.TabStop = false;
            // 
            // lbCurrentChar
            // 
            this.lbCurrentChar.AutoSize = true;
            this.lbCurrentChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCurrentChar.Location = new System.Drawing.Point(12, 13);
            this.lbCurrentChar.Name = "lbCurrentChar";
            this.lbCurrentChar.Size = new System.Drawing.Size(42, 12);
            this.lbCurrentChar.TabIndex = 8;
            this.lbCurrentChar.Text = "Символ:";
            // 
            // tbCurrentChar
            // 
            this.tbCurrentChar.Location = new System.Drawing.Point(60, 9);
            this.tbCurrentChar.Name = "tbCurrentChar";
            this.tbCurrentChar.ReadOnly = true;
            this.tbCurrentChar.Size = new System.Drawing.Size(71, 20);
            this.tbCurrentChar.TabIndex = 7;
            this.tbCurrentChar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 466);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.rtbEditor);
            this.Name = "EditorWindow";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorWindow_FormClosing);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbEditor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCurrLine;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label lbCurrentChar;
        private System.Windows.Forms.TextBox tbCurrentChar;
    }
}