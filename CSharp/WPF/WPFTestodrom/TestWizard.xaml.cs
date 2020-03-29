using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;

namespace WPFTestodrom
{
    /// <summary>
    /// Логика взаимодействия для TestWizard.xaml
    /// </summary>
    public partial class TestWizard : MetroWindow
    {
        public Test Test { get; private set; }

        private TestWizard()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            DataContext = this;
        }
        public TestWizard(Test test) : this()
        {
            Test = test;
        }

        private void EditSwitcher(bool @switch)
        {
            tbQName.IsEnabled = @switch;
            chbA1.IsEnabled = @switch;
            chbA2.IsEnabled = @switch;
            chbA3.IsEnabled = @switch;
            chbA4.IsEnabled = @switch;
            tbA1.IsEnabled = @switch;
            tbA2.IsEnabled = @switch;
            tbA3.IsEnabled = @switch;
            tbA4.IsEnabled = @switch;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Test.Questions.Add(new Question());
            lbQuestions.SelectedIndex = Test.Questions.Count - 1;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbQuestions.SelectedIndex != -1)
            {
                Test.Questions.RemoveAt(lbQuestions.SelectedIndex);
            }
        }

        private void lbQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbQuestions.SelectedIndex != -1) EditSwitcher(true);
            else EditSwitcher(false);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Test.IsEmpty()) MessageBox.Show("", "Не все поля заполнены или нет вопросов.", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                DialogResult = true;
                this.Close();
            }
        }
    }
}
