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

namespace task3
{
    partial class Form1 : Form
    {
        public string FilePath { get; set; }
        public string TextFile { get; set; }
        EditForm editForm;
        public Form1()
        {
            InitializeComponent();
        }
        public void UpdateText() => txtBoxTextShow.Text = TextFile;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "txt";
            ofd.Filter = "Текстовые файлы (*.txt)|*.txt";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                FilePath = ofd.FileName;
                TextFile = File.ReadAllText(FilePath);
                UpdateText();
                btnEdit.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (editForm != null) editForm.Close();
            editForm = new EditForm(this);
            editForm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "txt";
            sfd.Filter = "Текстовые файлы (*.txt)|*.txt";
            
            if (sfd.ShowDialog() == DialogResult.OK)
                File.WriteAllText(sfd.FileName, TextFile);
        }
    }
}
