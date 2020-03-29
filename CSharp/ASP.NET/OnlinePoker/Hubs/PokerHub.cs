using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using OnlinePoker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlinePoker.Hubs
{
    /// <summary>
    /// SignalR хаб для игры в покер
    /// </summary>
    public class PokerHub : Hub
    {
        UserManager<User> _userManager;

        static public List<Game> ListGames { get; } = new List<Game>();
        public const int THROW_TIME_ANIM = 700;

        public PokerHub(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public override Task OnConnectedAsync() => base.OnConnectedAsync();
        public override Task OnDisconnectedAsync(Exception exception)
        {
            var game = ListGames.FirstOrDefault(g => g.Players.Exists(p => p.UserId == Context.UserIdentifier));
            if(game != null)
                game.DelConnection(Context.UserIdentifier, Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
        /// <summary>
        /// Подключение игрока в игре
        /// </summary>
        /// <param name="gameId">Иидентификатор игры</param>
        public void ConnectToGame([NotNull]string gameId)
        {
            try
            {
                var game = GetGame(gameId);

                if (game != null)
                {
                    //Если пользователь уже был в игре переподключаем его
                    if (game.IsUserExists(Context.UserIdentifier))
                        ReconnectToGame(game);
                    //Если в игре есть место для игрока
                    else if (game.IsPlacePlayer)
                    {
                        var account = GetAccountById(Context.UserIdentifier);

                        //Если у игрока достаточно монет
                        if (account.CoinsAmount >= Game.STARTING_BET)
                        {
                            game.AddConnection(account, Context.ConnectionId);
                            var allConnsExcept = game.GetConnectionsExcept(Context.UserIdentifier);
                            var userConns = game.GetConnections(Context.UserIdentifier);
                            Console.WriteLine(account.NickName + ' ' + "Connection added");

                            Clients.Clients(userConns).SendAsync("WaitWindow");
                            Clients.Clients(game.Connections).SendAsync("AddPlayer", game.GetPlayersNickNames());
                            Clients.Clients(allConnsExcept).SendAsync("AddAlert", account.NickName, "Подключился к игре", "success");
                        }
                        else
                        {
                            Clients.Clients(Context.ConnectionId).SendAsync("AddAlert", account.NickName, "У вас не достаточно монет", "danger");
                        }
                    }

                    StartGame(game);
                }
                else throw new NullReferenceException();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        /// <summary>
        /// Переподключение игрока к игре
        /// </summary>
        /// <param name="game">Объект игры</param>
        protected void ReconnectToGame(Game game)
        {
            if (game != null)
            {
                var account = GetAccountById(Context.UserIdentifier);
                game.AddConnection(account, Context.ConnectionId);
                var userConns = game.GetConnections(Context.UserIdentifier);
                if (game.IsStarted)
                {
                    var player = GetCurrentPlayerOnGame(game);

                    Clients.Clients(userConns).SendAsync("CloseWaitWindow");
                    Clients.Clients(userConns).SendAsync("AddPlayer", game.GetPlayersNickNames());
                    Clients.Clients(userConns).SendAsync("AddCoinsToBank", game.Bank);
                    Clients.Clients(userConns).SendAsync("AddCombName", player.GetCombination());

                    var cardVersion = "v1/";
                    var plNum = 0;
                    var cards = game.Players.Select(p =>
                    {
                        plNum = game.Players.IndexOf(p) + 1;

                        return (p.UserId == Context.UserIdentifier)
                                ? p.Cards.Select(c => cardVersion + c.GetNumericString()).ToList()
                                : Game.GetEmptyCards(cardVersion);
                    });

                    Clients.Clients(userConns).SendAsync("QuickCardDist", cards);
                }
                else
                {
                    Clients.Clients(userConns).SendAsync("WaitWindow").Wait();
                    Clients.Clients(userConns).SendAsync("AddPlayer", game.GetPlayersNickNames()).Wait();
                }
            }
            else throw new NullReferenceException();
        }
        /// <summary>
        /// Запуск начала игры
        /// </summary>
        /// <param name="game">Объект игры</param>
        protected void StartGame(Game game)
        {
            if (game != null)
            {
                //Начинать игру если все игроки подключены и игра ещё не разу не стартовала
                if (!game.IsPlacePlayer && !game.IsStarted)
                {
                    game.Bet();
                    game.CardDist();
                    Clients.Clients(game.Connections).SendAsync("CloseWaitWindow");
                    Clients.Clients(game.Connections).SendAsync("AddCoinsToBank", game.Bank);

                    game.Players.ForEach(p =>
                    {
                        var currPlNum = game.Players.IndexOf(p) + 1;
                        var userConns = game.GetConnections(p.UserId);
                        var cardVersion = "v1/";
                        var cards = game.Players.Select(pp => (currPlNum == game.Players.IndexOf(pp) + 1)
                            ? p.Cards.Select(c => cardVersion + c.GetNumericString()).ToList()
                            : Game.GetEmptyCards(cardVersion));

                        Clients.Clients(userConns).SendAsync("CardDist", cards);
                        Clients.Clients(userConns).SendAsync("AddCombName", p.GetCombination());
                        Clients.Clients(game.Connections).SendAsync("AddAlert", p.NickName, $"Делает начальную ставку {Game.STARTING_BET} монет", "danger");
                    });
                }
            }
            else throw new NullReferenceException();
        }
        /// <summary>
        /// Ставка игрока
        /// </summary>
        /// <param name="amountBet">Сумма ставки</param>
        /// <param name="gameId">Идентификатор игры</param>
        public void Bet(string gameId, int amountBet)
        {
            Game game = GetGame(gameId);
            
            if (game != null)
            {
                var account = GetAccountById(Context.UserIdentifier);
                var userConnsExcept = game.GetConnectionsExcept(Context.UserIdentifier);

                if (GetCurrentPlayerOnGame(game).SubtractionCoinsAmount(amountBet))
                {
                    game.Bank += amountBet;
                    Clients.Clients(game.Connections).SendAsync("AddAlert", account.NickName, $"Ставит {amountBet}", "warning");
                    Clients.Clients(game.Connections).SendAsync("AddCoinsToBank", game.Bank);
                }
                else
                    Clients.Clients(game.GetConnections(Context.UserIdentifier)).SendAsync("AddAlert", "У вас недостаточно монет", "", "danger");
            }
        }
        /// <summary>
        /// Завершить партию игры
        /// </summary>
        /// <param name="gameId">Идентификатор игры</param>
        public void Fold(string gameId)
        {
            var game = GetGame(gameId);

            if (game != null)
            {
                //Если остальные игроки не завершили партию (ведь должен быть победитель)
                if (game.Players.Sum(p => (p.IsFold) ? 1 : 0) != game.Players.Count - 1)
                {
                    var account = GetAccountById(Context.UserIdentifier);
                    var userConnsExcept = game.GetConnectionsExcept(Context.ConnectionId);

                    GetCurrentPlayerOnGame(game).IsFold = true;
                    Clients.Clients(userConnsExcept).SendAsync("AddAlert", account.NickName, "Завершает игру", "danger");
                }
            }

            if(game.CheckAtGameOver())
                GameOver(gameId);
        }
        /// <summary>
        /// Предложение вскрыть карты
        /// </summary>
        /// <param name="gameId">Идентификатор игры</param>
        public void OfferToBeShowdown(string gameId)
        {
            var game = GetGame(gameId);

            if (game != null)
            {
                var account = GetAccountById(Context.UserIdentifier);
                var userConnsExcept = game.GetConnectionsExcept(Context.UserIdentifier);

                GetCurrentPlayerOnGame(game).IsShowdown = true;
                Clients.Clients(userConnsExcept).SendAsync("ShowOfferToBeShowdown", account.NickName);
            }
        }
        /// <summary>
        /// Ответ на предложение вскрытся
        /// </summary>
        /// <param name="gameId">Принимает идентификатор игры</param>
        /// <param name="isAgree">Принимает булево да/нет</param>
        public void ShowdownAnswer(string gameId, bool isAgree)
        {
            var game = GetGame(gameId);

            if (game != null)
            {
                var account = GetAccountById(Context.UserIdentifier);
                var userConsExcept = game.GetConnectionsExcept(Context.ConnectionId);

                GetCurrentPlayerOnGame(game).IsShowdown = isAgree;
                Clients.Clients(userConsExcept).SendAsync("AddAlert",
                    account.NickName,
                    (isAgree?"Согласен вскрытся":"Отказывается вскрыватся"),
                    (isAgree?"warning":"danger"));

                if (!isAgree) game.Players.ForEach(p => p.IsShowdown = false);
            }

            if (game.CheckAtGameOver())
                GameOver(gameId);
        }
        /// <summary>
        /// Получить текущего аутентифицированного пользователя к игре по идентификатору
        /// </summary>
        /// <param name="gameId">Принимает идентификатор игры</param>
        /// <returns>Возвращает объект игры</returns>
        protected static Game GetGame(string gameId) => ListGames.FirstOrDefault(g => g.Id == gameId);
        /// <summary>
        /// Получить игру по идентификатору
        /// </summary>
        /// <param name="gameId">Принимает идентификатор игры</param>
        /// <returns>Возвращает объект игры</returns>
        protected Player GetCurrentPlayerOnGame(Game game) => game.Players.FirstOrDefault(p => p.UserId == Context.UserIdentifier);
        /// <summary>
        /// Конец игры
        /// </summary>
        /// <param name="gameId">Принимает идентификатор игры</param>
        protected void GameOver(string gameId)
        {
            var game = GetGame(gameId);

            if (game != null)
            {
                var winnerAccount = GetAccountById(game.Winner.UserId);
                var userConns = game.GetConnections(Context.UserIdentifier);
                var userConnsExcept = game.GetConnectionsExcept(Context.UserIdentifier);

                //Когда партия заканчивается сораняем все сделаные ставки и выигриши
                game.Players.ForEach(player =>
                {
                    var account = GetAccountById(player.UserId);
                    account.CoinsAmount = player.CoinsAmount;
                    _userManager.UpdateAsync(account).Wait();
                });
                
                Clients.Clients(userConnsExcept).SendAsync("ShowWindowGameOver", game.Winner.NickName, true);
                Clients.Clients(userConns).SendAsync("ShowWindowGameOver", game.Winner.NickName, false);
            }
        }
        /// <summary>
        /// Получить объект аккаунта по идентификатору
        /// </summary>
        /// <param name="accountId">Принимает идентификатор аккаунта</param>
        /// <returns>Возвращает объект аккаунта</returns>
        protected User GetAccountById(string accountId) => _userManager.FindByIdAsync(accountId).Result;
        /// <summary>
        /// Предложение начать новую партию
        /// </summary>
        /// <param name="gameId">Принимает идентификатор игры</param>
        public void NewParty(string gameId, bool isAgree)
        {
            var game = GetGame(gameId);

            if (game != null)
            {
                GetCurrentPlayerOnGame(game).IsAgreeNewParty = isAgree;
                if (isAgree)
                {
                    //Если все согласны
                    if (game.Players.Count == game.Players.Sum(p => (p.IsAgreeNewParty) ? 1 : 0))
                    {
                        game.NewParty();
                        StartGame(game);
                    }
                }
                else
                {
                    Clients.Clients(game.Connections).SendAsync("AddAlert", "", "Не все согласны на новую партию. Начните новую игру.", "danger");
                    ListGames.Remove(game);
                }
            }
        }
    }
}