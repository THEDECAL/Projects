using System;
using System.Threading;
using System.Text;
using static System.Console;

namespace practice
{
    //enum Suit { CLUBS=2660, DIAMONDS, HEARTS, SPADES };
    enum Suit { HEARTS = 3, DIAMONDS, SPADES, CLUBS };
    enum Rank { _1,_2,_3,_4,_5,_6,_7,_8,_9,_10,J,Q,K,A };
    class Card
    {
        private string[] ranks = new string[]{ "2 ","3 ","4 ","5 ","6 ","7 ","8 ","9 ","10","J ","Q ","K ","A " };
        Rank rank;
        Suit suit;
        public Card(Rank rank, Suit suit)
        {
            this.rank = rank;
            this.suit = suit;
        }
        public static bool operator >(Card o1, Card o2)
        {
            return o1.rank > o2.rank;
        }
        public static bool operator <(Card o1, Card o2)
        {
            return !(o1 > o2);
        }
        public static bool operator ==(Card o1, Card o2)
        {
            return (o1.rank == o2.rank) && (o1.suit == o2.suit);
        }
        public static bool operator !=(Card o1, Card o2)
        {
            return !(o1 == o2);
        }
        public override string ToString()
        {
            return $"[{ranks[(int)rank]}{(char)suit}]";
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }
        static public Card GetRCard()
        {
            Random rCard = new Random();
            Thread.Sleep(10);

            return new Card((Rank)rCard.Next((int)Rank._1, (int)Rank.A), (Suit)rCard.Next((int)Suit.HEARTS, (int)Suit.CLUBS));
        }
    }
    class CardStack
    {
        Card[] array;
        public int Length { get { return array.Length; } }
        public int CurrLength { get; private set; }
        public CardStack(int length)
        {
            array = new Card[length];
        }
        public Card this[int index]
        {
            get
            {
                if (index >= 0 && index < CurrLength)
                    return array[index];
                return null;
            }
            set
            {
                if(index >= 0 && index < CurrLength)
                    array[index] = value;
                else Add(value);
            }
        }
        public static bool operator >(CardStack o1, CardStack o2)
        {
            return o1.Length > o2.Length;
        }
        public static bool operator <(CardStack o1, CardStack o2)
        {
            return !(o1 > o2);
        }
        public static bool operator ==(CardStack o1, CardStack o2)
        {
            return o1.Length == o2.Length;
        }
        public static bool operator !=(CardStack o1, CardStack o2)
        {
            return !(o1 == o2);
        }
        public static CardStack operator +(CardStack o1, CardStack o2)
        {
            CardStack temp = new CardStack(o1.CurrLength + o2.CurrLength);
            for (int i = 0; i < o1.CurrLength; i++)
            {
                temp.Add(o1[i]);
            }
            for (int i = 0; i < o2.CurrLength; i++)
            {
                temp.Add(o2[i]);
            }

            return temp;
        }
        public static CardStack operator -(CardStack o1, CardStack o2)
        {
            CardStack temp = new CardStack(o1.CurrLength + o2.CurrLength);

            for (int i = 0; i < o1.CurrLength; i++)
            {
                bool isCoincidence = false;
                for (int j = 0; j < temp.CurrLength; j++)
                {
                    if (temp[j] == o1[i]) isCoincidence = true;
                }
                if (isCoincidence == false) temp.Add(o1[i]);
            }

            for (int i = 0; i < o2.CurrLength; i++)
            {
                bool isCoincidence = false;
                for (int j = 0; j < temp.CurrLength; j++)
                {
                    if (temp[j] == o2[i]) isCoincidence = true;
                }
                if (isCoincidence == false) temp.Add(o2[i]);
            }

            temp.Resize(temp.CurrLength);
            return temp;
        }
        public override string ToString()
        {
            StringBuilder line = new StringBuilder();
            for (int i = 0; i < CurrLength; i++)
                line.Append(array[i] + " ");

            return line.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }
        public void Add(Card card)
        {
            if (CurrLength >= Length) Resize(Length + 1);
            array[CurrLength++] = card;
        }
        public void Remove(int index)
        {
            if (index >= 0 && index < CurrLength)
            {
                for (int i = index; i < CurrLength - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                CurrLength--;
            }
        }
        public void Remove(int index, int amount)
        {
            if (index >= 0 && index < CurrLength)
            {
                for (int i = index; i < amount; i++)
                    Remove(index);
            }
        }
        public void Insert(int index, Card card)
        {
            if (index >= 0 && index < CurrLength)
            {
                //Если не хватает размера массива увеличить его
                if (++CurrLength >= Length) Resize(CurrLength);
                for (int i = CurrLength - 1; i > index; i--)
                    array[i] = array[i - 1];
                array[index] = card;
            }
            else Add(card);
        }
        public void Insert(int index, ref Card[] cards)
        {
            foreach (var item in cards)
                Insert(index++,item);
        }
        public void ClearMemory()
        {
            for (int i = CurrLength; i < Length; i++) array[i] = null;
        }
        public void Resize(int size)
        {
            Array.Resize(ref array, (int)size);
        }
    }
    class Program
    {
        static void Main()
        {
            //Для повторного запуска использую goto
            start:
            Console.Clear();
            
            CardStack first = new CardStack(5);
            CardStack second = new CardStack(7);

            //Генерация карт в колоде (заполняем не польностью для проверки CurrLength)
            for (int i = 0; i < first.Length - 1; i++)
                first.Add(Card.GetRCard());

            for (int i = 0; i < second.Length - 2; i++)
                second.Add(Card.GetRCard());

            //Показ колод
            WriteLine($"Колода first:\t {first}");
            WriteLine($"Колода second:\t {second}");
            WriteLine();

            //Показ карты по индексу
            WriteLine($"Первый элемент колоды first:\t {first[0]}");
            WriteLine($"Крайний элемент колоды second:\t {second[second.CurrLength - 1]}");
            WriteLine();

            //Удаление карт по индексу
            first.Remove(0);
            WriteLine($"Улаляем первый элемент колоды first:\t {first}");
            second.Remove(second.CurrLength - 1);
            WriteLine($"Улаляем крайний элемент колоды second:\t {second}");
            WriteLine();

            //Вставка карт по индексу
            first.Insert(0, Card.GetRCard());
            WriteLine($"Вставка на первое место колоды first:\t {first}");
            second.Insert(2, Card.GetRCard());
            WriteLine($"Вставка на третье место колоды second:\t {second}");
            WriteLine();

            //Сравнение колод
            if (first == second) WriteLine($"Колоды first и second равны.");
            else WriteLine($"Колода {(first > second ? "first" : "second")} больше чем {(first < second ? "first" : "second")}.");
            WriteLine();

            //Сложение и вычитание колод
            WriteLine($"Сумма колод first и second:\n{first + second}");
            WriteLine($"Разность колод first и second:\n{first - second}");
            WriteLine();

            //Вставка массива по индексу
            Card[] array = { Card.GetRCard(), Card.GetRCard(), Card.GetRCard(), Card.GetRCard(), Card.GetRCard() };
            first.Insert(1, ref array);
            WriteLine($"Вставка массива карт за первый элемент в колоду first:\n{first}");
            WriteLine();

            //Удаление по индексу и кол-ву
            second.Remove(2, 10);
            WriteLine($"Удаление с третьего элемента 10-ти элементов в колоде second:\n{second}");

            Console.WriteLine("Нажмите \"Ctrl + C\" для выхода или любую клавишу для повтора.");
            Console.ReadKey();
            goto start;
        }
    }
}
