using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileBooter.Models
{
    public class DownloadFile : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        const string TEMP_EXT = ".tmp";
        static int _currQueueLength;
        static Semaphore _queue = new Semaphore(Settings.GetInstance().QueueLength, Settings.MAX_QUEUE_LENGTH);
        const int BUFF_SIZE = 256;
        int _downloadProgressPercents = 0;
        int _size = 0;
        int _alreadyLoaded = 0;
        Thread _downloadThread;
        DownloadState _state;
        string _uri;
        string _fileName;
        string _pathToSave = Settings.GetInstance().PathToSave;
        public string URI
        {
            get => _uri;
            set
            {
                _uri = value;
                _fileName = Path.GetFileName(value);
                GetFileSize();
                OnPropertyChanged(nameof(URI));
                OnPropertyChanged(nameof(FileName));
            }
        }
        public string FileName
        {
            get => _fileName;
            set
            {
                value = value.Trim();
                if (value != null || value != "")
                {
                    var ext = Path.GetExtension(_fileName);
                    PathToSave = Path.Combine(_pathToSave, value + ext);
                    _fileName = value + ext;
                    OnPropertyChanged(nameof(FileName));
                }
            }
        }
        public DownloadState State
        {
            get => _state;
            set
            {
                _state = value;
                OnPropertyChanged(nameof(State));
            }
        }
        public int Size
        {
            get => _size;
            private set
            {
                _size = value;
                OnPropertyChanged(nameof(Size));
            }
        }
        public int AlreadyLoaded
        {
            get => _alreadyLoaded;
            private set
            {
                _alreadyLoaded = value;
                OnPropertyChanged(nameof(AlreadyLoaded));
            }
        }
        public int DownloadProgressPercents
        {
            get => _downloadProgressPercents;
            private set
            {
                _downloadProgressPercents = value;
                OnPropertyChanged(nameof(DownloadProgressPercents));
            }
        }
        public string PathToSave
        {
            get => _pathToSave;
            set
            {
                value = value.Trim();
                if (value != null || value != "")
                {
                    var srcPath = Path.Combine(_pathToSave, _fileName);

                    try
                    {
                        if (File.Exists(srcPath))
                        {
                            //CloseStreams();
                            File.Move(srcPath, value);
                        }

                        _pathToSave = Path.GetDirectoryName(value);
                    }
                    catch (Exception) { State.Error(); }
                    //_pathToSave = value;
                    OnPropertyChanged(nameof(PathToSave));
                }
            }
        }
        ~DownloadFile() => Stop();
        public DownloadFile()
        {
            State = new StopedState(this);
        }
        /// <summary>
        /// Метод установки размера очереди скачивания
        /// </summary>
        /// <param name="length">Принимает число размера очереди</param>
        static public void SetQueueLength(int length)
        {
            var queueLength = Settings.GetInstance().QueueLength;

            if (length <= Settings.MAX_QUEUE_LENGTH)
            {
                if (length > queueLength)
                    _currQueueLength = _queue.Release(length - queueLength);
                else
                {
                    for (int i = 0; i < Math.Abs(length - queueLength); i++)
                        Task.Run(() => _queue.WaitOne());
                }
            }
            else throw new ArgumentOutOfRangeException();
        }
        /// <summary>
        /// Метод старта загрузки
        /// </summary>
        public void Start()
        {
            if (State is StopedState || State is PausedState)
            {
                if (_downloadThread == null)
                    GetFileAsync();
                else _downloadThread.Resume();
            }
        }
        /// <summary>
        /// Метод остановки загрузки
        /// </summary>
        public void Stop()
        {
            if (_downloadThread != null)
            {
                if (_downloadThread.ThreadState == ThreadState.Running)
                {
                    _downloadThread.Abort();

                    var tmpFileName = Path.Combine(PathToSave, FileName + TEMP_EXT);
                    if (File.Exists(tmpFileName))
                        File.Delete(tmpFileName);
                }

                DownloadProgressPercents = 0;
                AlreadyLoaded = 0;
                _downloadThread = null;
            }

            State.Stopped();
        }
        /// <summary>
        /// Метод приостановки потока загрузки
        /// </summary>
        public void Pause()
        {
            if (State is RunningState)
            {
                if (_downloadThread != null && _downloadThread.ThreadState == ThreadState.Running)
                {
                    _downloadThread.Suspend();
                }

                State.Paused();
            }
        }
        /// <summary>
        /// Метод возобновления потока загрузки
        /// </summary>
        public void Resume()
        {
            if (State is PausedState)
            {
                _downloadThread.Resume();
                State.Running();
            }
        }
        /// <summary>
        /// Метод загрузки файла
        /// </summary>
        public async void GetFileAsync()
        {
            _downloadThread = new Thread(new ThreadStart(() =>
            {
                try
                {
                    State.InQueue();
                    _queue.WaitOne();
                    State.Running();

                    var filePath = Path.Combine(PathToSave, FileName + TEMP_EXT);
                    var onePercent = Size / 100;

                    using (var stream = (new WebClient()).OpenRead(URI))
                    {
                        using (var file = File.Create(filePath))
                        {
                            var buffer = new byte[BUFF_SIZE];
                            int bytesReceived = 0;
                            while ((bytesReceived = stream.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                file.Write(buffer, 0, bytesReceived);
                                AlreadyLoaded += bytesReceived;

                                DownloadProgressPercents = AlreadyLoaded / onePercent;
                            }
                        }

                        File.Move(filePath, Path.Combine(PathToSave, FileName));
                    }

                    State.Complete();
                    _currQueueLength = _queue.Release();
                }
                catch (IOException)
                {
                    //_currQueueLength = _queue.Release();
                    //CloseStreams();
                    State.Error();
                }
                catch (WebException)
                {
                    //_currQueueLength = _queue.Release();
                    //CloseStreams();
                    State.Error();
                }
                //catch (Exception)
                //{
                //    _currQueueLength = _queue.Release();
                //    //CloseStreams();
                //}
                finally { _currQueueLength = _queue.Release(); }
            }));

            await Task.Run(() => _downloadThread.Start());
        }
        /// <summary>
        /// Метод получения размера загружаемого файла
        /// </summary>
        public void GetFileSize()
        {
            using (var webClient = new WebClient())
            using (webClient.OpenRead(URI))
            {
                Size = Convert.ToInt32(webClient.ResponseHeaders["Content-Length"]);
            }
        }
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
