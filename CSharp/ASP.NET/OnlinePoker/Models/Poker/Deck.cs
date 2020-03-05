using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlinePoker.Models
{
    public class Deck
    {
        private readonly Random _random = new Random();
        private Stack<Card> _cards = new Stack<Card>();

        public Deck()
        {
            DeckInit();
            Shuffle();
        }

        /// <summary>
        /// Метод инициализации колоды карт
        /// </summary>
        protected void DeckInit()
        {
            for (int suit = (int)Suit.Hearts; suit <= (int)Suit.Spades; suit++)
            {
                for (int rank = (int)Rank._2; rank <= (int)Rank.Ace; rank++)
                {
                    _cards.Push(new Card((Suit)suit, (Rank)rank));
                }
            }
        }
        /// <summary>
        /// Метод перемешивания карт в колоде
        /// </summary>
        protected void Shuffle() => _cards = new Stack<Card>(_cards.OrderBy((c) => _random.Next()));
        /// <summary>
        /// Метод получения карты сверху колоды
        /// </summary>
        /// <returns></returns>
        public Card GetCard() => _cards.Pop();
    }
}