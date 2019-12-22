﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DelegatExam1Advanced.Notifer;

namespace DelegatExam1Advanced
{
    class Airplane
    {
        public static Airplane airplane { get; private set; } = new Airplane(); //Синглтон
        public Pilot Pilot { get; private set; }
        public int Penalty {
            get { return ListDispathers.Sum(d => d.Points); }
            private set  {}
        }
        public int Speed { get; private set; } //Скорость
        public int Height { get; private set; } //Высота
        int cntMessages; //Счётчик сообщений
        public Queue<string> Messages { get; private set; } //Список сообщений от диспетчеров
        public List<Dispather> ListDispathers { get; private set; } //Список диспетчеров
        event Func<int, int, string> SendIndicators //Событие
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
        Queue<Func<int, int, string>> qEvents; //Очередь делегатов
        Airplane()
        {
            Pilot = new Pilot();
            Speed = 0;
            Height = 0;
            cntMessages = 1;
            Messages = new Queue<string>();
            ListDispathers = new List<Dispather>();
            qEvents = new Queue<Func<int, int, string>>();
        }
        public void AddDispather(Dispather dispather = null)
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
        public void RemoveDispather()
        {
            Console.Write($"Введите имя диспетчера: ");
            string name = Console.ReadLine();

            qEvents.Clear();
            foreach (var item in ListDispathers)
                if (item.Name != name) SendIndicators += item.Processing;
        }
        public void StartSendIndicators()
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
        public string ShowMessages()
        {
            StringBuilder messages = new StringBuilder();
            foreach (string item in Messages)
                messages.Append(item + "\n");

            return messages.ToString();
        }
        public void SpeedUp(int speed) => Speed += speed;
        public void SpeedDown(int speed)
        {
            if (Speed - speed < 0) Speed = 0; //Не опускать скорость ниже 0
            else Speed -= speed;
        }
        public void HeightUp(int height)
        {
            if (Speed >= 50) //Если скорость меньше 50, то не добавлять высоту
            {
                Height += height;
            }
        }
        public void HeightDown(int height)
        {
            if (Height - height < 0) Height = 0; //Не опускать высоту ниже 0
            else Height -= height;
        }
        public bool CheckDispathers()
        {
            if (ListDispathers.Count < 2)
            {
                Console.WriteLine((notifer[mc.ERR_AM_DISP]));
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