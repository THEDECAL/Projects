using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace OnlinePoker.Models
{
    public enum Combination
    {
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    };

    public class Player
    {
        private List<Card> _cards = new List<Card>();

        public IReadOnlyList<Card> Cards { get => _cards; }
        public string UserId { get; private set; }
        public string NickName { get; private set; }
        /// <summary>
        /// Количество фишек
        /// </summary>
        public int CoinsAmount { get; private set; }
        /// <summary>
        /// Отказался игрок от дальнейшей игры или нет
        /// </summary>
        public bool IsFold { get; set; } = false;
        /// <summary>
        /// Вскрывает игрок карты или нет
        /// </summary>
        public bool IsShowdown { get; set; } = false;
        /// <summary>
        /// Согласен игрок на новую партию или нет
        /// </summary>
        public bool IsAgreeNewParty { get; set; } = false;

        public Player([NotNull] User account)
        {
            //var account = Data.DBCRUD.GetAccountById(userId).Result;
            UserId = account.Id;
            NickName = account.NickName;
            CoinsAmount = account.CoinsAmount;
        }
        /// <summary>
        /// Метод получения первой самой старшей карты среди карт
        /// </summary>
        /// <returns></returns>
        private Card GetHighCard() => Cards.FirstOrDefault((cc) => cc.Rank == Cards.Max((c) => c.Rank));
        /// <summary>
        /// Метод получения карты игроком
        /// </summary>
        /// <param name="card"></param>
        public void TakeCard(Card card) => _cards.Add(card);
        /// <summary>
        /// Метод получения карт игрока
        /// </summary>
        /// <returns></returns>
        //public ReadOnlyCollection<Card> GetCards() => Cards.AsReadOnly();
        /// <summary>
        /// Метод получения комбинации из текущих карт
        /// </summary>
        /// <returns></returns>
        public Combination GetCombination()
        {
            var sortCrd = Cards.OrderBy((c) => (int)c.Rank).ToArray();
            bool isOneSuit = Cards.All((c) => Cards[0].Suit == c.Suit);
            //RoyalFlush
            if (isOneSuit && sortCrd[0].Rank == Rank._10 && sortCrd[4].Rank == Rank.Ace)
                return Combination.RoyalFlush;
            //StraightFlush
            if (isOneSuit &&
                (((int)sortCrd[4].Rank - (int)sortCrd[0].Rank == 4) ||
                (sortCrd[0].Rank == Rank.Ace && (int)sortCrd[4].Rank - (int)sortCrd[1].Rank == 3) ||
                (sortCrd[4].Rank == Rank.Ace && (int)sortCrd[3].Rank - (int)sortCrd[0].Rank == 3)))
                return Combination.StraightFlush;
            //FourOfAKind
            if (sortCrd[0].Rank == sortCrd[3].Rank || sortCrd[1].Rank == sortCrd[4].Rank)
                return Combination.FourOfAKind;
            //FullHouse
            if ((sortCrd[0].Rank == sortCrd[1].Rank && sortCrd[2].Rank == sortCrd[4].Rank) ||
                (sortCrd[0].Rank == sortCrd[2].Rank && sortCrd[3].Rank == sortCrd[4].Rank))
                return Combination.FullHouse;
            //Flush
            if (isOneSuit)
                return Combination.Flush;
            //Straight
            if ((sortCrd[0].Rank == Rank.Ace && (int)sortCrd[4].Rank - (int)sortCrd[1].Rank == 3) ||
                (sortCrd[4].Rank == Rank.Ace && (int)sortCrd[3].Rank - (int)sortCrd[0].Rank == 3))
                return Combination.Straight;
            //ThreeOfAKind
            if (sortCrd[0].Rank == sortCrd[2].Rank ||
                sortCrd[1].Rank == sortCrd[3].Rank ||
                sortCrd[2].Rank == sortCrd[4].Rank)
                return Combination.ThreeOfAKind;
            //TwoPair
            if (sortCrd[0].Rank == sortCrd[1].Rank && sortCrd[2].Rank == sortCrd[3].Rank ||
                sortCrd[1].Rank == sortCrd[2].Rank && sortCrd[3].Rank == sortCrd[4].Rank)
                return Combination.TwoPair;
            //Pair
            if (sortCrd[0].Rank == sortCrd[1].Rank ||
                sortCrd[1].Rank == sortCrd[2].Rank ||
                sortCrd[2].Rank == sortCrd[3].Rank ||
                sortCrd[3].Rank == sortCrd[4].Rank)
                return Combination.Pair;
            //HighCard
            return Combination.HighCard;
        }
        /// <summary>
        /// Вычитание с проверкой из CoinsAmount
        /// </summary>
        /// <param name="amount">Принимает целое положительное число</param>
        /// <returns>Возвращает true при успешном изминении</returns>
        public bool SubtractionCoinsAmount(int amount)
        {
            if (amount > 0 && amount <= CoinsAmount)
            {
                CoinsAmount -= amount;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Прибавление к CoinsAmount
        /// </summary>
        /// <param name="amount">Принимает целое положительное число</param>
        public void AdditionCoinsAmount(int amount) => CoinsAmount += amount;
        /// <summary>
        /// Подготовка игрока к новой партии
        /// </summary>
        public void NewParty()
        {
            _cards.Clear();
            IsFold = false;
            IsShowdown = false;
        }

        public static bool operator ==(Player p1, Player p2) => p1.UserId == p2.UserId;
        public static bool operator !=(Player p1, Player p2) => !(p1 == p2);

        public override bool Equals(object obj) => (obj as Player) == this;
        public override int GetHashCode() => UserId.GetHashCode();
        public override string ToString() => $"{NickName} ({UserId})";
    }
}