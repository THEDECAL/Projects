﻿namespace HomeWork
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
            this.tvTree = new System.Windows.Forms.TreeView();
            this.cbSelectDisk = new System.Windows.Forms.ComboBox();
            this.lvList = new System.Windows.Forms.ListView();
            this.gbPlace = new System.Windows.Forms.GroupBox();
            this.chkSelectOnlyFolder = new System.Windows.Forms.CheckBox();
            this.lbSelectDisk = new System.Windows.Forms.Label();
            this.gbView = new System.Windows.Forms.GroupBox();
            this.lbView = new System.Windows.Forms.Label();
            this.cbSelectView = new System.Windows.Forms.ComboBox();
            this.gbPlace.SuspendLayout();
            this.gbView.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvTree
            // 
            this.tvTree.Location = new System.Drawing.Point(6, 46);
            this.tvTree.Name = "tvTree";
            this.tvTree.Size = new System.Drawing.Size(214, 283);
            this.tvTree.TabIndex = 0;
            this.tvTree.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvTree_BeforeCollapse);
            this.tvTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvTree_BeforeExpand);
            this.tvTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTree_AfterSelect);
            // 
            // cbSelectDisk
            // 
            this.cbSelectDisk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectDisk.FormattingEnabled = true;
            this.cbSelectDisk.Location = new System.Drawing.Point(179, 17);
            this.cbSelectDisk.Name = "cbSelectDisk";
            this.cbSelectDisk.Size = new System.Drawing.Size(41, 21);
            this.cbSelectDisk.TabIndex = 1;
            this.cbSelectDisk.DropDown += new System.EventHandler(this.cbSelectDisk_DropDown);
            this.cbSelectDisk.SelectionChangeCommitted += new System.EventHandler(this.cbSelectDisk_SelectionChangeCommitted);
            // 
            // lvList
            // 
            this.lvList.Location = new System.Drawing.Point(6, 46);
            this.lvList.Name = "lvList";
            this.lvList.Size = new System.Drawing.Size(414, 283);
            this.lvList.TabIndex = 2;
            this.lvList.UseCompatibleStateImageBehavior = false;
            this.lvList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvList_MouseDoubleClick);
            // 
            // gbPlace
            // 
            this.gbPlace.Controls.Add(this.chkSelectOnlyFolder);
            this.gbPlace.Controls.Add(this.lbSelectDisk);
            this.gbPlace.Controls.Add(this.tvTree);
            this.gbPlace.Controls.Add(this.cbSelectDisk);
            this.gbPlace.Location = new System.Drawing.Point(12, 12);
            this.gbPlace.Name = "gbPlace";
            this.gbPlace.Size = new System.Drawing.Size(226, 335);
            this.gbPlace.TabIndex = 3;
            this.gbPlace.TabStop = false;
            this.gbPlace.Text = "Выбор папки и диска:";
            // 
            // chkSelectOnlyFolder
            // 
            this.chkSelectOnlyFolder.AutoSize = true;
            this.chkSelectOnlyFolder.Checked = true;
            this.chkSelectOnlyFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelectOnlyFolder.Location = new System.Drawing.Point(19, 17);
            this.chkSelectOnlyFolder.Name = "chkSelectOnlyFolder";
            this.chkSelectOnlyFolder.Size = new System.Drawing.Size(96, 17);
            this.chkSelectOnlyFolder.TabIndex = 3;
            this.chkSelectOnlyFolder.Text = "Только папки";
            this.chkSelectOnlyFolder.UseVisualStyleBackColor = true;
            this.chkSelectOnlyFolder.CheckedChanged += new System.EventHandler(this.chkSelectOnlyFolder_CheckedChanged);
            // 
            // lbSelectDisk
            // 
            this.lbSelectDisk.AutoSize = true;
            this.lbSelectDisk.Location = new System.Drawing.Point(136, 19);
            this.lbSelectDisk.Name = "lbSelectDisk";
            this.lbSelectDisk.Size = new System.Drawing.Size(37, 13);
            this.lbSelectDisk.TabIndex = 2;
            this.lbSelectDisk.Text = "Диск:";
            // 
            // gbView
            // 
            this.gbView.Controls.Add(this.lbView);
            this.gbView.Controls.Add(this.cbSelectView);
            this.gbView.Controls.Add(this.lvList);
            this.gbView.Location = new System.Drawing.Point(244, 12);
            this.gbView.Name = "gbView";
            this.gbView.Size = new System.Drawing.Size(426, 335);
            this.gbView.TabIndex = 4;
            this.gbView.TabStop = false;
            this.gbView.Text = "Выбор файла:";
            // 
            // lbView
            // 
            this.lbView.AutoSize = true;
            this.lbView.Location = new System.Drawing.Point(296, 18);
            this.lbView.Name = "lbView";
            this.lbView.Size = new System.Drawing.Size(29, 13);
            this.lbView.TabIndex = 3;
            this.lbView.Text = "Вид:";
            // 
            // cbSelectView
            // 
            this.cbSelectView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectView.FormattingEnabled = true;
            this.cbSelectView.Location = new System.Drawing.Point(331, 16);
            this.cbSelectView.Name = "cbSelectView";
            this.cbSelectView.Size = new System.Drawing.Size(89, 21);
            this.cbSelectView.TabIndex = 3;
            this.cbSelectView.SelectionChangeCommitted += new System.EventHandler(this.cbSelectView_SelectionChangeCommitted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 358);
            this.Controls.Add(this.gbView);
            this.Controls.Add(this.gbPlace);
            this.MaximumSize = new System.Drawing.Size(690, 386);
            this.MinimumSize = new System.Drawing.Size(690, 386);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Файловый менедежер";
            this.gbPlace.ResumeLayout(false);
            this.gbPlace.PerformLayout();
            this.gbView.ResumeLayout(false);
            this.gbView.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvTree;
        private System.Windows.Forms.ComboBox cbSelectDisk;
        private System.Windows.Forms.ListView lvList;
        private System.Windows.Forms.GroupBox gbPlace;
        private System.Windows.Forms.GroupBox gbView;
        private System.Windows.Forms.Label lbSelectDisk;
        private System.Windows.Forms.Label lbView;
        private System.Windows.Forms.ComboBox cbSelectView;
        private System.Windows.Forms.CheckBox chkSelectOnlyFolder;
    }
}

