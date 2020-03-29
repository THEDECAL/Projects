using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task2
{
    partial class Form1 : Form
    {
        Stock stockForm;
        public List<Product> stock { get; set; } = new List<Product>() { new Product() };
        List<Product> cart = new List<Product>();
        public Form1()
        {
            InitializeComponent();

            //Добавление тестовых товаров
            stock.Add(new Product { Name = "Kingston KVR26S", Specification = "8 Гб", Description = "RAM SODIMM", Price = 20.22 });
            stock.Add(new Product { Name = "Samsung 860 Evo", Specification = "250 Гб", Description = "SSD TLC", Price = 50.22 });
            stock.Add(new Product { Name = "Intel Core i7-8700", Specification = "3.2ГГц", Description = "CPU s1151", Price = 20.22 });

            txtBoxSum.Text = "0.0$";
            UpdateStock();
        }
        private void UpdateStock() => cmbBoxSelect.DataSource = stock.ToArray();
        private void UpdateCart() => lstBoxCart.DataSource = cart.ToArray();
        private void UpdatePrice() => txtBoxSum.Text = cart.Sum(o => o.Price).ToString() + '$';

        private void btnStock_Click(object sender, EventArgs e)
        {
            if (stockForm != null) stockForm.Close();
            stockForm = new Stock(this);
            stockForm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbBoxSelect.SelectedIndex > 0)
            {
                cart.Add(cmbBoxSelect.SelectedItem as Product);
                UpdateCart();
                UpdatePrice();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstBoxCart.SelectedIndex != -1)
            {
                cart.RemoveAt(lstBoxCart.SelectedIndex);
                UpdateCart();
                UpdatePrice();
            }
        }

        private void cmbBoxSelect_DropDown(object sender, EventArgs e) => UpdateStock();

        private void cmbBoxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxSelect.SelectedIndex > 0)
            {
                Product p = cmbBoxSelect.SelectedItem as Product;
                txtBoxPrice.Text = p.Price.ToString() + '$';
                txtBoxDesc.Text = p.Description;
            }
            else
            {
                txtBoxPrice.Text = "";
                txtBoxDesc.Text = "";
            }
        }
    }
}
