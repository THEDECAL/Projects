using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static practice.SQLClientSingleton;

namespace practice
{
    public partial class Form1 : Form
    {
        string userName;
        int amMessages;
        Timer timer;
        List<string> messages = new List<string>();
        public Form1()
        {
            InitializeComponent();
            UpdateAmountMessages();

            timer = new Timer { Interval = 2000 };
            timer.Tick += (s, e) => UpdateMessages();
        }
        ~Form1()
        {
            timer.Stop();
        }
        private void UpdateAmountMessages() => amMessages = SQLConn.GetAmountMessages();
        private void UpdateMessages()
        {
            int oldAmMessages = amMessages;
            UpdateAmountMessages();
            int newAmMessages = amMessages - oldAmMessages;
            if (newAmMessages > 0)
            {
                messages.AddRange(SQLConn.GetMessages(newAmMessages));
                txtBoxChat.Lines = messages.ToArray();
            }
        }
        private void btnName_Click(object sender, EventArgs e)
        {
            if (txtBoxName.Text != "")
            {
                timer.Start();
                userName = txtBoxName.Text;
                txtBoxName.Enabled = false;
                btnName.Enabled = false;
                txtBoxChat.Enabled = true;
                txtBoxInput.Enabled = true;
                btnSend.Enabled = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtBoxInput.Text != "")
            {
                SQLConn.AddMessage(userName,txtBoxInput.Text);
                UpdateMessages();
                txtBoxInput.Text = "";
            }
        }
        
        private void txtBoxInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSend_Click(null, null);
        }
    }
}
