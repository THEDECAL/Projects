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
    partial class Stock : Form
    {
        Form1 parentForm;
        private Stock()
        {
            InitializeComponent();
        }
        public Stock(Form1 parent) : this()
        {
            parentForm = parent;
            UpdateStock();
            lstBoxStock.SetSelected(0, true);
        }
        private void UpdateStock() => lstBoxStock.DataSource = parentForm.stock.ToArray();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            double price = 0.0;

            if (txtBoxName.Text == "")
            {
                MessageBox.Show("Поле название пусто, заполните его.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtBoxSpec.Text == "")
            {
                MessageBox.Show("Поле характеристики пусто, заполните его.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtBoxPrice.Text == "")
            {
                MessageBox.Show("Поле цена пусто, заполните его.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try { price = Convert.ToDouble(txtBoxPrice.Text.Replace('.',',')); }
            catch (Exception) { MessageBox.Show("Недопустимый формат цены.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (lstBoxStock.SelectedIndex == 0)
                parentForm.stock.Add(new Product { Name = txtBoxName.Text, Specification = txtBoxSpec.Text, Description = txtBoxDesc.Text, Price = price });
            else
            {
                Product p = parentForm.stock[lstBoxStock.SelectedIndex];
                p.Name = txtBoxName.Text;
                p.Specification = txtBoxSpec.Text;
                p.Description = txtBoxDesc.Text;
                p.Price = price; 
            }
            
            UpdateStock();
            lstBoxStock.SetSelected(0, true);
            txtBoxName.Text = ""; txtBoxSpec.Text = ""; txtBoxDesc.Text = ""; txtBoxPrice.Text = "";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstBoxStock.SelectedIndex > 0)
            {
                parentForm.stock.RemoveAt(lstBoxStock.SelectedIndex);
                UpdateStock();
            }
        }

        private void lstBoxStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lstBoxStock.SelectedIndex > 0)
            //{
                Product p = parentForm.stock[lstBoxStock.SelectedIndex];
                txtBoxName.Text = p.Name;
                txtBoxSpec.Text = p.Specification;
                txtBoxDesc.Text = p.Description;
                txtBoxPrice.Text = p.Price.ToString();
            //}
        }
    }
}
