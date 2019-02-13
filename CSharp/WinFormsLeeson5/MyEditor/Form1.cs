using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEditor
{
    public partial class Form1 : Form
    {
        Font fontEditorWindow = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        readonly string filter = @"Любые файлы(*.*)|*.*|Текстовые файлы(*.txt)|*.txt|С-Sharp файлы(*.cs)|*.cs";
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
                if(File.Exists(path)) LoadFile(path);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e) => new EditorWindow(this) { MdiParent = this, Font = fontEditorWindow }.Show();

        private void закрытьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var child in MdiChildren)
                child.Close();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e) => LoadFile();
        public void LoadFile(string path = null)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = @"txt";
            ofd.Filter = filter;
            if (path != null || ofd.ShowDialog() == DialogResult.OK)
            {
                EditorWindow ew = new EditorWindow(this) { MdiParent = this, Font = fontEditorWindow };
                if (!ew.LoadFile((path != null) ? path : ofd.FileName)) Error("Ошибка чтения файла.");
                else
                {
                    ew.Show();
                    EnableDisableFileOperations();
                }
            }
        }
        public void EnableDisableFileOperations()
        {
            закрытьToolStripMenuItem.Enabled = !закрытьToolStripMenuItem.Enabled;
            закрытьВсёToolStripMenuItem.Enabled = !закрытьВсёToolStripMenuItem.Enabled;
            сохранитьToolStripMenuItem.Enabled = !сохранитьToolStripMenuItem.Enabled;
            сохранитьКакToolStripMenuItem.Enabled = !сохранитьКакToolStripMenuItem.Enabled;
        }
        public void Error(string text) => MessageBox.Show(text, typeof(Form1).Namespace, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorWindow ew = ActiveMdiChild as EditorWindow;

            if (ew != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.DefaultExt = @"txt";
                sfd.Filter = filter;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!ew.SaveFile(sfd.FileName)) Error("Ошибка записи файла.");
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorWindow ew = ActiveMdiChild as EditorWindow;
            if (ew != null && !ew.SaveFile()) Error("Ошибка записи файла.");
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog{ Font = fontEditorWindow };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                fontEditorWindow = fd.Font;
                foreach (EditorWindow item in MdiChildren)
                {
                    item.rtbEditor.Font = fontEditorWindow;
                    item.HighlightingWords();
                }
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
        }

        //private void поискToolStripMenuItem_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (ActiveMdiChild != null && e.KeyData == Keys.Enter && поискToolStripMenuItem.Text != "")
        //        {
        //            EditorWindow ew = ActiveMdiChild as EditorWindow;
        //            Regex re = new Regex($"\\b{поискToolStripMenuItem.Text}\\b");
        //            var matches = re.Matches(ew.rtbEditor.Text);
        //            int position = ew.rtbEditor.SelectionStart;

        //            foreach (Match item in matches)
        //            {
        //                ew.rtbEditor.Select(item.Index, item.Length);
        //                ew.rtbEditor.SelectionBackColor = Color.Yellow;
        //            }

        //            ew.rtbEditor.Select(position, 0);
        //            ew.rtbEditor.SelectionColor = Color.Gainsboro;
        //        }
        //    }
        //    catch (Exception) { }
        //}
    }
}
