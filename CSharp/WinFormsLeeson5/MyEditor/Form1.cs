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

namespace MyEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            AllowDrop = true;
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as string[];
            foreach (var path in files)
                LoadFile(path);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e) => new EditorWindow { MdiParent = this }.Show();

        private void закрытьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (EditorWindow child in MdiChildren)
                child.Close();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e) => LoadFile();
        public void LoadFile(string path = null)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = @"txt";
            ofd.Filter = @"С-Sharp файлы(*.cs)|*.cs|Текстовые файлы(*.txt)|*.txt|Любые файлы(*.*)|*.*";
            if (path != null || ofd.ShowDialog() == DialogResult.OK)
            {
                EditorWindow ew = new EditorWindow { MdiParent = this };
                if (!ew.LoadFile((path != null) ? path : ofd.FileName)) Error("Ошибка чтения файла.");
                else ew.Show();
            }
        }
        public void Error(string text) => MessageBox.Show(text, typeof(Form1).Namespace, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
