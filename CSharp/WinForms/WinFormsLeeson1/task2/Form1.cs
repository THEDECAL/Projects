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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Hide();

            string title = "Загадай число";
            Random random = new Random();

            bool isEnd = false;
            while(!isEnd)
            {
                MessageBox.Show($"{title} от 1 до 2000.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                List<int> assNumbers = new List<int>(); //Предпологаемые числа
                int num = random.Next(1, 2001);
                assNumbers.Add(num);

                for (;;)
                {
                    DialogResult result;
                    result = MessageBox.Show($"Вы загадали {num}?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string text = $"Поздравьте компьютер он отгадал ваше число за {assNumbers.Count + 1} попыток.\nСыграть снова?";
                        result = MessageBox.Show(text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.No) isEnd = true;
                        break;
                    }
                    else
                    {
                        for (;;)
                        {
                            num = random.Next(1, 2001);
                            if (!assNumbers.Exists(n => n == num))
                            {
                                assNumbers.Add(num);
                                break;
                            }
                        }
                    }
                }
            }

            this.Close();
        }
    }
}
