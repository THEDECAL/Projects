using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePoker.Models
{
    public enum Suit { NULL, Hearts, Diamonds, Clubs, Spades }
    public enum Rank { NULL, _2 = 2, _3, _4, _5, _6, _7, _8, _9, _10, Jack, Queen, King, Ace }

    public class Card
    {
        public Suit Suit { get; private set; } = Suit.NULL;
        public Rank Rank { get; private set; } = Rank.NULL;

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        /// <summary>
        /// Получить числовой формат карты в формате: {номер_ранга}_{номер_масти} (Пример: 1_4 для двойки чирва)
        /// </summary>
        /// <returns>Возвращает строку</returns>
        public string GetNumericString() => ((int)Rank).ToString() + '_' + ((int)Suit).ToString();
        /// <summary>
        /// Выдаёт строковое представление ранга карты (число или первая буква)
        /// </summary>
        /// <returns>Возвращает строку ранга карты (Например J или 10)</returns>
        public string GetRankString() => $"{(Rank < Rank.Jack ? $"{(int)Rank}" : $"{Rank.ToString()[0]}")}";
        /// <summary>
        /// Преобразовывает карту в строку в формате {Ранг}-{Масть} (Пример: J-Hearts, 10-Spades)
        /// </summary>
        /// <returns>
        /// Возвращает строку
        /// </returns>
        public override string ToString() => $"{GetRankString()}-{Suit.ToString()}";
    }
}