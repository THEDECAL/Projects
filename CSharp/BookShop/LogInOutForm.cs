using System;
using System.Windows.Forms;

namespace BookShop
{
    public partial class LogInOutForm : Form
    {
        Form1 parent;
        private LogInOutForm()
        {
            InitializeComponent();
            MinimumSize = Size;
            MaximumSize = Size;
        }
        public LogInOutForm(Form1 parent) : this()
        {
            this.parent = parent;
        }


        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (!parent.CheckAccount(tbLogin.Text, tbPassword.Text))
                MessageBox.Show("Неверный логин или пароль.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else Close();
        }
    }
}
