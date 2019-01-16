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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.MouseMove += Form1_MouseEvent;
            this.MouseClick += Form1_MouseEvent;
        }
        private void Form1_MouseEvent(object sender, MouseEventArgs e)
        {
            Text = $"X{e.X.ToString()}:Y{e.Y.ToString()}";

            if (e.Button == MouseButtons.Left)
            {
                if (Control.ModifierKeys == Keys.Control) this.Close();

                string position = "";
                int topBorder = 9, bottomBorder = ClientSize.Height - 19;
                int leftBorder = 9, rightBorder = ClientSize.Width - 19;

                if (e.X == leftBorder || e.X == rightBorder || e.Y == topBorder || e.Y == bottomBorder)
                    position = "Курсор на границе прямоугольника";
                else if (e.X < leftBorder || e.X > rightBorder || e.Y < topBorder || e.Y > bottomBorder)
                    position = "Курсор снаружи прямоугольника";
                else if (e.X > leftBorder || e.X < rightBorder || e.Y > topBorder || e.Y < bottomBorder)
                    position = "Курсор внутри прямоугольника";

                MessageBox.Show(position, "Нажата левая кнопка мыши", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (e.Button == MouseButtons.Right)
                Text += $" W{ClientSize.Width}:H{ClientSize.Height}";
        }
    }
}
