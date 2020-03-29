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
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для UserNameDialog.xaml
    /// </summary>
    public partial class UserNameDialog : Window
    {
        readonly char[] TRIM_SYMBOLS = { ' ', '\t' };
        public UserNameDialog()
        {
            InitializeComponent();
        }
        private void btnAcceptName_Click(object sender, RoutedEventArgs e)
        {
            var enterName = tbUserName.Text.Trim(TRIM_SYMBOLS);
            if (enterName != "")
            {
                MainWindow.UserName = enterName;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Введите имя пользователя", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
