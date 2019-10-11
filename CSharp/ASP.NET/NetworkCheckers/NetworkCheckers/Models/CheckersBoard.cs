using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace NetworkCheckers.Models
{
    public enum BoardSize { _8x8 = 8, _10x10 = 10 }
    public class CheckersBoard
    {
        public delegate void ChangeStateBoard();
        public event ChangeStateBoard ChangeBoard;
        public BoardSize Size { get; set; }
        public BoardCell[,] Board { get; set; }
        public object[] GetCheckerPositions()
        {
            List<object> list = new List<object>();

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    var cell = Board[i, j];
                    if (cell.Checker != null)
                    {
                        var color = (cell.Checker.Color == CheckerColor.White)
                                ? "white"
                                : "black";

                        list.Add(new
                        {
                            cell.Position.X,
                            cell.Position.Y,
                            color
                        });
                    }
                }
            }
            return list.ToArray();
        }
        public CheckersBoard(BoardSize size = BoardSize._8x8)
        {
            this.Size = size;

            //Создание поля
            int sz = (int)Size;
            int rowsOfCheckers = (sz - 2) / 2;
            Board = new BoardCell[sz, sz];

            //Раскладывание шашек по полю
            bool shift = false;
            for (int row = 0; row < sz; row++)
            {
                for (int col = 0; col < sz; col++)
                {
                    int _shift = Convert.ToInt32(shift);
                    if ((col + _shift) % 2 > 0)
                    {
                        Board[row, col] = new BoardCell(CellColor.Black, new Point(row, col));

                        if (row < rowsOfCheckers)
                            Board[row, col].Checker = new Checker() { Color = CheckerColor.White };
                        else if (row >= (sz - rowsOfCheckers))
                            Board[row, col].Checker = new Checker() { Color = CheckerColor.Black };
                    }
                    else Board[row, col] = new BoardCell(CellColor.White, new Point(row, col));
                }
                shift = !shift;
            }
        }
        /// <summary>
        /// Перемещает шашку и если возможно бъёт шашки противника
        /// </summary>
        /// <param name="src">Точка исхода шашки</param>
        /// <param name="dst">Точка назначения шашки</param>
        /// <returns>Возвращает кол-во битых шашек</returns>
        public object[] Move(Point src, Point dst, CheckerColor color)
        {
            var srcCell = Board[src.X, src.Y];
            var dstCell = Board[dst.X, dst.Y];

            if (srcCell.Checker.Color == color) //Проверка передвижения своих шашек
            {
                if (IsCorrectMove(ref srcCell, ref dstCell)) //Проверка на корректность хода
                {
                    var pickUpCheckers = PickUp(ref srcCell, ref dstCell);
                    if (IsChangeToKing(ref src, ref dst, color)) //Проверка попадания в дамки
                        srcCell.Checker.Type = CheckerType.King;
                    dstCell.Checker = srcCell.Checker;
                    srcCell.Checker = null;

                    ChangeBoard?.Invoke();
                    return pickUpCheckers;
                }
            }
            throw new ArgumentException();
        }
        /// <summary>
        /// Проверяет корректность перемещения шашки
        /// </summary>
        /// <param name="src">Клетка исхода шашки</param>
        /// <param name="dst">Клетка назначения шашки</param>
        /// <returns>Возвращает true или false результата проверки</returns>
        bool IsCorrectMove(ref BoardCell src, ref BoardCell dst)
        {
            //Проверка на ход только по чёрным клеткам,
            //Проверка наличия на исходящей клетке шашки и отсутсвие шашки на получающей клетке
            if (src.Color == CellColor.Black && dst.Color == CellColor.Black &&
            src.Checker != null && dst.Checker == null)
            {
                //Проверка на диагональный ход
                if (src.Position.X != dst.Position.X &&
                    src.Position.Y != dst.Position.Y)
                {
                    //Условия при обычной шашке
                    if (src.Checker.Type == CheckerType.Men)
                    {
                        int mul = (src.Checker.Color == CheckerColor.White) ? -1 : 1;
                        var distance = (src.Position.X - dst.Position.X) * mul;

                        if (distance > 0 && distance < 3)
                            return true;
                    }
                    //Условия при дамке
                    else return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Получает перекрёстные шашки
        /// </summary>
        /// <param name="src">Клетка исхода шашки</param>
        /// <param name="dst">Клетка назначения шашки</param>
        /// <returns>Возвращает список клеток с перекрёстными шашками</returns>
        List<BoardCell> GetCrossCheckers(ref BoardCell src, ref BoardCell dst)
        {
            var foundCheckers = new List<BoardCell>();
            int XPlus = ((src.Position.X > dst.Position.X) ? -1 : 1);
            int YPlus = (src.Position.Y > dst.Position.Y) ? -1 : 1;

            for (int row = src.Position.X + XPlus; row != dst.Position.X; row += XPlus)
            {
                for (int col = src.Position.Y + YPlus; col != dst.Position.Y; col += YPlus)
                {
                    ref var cell = ref Board[row, col];
                    if (cell.Checker != null && cell.Checker.Color != src.Checker.Color)
                        foundCheckers.Add(cell);
                    else new InvalidOperationException();
                }
            }

            return foundCheckers;
        }
        /// <summary>
        /// Соберает битые шашки противника
        /// </summary>
        /// <param name="src">Клетка исхода шашки</param>
        /// <param name="dst">Клетка назначения шашки</param>
        /// <returns>Возвращает кол-во битых шашок</returns>
        object[] PickUp(ref BoardCell src, ref BoardCell dst)
        {
            var listCellsForPickUp = GetCrossCheckers(ref src, ref dst);
            listCellsForPickUp.ForEach(cell => cell.Checker = null);

            return listCellsForPickUp.Select(c => new { c.Position.X, c.Position.Y } ).ToArray();
        }
        bool IsChangeToKing(ref Point src, ref Point dst, CheckerColor color)
        {
            var srcCell = Board[src.X, src.Y];
            var dstCell = Board[dst.X, dst.Y];

            if (srcCell.Checker.Type != CheckerType.King)
            {
                if (color == CheckerColor.White && dstCell.Position.X == (int)Size - 1)
                    return true;
                else if (color == CheckerColor.Black && dstCell.Position.X == 0)
                    return true;
            }

            return false;
        }
        public bool IsKing(ref Point position) => (Board[position.X, position.Y].Checker.Type == CheckerType.King);
    }
    
    public enum CellColor { White, Black }
    public class BoardCell
    {
        public Point Position { get; private set; }
        public CellColor Color { get; private set; }
        public Checker Checker { get; set; }
        public BoardCell(CellColor color, Point position, Checker check = null)
        {
            Position = position;
            Color = color;
            Checker = check;
        }
    }
    
    public enum CheckerType { Men, King }
    public enum CheckerColor { None, White, Black };
    public class Checker
    {
        public CheckerType Type { get; set; } = CheckerType.Men;
        public CheckerColor Color { get; set; } = CheckerColor.None;
    }
}