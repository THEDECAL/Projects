using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatExam1Advanced
{
    class Airplane //: SingletonTemplate<Airplane>
    {
        //static public Airplane o;
        static public Pilot Pilot { get; private set; }
        static public int Penalty {
            get { return ListDispathers.Sum(d => d.Points); }
            private set  {}
        }
        static public int Speed { get; private set; } //Скорость
        static public int Height { get; private set; } //Высота
        static int cntMessages; //Счётчик сообщений
        static public Queue<string> Messages { get; private set; } //Список сообщений от диспетчеров
        static public List<Dispather> ListDispathers { get; private set; } //Список диспетчеров
        static event Func<int, int, string> SendIndicators //Событие
        {
            add
            {
                qEvents.Enqueue(value);
            }
            remove
            {
                qEvents.Dequeue();
            }
        }
        static Queue<Func<int, int, string>> qEvents; //Очередь делегатов
        static Airplane()
        {
            Pilot = new Pilot();
            Speed = 0;
            Height = 0;
            cntMessages = 1;
            Messages = new Queue<string>();
            ListDispathers = new List<Dispather>();
            qEvents = new Queue<Func<int, int, string>>();
        }
        static public void AddDispather(Dispather dispather = null)
        {
            if (dispather == null)
            {
                Console.Write($"Введите имя диспетчера №{ListDispathers.Count + 1}: ");
                string name = Console.ReadLine();

                dispather = new Dispather(name);
            }

            ListDispathers.Add(dispather);
            SendIndicators += dispather.Processing;
        }
        static public void RemoveDispather()
        {

            Console.Write($"Введите имя диспетчера: ");
            string name = Console.ReadLine();

            qEvents.Clear();
            foreach (var item in ListDispathers)
                if (item.Name != name) SendIndicators += item.Processing;
        }
        static public void StartSendIndicators()
        {
            int messagesBufferSize = 12;
            if (Speed >= 50)
            {
                foreach (var item in qEvents)
                {
                    //Если сообщений больше размера буфера сообщений, то удалять старые сообщения
                    if (Messages.Count > messagesBufferSize) Messages.Dequeue();
                    //Запускаем события и складываем возвращаемые сообщения в очередь
                    Messages.Enqueue(cntMessages + ". " + item(Speed, Height));
                    cntMessages++;
                }
            }
        }
        static public string ShowMessages(string message = null)
        {
            StringBuilder messages = new StringBuilder();
            if (message == null)
            {
                foreach (string item in Messages)
                    messages.Append(item + "\n");
            }
            else messages.Append(message + "\n");

            return messages.ToString();
        }
        static public void SpeedUp(int speed) => Speed += speed;
        static public void SpeedDown(int speed)
        {
            if (Speed - speed < 0) Speed = 0; //Не опускать скорость ниже 0
            else Speed -= speed;
        }
        static public void HeightUp(int height)
        {
            if (Speed >= 50) //Если скорость меньше 50, то не добавлять высоту
            {
                Height += height;
            }
        }
        static public void HeightDown(int height)
        {
            if (Height - height < 0) Height = 0; //Не опускать высоту ниже 0
            else Height -= height;
        }
        static public bool CheckDispathers()
        {
            if (ListDispathers.Count < 2)
            {
                ShowMessages(Notifer.o[mc.ERR_AM_DISP]);
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            return $"Имя игрока: {Pilot.Name}\nСкорость: { Speed }км / ч, Высота: { Height }м, Пенальти: {Penalty}";
        }
    }
}
