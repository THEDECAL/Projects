using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateListDisks();
            cbSelectDisk_SelectionChangeCommitted(null, null);
        }
        private void UpdateListDisks() => cbSelectDisk.DataSource = Environment.GetLogicalDrives();
        private void LoadDirectoryContent(string path, TreeNode node = null)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    var dirsAndFiles = Directory.GetDirectories(path).ToList();
                    if (!chkSelectOnlyFolder.Checked) dirsAndFiles.AddRange(Directory.GetFiles(path).ToList());

                    if (dirsAndFiles.Count > 0)
                    {
                        dynamic parentNode;

                        if (node == null)
                        {
                            parentNode = tvTree;
                            var iList = new ImageList();
                            iList.Images.Add(Image.FromFile("../../Icons/folder-closed.png"));
                            iList.Images.Add(Image.FromFile("../../Icons/folder-open.png"));
                            iList.Images.Add(Image.FromFile("../../Icons/file.png"));
                            iList.ImageSize = new Size(16, 16);
                            tvTree.ImageList = iList;
                        }
                        else
                        {
                            parentNode = node;
                            parentNode.ImageIndex = 1;
                        }

                        parentNode.Nodes.Clear();
                        foreach (var fullPath in dirsAndFiles)
                        {
                            var newNode = new TreeNode(fullPath.Replace(path + '\\', ""));
                            try
                            {
                                if (Directory.Exists(fullPath) && Directory.GetDirectories(fullPath).Length > 0)
                                    newNode.Nodes.Add("");
                                else if (File.Exists(fullPath))
                                    newNode.ImageIndex = 2;
                            }
                            catch (UnauthorizedAccessException) { } //На случай недостатка прав на операцию

                            newNode.Tag = fullPath;
                            parentNode.Nodes.Add(newNode);
                        }
                    }
                }
                catch (UnauthorizedAccessException) { } //На случай недостатка прав на операцию
            }
        }
        private void cbSelectDisk_DropDown(object sender, EventArgs e) => UpdateListDisks();

        private void chkSelectOnlyFolder_CheckedChanged(object sender, EventArgs e) => cbSelectDisk_SelectionChangeCommitted(null, null);

        private void cbSelectDisk_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbSelectDisk.SelectedIndex != -1)
                LoadDirectoryContent((string)cbSelectDisk.SelectedItem);
        }

        private void tvTree_BeforeExpand(object sender, TreeViewCancelEventArgs e) => LoadDirectoryContent(e.Node.Tag as string, e.Node);

        private void tvTree_AfterExpand(object sender, TreeViewEventArgs e) {; }// => LoadDirectoryContent(e.Node.Tag as string, e.Node);

        private void tvTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (Directory.Exists(e.Node.Tag as string))
                LoadDirectoryContent(e.Node.Tag as string, e.Node);
            else if (File.Exists(e.Node.Tag as string))
                Process.Start(e.Node.Tag as string);
        }

        private void tvTree_AfterSelect(object sender, TreeViewEventArgs e) {; }// => LoadDirectoryContent(e.Node.Tag as string, e.Node);

        private void cbSelectView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tvTree_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 0;
            e.Node.Nodes.Clear();
            e.Node.Nodes.Add("");
        }
    }
}
