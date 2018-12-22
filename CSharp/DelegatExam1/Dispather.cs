using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatExam1
{
    class Dispather
    {
        public string Name { get; private set; }
        public int Points { get; private set; }
        int Weather;
        public Dispather(string name)
        {
            Name = name;
            Points = 0;
            Weather = Program.random.Next(-200, 201);
        }
        public string Processing(int speed, int height)
        {
            StringBuilder message = new StringBuilder();
            message.Append(Name + ": ");
            int Hp = 7 * speed - Weather;
            int diff = Hp - height;

            message.Append($"Рекоммендуемая высота: {Hp}м. ");

            if (speed > 1000)
            {
                message.Append("Понижайте скорость. ");
                Points += 100;
            }

            if (diff > 300 && diff < 600) Points += 25; 
            else if (diff > 600 && diff < 1000) Points += 50;
            else if (diff > 1000) throw new InvalidOperationException("Самолёт разбился\n(разинца между текущей и рекоммендованной скоростью больше 1000)\n");

            return message.ToString();
        }
    }
}
