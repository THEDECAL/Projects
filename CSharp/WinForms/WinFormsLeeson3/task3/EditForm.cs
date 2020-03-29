using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task3
{
    partial class EditForm : Form
    {
        Form1 parentForm;
        private EditForm()
        {
            InitializeComponent();
        }
        private void UpdateText() => txtBoxTextEdit.Text = parentForm.TextFile;
        public EditForm(Form1 parent) : this()
        {
            parentForm = parent;
            UpdateText();
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void btnSave_Click(object sender, EventArgs e)
        {
            parentForm.TextFile = txtBoxTextEdit.Text;
            parentForm.UpdateText();
        }
    }
}
