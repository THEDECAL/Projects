using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFCalc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string action = "";
        double? prevDigit;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DigitButton(object s, EventArgs e)
        {
            Button btn = s as Button;
            TextBlock tblck = btn.Content as TextBlock;

            tblckInput.Text += tblck.Text;
        }
        private void CommaButton(object s, EventArgs e)
        {
            if (tblckInput.Text != "")
            {
                tblckInput.Text = tblckInput.Text.Replace(",", "");
                tblckInput.Text += ",";
            }
        }
        private void CEButton(object s, EventArgs e) => tblckInput.Text = "";
        private void CButton(object s, EventArgs e)
        {
            tblckInput.Text = "";
            tblckHistory.Text = "";
        }
        private void BackSpaceButton(object s, EventArgs e)
        {
            if (tblckInput.Text != "")
            {
                tblckInput.Text = tblckInput.Text.Remove(tblckInput.Text.Length - 1);
            }
        }
        private void PlusMinusButton(object s, EventArgs e)
        {
            if (tblckInput.Text != "")
            {
                if (tblckInput.Text[0] == '-')
                    tblckInput.Text = tblckInput.Text.Remove(0, 1);
                else
                    tblckInput.Text = tblckInput.Text.Insert(0, "-");
            }
        }
        private void ActionButton(object s, EventArgs e)
        {
            Button btn = s as Button;
            TextBlock tblck = btn.Content as TextBlock;

            if (tblckInput.Text != "")
            {
                action = tblck.Text;
                if (tblckHistory.Text == "") tblckHistory.Text = tblckInput.Text + " ";
                tblckHistory.Text += action + " ";
                prevDigit = Convert.ToDouble(tblckInput.Text);
                tblckInput.Text = "";
            }
        }
        private void AnswerButton(object s, EventArgs e)
        {
            if (action != "" && tblckInput.Text != "" && prevDigit != null)
            {
                double answer = 0;
                double currDigit = Convert.ToDouble(tblckInput.Text);

                switch (action)
                {
                    case "+": answer = (double)prevDigit + currDigit; break;
                    case "-": answer = (double)prevDigit - currDigit; break;
                    case "*": answer = (double)prevDigit * currDigit; break;
                    case "/": answer = (currDigit == 0) ? 0 : (double)prevDigit / currDigit; break;
                }

                action = "";
                tblckHistory.Text += tblckInput.Text + " ";
                tblckInput.Text = answer.ToString();
                prevDigit = Convert.ToDouble(tblckInput.Text);
            }
        }
    }
}
