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
    partial class EditorWindow : Form
    {
        List<string> keyWords = new List<string>();
        FileInfo currFile;
        bool isSave = true;
        Form1 parentForm;
        private EditorWindow()
        {
            InitializeComponent();
        }
        public EditorWindow(Form1 parent) : this()
        {
            parentForm = parent;
            Init_cmsRightClick();
        }
        private void Init_cmsRightClick()
        {
            rtbEditor.ContextMenuStrip = cmsRightClick;
            отменитьToolStripMenuItem.Click += (s, e) => { rtbEditor.Undo(); };
            вернутьToolStripMenuItem.Click += (s, e) => { rtbEditor.Redo(); };
            копироватьToolStripMenuItem.Click += (s, e) => { rtbEditor.Copy(); };
            вставитьToolStripMenuItem.Click += (s, e) => { rtbEditor.Paste(); };
            вырезатьToolStripMenuItem.Click += (s, e) => { rtbEditor.Cut(); };
        }
        private bool LoadKeyWords(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                ;
                keyWords = new List<string>();
                keyWords.AddRange(File.ReadAllLines(file.Extension + ".txt"));
                keyWords.Select(o => o != "").ToList();
            }
            catch (Exception) { return false; }
            return true;
        }
        public bool LoadFile(string path)
        {
            try
            {
                currFile = new FileInfo(path);
                Text = currFile.Name;
                rtbEditor.Lines = File.ReadAllLines(path);
                rtbEditor.SelectionColor = Color.Gainsboro;
                UpdateInfo();
            }
            catch (Exception) { return false; }

            //Если найден список ключевых слов для текущего формата файла, то подсвечиваем их
            if (LoadKeyWords(path)) HighlightingWords();
            isSave = true;

            return true;
        }
        public bool SaveFile(string path = null)
        {
            try
            {
                if (path == null && currFile == null) //Если это новый файл
                    parentForm.сохранитьКакToolStripMenuItem_Click(null, null);
                else //Если это перезапись
                {
                    if (path == null) path = currFile.FullName;
                    else currFile = new FileInfo(path);

                    Text = currFile.Name;
                    File.WriteAllLines(path, rtbEditor.Lines);
                    isSave = true;
                }
            }
            catch (Exception) { return false; }
            return true;
        }
        public void HighlightingWords(int line = -1)
        {
            try
            {
                Color blue = Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(156)))), ((int)(((byte)(214)))));

                //Если меньше ноля, то ищем во всем тексте иначе в заданной строке
                string textSearch = (line < 0) ? rtbEditor.Text : rtbEditor.Lines[line];
                int shift = (line < 0) ? 0 : rtbEditor.GetFirstCharIndexOfCurrentLine();
                int position = rtbEditor.SelectionStart;

                foreach (var word in keyWords)
                {
                    Regex re = new Regex($"\\b({word})\\b");
                    var matches = re.Matches(textSearch);

                    foreach (Match item in matches)
                    {
                        rtbEditor.Select(shift + item.Index, item.Length);
                        rtbEditor.SelectionColor = blue;
                    }
                }

                rtbEditor.Select(position, 0);
                rtbEditor.SelectionColor = Color.Gainsboro;
            }
            catch (Exception) { }
        }
        private void UpdateInfo()
        {
            slChars.Text = rtbEditor.SelectionStart.ToString() + '/' + rtbEditor.TextLength.ToString();
            slLines.Text = (GetCurrentCaretPossition() + 1).ToString() + '/' + (rtbEditor.Lines?.Length + 1).ToString();
        }
        private int GetCurrentCaretPossition() => rtbEditor.GetLineFromCharIndex(rtbEditor.SelectionStart);

        private void rtbEditor_TextChanged(object sender, EventArgs e)
        {
            HighlightingWords(GetCurrentCaretPossition());
            isSave = false;
        }

        private void rtbEditor_SelectionChanged(object sender, EventArgs e) => UpdateInfo();

        private void EditorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSave &&
                MessageBox.Show($"Файл{(currFile == null ? " " : " " + currFile.Name)}не сохранён, сохранить?", typeof(Form1).Namespace, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                SaveFile();

            if (parentForm.MdiChildren.Length == 1)
                parentForm.EnableDisableFileOperations();
        }
    }
}
