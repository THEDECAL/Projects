using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Race
{
    public partial class Race : Form
    {
        public List<Button> ListRacers { get; } = new List<Button>();
        public Race()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            btn.Enabled = false;

            //Создаём список гонщиков (кнопок)
            ListRacers.Clear();
            foreach (var item in gbGame.Controls)
            {
                Button b = item as Button;
                if (b != null)
                {
                    b.Location = new Point(6, b.Location.Y);
                    ListRacers.Add(b);
                }
            }

            lbFinifhRacers.Items.Clear();

            //Поток старта игры
            var start = new Thread(new ThreadStart(() =>
            {

                var random = new Random();

                //Запускаем анимацию старта
                gbGame.Invoke(new Action(() => lbStart.Text = "3"));

                for (int i = 2; i != -1; i--)
                {
                    Thread.Sleep(1000);
                    lbStart.Invoke(new Action(() => lbStart.Text = $"{i}"));
                }
                gbGame.Invoke(new Action(() => lbStart.Text = ""));

                Thread.Sleep(1000);
                //Передвигаем каждого гонщика в своём потоке
                foreach (var item in ListRacers)
                {
                    var thread = new Thread(new ThreadStart(() =>
                    {
                        var index = gbGame.Controls.IndexOf(item);
                        Button b = gbGame.Controls[index] as Button;
                        b.Tag = Thread.CurrentThread;
                        var finishLine = gbFinishLine.Location.X + gbFinishLine.Size.Width;
                        var endOfRaceTrack = finishLine + 10;
                        var isWriteToList = false;

                        while (endOfRaceTrack >= b.Location.X)
                        {
                            b.Invoke(new Action(() =>
                            {
                                var rnum = random.Next(2, 9);
                                b.Location = new Point(b.Location.X + rnum, b.Location.Y);
                                //currPosition = b.Location.X + b.Size.Width;
                            }));
                            Thread.Sleep(90);

                            
                            if (b.Location.X + b.Size.Width >= finishLine && !isWriteToList)
                            {
                                isWriteToList = true;
                                lbFinifhRacers.Invoke(new Action(() =>
                                {
                                    var countWinners = lbFinifhRacers.Items.Count;
                                    lbFinifhRacers.Items.Add($"{countWinners + 1}. {b.Text}");
                                }));

                                if (lbFinifhRacers.Items.Count == ListRacers.Count)
                                    btnStart.Invoke(new Action(() => btnStart.Enabled = true));
                            }
                        }
                    }));
                    thread.Start();
                }
            }));
            start.Start();
        }
        private void btnRacer_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            ListRacers.Remove(btn);
            var thread = new Thread(new ThreadStart(() =>
            {
                gbGame.Invoke(new Action(() =>
                {
                    var btnThread = btn.Tag as Thread;

                    if (btnThread != null)
                        btnThread.Abort();
                }));
            }));
            thread.Start();
        }
    }
}
