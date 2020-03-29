using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    enum Rank { _6 = 6, _7, _8, _9, _10, Jack, Queen, King, Ace };
    enum Suit { Hearts = 3, Diamonds, Clubs, Spades };

    class Card
    {
        Rank rank;
        Suit suit;
        public Card(Rank rank, Suit suit)
        {
            this.suit = suit;
            this.rank = rank;
        }
        static public bool operator >(Card o1, Card o2) => o1.rank > o2.rank;
        static public bool operator <(Card o1, Card o2) => !(o1 > o2);
        //public override string ToString() => $"{RankToString()}{(char)suit}";
        public void ShowCard(int indentSize=0) //Метод показа карты с указанием отступа от края
        {
            char s = (char)suit;
            string r = RankToString();
            Console.CursorLeft = indentSize;
            Console.WriteLine("┌─────────┐");
            Console.CursorLeft = indentSize;
            Console.WriteLine($"│ {r}      │");
            Console.CursorLeft = indentSize;
            Console.WriteLine("│         │");
            Console.CursorLeft = indentSize;
            Console.WriteLine("│         │");
            Console.CursorLeft = indentSize;
            Console.WriteLine($"│    {s}    │");
            Console.CursorLeft = indentSize;
            Console.WriteLine("│         │");
            Console.CursorLeft = indentSize;
            Console.WriteLine("│         │");
            Console.CursorLeft = indentSize;
            Console.WriteLine($"│      {r} │");
            Console.CursorLeft = indentSize;
            Console.WriteLine("└─────────┘");
        }
        string RankToString() //Метод преобразования достоинтсва карты в строку
        {
            switch (rank)
            {
                case Rank._6:
                case Rank._7:
                case Rank._8:
                case Rank._9:
                    return $"{(int)rank} ";
                case Rank._10:
                    return $"{(int)rank}";
                case Rank.Jack:
                    return "J ";
                case Rank.Queen:
                    return "Q ";
                case Rank.King:
                    return "K ";
                case Rank.Ace:
                    return "A ";
                default:
                    return null;
            }
        }
    }
}
