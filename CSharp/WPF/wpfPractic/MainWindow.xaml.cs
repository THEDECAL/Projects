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

namespace wpfPractic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public People People { get; set; } = new People();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            People.Gender = (cbGender.SelectedItem as ComboBoxItem).Content as string;
            People.Want = (cbWant.SelectedItem as ComboBoxItem).Content as string;

            lbPeoples.Items.Add(People.Clone());
            People.Clear();
            ClearTextBoxes();
        }
        private void ClearTextBoxes()
        {
            tboxName.Text = "";
            tboxEmail.Text = "";
            tboxPhone.Text = "";
        }
    }
}
