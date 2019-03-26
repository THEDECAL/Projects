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
        public List<People> PhoneBook { get; set; } = new List<People>();
        //public People CurrentPeople { get; set; } = new People();
        public MainWindow()
        {

            InitializeComponent();
            InitPhoneBookList();
            DataContext = this;
        }

        private void btnAdd_Click(object s, RoutedEventArgs e)
        {
            MainGridShowSwitcher();
        }
        private void MainGridShowSwitcher() => gMain.Visibility = (gMain.Visibility == Visibility.Hidden) ? Visibility.Visible : Visibility.Hidden;
        private void btnInfo_Click(object s, RoutedEventArgs e)
        {
            Button btn = s as Button;
            //CurrentPeople.CopyPropertyValues(btn.DataContext as People);
            var People = btn.DataContext as People;
            var uri = new Uri(People.PathToImage);
            iImage.Source = BitmapFrame.Create(uri);

            MainGridShowSwitcher();
            gInfo.Visibility = Visibility.Visible;
        }
        private void InitPhoneBookList()
        {
            PhoneBook.Add(new People
            {
                FName = "Игорь",
                SName = "Прокофьев",
                PName = "Иванович",
                Birth = new DateTime(1990, 10, 2),
                Email = "www@www.www",
                PhoneNumber = "+380991230981",
                PathToImage = "https://cdn130.picsart.com/285935885003201.jpg?c256x256"
            });
            PhoneBook.Add(new People
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
    }
}
