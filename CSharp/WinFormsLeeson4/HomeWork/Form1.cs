﻿using System;
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
            cbSelectView.SelectedIndex = 2;
            UpdateView();
            UpdateListDisks();
            Init_lvList();
            tvTree.ImageList = InitImages(new Size(16, 16));
            ChangeDisk();
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
        private void Init_cbSelectView() => cbSelectView.Items.AddRange(Enum.GetNames(typeof(View)));
        private void ChangeDisk()
        {
            if (cbSelectDisk.SelectedIndex != -1)
                LoadTreeContent(cbSelectDisk.SelectedItem as string);
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

            if(cbSelectDisk.SelectedIndex != -1)
                LoadListContent(cbSelectDisk.SelectedItem as string);
        }
        private void LoadListContent(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    var files = Directory.GetFiles(path);
                    var dirs = Directory.GetDirectories(path);

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
                            lvList.Items.Add(lvi);
                        }

                        foreach (var filePath in files)
                        {
                            var f = new FileInfo(filePath);
                            ListViewItem lvi = new ListViewItem(f.Name);
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Файл"));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, f.Length.ToString()));
                            lvi.ImageIndex = 2;
                            lvList.Items.Add(lvi);
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException) { }
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
        private void LoadTreeContent(string path, TreeNode node = null)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    var dirsAndFiles = Directory.GetDirectories(path).ToList();
                    //Искать файлы если снят флажок "Только папки"
                    if (!chkSelectOnlyFolder.Checked) dirsAndFiles.AddRange(Directory.GetFiles(path).ToList());

                    //Переменная типа TreeView для корневого узла или типа TreeNode для дочерних узлов
                    dynamic parentNode;
                    if (node == null) parentNode = tvTree; //Если это корневой узел
                    else parentNode = node; //Если это дочерний узел
                    
                    parentNode.Nodes.Clear();
                    if (dirsAndFiles.Count > 0)
                    {
                        foreach (var fullPath in dirsAndFiles)
                        {
                            //Удаляем лишние символы для имени узла
                            var newNode = new TreeNode(fullPath.Replace(path + $"{(node == null ? "" : "\\")}", ""));
                            try
                            {
                                //Если это папка и в ней есть папки добавляем "плюсик" к узлу
                                if (Directory.Exists(fullPath) && Directory.GetDirectories(fullPath).Length > 0)
                                    newNode.Nodes.Add("");
                                //Если это файл меняем иконку на иконку "файл"
                                else if (File.Exists(fullPath)) newNode.ImageIndex = 2;
                            }
                            catch (UnauthorizedAccessException) { } //На случай недостатка прав на операцию

                            newNode.Tag = fullPath;
                            parentNode.Nodes.Add(newNode);
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException) { } //На случай недостатка прав на операцию
        }
        private void cbSelectDisk_DropDown(object sender, EventArgs e) => UpdateListDisks();

        private void chkSelectOnlyFolder_CheckedChanged(object sender, EventArgs e) => cbSelectDisk_SelectionChangeCommitted(null, null);

        private void cbSelectDisk_SelectionChangeCommitted(object sender, EventArgs e) => ChangeDisk();

        private void tvTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 1;
            LoadTreeContent(e.Node.Tag as string, e.Node);
        }

        private void tvTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Directory.Exists(e.Node.Tag as string))
                LoadListContent(e.Node.Tag as string);
            else if (File.Exists(e.Node.Tag as string))
                Process.Start(e.Node.Tag as string);
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
            var lvi = lvList.SelectedItems[0] as ListViewItem;
            Process.Start(lvi.Tag as string);
        }
    }
}
