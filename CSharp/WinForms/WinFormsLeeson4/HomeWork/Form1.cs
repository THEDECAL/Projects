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
        FileSystemWatcher fsw;
        public Form1()
        {
            InitializeComponent();

            Init_cbSelectView();
            UpdateView();
            UpdateListDisks();
            Init_lvList();
            tvTree.ImageList = InitImages(new Size(16, 16));
            ChangeDisk();
        }
        private void InitFileSystemWatcher(string path, dynamic parentNode)
        {
            //Отключаем старое наблюдение за ФС
            if (fsw != null) fsw.EnableRaisingEvents = false;

            fsw = new FileSystemWatcher(path);
            Action updateList = () => { LoadTreeContent(path, parentNode); LoadListContent(path); };
            fsw.Created += (s, e) => { updateList(); };
            fsw.Deleted += (s, e) => { updateList(); };
            fsw.Changed += (s, e) => { updateList(); };
            fsw.Renamed += (s, e) => { updateList(); };
            fsw.SynchronizingObject = tvTree;
            fsw.EnableRaisingEvents = true;
        }
        private void UpdateListDisks() => cbSelectDisk.DataSource = Environment.GetLogicalDrives();
        private void UpdateView()
        {
            if (cbSelectView.SelectedIndex != -1)
            {
                string style = cbSelectView.SelectedItem as string;
                lvList.View = (View)Enum.Parse(typeof(View), style);
            }
        }
        private void Init_cbSelectView()
        {
            cbSelectView.Items.AddRange(Enum.GetNames(typeof(View)));
            cbSelectView.SelectedIndex = 3;
        }
        private void ChangeDisk()
        {
            if (cbSelectDisk.SelectedIndex != -1)
            {
                tvTree.Nodes.Clear();
                LoadTreeContent(cbSelectDisk.SelectedItem as string, tvTree);
                tvTree.SelectedNode = null;
            }
        }
        private void Init_lvList()
        {
            ImageList largeIcon = InitImages(new Size(96, 96));
            ImageList smallIcon = InitImages(new Size(16, 16));
            lvList.LargeImageList = largeIcon;
            lvList.SmallImageList = smallIcon;
            lvList.FullRowSelect = true;

            lvList.Columns.Add("Имя");
            lvList.Columns.Add("Тип");
            lvList.Columns.Add("Размер");
        }
        private ImageList InitImages(Size size)
        {
            var iList = new ImageList();
            iList.Images.Add(Image.FromFile("../../Icons/folder-closed.png"));
            iList.Images.Add(Image.FromFile("../../Icons/folder-open.png"));
            iList.Images.Add(Image.FromFile("../../Icons/file.png"));
            iList.ImageSize = size;

            return iList;
        }
        private void LoadListContent(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    var dirs = Directory.GetDirectories(path);
                    var files = Directory.GetFiles(path);

                    lvList.Items.Clear();
                    if (files.Length > 0 || dirs.Length > 0)
                    {
                        foreach (var dirPath in dirs)
                        {
                            var d = new FileInfo(dirPath);
                            ListViewItem lvi = new ListViewItem(d.Name);
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Папка"));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "-"));
                            lvi.ImageIndex = 0;
                            lvi.Tag = dirPath;
                            lvList.Items.Add(lvi);
                        }

                        foreach (var filePath in files)
                        {
                            var f = new FileInfo(filePath);
                            ListViewItem lvi = new ListViewItem(f.Name);
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Файл"));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, f.Length.ToString()));
                            lvi.ImageIndex = 2;
                            lvi.Tag = filePath;
                            lvList.Items.Add(lvi);
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException) { }
        }
        private void LoadTreeContent(string path, dynamic parentNode)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    var dirs = Directory.GetDirectories(path);
                    //Искать файлы если снят флажок "Только папки"
                    var files = (!chkSelectOnlyFolder.Checked) ? Directory.GetFiles(path) : new string[0];

                    tbCurrentPath.Text = path;
                    LoadListContent(path);
                    InitFileSystemWatcher(path, parentNode);
                    parentNode.Nodes.Clear();

                    if (dirs.Length > 0 || files.Length > 0)
                    {
                        foreach (var dirPath in dirs)
                        {
                            DirectoryInfo di = new DirectoryInfo(dirPath);
                            var newNode = new TreeNode(di.Name);
                            newNode.Nodes.Add("");
                            newNode.Tag = dirPath;
                            parentNode.Nodes.Add(newNode);
                        }
                        
                        foreach (var filePath in files)
                        {
                            FileInfo fi = new FileInfo(filePath);
                            var newNode = new TreeNode(fi.Name);
                            //Меняем иконку на иконку "файл"
                            newNode.ImageIndex = 2;
                            newNode.Tag = filePath;
                            parentNode.Nodes.Add(newNode);
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException) {} //На случай недостатка прав на операцию
        }
        private void cbSelectDisk_DropDown(object sender, EventArgs e) => UpdateListDisks();

        private void chkSelectOnlyFolder_CheckedChanged(object sender, EventArgs e) => ChangeDisk();

        private void cbSelectDisk_SelectionChangeCommitted(object sender, EventArgs e) => ChangeDisk();

        private void tvTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            string path = e.Node.Tag as string;
            tvTree.SelectedNode = e.Node;
            try
            {
                if (chkSelectOnlyFolder.Checked &&
                    Directory.GetDirectories(path).Length > 0) LoadTreeContent(path, e.Node);
                else if (!chkSelectOnlyFolder.Checked &&
                    Directory.GetFiles(path).Length > 0 ||
                    Directory.GetDirectories(path).Length > 0) LoadTreeContent(path, e.Node);
                else throw new UnauthorizedAccessException();
            }
            catch (UnauthorizedAccessException)
            {
                e.Node.Nodes.Clear();
                lvList.Items.Clear();
                return;
            }
            e.Node.ImageIndex = 1;
        }

        private void tvTree_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 0;
            e.Node.Nodes.Clear();
            e.Node.Nodes.Add("");
        }

        private void cbSelectView_SelectionChangeCommitted(object sender, EventArgs e) => UpdateView();

        private void lvList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string path = lvList.SelectedItems[0].Tag as string;
            if (File.Exists(path)) Process.Start(path);
        }

        private void tvTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string path = tvTree.SelectedNode.Tag as string;
            if (File.Exists(path)) Process.Start(path);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tvTree.SelectedNode = tvTree.SelectedNode?.Parent;
            if (tvTree.SelectedNode == null) ChangeDisk();
            else LoadTreeContent(tvTree.SelectedNode.Tag as string, tvTree.SelectedNode);
        }
    }
}
