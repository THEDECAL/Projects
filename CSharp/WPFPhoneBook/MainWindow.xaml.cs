using MahApps.Metro.Controls;
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
using System.IO;

namespace WPFPhoneBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        enum mode { SHOW, EDIT, ADD };
        mode currMode = mode.SHOW;
        public MainWindow()
        {

            InitializeComponent();
            InitPhoneBookList();
            DataContext = this;
        }

        private void btnAdd_Click(object s, RoutedEventArgs e)
        {
            currMode = mode.ADD;
            lbPeoples.Items.Add(new People());
        }
        private void btnInfo_Click(object s, RoutedEventArgs e)
        {
            Button btn = s as Button;
            var People = btn.DataContext as People;
            fInfo.IsOpen = !fInfo.IsOpen;

            var uri = new Uri(People.PathToImage);
            iImage.Source = BitmapFrame.Create(uri);
            tboxFName.Text = People.FName;
            tboxSName.Text = People.SName;
            tboxPName.Text = People.PName;
            tboxPhoneNumber.Text = People.PhoneNumber;
            tboxEmail.Text = People.Email;
            tboxBirth.Text = People.Birth.ToShortDateString();
        }
        private void TextBoxReadOnlySwitcher(bool value)
        {
            tboxFName.IsReadOnly = value;
            tboxSName.IsReadOnly = value;
            tboxPName.IsReadOnly = value;
            tboxPhoneNumber.IsReadOnly = value;
            tboxEmail.IsReadOnly = value;
            tboxBirth.IsReadOnly = value;
        }
        private void btnEdit_Click(object s, RoutedEventArgs e)
        {
            currMode = mode.EDIT;
            TextBoxReadOnlySwitcher(false);

            
        }
        private void btnDelete_Click(object s, RoutedEventArgs e)
        {
            Button btn = s as Button;
            var People = btn.DataContext as People;
            lbPeoples.Items.Remove(People);
        }
        private void InitPhoneBookList()
        {
            lbPeoples.Items.Add(new People
            {
                FName = "Игорь",
                SName = "Прокофьев",
                PName = "Иванович",
                Birth = new DateTime(1990, 10, 2),
                Email = "www@www.www",
                PhoneNumber = "+380991230981",
                PathToImage = "https://cdn130.picsart.com/285935885003201.jpg?c256x256"
            });
            lbPeoples.Items.Add(new People
            {
                FName = "Никита",
                SName = "Звегинцев",
                PName = "Юрьевич",
                Birth = new DateTime(1990, 8, 23),
                Email = "thedecal1@gmail.com",
                PhoneNumber = "+380992993734",
                PathToImage = "https://scontent.fiev15-1.fna.fbcdn.net/v/t1.0-1/p160x160/44032498_718402521850990_7366167004845178880_n.jpg?_nc_cat=100&_nc_ht=scontent.fiev15-1.fna&oh=61b84b01d5fa47156a458f9f831b53f0&oe=5D041E18"
            });
        }

        private void FInfo_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            if (!fInfo.IsOpen)
            {
                if (currMode == mode.ADD)
                {
                }
                else if (currMode == mode.EDIT)
                {
                }
            }

            TextBoxReadOnlySwitcher(true);
            currMode = mode.SHOW;
        }
    }
}
