using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace OnlinePoker.Models
{
    public class Game
    {
        public const int MAX_PLAYERS = 8;
        public const int CARDS_FOR_DIST = 5;
        public const int STARTING_BET = 10;
        private readonly Deck _deck = new Deck();
        //Словарь подключений к игре, где key = id аккаунта, value = список id подключений
        private readonly Dictionary<string, List<string>> _playersConnections = new Dictionary<string, List<string>>();

        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public List<Player> Players { get; private set; } = new List<Player>();
        public IReadOnlyList<string> Connections { get => _playersConnections.Values.SelectMany(c => c).ToList(); }
        public bool IsStarted { get; private set; }
        public bool IsPlacePlayer { get => !(Players.Count == PlayersCapacity); }
        public int PlayersCapacity { get; private set; }
        public int Bank { get; set; }
        /// <summary>
        /// Победитель партии игры
        /// </summary>
        public Player Winner { get; private set; }

        public Game(int playerCapacity)
        {
            if (playerCapacity % 2 == 0 && playerCapacity <= MAX_PLAYERS)
                PlayersCapacity = playerCapacity;
            else throw new ArgumentOutOfRangeException($"Недопустимое количество игроков (=<{playerCapacity}).");
        }
        /// <summary>
        /// Получить пустые карты (список нолей, что соответсвует картинке рубашки карты)
        /// </summary>
        /// <returns>Возвращает список строк</returns>
        static public IReadOnlyList<string> GetEmptyCards(string cardVersion) => new int[CARDS_FOR_DIST].Select(c => cardVersion + c.ToString()).ToList();
        /// <summary>
        /// Добавление соединения и игрока по id аккаунта
        /// </summary>
        /// <param name="player">Принимает объект игрока</param>
        /// <param name="connId">Принимает id соединения</param>
        public void AddConnection([NotNull]User account, [NotNull] string connId)
        {
            lock (Players)
                if (!IsUserExists(account.Id)) Players.Add(new Player(account));

            lock (_playersConnections)
            {
                var isExistingPlayer = _playersConnections.ContainsKey(account.Id);
                if (isExistingPlayer) //Этот userId уже есть?
                {
                    var isExistingConnId = _playersConnections[account.Id].Contains(connId);
                    if (!isExistingConnId) //Это соединение уже есть?
                        _playersConnections[account.Id].Add(connId);
                }
                else
                    _playersConnections.Add(account.Id, new List<string>() { connId });
            }
        }
        /// <summary>
        /// Удаление соединения
        /// </summary>
        /// <param name="player">Принимает объект игрока</param>
        /// <param name="connId">Принимает id соединения</param>
        public void DelConnection(string userId, string connId)
        {
            if (userId != null && connId != null)
            {
                lock (_playersConnections)
                {
                    var isExistingPlayer = _playersConnections.ContainsKey(userId);
                    if (isExistingPlayer) //Этот игрок уже есть?
                    {
                        var isExistingConnId = _playersConnections[userId].Contains(connId);
                        if (isExistingConnId) //Это соединение уже есть?
                        {
                            if (_playersConnections[userId].Count > 1)
                                _playersConnections[userId].Remove(connId);
                            else
                                _playersConnections.Remove(userId);
                        }
                    }
                }
            }
            else throw new NullReferenceException();
        }
        /// <summary>
        /// Раздача карт игрокам
        /// </summary>
        public void CardDist()
        {
            IsStarted = true;
            for (int i = 0; i < CARDS_FOR_DIST; i++)
                Players.ForEach(p => p.TakeCard(_deck.GetCard()));
        }
        /// <summary>
        /// Получение списка соеденений по идентификатору аккаунта
        /// </summary>
        /// <param name="userId">Принимает идентификатор аккаунта</param>
        /// <returns>Возвращает список соединений</returns>
        public IReadOnlyList<string> GetConnections(string userId) => _playersConnections.GetValueOrDefault(userId);
        /// <summary>
        /// Получение всех соеденений кроме введённого идентификатора аккаунта
        /// </summary>
        /// <param name="userId">Принимает идентификатор аккаунта</param>
        /// <returns>Возвращает список соединений</returns>
        public IReadOnlyList<string> GetConnectionsExcept(string userId) =>
            _playersConnections.Where(c => c.Key != userId).SelectMany(c => c.Value).ToList();
        /// <summary>
        /// Проверка существования игрока по id аккаунта
        /// </summary>
        /// <param name="userId">Принимает Id аккаунта</param>
        /// <returns>Возвращает true если id найден или false если нет</returns>
        public bool IsUserExists(string userId) => Players.Exists(p => p.UserId == userId);
        /// <summary>
        /// Получение всех ников игроков
        /// </summary>
        /// <returns>Возвращает список ников игроков</returns>
        public IReadOnlyList<string> GetPlayersNickNames() => Players.Select(p => p.NickName).ToList();
        /// <summary>
        /// Получение стартовой ставки со всех игроков
        /// </summary>
        public void Bet() {
            Players.ForEach(p => {
                if (p.SubtractionCoinsAmount(STARTING_BET))
                    this.Bank += STARTING_BET;
                else
                    throw new ArgumentException($"Не достаточно монет у {p.NickName}");
            });
        }
        /// <summary>
        /// Проверка окончания игры
        /// </summary>
        /// <param name="game">Принимает идентификатор игры</param>
        public bool CheckAtGameOver()
        {
            bool isGameOver = false;

            if (Players.All(p => p.IsShowdown))
            {
                Winner = Players.OrderBy(p => (int)p.GetCombination()).LastOrDefault();
                Winner.AdditionCoinsAmount(Bank);
                isGameOver = true;
            }
            else if (Players.Sum(p => (p.IsFold) ? 1 : 0) == Players.Count - 1)
            {
                Winner = Players.FirstOrDefault(p => !p.IsFold);
                Winner.AdditionCoinsAmount(Bank);
                isGameOver = true;
            }

            return isGameOver;
        }
        /// <summary>
        /// Подготовка игры к новой партии с теми-же игроками
        /// </summary>
        public void NewParty()
        {
            IsStarted = false;
            Bank = 0;
            Winner = null;
            Players.ForEach(p => p.NewParty());
        }
    }
}
