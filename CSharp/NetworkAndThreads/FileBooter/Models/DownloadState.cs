using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBooter.Models
{
    public abstract class DownloadState
    {
        private readonly DownloadFile _downloadFile;
        public DownloadState(DownloadFile downloadFile)
        {
            _downloadFile = downloadFile;
        }
        public void Stopped() => _downloadFile.State = new StopedState(_downloadFile);
        public void Paused() => _downloadFile.State = new PausedState(_downloadFile);
        public void Running() => _downloadFile.State = new RunningState(_downloadFile);
        public void Complete() => _downloadFile.State = new CompleteState(_downloadFile);
        public void InQueue() => _downloadFile.State = new InQueueState(_downloadFile);
        public void Error() => _downloadFile.State = new ErrorState(_downloadFile);
    }

    public class InQueueState : DownloadState
    {
        public InQueueState(DownloadFile downloadFile) : base(downloadFile) { }
        public override string ToString() => "В очереди";
    }
    public class PausedState : DownloadState
    {
        public PausedState(DownloadFile downloadFile) : base(downloadFile) { }
        public override string ToString() => "Приостановлен";
    }
    public class RunningState : DownloadState
    {
        public RunningState(DownloadFile downloadFile) : base(downloadFile) { }
        public override string ToString() => "Загружается";
    }
    public class CompleteState : DownloadState
    {
        public CompleteState(DownloadFile downloadFile) : base(downloadFile) { }
        public override string ToString() => "Загружен";
    }
    public class StopedState : DownloadState
    {
        public StopedState(DownloadFile downloadFile) : base(downloadFile) { }
        public override string ToString() => "Остановлен";
    }
    public class ErrorState : DownloadState
    {
        public ErrorState(DownloadFile downloadFile) : base(downloadFile) { }
        public override string ToString() => "Ошибка";
    }
}
