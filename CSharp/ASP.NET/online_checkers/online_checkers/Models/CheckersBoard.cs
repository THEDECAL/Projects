using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace online_checkers.Models
{
    public enum BoardSize { _8x8 = 8, _10x10 = 10 }
    public class CheckersBoard
    {
        public BoardSize Size { get; private set; }
        BoardCell[,] board;
        public CheckersBoard(BoardSize size = BoardSize._8x8)
        {
            this.Size = size;

            //Создание поля
            int sz = (int)size;
            int rowsOfCheckers = (sz - 2) / 2;
            board = new BoardCell[sz, sz];

            //Раскладывание шашек по полю
            bool shift = false;
            for (int row = 0; row < sz; row++)
            {
                for (int col = 0; col < sz; col++)
                {
                    int _shift = Convert.ToInt32(shift);
                    if ((col + _shift) % 2 > 0)
                    {
                        board[row, col] = new BoardCell(CellColor.Black, new Point(row, col));

                        if (row < rowsOfCheckers)
                            board[row, col].Check = new Check() { Color = CheckColor.White };
                        else if (row >= (sz - rowsOfCheckers))
                            board[row, col].Check = new Check() { Color = CheckColor.Black };
                    }
                    else board[row, col] = new BoardCell(CellColor.White, new Point(row, col));
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
        public int Move(Point src, Point dst)
        {
            var srcCell = board[src.X, src.Y];
            var dstCell = board[dst.X, dst.Y];

            if (IsCorrectMove(ref srcCell, ref dstCell))
            {
                dstCell.Check = srcCell.Check;
                srcCell.Check = null;

                return PickUp(ref srcCell, ref dstCell);
            }

            return 0;
        }
        /// <summary>
        /// Проверяет корректность перемещения шашки
        /// </summary>
        /// <param name="src">Клетка исхода шашки</param>
        /// <param name="dst">Клетка назначения шашки</param>
        /// <returns>Возвращает true или false результата проверки</returns>
        private bool IsCorrectMove(ref BoardCell src, ref BoardCell dst)
        {
                //Проверка на ход только по чёрным клеткам,
                //Проверка наличия на исходящей клетке шашки и отсутсвие шашки на получающей клетке
                if (src.Color == CellColor.Black && dst.Color == CellColor.Black &&
                src.Check != null && dst.Check == null)
                {
                    //Проверка на диагональный ход
                    if (src.Position.X != dst.Position.X &&
                        src.Position.Y != dst.Position.Y)
                    {
                        //Проверка для взятия только чужих шашек
                        if (IsHaveCrossCheckers(ref src, ref dst))
                        {
                        //Условия при обычной шашке
                            if (src.Check.Type == CheckType.Men)
                            {
                                int mul = (src.Check.Color == CheckColor.White) ? -1 : 1;
                                var distantion = (src.Position.X - dst.Position.X) * mul;
                                
                                if (distantion > 0 && distantion < 3)
                                    return true;
                            }
                            //Условия при дамке
                            else return true;
                        }
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
        private List<BoardCell> GetCrossCheckers(ref BoardCell src, ref BoardCell dst)
        {
            var foundCheckers = new List<BoardCell>();
            int XMul = ((src.Position.X > dst.Position.X) ? -1 : 1);
            int YMul = (src.Position.Y > dst.Position.Y) ? -1 : 1;
            
            for (int row = src.Position.X; row < dst.Position.X;)
            {
                row = Math.Abs(row + XMul);
                for (int col = src.Position.Y; col < dst.Position.Y;)
                {
                    col = Math.Abs(col + YMul);

                    ref var cell = ref board[row, col];
                    if (cell.Check != null && cell.Check.Color != src.Check.Color)
                        foundCheckers.Add(cell);
                    else new InvalidOperationException();
                }
            }

            return foundCheckers;
        }
        /// <summary>
        /// Проверяет, чтобы белые били только чёрных и наоборот
        /// </summary>
        /// <param name="src">Клетка исхода шашки</param>
        /// <param name="dst">Клетка назначения шашки</param>
        /// <returns>Возвращает true или false результата проверки</returns>
        private bool IsHaveCrossCheckers(ref BoardCell src, ref BoardCell dst)
        {
            try
            {
                return (GetCrossCheckers(ref src, ref dst) != null) ? true : false;
            }
            catch (InvalidOperationException) { }

            return false;
        }
        /// <summary>
        /// Соберает битые шашки противника
        /// </summary>
        /// <param name="src">Клетка исхода шашки</param>
        /// <param name="dst">Клетка назначения шашки</param>
        /// <returns>Возвращает кол-во битых шашок</returns>
        private int PickUp(ref BoardCell src, ref BoardCell dst)
        {
            var listCellsForPickUp = GetCrossCheckers(ref src, ref dst);
            int countPickUpCheckers = listCellsForPickUp.Count;

            listCellsForPickUp.ForEach(cell => cell.Check = null);

            return countPickUpCheckers;
        }
    }

    public enum CellColor { White, Black }
    public class BoardCell
    {
        public Point Position { get; private set; }
        public CellColor Color { get; private set; }
        public Check Check { get; set; }
        public BoardCell(CellColor color, Point position, Check check = null)
        {
            this.Position = position;
            this.Color = color;
            this.Check = check;
        }
    }
}