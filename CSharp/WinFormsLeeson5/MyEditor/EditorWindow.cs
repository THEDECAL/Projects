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
        List<string> keyWords;
        FileInfo currFile;
        bool isSave;
        //Form1 parentForm;
        public EditorWindow()
        {
            InitializeComponent();
        }
        //public EditorWindow(Form1 parent) : this()
        //{
        //    parentForm = parent;
        //    rtbEditor.AllowDrop = true;
        //    rtbEditor.DragEnter += rtbEditor_DragEnter;
        //    rtbEditor.DragDrop += rtbEditor_DragDrop;
        //}

        //private void rtbEditor_DragDrop(object sender, DragEventArgs e)
        //{
        //    var files = e.Data.GetData(DataFormats.FileDrop) as List<string>;
        //    files.ForEach(path => parentForm.LoadFile(path));
        //}

        //private void rtbEditor_DragEnter(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.FileDrop))
        //        e.Effect = DragDropEffects.All;
        //}

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
                rtbEditor.Lines = File.ReadAllLines(path);
                rtbEditor.SelectionColor = Color.Gainsboro;
                UpdateInfo();
                if (LoadKeyWords(path)) HighlightingWords();
            }
            catch (Exception) { return false; }
            return true;
        }
        private void HighlightingWords(int line = -1)
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
        private void UpdateInfo()
        {
            tbCurrentChar.Text = rtbEditor.SelectionStart.ToString() + '/' + rtbEditor.TextLength.ToString();
            tbCurrLine.Text = (GetCurrentCaretPossition() + 1).ToString() + '/' + rtbEditor.Lines.Length.ToString();
        }
        private int GetCurrentCaretPossition() => rtbEditor.GetLineFromCharIndex(rtbEditor.SelectionStart);

        private void rtbEditor_TextChanged(object sender, EventArgs e) => HighlightingWords(GetCurrentCaretPossition());

        private void rtbEditor_SelectionChanged(object sender, EventArgs e) => UpdateInfo();
        private void EditorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSave && MessageBox.Show($"Файл {(currFile == null ? "\b" : currFile.Name)} не сохранён, сохранить?", typeof(Form1).Namespace, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

            }
        }
    }
}
