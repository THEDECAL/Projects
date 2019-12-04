using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Card
    {
        public int number { get; set; }
        public char rank { get; set; }
        public static bool operator >(Card o1, Card o2)
        {
            return (o1.number > o1.rank) && (o2.number > o2.rank);
        }
        public static bool operator <(Card o1, Card o2)
        {
            return !(o1 > o2);
        }
        public static bool operator ==(Card o1, Card o2)
        {
            return (o1.number == o1.rank) && (o2.number == o2.rank);
        }
        public static bool operator !=(Card o1, Card o2)
        {
            return !(o1 == o2);
        }
        public override string ToString()
        {
            return $"{number} {rank}";
        }
    }
    class Stack {
        Card[] array;
        public int Length { get; private set; }
        Stack(int size)
        {
            array = new Card[size];
        }
        public Card this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }
        public static bool operator >(Stack o1, Stack o2)
        {
            return o1.Length > o2.Length;
        }
        public static bool operator <(Stack o1, Stack o2)
        {
            return !(o1 > o2);
        }
        public static bool operator ==(Stack o1, Stack o2)
        {
            return o1.Length == o2.Length;
        }
        public static bool operator !=(Stack o1, Stack o2)
        {
            return !(o1 == o2);
        }
        public static Stack operator +(Stack o1, Stack o2)
        {
            Stack temp = new Stack(o1.Length + o2.Length);
            for (int i = 0; i < o1.Length; i++)
            {
                temp[i] = o1[i];
            }
            for (int i = 0; i < o2.Length; i++)
            {
                temp[i+o1.Length] = o2[i];
            }
            return temp;
        }
        public static Stack operator -(Stack o1, Stack o2)
        {
            Stack temp = new Stack(o1.Length + o2.Length);
            uint size = 0;

            for (int i = 0; i < o1.Length; i++)
            {
                bool isCoincidence = false;
                for (int j = 0; j < temp.Length; j++)
                {
                    if (temp[j] == o1[i]) isCoincidence = true;
                }
                if (isCoincidence == false) temp.Add(o1[i]);
            }

            for (int i = 0; i < o2.Length; i++)
            {
                bool isCoincidence = false;
                for (int j = 0; j < temp.Length; j++)
                {
                    if (temp[j] == o2[i]) isCoincidence = true;
                }
                if (isCoincidence == false) temp.Add(o2[i]);
            }

            temp.Resize(size);
            return temp;
        }
        public override string ToString()
        {
            StringBuilder line = new StringBuilder();
            foreach (var item in array)
            {
                line.Append(item);
                line.Append("\n");
            }
            return line.ToString();
        }
        public void Add(Card card)
        {
            if (array.Length < Length)
            {
                array[Length++] = card;
            }
            else
            {
                Resize((uint)Length+1);
                array[Length++] = card;
            }
        }
        public void Add(Card[] cards)
        {

        }
        public void Remove(uint index)
        {
            if (index <= Length)
            {
                for (uint i = index; i < Length; i++)
                {
                    array[i] = array[i + 1];
                }
                Length--;
            }
            else Console.WriteLine("Выход за пределы массива.");
        }
        public void Remove(uint index, uint count)
        {

        }
        public void Insert(uint index, Card card)
        {
            if (index < Length && index < array.Length - 1)
            {
                for (int i = Length - 1; i >= 0; i--)
                {
                    array[i + 1] = array[i];
                }
                array[index] = card;
            }
            else Add(card);
        }
        public void clearMemory()
        {
            for (int i = Length; i < array.Length; i++)
            {
                array[i] = null;
            }
        }
        public void Resize(uint size)
        {
            Array.Resize(ref array, (int)size);
        }
    }
    class Program
    {
        static void Main()
        {
            
        }
    }
}
