using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
using System.Runtime.Serialization.Formatters.Binary;

namespace WPFPhoneBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        readonly string dbFileName = "PhoneBook.dat";
        public MainWindow()
        {
            InitializeComponent();
            Deserialize();
            Closing += (s, e) =>
            {
                lbPeoples.Items.Filter = (o) => { return true; };
                Serialize();
            };
            cbSearchTypes.SelectionChanged += (s,e) => { TboxSearch_TextChanged(null, null); };
            DataContext = this;
        }
        private void btnAdd_Click(object s, RoutedEventArgs e)
        {
            People People = new People();
            lbPeoples.Items.Add(People);
            Button btn = new Button();
            btn.DataContext = People;
            btnEdit_Click(btn, null);
        }
        private void btnInfo_Click(object s, RoutedEventArgs e)
        {
            Button btn = s as Button;
            var People = btn.DataContext as People;
            fInfo.IsOpen = !fInfo.IsOpen;

            gInfo.DataContext = People;
        }
        private void btnEdit_Click(object s, RoutedEventArgs e)
        {
            TextBoxReadOnlySwitcher(false);
            btnImage.Click += ImageSourceSet;
            btnInfo_Click(s, e);
        }
        private void btnDelete_Click(object s, RoutedEventArgs e)
        {
            Button btn = s as Button;
            var People = btn.DataContext as People;
            lbPeoples.Items.Remove(People);
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
        private void ImageSourceSet(object s, RoutedEventArgs e)
        {
            Button btn = s as Button;
            gImageInsert.DataContext = btn.DataContext;
            fImageInsert.IsOpen = true;
        }
        private void FInfo_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            if (!fInfo.IsOpen)
            {
                TextBoxReadOnlySwitcher(true);
                btnImage.Click -= ImageSourceSet;
                fImageInsert.IsOpen = false;
            }
        }
        private void TboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tboxSearch.Text.Length > 2)
            {
                string searchType = (cbSearchTypes.SelectedItem as TextBlock).Tag as string;
                Type t = typeof(People);
                var prop = t.GetProperty(searchType);
                
                lbPeoples.Items.Filter = (o) =>
                {
                    var text = prop.GetValue(o).ToString().ToLower();
                    return text.Contains(tboxSearch.Text.ToLower());
                };
            }
            else lbPeoples.Items.Filter = (o) => { return true; };
        }
        private void BtnHideImageInsert_Click(object sender, RoutedEventArgs e) => fImageInsert.IsOpen = false;
        private void Serialize()
        {
            var list = lbPeoples.Items.Cast<People>().ToList();
            using (FileStream fs = new FileStream(dbFileName, (File.Exists(dbFileName) ? FileMode.Truncate : FileMode.Create), FileAccess.Write))
            {
                new BinaryFormatter().Serialize(fs, list);
            }
        }
        private void Deserialize()
        {
            var list = new List<People>();
            if (File.Exists(dbFileName))
            {
                using (FileStream fs = new FileStream(dbFileName, FileMode.Open, FileAccess.Read))
                {
                    list = new BinaryFormatter().Deserialize(fs) as List<People>;
                }
                list.ForEach(o => lbPeoples.Items.Add(o));
            }
        }
    }
}
