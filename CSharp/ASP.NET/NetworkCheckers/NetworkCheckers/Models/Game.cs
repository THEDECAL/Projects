using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using NetworkCheckers.Controllers;
using Newtonsoft.Json;
using NetworkCheckers.Data;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace NetworkCheckers.Models
{
    public class Game : DbContext
    {
        [Key]
        public int Id { get; set; }
        public string JsonBoard { get; set; } = "";
        [NotMapped]
        readonly CheckersBoard _board = new CheckersBoard();
        [NotMapped]
        public CheckersBoard Board
        {
            get
            {
                if (JsonBoard != "")
                {
                    var board = JsonConvert.DeserializeObject<CheckersBoard>(JsonBoard);
                    _board.Board = board.Board;
                    _board.Size = board.Size;
                }
                return _board;
            }
        }

        public string WhitePlayerId { get; set; }
        [NotMapped]
        User _whitePlayer = null;
        [NotMapped]
        public User WhitePlayer
        {
            get
            {
                if (_whitePlayer == null && WhitePlayerId != null)
                {
                    using (ApplicationDbContext.DbContext)
                    {
                        var user = ApplicationDbContext.DbContext.Users.FirstOrDefaultAsync(u => u.Id == WhitePlayerId);
                        user.Wait();
                        _whitePlayer = user.Result;
                    }
                }

                return _whitePlayer;
            }
            set
            {
                if (WhitePlayerId == null)
                    WhitePlayerId = value.Id;

                _whitePlayer = value;
            }
        }

        public string BlackPlayerId { get; set; }
        [NotMapped]
        User _blackPlayer = null;
        [NotMapped]
        public User BlackPlayer
        {
            get
            {
                if (_blackPlayer == null && BlackPlayerId != null)
                {
                    using (ApplicationDbContext.DbContext)
                    {
                        var user = ApplicationDbContext.DbContext.Users.FirstOrDefaultAsync(u => u.Id == BlackPlayerId);
                        user.Wait();
                        _blackPlayer = user.Result;
                    }
                }

                return _blackPlayer;
            }
            set
            {
                if (BlackPlayerId == null)
                    BlackPlayerId = value.Id;

                _blackPlayer = value;
            }
        }

        public int WhiteScore { get; set; } = 0;
        public int BlackScore { get; set; } = 0;
        public int GameTimeCounter { get; set; } = 0;
        public string JsonGameLog { get; set; } = "";
        [NotMapped]
        ObservableCollection<string> _gameLog = new ObservableCollection<string>();
        [NotMapped]
        public ObservableCollection<string> GameLog
        {
            get
            {
                if (JsonGameLog != "" && _gameLog.Count == 0)
                {
                    var gameLog = JsonConvert.DeserializeObject<ObservableCollection<string>>(JsonGameLog);

                    if (gameLog != null)
                    {
                        foreach (var item in gameLog)
                            _gameLog.Add(item);
                    }
                }

                return _gameLog;
            }
        }
        public DateTime DateStart { get; private set; } = DateTime.Now;
        public DateTime DateFinish { get; private set; } = DateTime.Now;
        
        public string WinnerPlayerId { get; set; }
        
        public string CurrentMovePlayerId { get; set; }
        public Game()
        {
            Board.ChangeBoard += new CheckersBoard.ChangeStateBoard(
                new Action(() =>
                {
                    JsonBoard = JsonConvert.SerializeObject(_board);
                }));

            _gameLog.CollectionChanged += new NotifyCollectionChangedEventHandler(
                 new Action<object, NotifyCollectionChangedEventArgs>((sender, e) =>
                 {
                     JsonGameLog = JsonConvert.SerializeObject(_gameLog);
                 }));
        }
        public void ChangeMovePlayer() => CurrentMovePlayerId = (WhitePlayer.Id == CurrentMovePlayerId) ? BlackPlayer.Id: WhitePlayerId ;
    }
}
