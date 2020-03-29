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

            InitEncodingList();
            InitSyntaxList();
            AllowDrop = true;
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            MdiChildActivate += ChildActivate;
        }
        private void InitEncodingList()
        {
            var list = Encoding.GetEncodings().OrderBy(o => o.DisplayName).ToArray();
            tscbEncodingLIst.ComboBox.DataSource = list;
            tscbEncodingLIst.ComboBox.DisplayMember = "DisplayName";
            tscbEncodingLIst.ComboBox.SelectedIndex = -1;
        }
        private void InitSyntaxList()
        {
            var list = Directory.GetFiles(".",".*.txt").Select( o => 
            {
                var fi = new FileInfo(o);
                return fi.Name;
            }).ToArray();

            tscbSelectSyntax.Items.AddRange(list);
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
        private void ChildActivate(object sender, EventArgs e)
        {
            EditorWindow ew = ActiveMdiChild as EditorWindow;
            if (ew != null)
            {
                string name = ew.CodePage.EncodingName;
                tscbEncodingLIst.ComboBox.SelectedItem =
                    (tscbEncodingLIst.ComboBox.DataSource as EncodingInfo[]).First(o => o.DisplayName == name);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditorWindow(this) { MdiParent = this, Font = fontEditorWindow }.Show();
            EnableDisableFileOperations(true);
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
                    EnableDisableFileOperations(true);
                }
            }
        }
        public void EnableDisableFileOperations(bool @switch)
        {
            правкаToolStripMenuItem.Enabled = @switch;
            видToolStripMenuItem.Enabled = @switch;
            tscbEncodingLIst.Enabled = @switch;
            закрытьToolStripMenuItem.Enabled = @switch;
            закрытьВсёToolStripMenuItem.Enabled = @switch;
            сохранитьToolStripMenuItem.Enabled = @switch;
            сохранитьКакToolStripMenuItem.Enabled = @switch;
            //if (!@switch) tscbEncodingLIst.ComboBox.SelectedItem = null; //tscbEncodingLIst.ComboBox.SelectedIndex = -1;
            //if (!@switch) tscbSelectSyntax.SelectedIndex = -1;
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
        private void закрытьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var child in MdiChildren)
                child.Close();
        }

        private void толькоЧтениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorWindow ew = ActiveMdiChild as EditorWindow;
            if (ew != null)
            {
                ew.rtbEditor.ReadOnly = !ew.rtbEditor.ReadOnly;
                толькоЧтениеToolStripMenuItem.Checked = !толькоЧтениеToolStripMenuItem.Checked;
            }
        }

        private void выделитьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorWindow ew = ActiveMdiChild as EditorWindow;
            if (ew != null)
                ew.rtbEditor.Select(0, ew.rtbEditor.Text.Length);
        }

        private void tscbEncodingLIst_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditorWindow ew = ActiveMdiChild as EditorWindow;
            if (ew != null && tscbEncodingLIst.ComboBox.SelectedIndex != -1)
            {
                if (!ew.IsSave) ew.SaveFile();
                EncodingInfo ei = tscbEncodingLIst.ComboBox.SelectedItem as EncodingInfo;
                ew.CodePage = ei.GetEncoding();
                ew.LoadFile(ew.CurrentFile.FullName);
            }
        }

        private void tscbSelectSyntax_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditorWindow ew = ActiveMdiChild as EditorWindow;
            if (ew != null && tscbSelectSyntax.SelectedIndex != -1)
            {
                string pathToKeyWords = tscbSelectSyntax.SelectedItem as string;
                if (!ew.LoadKeyWords(".\\" + pathToKeyWords)) Error("Ошибка при чтении файла ключевых слов.");
            }
        }
    }
}
