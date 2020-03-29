using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadsExam
{
    public partial class Form1 : Form
    {
        const int MAX_SEARCH_THREADS = 200;
        //static Semaphore _searchSemafore = new Semaphore(MAX_SEARCH_THREADS, MAX_SEARCH_THREADS);
        bool _isPause = false;
        bool IsPause
        {
            get => _isPause;
            set
            {
                _isPause = value;
                btnPause.Invoke(new Action(() => btnPause.Text = (_isPause) ? "Возобновить" : "Приостановить"));
            }
        }
        const string FOLDER_NAME_TO_SAVE = "Saved Files";
        readonly char[] TRIM_SYMBOLS = { ' ', '\t' };
        readonly string[] FILE_EXT_FOR_SEARCH = { "cs", "txt"};
        //string pathToSaveContainsFile = Directory.GetCurrentDirectory();
        //string _pathToLog = "";
        Mutex _logMutex = new Mutex();
        static readonly List<Thread> _threadPool = new List<Thread>();
        static readonly Mutex _threadPoolMutex = new Mutex();
        public Form1()
        {
            InitializeComponent();

            tbCurrentPath.Text = Directory.GetCurrentDirectory();
            initDisks();
        }
        private void initDisks()
        {
            var listDisks = DriveInfo.GetDrives();

            lbDisks.Items.Clear();
            foreach (var item in listDisks)
            {
                lbDisks.Items.Add(item.Name);
                lbDisks.SelectedItem = item.Name;
            }
        }
        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Текстовые файлы (*.txt)|*.txt";
            ofd.InitialDirectory = tbCurrentPath.Text;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var fileName = ofd.FileName;
                var strings = File.ReadAllLines(fileName);

                if (strings.Count() > 0)
                {
                    foreach (var item in strings)
                    {
                        var word = item.Trim(TRIM_SYMBOLS);

                        if (word.Count() > 0)
                            lbWords.Items.Add(word);
                    }
                }
                else
                {
                    MessageBox.Show("Файл пустой.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnAddWord_Click(object sender, EventArgs e)
        {
            var word = tbWord.Text.Trim(TRIM_SYMBOLS);

            if (word.Count() > 0)
            {
                lbWords.Items.Add(word);
                tbWord.Text = "";
            }
        }
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var folderPath = fbd.SelectedPath;
                if(checkPermission(folderPath))
                    tbCurrentPath.Text = folderPath;
            }
        }
        /// <summary>
        /// 
        /// Проверка прав пути на создание и запись файлов
        /// </summary>
        /// <param name="path">Принимает путь для проверки</param>
        private bool checkPermission(string path)
        {
            try
            {
                var fileName = Guid.NewGuid().ToString();
                var pathToFile = $"{path}\\{ fileName}";

                using (var fs = File.Create(pathToFile)) { }
                File.WriteAllText(pathToFile, "Test On Write");
                File.Delete(pathToFile);

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("В указанном месте нет прав на создание и запись файлов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e) => initDisks();
        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.SelectedPath = tbCurrentPath.Text;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var folderPath = fbd.SelectedPath;
                if(checkPermission(folderPath))
                    lbFolders.Items.Add(folderPath);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (lbWords.Items.Count > 0)
            {
                if (lbDisks.SelectedItems.Count > 0 || lbFolders.Items.Count > 0)
                {
                    ClearResult();
                    LockUnlockButtons();

                    //Записываем путь для сохранения файлов во избежания использования метода Invoke
                    //pathToSaveContainsFile = tbCurrentPath.Text;

                    //Проверяем наличие папки для сохранения если нет, то создаём её
                    if(!Directory.Exists(tbCurrentPath.Text + @"\" + FOLDER_NAME_TO_SAVE))
                        Directory.CreateDirectory(tbCurrentPath.Text + @"\" + FOLDER_NAME_TO_SAVE);

                    //Делаем один массив из дисков и путей поиска
                    var allListToSearch = new List<string>();
                    foreach (var item in lbDisks.SelectedItems)
                        allListToSearch.Add(item.ToString());
                    foreach (var item in lbFolders.Items)
                        allListToSearch.Add(item.ToString());

                    pbProgress.BeginInvoke(new Action(() => pbProgress.Maximum = allListToSearch.Count + 1));
                    ChangeCounterOnLabel(lblViewFoldersCount, lbFolders.Items.Count);

                    //Запускаем потоки для поиска
                    foreach (var item in allListToSearch)
                    {
                        var searchThread = new Thread(new ThreadStart(() =>
                        {
                            var currSearchThread = Thread.CurrentThread;
                            AddThreadToPool(currSearchThread);

                            SearchFileAndFolders(item);

                            pbProgress.BeginInvoke(new Action(() => pbProgress.Value += 1));

                            DelThreadInPool(currSearchThread);
                        }));
                        searchThread.Name = $"searchThread_{item}";
                        searchThread.Start();
                    }
                }
                else MessageBox.Show("Не выбрано ни одного места для поиска.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Не добавлено ни одного слова для поиска.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// Поиск файлов и папок
        /// </summary>
        /// <param name="path"></param>
        private void SearchFileAndFolders(string path)
        {
            try
            {
                var directories = Directory.GetDirectories(path);
                List<string> files = new List<string>();

                foreach (var ext in FILE_EXT_FOR_SEARCH)
                    files.AddRange(Directory.GetFiles(path, $"*.{ext}"));

                foreach (var filePath in files)
                {
                    try
                    {
                        if (SearchAndSaveContains(filePath))
                            ChangeCounterOnLabel(lblFilesCount);
                    }
                    catch (UnauthorizedAccessException) { }
                }

                if (directories.Count() != 0)
                {
                    ChangeCounterOnLabel(lblViewFoldersCount, directories.Count());

                    foreach (var dirPath in directories)
                        SearchFileAndFolders(dirPath);

                    pbProgress.BeginInvoke(new Action(() =>
                    {
                        pbProgress.Maximum += directories.Count();
                        pbProgress.Value += directories.Count();
                    }));
                }
            }
            catch (UnauthorizedAccessException) { }
        }
        /// <summary>
        /// Поиск совпадений в файле
        /// </summary>
        /// <param name="files"></param>
        private bool SearchAndSaveContains(string filePath)
        {
            var fileText = File.ReadAllLines(filePath);
            var isContain = false;


            for (int i = 0; i < fileText.Count(); i++)
            {
                var str = fileText[i];
                foreach (var word in lbWords.Items)
                {
                    Regex reg = new Regex(@"\b" + word + @"\b", RegexOptions.Multiline);
                    if (reg.IsMatch(str))
                    {
                        fileText[i] = reg.Replace(str, "*******");
                        ChangeCounterOnLabel(lblFindCount);
                        isContain = true;
                    }
                }
            }

            if (isContain)
            {
                int numberFileContains = int.Parse(lblFilesCount.Text);
                var fileName = Path.GetFileName(filePath);
                string pathToSave = tbCurrentPath.Text;
                pathToSave += @"\" + FOLDER_NAME_TO_SAVE + @"\" + ++numberFileContains + '_' + fileName;

                File.WriteAllLines(pathToSave, fileText);
            }

            return isContain;
        }
        /// <summary>
        /// Добавляет поток в пул
        /// </summary>
        /// <param name="thread">Принимает объект потока</param>
        private void AddThreadToPool(Thread thread)
        {
            lock (_threadPoolMutex)
            {
                try
                {
                    _threadPoolMutex.WaitOne();
                    _threadPool.Add(thread);
                }
                catch (AbandonedMutexException) { }
                finally { _threadPoolMutex.ReleaseMutex(); }
            }
        }
        /// <summary>
        /// Удаляет поток из пула
        /// </summary>
        /// <param name="thread">Принимает объект потока</param>
        private void DelThreadInPool(Thread thread)
        {
            lock (_threadPoolMutex)
            {
                try
                {
                    _threadPoolMutex.WaitOne();
                    thread.Abort();
                    _threadPool.Remove(thread);
                }
                catch (AbandonedMutexException) { }
                finally { _threadPoolMutex.ReleaseMutex(); }
            }
        }
        /// <summary>
        /// Чистка результатов поиска
        /// </summary>
        private void ClearResult()
        {
            lbFindFiles.Items.Clear();
            lblFilesCount.Text = "0";
            lblFindCount.Text = "0";
            lblViewFoldersCount.Text = "0";
            pbProgress.Value = 0;
        }
        /// <summary>
        /// Блокировка и разблокировка кнопок во время выполнения поиска
        /// </summary>
        private void LockUnlockButtons()
        {
            btnSearch.Enabled = !btnSearch.Enabled;
            btnAddWord.Enabled = !btnAddWord.Enabled;
            btnRefresh.Enabled = !btnRefresh.Enabled;
            btnAddFolder.Enabled = !btnAddFolder.Enabled;
            btnOpenFileDialog.Enabled = !btnOpenFileDialog.Enabled;
            tbWord.Enabled = !tbWord.Enabled;
            btnSelectPath.Enabled = !btnSelectPath.Enabled;
            btnPause.Enabled = !btnPause.Enabled;
            btnStop.Enabled = !btnStop.Enabled;
            lbDisks.Enabled = !lbDisks.Enabled;
            lbWords.Enabled = !lbWords.Enabled;
            lbFolders.Enabled = !lbFolders.Enabled;
        }
        /// <summary>
        /// Остановка всех потоков из пула
        /// </summary>
        private void StopThreads()
        {
            lock (_threadPoolMutex)
            {
                try
                {
                    _threadPoolMutex.WaitOne();
                    foreach (var item in _threadPool)
                        if(item.ThreadState != (ThreadState.Suspended | ThreadState.AbortRequested))
                            item.Abort();
                    _threadPool.Clear();
                }
                catch (AbandonedMutexException) { }
                finally { _threadPoolMutex.ReleaseMutex(); }
            }
        }
        /// <summary>
        /// Приоставновка всех потоков из пула
        /// </summary>
        private void SuspendThreads()
        {
            lock (_threadPoolMutex)
            {
                try
                {
                    _threadPoolMutex.WaitOne();
                    foreach (var item in _threadPool)
                    {
                        if (item.ThreadState == ThreadState.Suspended)
                            item.Resume();
                        else if (item.ThreadState != ThreadState.Stopped &&
                            item.ThreadState != ThreadState.Suspended)
                            item.Suspend();
                    }
                }
                catch (AbandonedMutexException) { }
                finally { _threadPoolMutex.ReleaseMutex(); }
            }
        }
        /// <summary>
        /// Изменяет счётчик на метке
        /// </summary>
        /// <param name="lbl">Объект метки</param>
        /// <param name="count">Инкремент</param>
        private void ChangeCounterOnLabel(Label lbl, int count = 1)
        {
            lbl.BeginInvoke(new Action(() =>
            {
                var currCount = int.Parse(lbl.Text);
                lbl.Text = (currCount + count).ToString();
            }));
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            var task = Task.Run(() => StopThreads());
            task.Wait();
            ClearResult();
            LockUnlockButtons();
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            var task = Task.Run(() => SuspendThreads());
            task.Wait();
            IsPause = !IsPause;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) => StopThreads();
    }
}
