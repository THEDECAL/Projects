using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FileBooter.Models
{
    public class Settings : INotifyPropertyChanged
    {
        static public readonly int MAX_QUEUE_LENGTH = 5;
        public int MaxQueueLength { get => MAX_QUEUE_LENGTH; }
        public event PropertyChangedEventHandler PropertyChanged;
        static Settings _instance = null;
        int _queueLength = 1;
        string _pathToSave = Directory.GetCurrentDirectory();
        bool _isStartDownloadingAfterAdding = true;
        public bool IsStartDownloadingAfterAdding
        {
            get => _isStartDownloadingAfterAdding;
            set
            {
                _isStartDownloadingAfterAdding = value;
                OnPropertyChanged(nameof(IsStartDownloadingAfterAdding));
            }
        }
        public int QueueLength
        {
            get => _queueLength;
            set
            {
                _queueLength = value;
                OnPropertyChanged(nameof(QueueLength));
            }
        }
        public string PathToSave
        {
            get => _pathToSave;
            set
            {
                _pathToSave = value;
                OnPropertyChanged(nameof(PathToSave));
            }
        }
        /// <summary>
        /// Метод для получения ссылки на главный экземпляр Settings
        /// </summary>
        /// <returns>Возвращает объект класса Settings</returns>
        static public Settings GetInstance() => _instance = _instance ?? new Settings();
        /// <summary>
        /// Метод применения новых настроек
        /// </summary>
        /// <param name="settings">Принимает объект класса Settings</param>
        static public void Apply(Settings settings)
        {
            if (_instance != null)
            {
                _instance.QueueLength = settings.QueueLength;
                _instance.PathToSave = settings.PathToSave;
                _instance.IsStartDownloadingAfterAdding = settings.IsStartDownloadingAfterAdding;

                DownloadFile.SetQueueLength(settings.QueueLength);
            }
            else throw new NullReferenceException();
        }
        static public Settings GetCopy()
        {
            if (_instance != null)
            {
                var copy = new Settings();
                copy.QueueLength = _instance.QueueLength;
                copy.PathToSave = _instance.PathToSave;
                copy.IsStartDownloadingAfterAdding = _instance.IsStartDownloadingAfterAdding;

                return copy;
            }
            else throw new NullReferenceException();
        }
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
