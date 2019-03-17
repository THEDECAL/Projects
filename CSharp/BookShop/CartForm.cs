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
    partial class CartForm : Form
    {
        public CartForm()
        {
            InitializeComponent();

            MaximumSize = Size;
            MinimumSize = Size;
            InitListBox();
            UpdateAllPrice();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            Form1.ListBooks.Clear();
            Close();
        }
        private void UpdateAllPrice() => lbAllPrice.Text = Form1.ListBooks.Sum(b => b.Price).ToString() + "грн.";
        private void InitListBox() => lstbBooks.DataSource = Form1.ListBooks.ToArray();

        private void lstbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstbBooks.SelectedIndex != -1)
            {
                Book b = lstbBooks.SelectedItem as Book;
                bcInfo.Init(b);
            }
        }
    }
}
