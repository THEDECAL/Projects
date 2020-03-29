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
            
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                clickDownX = e.X; clickDownY = e.Y;
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            int Width = Math.Abs(clickDownX - e.X);
            int Height = Math.Abs(clickDownY - e.Y);

            if (e.Button == MouseButtons.Left)
            {
                if (Width < 10 || Height < 10)
                    MessageBox.Show("Минимальный размер прямоугольника 10х10.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    int r = random.Next(255);
                    int g = random.Next(255);
                    int b = random.Next(255);

                    Label square = new Label()
                    {
                        Text = "",
                        Top = clickDownY,
                        Left = clickDownX,
                        BackColor = Color.FromArgb(r, g, b),
                        Size = new Size(Width, Height)
                    };
                    square.MouseDown += Form1_LabelMouseClick;
                    square.MouseDoubleClick += Form1_LabelMouseDoubleClick;

                    Controls.Add(square);
                }
            }
        }
        private void Form1_LabelMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Label lbl = sender as Label;
                StringBuilder sb = new StringBuilder();

                Point[] coordinates = new Point[]
                {
                        new Point() { X = lbl.Top, Y = lbl.Left},
                        new Point() { X = lbl.Top + lbl.Width, Y = lbl.Left},
                        new Point() { X = lbl.Top, Y = lbl.Left + lbl.Height},
                        new Point() { X = lbl.Top + lbl.Width, Y = lbl.Left + lbl.Height}
                };

                sb.Append($"Площадь: {lbl.Width + lbl.Height}. Координаты: ");
                for (int i = 0; i < coordinates.Length; i++)
                    sb.Append($"{coordinates[i].ToString()}");

                Text = sb.ToString();
            }
        }
        private void Form1_LabelMouseDoubleClick(object s, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Controls[Controls.IndexOf(s as Label)]?.Dispose();
        }
    }
}
