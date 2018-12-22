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

namespace Autorization
{
    public partial class AutorizationForm : Form
    {
        List<string> logins;
        public AutorizationForm()
        {
            logins = new List<string>();
            InitializeComponent();
            LoadLogins();
        }
        void LoadLogins()
        {
            logins = File.ReadAllLines("../../logins.txt").ToList();
        }
        bool CheckLoginAndPassword(string login, string password)
        {
            string loginAndPassword = logins.Find(line => line == (login + ' ' + password));
            return (loginAndPassword != null) ? true : false;
        }
        private void ClickEnterButton(object sender, EventArgs e)
        {
            MessageBox.Show($"{(CheckLoginAndPassword(LoginTextBox.Text,PasswordTextBox.Text) ? "Добро пожаловать." : "Ошибка авторизации.") }", this.Name, MessageBoxButtons.OK);
        }

        private void PasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13) MessageBox.Show($"{(CheckLoginAndPassword(LoginTextBox.Text, PasswordTextBox.Text) ? "Добро пожаловать." : "Ошибка авторизации.") }", this.Name, MessageBoxButtons.OK);
        }
    }
}
