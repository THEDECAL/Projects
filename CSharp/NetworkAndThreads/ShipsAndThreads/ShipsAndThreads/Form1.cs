using ShipsAndThreads.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipsAndThreads
{
    public partial class Form1 : Form
    {
        bool _isStart = false;
        const int CHANNEL_WIDTH = 5;
        const int UNIT_OF_SHIPMENT = 10;
        readonly Semaphore _channelSemaphore = new Semaphore(CHANNEL_WIDTH, CHANNEL_WIDTH);
        readonly Random _rand = new Random();
        readonly BlockingCollection<Thread> _threadPool = new BlockingCollection<Thread>();
        Queue<String> _shipNames = new Queue<string>();
        Mutex _breadMutex = new Mutex();
        Mutex _bananaMutex = new Mutex();
        Mutex _clothesMutex = new Mutex();
        Ship _breadPier = new Ship();
        Ship _bananaPier = new Ship();
        Ship _clothesPier = new Ship();
        Ship BreadPier
        {
            get => _breadPier;
            set
            {
                _breadPier = value;
                ChangeShip(value);
            }
        }
        Ship BananaPier
        {
            get => _bananaPier;
            set
            {
                _bananaPier = value;
                ChangeShip(value);
            }
        }
        Ship ClothesPier
        {
            get => _clothesPier;
            set
            {
                _clothesPier = value;
                ChangeShip(value);
            }
        }
        public Form1()
        {
            InitializeComponent();

            _shipNames = new Queue<string>(Resource1.ResourceManager.GetString("ShipNames")?.Split('\n'))
                ?? throw new NullReferenceException();

            //_sea.OnChangeList += new SeaList.ChangeList(new Action<Ship, ListAction>((ship, action) => {
            //    lbSea.Invoke(new Action(() =>
            //    {
            //        if (action == ListAction.Add) lbSea.Items.Add(ship);
            //        else lbSea.Items.Remove(ship);
            //    }));
            //}));

            //_channel.OnChangeList += new ChannelList.ChangeList(new Action<Ship, ListAction>((ship, action) => {
            //    lbChannel.Invoke(new Action(() =>
            //    {
            //        if (action == ListAction.Add) lbChannel.Items.Add(ship);
            //        else lbChannel.Items.Remove(ship);
            //    }));
            //}));
        }
        /// <summary>
        /// Смена названия корабля на форме в пире
        /// </summary>
        /// <param name="ship"></param>
        private void ChangeShip(Ship ship)
        {
            //Ищим метку на форме для корабля на пире
            var findResult = this.Controls.Find($"lbl{ship.Cargo.ToString()}", true);

            var lbl = findResult[0] as Label;
            lbl.Invoke(new Action(() => lbl.Text = ship.ToString()));
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            _isStart = !_isStart;

            btn.Text = (_isStart) ? "Стоп" : "Старт";

            if (_isStart)
            {
                var threadOfGenerateShips = new Thread(new ThreadStart(() =>
                {
                    var currThreadOfGenerateShips = Thread.CurrentThread;
                    AddThreadToPool(currThreadOfGenerateShips);

                    while (true)
                    {
                        WaitOtherTime();
                        var ship = GetRandomShip();

                        lbSea.Invoke(new Action(() => lbSea.Items.Add(ship)));

                        //Поток добавления корабля в канал, а затем на пир
                        var onAddShipThread = new Thread(new ThreadStart(() =>
                        {
                            var shipThread = Thread.CurrentThread;
                            AddThreadToPool(shipThread);

                            WaitOtherTime();
                            _channelSemaphore.WaitOne();

                            lbSea.Invoke(new Action(() => lbChannel.Items.Add(ship)));
                            lbSea.Invoke(new Action(() => lbSea.Items.Remove(ship)));

                            WaitOtherTime();
                            AddShipToPier(ship);

                            DelThreadInPool(shipThread);
                        }));

                        onAddShipThread.Start();
                    }
                }
                ));

                threadOfGenerateShips.Start();
            }
            else
            {
                StopThreads();
                Thread.Sleep(1000);

                lbSea.Items.Clear();
                lbChannel.Items.Clear();
                BreadPier = new Ship();
                BananaPier = new Ship();
                ClothesPier = new Ship();
                pbBread.Maximum = 0;
                pbBanana.Maximum = 0;
                pbClothes.Maximum = 0;
                pbBread.Value = 0;
                pbBanana.Value = 0;
                pbClothes.Value = 0;
            }
        }
        /// <summary>
        /// Добавляет корабль на пир
        /// </summary>
        /// <param name="ship">Принимает объект корабля</param>
        private void AddShipToPier(Ship ship)
        {
            var addShipToPierThread = new Thread(new ThreadStart(() =>
            {
                var currAddShipToPierThread = Thread.CurrentThread;
                AddThreadToPool(currAddShipToPierThread);

                var type = this.GetType();
                var mutexFieldName = "_" + ship.Cargo.ToString().ToLower() + "Mutex";
                var mutexField = type.GetField(mutexFieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var mutex = mutexField.GetValue(this) as Mutex;

                var pierPropName = ship.Cargo.ToString() + "Pier";
                var pierProp = type.GetProperty(pierPropName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                lock (mutex)
                {
                    try
                    {
                        mutex.WaitOne();
                        pierProp.SetValue(this, ship);
                        lbSea.Invoke(new Action(() => lbChannel.Items.Remove(ship)));
                        _channelSemaphore.Release();
                        Shipment(ship);
                    }
                    catch (AbandonedMutexException) { }
                    finally { mutex.ReleaseMutex(); }
                }

                DelThreadInPool(currAddShipToPierThread);
            }));
            addShipToPierThread.Start();
        }
        /// <summary>
        /// Выгрузка груза с корабля
        /// </summary>
        /// <param name="ship">Принимает объект корабля</param>
        private void Shipment(Ship ship)
        {
            var currShipmentThread = Thread.CurrentThread;
            AddThreadToPool(currShipmentThread);

            var findResult = this.Controls.Find($"pb{ship.Cargo.ToString()}", true);
            var pb = findResult[0] as ProgressBar;

            var count = (int)ship.Capacity;
            Thread.Sleep(25);
            while (count != 0)
            {
                Thread.Sleep(1000);
                pb.Invoke(new Action(() =>
                {
                    pb.Maximum = (int)ship.Capacity;
                    pb.Value = count;
                }));
                count -= UNIT_OF_SHIPMENT;
            }
        }
        /// <summary>
        /// Добавляет поток в пул
        /// </summary>
        /// <param name="thread">Принимает объект потока</param>
        private void AddThreadToPool(Thread thread)
        {
            lock (_threadPool)
            {
                _threadPool.Add(thread);
            }
        }
        /// <summary>
        /// Удаляет поток из пула
        /// </summary>
        /// <param name="thread">Принимает объект потока</param>
        private void DelThreadInPool(Thread thread)
        {
            lock (_threadPool)
            {
                if(thread.ThreadState == ThreadState.Running)
                    thread.Abort();
                _threadPool.TryTake(out thread);
            }
        }
        /// <summary>
        /// Генерация случайного типа и вместимости корабля
        /// </summary>
        /// <returns>Возвращает объект корабля</returns>
        private Ship GetRandomShip()
        {
            var capacityVars = Enum.GetValues(typeof(Capacity));
            var capacity = (Capacity)capacityVars?.GetValue(_rand.Next(0, capacityVars.Length));
            var cargo = (CargoType)_rand.Next(0, Enum.GetValues(typeof(CargoType)).Length);

            return new Ship(GetShipName(), capacity, cargo);
        }
        /// <summary>
        /// Получает из текстового файла имя для корабля
        /// </summary>
        /// <returns></returns>
        private string GetShipName()
        {
            var topName = _shipNames.Dequeue();
            _shipNames.Enqueue(topName);

            return topName;
        }
        /// <summary>
        /// Останавливает все потоки из пула
        /// </summary>
        private void StopThreads()
        {
            foreach (var thread in _threadPool)
                thread.Abort();
        }
        /// <summary>
        /// Генерация слуйного времени ожидания
        /// </summary>
        private void WaitOtherTime() => Thread.Sleep(_rand.Next(1, 5) * 500);
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) => StopThreads();
    }
}
