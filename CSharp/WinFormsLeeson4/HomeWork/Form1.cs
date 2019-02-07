using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                var dirsAndFiles = Directory.GetDirectories(path).ToList();
                if(!chkSelectOnlyFolder.Checked) dirsAndFiles.AddRange(Directory.GetFiles(path).ToList());

                if (dirsAndFiles.Count > 0)
                {
                    var iList = new ImageList();
                    iList.Images.Add(Image.FromFile("Icons/folder-open.png"));
                    iList.Images.Add(Image.FromFile("Icons/folder-closed.png"));
                    iList.Images.Add(Image.FromFile("Icons/file.png"));
                    iList.ImageSize = new Size(8, 8);

                    dynamic parentNode;
                    if (node == null) parentNode = tvTree;
                    else parentNode = node;
                    
                    parentNode.Nodes.Clear();
                    foreach (var fullPath in dirsAndFiles)
                    {
                        var newNode = new TreeNode(fullPath.Replace(path + '\\',""));
                        try
                        {
                            if (Directory.Exists(fullPath))
                            {
                                if (Directory.GetDirectories(fullPath).Length > 0)
                                    newNode.Nodes.Add("");
                            }
                            if (File.Exists(fullPath)) ;
                            
                        }
                        catch (UnauthorizedAccessException) { } //На случай недостатка прав на операцию

                        newNode.Tag = fullPath;
                        parentNode.Nodes.Add(newNode);
                    }
                }
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
    }
}
