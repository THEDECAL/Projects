using System;
using System.Windows.Forms;

namespace BookShop
{
    partial class LogInOutForm : Form
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
                Form1.Msg(Form1.MsgType.ERR_LOGIN, MessageBoxIcon.Warning);
            else Close();
        }
    }
}
