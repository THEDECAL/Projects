using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
            MaximumSize = Size;
            MinimumSize = Size;
        }

        private void btnRegIn_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text != "" && tbPasswordFirst.Text != "" && tbName.Text != "" && !SQLDbConntext.CheckLogin(tbLogin.Text))
            {
                if (tbPasswordFirst.Text != tbPasswordSecond.Text) Form1.Msg(Form1.MsgType.ERR_PASSWORD, MessageBoxIcon.Warning);
                else
                {
                    Account a = new Account
                    {
                        Login = tbLogin.Text,
                        Password = tbPasswordFirst.Text,
                        User = new User
                        {
                            Name = tbName.Text,
                            UserType = SQLDbConntext.DbContext.UserTypes.FirstOrDefault(u => u.Name == "User")
                        }
                    };

                    SQLDbConntext.DbContext.Accounts.Add(a);
                    SQLDbConntext.DbContext.SaveChanges();
                    Close();
                }
            }
            else Form1.Msg(Form1.MsgType.ERR_UNIQ_LOGIN, MessageBoxIcon.Warning);
        }
    }
}
