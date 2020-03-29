using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task5
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            button2.MouseEnter += Form1_MouseEnter;
        }
        private void Form1_MouseEnter(object s, EventArgs e)
        {
            for (;;)
            {
                int x = rnd.Next(Width - button2.Width);
                int y = rnd.Next(Height - button2.Height);

                if (x != button2.Location.X && y != button2.Location.Y)
                {
                    button2.Location = new Point{ X = x, Y = y };
                    break;
                }
            }
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
