using FileBooter.Models;
using MahApps.Metro.Controls;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FileBooter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public Settings Settings { get => Settings.GetInstance(); }
        public ObservableCollection<DownloadFile> Files { get; set; } = new ObservableCollection<DownloadFile>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            var testFile1 = new DownloadFile() { URI = @"http://x.kinovasek.space/0004d00fb75027024efd86269dfa0be9:2019112214/movies/a1/Angely_Charli_2019_ts_dubteatre_320-kinovasek.net.mp4" };
            var testFile2 = new DownloadFile() { URI = @"http://x.kinovasek.space/d2b79e85dba4292c85da2cb2052a1dd9:2019112214/movies/ay/Sinyaya_ptica_v_moem_serdce_2018_webripmvo_320-kinovasek.net.mp4" };
            var testFile3 = new DownloadFile() { URI = @"https://st1.z1.fm/music/2/a2/blink_182_-_first_date_(zvukoff.ru).mp3" };
            Files.Add(testFile3);
            Files.Add(testFile1);
            Files.Add(testFile2);
            var dg = dgDFiles;
        }
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var df = btn.DataContext as DownloadFile;

            if (df.State is RunningState)
                df.Pause();
        }
        private void StartResume_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var df = btn.DataContext as DownloadFile;

            if (df.State is PausedState)
                df.Resume();
            else
            {
                if (!File.Exists(Path.Combine(df.PathToSave, df.FileName)))
                    df.Start();
                else MessageBox.Show("Файл уже скачан.", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var df = btn.DataContext as DownloadFile;

            df.Stop();
        }
        private void SettingsApply(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var st = btn.DataContext as Settings;

            Settings.Apply(st);

            fcSettings.IsOpen = false;
        }
        private void OpenCloseSettings(object sender, RoutedEventArgs e)
        {
            fcSettings.IsOpen = true;

            fcSettings.DataContext = Settings.GetCopy();
        }
        private void AddFile(object sender, RoutedEventArgs e)
        {
            var df = fcAdd.DataContext as DownloadFile;

            try
            {
                Files.Add(df);

                if (Settings.IsStartDownloadingAfterAdding)
                    df.Start();

                fcAdd.IsOpen = false;
                fcAdd.DataContext = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Не верный формат ссылки или ссылка удалена.", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void OpenCloseAddFile(object sender, RoutedEventArgs e)
        {
            fcAdd.IsOpen = true;
            fcAdd.DataContext = new DownloadFile();
        }
        private void DelFile_Click(object sender, RoutedEventArgs e)
        {
            var mi = sender as MenuItem;
            var df = mi.DataContext as DownloadFile;

            Files.Remove(df);
        }
        private void MoveFile_Click(object sender, RoutedEventArgs e)
        {
            var mi = sender as MenuItem;
            var df = mi.DataContext as DownloadFile;
            var fbd = new System.Windows.Forms.FolderBrowserDialog();

            if (df.State is RunningState || df.State is PausedState)
            {
                MessageBox.Show("Сперва остановите загрузку этого файла.", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (CheckOnWritePermission(fbd.SelectedPath))
                    {
                        df.PathToSave = Path.Combine(fbd.SelectedPath, df.FileName);
                    }
                    else MessageBox.Show("Не возможно сохранить в этой дирректории т.к. в ней нет прав на запись.", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        private void OpenCloseRenameFile(object sender, RoutedEventArgs e)
        {
            var mi = sender as MenuItem;
            var df = mi.DataContext as DownloadFile;

            fcRename.IsOpen = true;

            tbNewName.Text = Path.GetFileNameWithoutExtension(df.FileName);
        }
        private void RenameFile(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var df = btn.DataContext as DownloadFile;

            if (df.State is RunningState || df.State is PausedState)
                MessageBox.Show("Сперва остановите загрузку этого файла.", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                fcRename.IsOpen = false;
                df.FileName = tbNewName.Text;
                tbNewName.Text = "";
            }
        }
        private bool CheckOnWritePermission(string path)
        {
            try
            {
                System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(path);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }
    }
}
