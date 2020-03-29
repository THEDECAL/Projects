using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using NetworkCheckers.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkCheckers.Models.Hubs
{
    public class GameHub : Hub
    {
        readonly UserManager<User> _userManager;
        ApplicationDbContext _dbContext;
        static Dictionary<string, List<string>> _users = new Dictionary<string, List<string>>();
        static public Game NewGame { get; private set; } = new Game();
        static public bool IsNewGame { get; set; } = true;
        User CurrentUser
        {
            get
            {
                //using (_userManager)
                //{
                return _userManager.Users.FirstOrDefault(u => u.Email == Context.User.Identity.Name);
                //var userTask = _userManager.GetUserAsync(Context.User);
                //userTask.Wait();
                //return userTask.Result;
                //}
            }
        }
        Game CurrentGame
        {
            get
            {
                using (ApplicationDbContext.DbContext)
                {
                    Func<Game, bool> predicate = (g) =>
                    {
                        var currUser = CurrentUser;

                        return (g.WinnerPlayerId == null && (g.WhitePlayerId == currUser.Id || g.BlackPlayerId == currUser.Id));
                    };

                    return ApplicationDbContext.DbContext.Games.LastOrDefault(predicate);
                }
            }
        }
        public GameHub(UserManager<User> userManager)
        {
            _userManager = userManager;
            _dbContext = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
        }
        /// <summary>
        /// Метод передвижения шашки и бой шпшек соперника, если это возможно
        /// </summary>
        /// <param name="srcX">Принимает X исходящей клетки</param>
        /// <param name="srcY">Принимает Y исходящей клетки</param>
        /// <param name="dstX">Принимает X клетки назначения</param>
        /// <param name="dstY">Принимает Y клетки назначения</param>
        public void MoveChecker(int srcX, int srcY, int dstX, int dstY)
        {
            var currGame = CurrentGame;
            var currUser = CurrentUser;

            if (currGame != null)
            {
                var boardSize = (int)currGame.Board.Size;
                var ids = GetPlayersIds(currGame);

                //Если это очередь игрока
                if (currGame.CurrentMovePlayerId == currUser.Id)
                {
                    var srcPoint = new Point(srcX, srcY);
                    var dstPoint = new Point(dstX, dstY);

                    try
                    {
                        CheckerColor currPlayerColor;
                        string currPlayerColorString = "";
                        string nextMovePlayerName;
                        if (currGame.CurrentMovePlayerId == currGame.WhitePlayerId)
                        {
                            currPlayerColor = CheckerColor.White;
                            nextMovePlayerName = currGame.BlackPlayer.NickName;
                            currPlayerColorString = "white";
                        }
                        else
                        {
                            currPlayerColor = CheckerColor.Black;
                            nextMovePlayerName = currGame.WhitePlayer.NickName;
                            currPlayerColorString = "black";
                        }

                        var cellsToPickUp = currGame.Board.Move(srcPoint, dstPoint, currPlayerColor);

                        if (cellsToPickUp.Count() > 0)
                        {
                            if (currPlayerColor == CheckerColor.White)
                            {
                                currGame.WhiteScore += cellsToPickUp.Count();
                                Clients.Clients(ids).SendAsync("SetScore", currGame.WhiteScore, currPlayerColorString);
                            }
                            else
                            {
                                currGame.BlackScore += cellsToPickUp.Count();
                                Clients.Clients(ids).SendAsync("SetScore", currGame.BlackScore, currPlayerColorString);
                            }
                        }

                        Clients.Clients(ids).SendAsync("MoveAndPickUpChecker",
                            new { srcPoint.X, srcPoint.Y },
                            new { dstPoint.X, dstPoint.Y },
                            cellsToPickUp).Wait();

                        if (currGame.Board.IsKing(ref dstPoint))
                            Clients.Clients(ids).SendAsync("SetKing", new { dstPoint.X, dstPoint.Y, color = currPlayerColorString }).Wait();

                        int winnerScorePoints = (boardSize - 2) / 2 * boardSize / 2;
                        //Если есть победитель
                        if (currGame.WhiteScore == winnerScorePoints || currGame.BlackScore == winnerScorePoints)
                        {
                            currGame.WinnerPlayerId = (currGame.WhiteScore > currGame.BlackScore)
                                ? currGame.WhitePlayerId
                                : currGame.BlackPlayerId;

                            var winnerName = (currGame.WhiteScore > currGame.BlackScore)
                                ? currGame.WhitePlayer.NickName
                                : currGame.BlackPlayer.NickName;

                            Clients.Clients(ids).SendAsync("CreateModalWindow", "Конец игры", $"Победил {winnerName}");
                        }
                        //Если нет победителя
                        else
                        {
                            //Добавление сообщений в журнал
                            const int asciiA = 65;
                            var messages = new List<string>();
                            var moveMessage = $"Ход { (currPlayerColor == CheckerColor.White ? "чёрных" : "белых")}: ";
                            var positionMessage = $"{Math.Abs(srcPoint.X - boardSize)}{(char)(srcPoint.Y + asciiA)} &rarr; {Math.Abs(dstPoint.X - boardSize)}{(char)(dstPoint.Y + asciiA)}";

                            currGame.GameLog.Add(positionMessage);
                            messages.Add(positionMessage);
                            if (cellsToPickUp.Count() > 0)
                            {
                                var pickUpMessage = $"{ (currPlayerColor == CheckerColor.White ? "Белый" : "Чёрный")} взял шашки({cellsToPickUp.Count()})";
                                currGame.GameLog.Add(pickUpMessage);
                                messages.Add(pickUpMessage);
                            }
                            currGame.GameLog.Add(moveMessage);
                            messages.Add(moveMessage);

                            Clients.Clients(ids).SendAsync("AddMessagesToLog", messages).Wait();
                            currGame.ChangeMovePlayer();
                        }

                        using (_dbContext)
                        {
                            _dbContext.Games.Update(currGame);
                            _dbContext.SaveChanges();
                        }
                    }
                    catch (Exception)
                    {
                        //Сообщение о запрещённом ходе
                        Clients.Clients(ids).SendAsync("SendMessage", "Ошибка", "Недопустимы ход").Wait();
                    }
                }
                //Если игрок пытатеся ходить внеочереди
                else
                {
                    //Сообщение о внеочередном ходе
                    Clients.Clients(ids).SendAsync("SendMessage", "Ошибка", "Не ваша очередь ходить").Wait();
                }
            }
        }
        public override Task OnConnectedAsync()
        {
            var currUser = CurrentUser;
            var currGame = CurrentGame;
            if (!_users.Values.Any(IDs => IDs.Any(id => id == Context.ConnectionId)))
            {
                var userKey = _users.Keys.FirstOrDefault(k => k == currUser.Id);

                if (userKey == null)
                    _users.Add(currUser.Id, new List<string>() { Context.ConnectionId });
                else
                    _users[userKey].Add(Context.ConnectionId);
            }

            var game = (currGame != null && !IsNewGame) ? currGame : NewGame;

            if (game != null)
            {
                var startGame = new Action<Game>((g) => {
                    var ids = GetPlayersIds(g);
                    if (!IsNewGame)
                    {
                        Clients.Clients(ids).SendAsync("SetScore", currGame.WhiteScore, "white").Wait();
                        Clients.Clients(ids).SendAsync("SetScore", currGame.BlackScore, "black").Wait();
                    }
                    else
                    {
                        var message = "Ход белых: ";
                        g.GameLog.Add(message);
                    }

                    Clients.Clients(ids).SendAsync("ClearGame").Wait();
                    Clients.Clients(ids).SendAsync("SetNamePlayers", new string[] { g.WhitePlayer.NickName, g.BlackPlayer.NickName }).Wait();
                    Clients.Clients(ids).SendAsync("SetCheckers", g.Board.GetCheckerPositions()).Wait();
                    Clients.Clients(ids).SendAsync("AddMessagesToLog", g.GameLog).Wait();
                    Clients.Clients(ids).SendAsync("CloseModalWindow").Wait();
                    Clients.Clients(ids).SendAsync("StartTimer").Wait();
                });

                //Если это новая игра
                if (IsNewGame)
                {
                    if (game.WhitePlayerId == null)
                    {
                        //NewGame.WhitePlayerId = currUser.Id;
                        NewGame.WhitePlayer = currUser;
                        NewGame.CurrentMovePlayerId = currUser.Id;
                    }
                    else if (game.WhitePlayerId != currUser.Id)
                    {
                        //NewGame.BlackPlayerId = currUser.Id;
                        game.BlackPlayer = currUser;
                        //NewGame.CurrentMovePlayerId = NewGame.WhitePlayerId;

                        using (_dbContext)
                        {
                            _dbContext.Games.Add(game);
                            _dbContext.SaveChanges();
                        }

                        startGame(game);

                        NewGame = new Game();
                    }
                }
                //Если это продолжение старой
                else
                {
                    var playerKeys = _users.Keys.Where(k => k == currGame.BlackPlayerId || k == currGame.WhitePlayerId).ToArray();

                    if (playerKeys != null && playerKeys.Count() == 2)
                        startGame(game);
                }
                //Clients.Clients(ids).SendAsync("SendMessage", "Внимание!", $"Ходит {NewGame.WhitePlayer.NickName}").Wait();
            }

            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            var currUser = CurrentUser;
            if (_users.Values.Any(ids => ids.Any(id => id == Context.ConnectionId)))
            {
                var userKey = _users.Keys.FirstOrDefault(k => k == currUser.Id);
                _users[userKey].Remove(Context.ConnectionId);

                if (_users[userKey].Count == 0)
                {
                    _users.Remove(userKey);

                    var currGame = CurrentGame;

                    if (currGame != null)
                    {
                        var userKeyForSendMessage = (currGame.WhitePlayerId == currUser.Id)
                            ? currGame.BlackPlayerId
                            : currGame.WhitePlayerId;

                        try
                        {
                            Clients.Clients(_users[userKeyForSendMessage])
                                .SendAsync("CreateModalWindow", "Соперник ушёл, ждём его возвращения...", "")
                                .Wait();
                        }
                        catch (Exception) { }
                    }
                }
            }

            return base.OnDisconnectedAsync(exception);
        }
        /// <summary>
        /// Метод получения списка идентификаторов соединений для текущей игры
        /// </summary>
        /// <param name="game">Принимает игру</param>
        /// <returns>Возвращает список строк идентификаторов соедениния</returns>
        List<string> GetPlayersIds(Game game)
        {
            if (game != null)
            {
                var ids = new List<string>();
                ids.AddRange(_users[game.WhitePlayerId]);
                ids.AddRange(_users[game.BlackPlayerId]);

                return ids;
            }

            throw new ArgumentNullException();
        }
    }
}
