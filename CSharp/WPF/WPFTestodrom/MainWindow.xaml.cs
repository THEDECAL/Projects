using System;
using System.Windows;
using MahApps.Metro.Controls;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Controls;

namespace WPFTestodrom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        readonly static string dbFileName = "Tests.dat";
        public ObservableCollection<Test> Tests { get; private set; } = Deserialize();

        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            DataContext = this;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Test test = new Test();
            TestWizard tw = new TestWizard(test);
            if (tw.ShowDialog() == true)
            {
                Tests.Add(test);
                Serialize();
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbTests.SelectedIndex != -1)
            {
                Tests.RemoveAt(lbTests.SelectedIndex);
                Serialize();
            }
        }

        private void lbTests_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left && lbTests.SelectedIndex != -1)
            {
                var selectedTest = lbTests.SelectedItem as Test;
                var copyTest = new Test();
                copyTest.Copy(selectedTest);

                TestWizard tw = new TestWizard(copyTest);
                if (tw.ShowDialog() == true)
                {
                    selectedTest.Copy(copyTest);
                    Serialize();
                }
                lbTests_SelectionChanged(null, null);
            }
        }

        private void lbTests_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lbTests.SelectedIndex != -1)
            {
                var selectedTest = lbTests.SelectedItem as Test;
                fdTest.Blocks.Clear();

                var prgphTitle = new Paragraph();
                prgphTitle.Inlines.Add(new Bold(new Run() { Text = selectedTest.Name, FontSize = 20 }));
                prgphTitle.Inlines.Add(new LineBreak());
                prgphTitle.Inlines.Add(new Bold(new Run() { Text = selectedTest.Theme, FontSize = 18, Foreground = Brushes.Olive }));
                prgphTitle.Inlines.Add(new LineBreak());

                fdTest.Blocks.Add(prgphTitle);

                foreach (var question in selectedTest.Questions)
                {
                    var prgphQuestion = new Paragraph();
                    prgphQuestion.Inlines.Add(new Run() { Text = question.Name, FontSize = 18 });
                    fdTest.Blocks.Add(prgphQuestion);

                    var lstAnswers = new List();
                    foreach (var answer in question.Answers)
                    {
                        var variant = new ListItem()
                        {
                            Blocks =
                            {
                                new BlockUIContainer()
                                {
                                    Child = new StackPanel()
                                    {
                                        Orientation = Orientation.Horizontal,
                                        Children =
                                        {
                                            new CheckBox() { IsChecked = answer.isCorrect },
                                            new TextBlock() { Text = answer.Name }
                                        }
                                    }
                                }
                            }
                        };

                        lstAnswers.ListItems.Add(variant);
                    }

                    fdTest.Blocks.Add(lstAnswers);
                }
            }
            else fdTest.Blocks.Clear();
        }

        public void Serialize()
        {
            using (FileStream fs = new FileStream(dbFileName, (File.Exists(dbFileName) ? FileMode.Truncate : FileMode.Create), FileAccess.Write))
            {
                new BinaryFormatter().Serialize(fs, Tests);
            }
        }

        private static ObservableCollection<Test> Deserialize()
        {
            if (File.Exists(dbFileName))
            {
                using (FileStream fs = new FileStream(dbFileName, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        return new BinaryFormatter().Deserialize(fs) as ObservableCollection<Test>;
                    }
                    catch (Exception) { }
                }
            }
            return new ObservableCollection<Test>();
        }
    }
}
