using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task4
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int clickDownX, clickDownY;
        public Form1()
        {
            InitializeComponent();

            this.MouseMove += Form1_MouseEvent;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e) { clickDownX = e.X; clickDownY = e.Y; }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (clickDownX + e.X < 10 || clickDownY + e.Y < 10)
                MessageBox.Show("Минимальный размер прямоугольника 10х10.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int r = random.Next(255);
                int g = random.Next(255);
                int b = random.Next(255);

                Label square = new Label();
                int Width = Math.Abs(clickDownX - e.X);
                int Height = Math.Abs(clickDownY - e.Y);

                square.Text = "";
                square.Top = clickDownY;
                square.Left = clickDownX;
                square.BackColor = Color.FromArgb(r, g, b);
                square.Size = new Size(Width, Height);
                square.Tag = DateTime.Now;

                Controls.Add(square);
            }
        }
        private void Form1_MouseEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Text = "Naz";
                if (e.Button == MouseButtons.None)
                    Text = "Nena";
            }
        }
    }
}
