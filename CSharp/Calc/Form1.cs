using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Calc : Form
    {
        StringBuilder history = new StringBuilder();
        StringBuilder input = new StringBuilder();
        StringBuilder action = new StringBuilder();
        double? fNum, sNum;
        public Calc()
        {
            InitializeComponent();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
 
            input.Append(button.Text);
            txtBoxInput.Text = input.ToString();
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            input.Clear();
            txtBoxInput.Text = input.ToString();
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            input.Remove(input.Length - 1, 1);
            txtBoxInput.Text = input.ToString();
        }

        private void btnAllCls_Click(object sender, EventArgs e)
        {
            input.Clear();
            history.Clear();
            action.Clear();
            fNum = sNum = null;
            txtBoxInput.Text = input.ToString();
            lblHistory.Text = history.ToString();
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (input.Length > 0 && !input.ToString().Contains("."))
            {
                input.Append(btnPoint.Text);
                txtBoxInput.Text = input.ToString();
            }
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            if (fNum != null && sNum == null)
            {
                sNum = Convert.ToDouble(input.ToString());
                history.Append(sNum + " ");
                lblHistory.Text = history.ToString();
            }

            if (fNum != null && sNum != null)
            {
                double? answer = 0;
                switch (action.ToString())
                {
                    case "+":
                        answer = fNum + sNum;
                        break;
                    case "-":
                        answer = fNum - sNum;
                        break;
                    case "*":
                        answer = fNum * sNum;
                        break;
                    case "/":
                        if (sNum != 0) answer = fNum / sNum;
                        break;
                }
                fNum = sNum = null;
                input.Clear();
                input.Append(answer);
                txtBoxInput.Text = input.ToString();
                history.Append("\n");
            }
        }

        private void txtBoxInput_TextChanged(object sender, EventArgs e)
        {
            //На случай, если хочеться ввести текст вместо цифр
            txtBoxInput.Text = Regex.Replace(txtBoxInput.Text, @"[^0-9-]", "");
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            //Если поле ввода не пустое
            if (input.Length > 0)
            {
                //Если в конце строки точка убрать её
                if(input.ToString().Last() == '.') input.Remove(input.Length - 1, 1);

                if (fNum == null) fNum = Convert.ToDouble(input.ToString());
                else sNum = Convert.ToDouble(input.ToString());

                action.Clear();
                action.Append(button.Text);
                history.Append(input + " " + action + " ");
                input.Clear();
                txtBoxInput.Text = "";
                lblHistory.Text = history.ToString();
            }
        }
    }
}
