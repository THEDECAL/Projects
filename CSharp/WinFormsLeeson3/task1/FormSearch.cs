using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace task1
{
    public partial class FormSearch : Form
    {
        string selectedFolder = null;
        List<string> searchResults = new List<string>();
        public FormSearch()
        {
            InitializeComponent();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                selectedFolder = fbd.SelectedPath;
                txtBoxSelectedFolder.Text = fbd.SelectedPath;
            }
        }

        private void btnSaveResults_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "txt";
            sfd.Filter = "Текстовые файлы(*.txt)|*.txt";

            if (searchResults.Count == 0)
            {
                MessageBox.Show("Нечего сохранять, список пуст.","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sfd.ShowDialog() == DialogResult.OK)
                File.WriteAllLines(sfd.FileName, searchResults.ToArray());
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            searchResults.Clear();

            if (selectedFolder == null || selectedFolder == "")
            {
                MessageBox.Show("Вы не выбрали папку поиска.","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (txtSearchString.Text == "")
            {
                MessageBox.Show("Вы не заполнили строку поиска.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Directory.Exists(txtBoxSelectedFolder.Text))
            {
                MessageBox.Show("Введён не корректный путь.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool isSelectedParams = false;
                foreach (CheckBox item in grpBoxParams.Controls)
                    if (item.Checked) { isSelectedParams = true; break; }

                if (isSelectedParams) txtSearchString.Text = txtSearchString.Text.Replace("*", "");

                searchResults = Directory.GetFiles
                    (
                        selectedFolder,
                        (isSelectedParams) ? "*" : txtSearchString.Text,
                        (chkBoxRecursive.Checked) ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly
                    ).Select(o => o.Replace(selectedFolder + '\\', "")).ToList();

                if (chkBoxRegister.Checked) searchResults = searchResults.Where(o => o.Contains(txtSearchString.Text)).ToList();
                else if (chkBoxMath.Checked) searchResults = searchResults.Where(o => o.Equals(txtSearchString.Text)).ToList();
                else if (chkBoxRegex.Checked) searchResults = searchResults.Where(o => Regex.IsMatch(o, txtSearchString.Text)).ToList();
            }
            catch (Exception) { MessageBox.Show("Недостаточно прав.", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            if (searchResults.Count == 0) MessageBox.Show("Поиск не дал результата.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            lstBoxResults.DataSource = searchResults.ToArray();
        }

        private void chkBoxRegister_CheckedChanged(object sender, EventArgs e)
        {
            chkBoxMath.Enabled = !chkBoxMath.Enabled;
            chkBoxRegex.Enabled = !chkBoxRegex.Enabled;
        }

        private void chkBoxMath_CheckedChanged(object sender, EventArgs e)
        {
            chkBoxRegister.Enabled = !chkBoxRegister.Enabled;
            chkBoxRegex.Enabled = !chkBoxRegex.Enabled;
        }

        private void chkBoxRegex_CheckedChanged(object sender, EventArgs e)
        {
            chkBoxMath.Enabled = !chkBoxMath.Enabled;
            chkBoxRegister.Enabled = !chkBoxRegister.Enabled;
        }
    }
}
