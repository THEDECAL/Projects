using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Position
    {
        public short Line { get; set; }
        public short Col { get; set; }
    }
    class Board
    {
        Checker[,] deck;
        public Board(short boardSize = 8)
        {
            init(boardSize);
        }
        public void init(short boardSize = 8)
        {
            if (boardSize % 2 == 0)
            {
                deck = new Checker[boardSize, boardSize];

                bool shift = true;
                for (int tLine = 0, bLine = boardSize - 1; tLine < boardSize / 2 - 1; tLine++, bLine--)
                {
                    int tCol = (!shift) ? 0 : 1;
                    int bCol = (tCol == 0) ? 0 : 1;
                    for (int i = 0; i < boardSize / 2; tCol += 2, bCol += 2, i++)
                    {
                        deck[tLine, tCol] = new Checker(CheckerColor.White);
                        deck[bLine, bCol] = new Checker(CheckerColor.Black);

                        shift = (shift) ? false : true;
                    }
                }
            }
            else throw new NotSupportedException("Размер доски не может быть не чётным.");
        }
        public void MoveChecker(Position from, Position to)
        {
            Checker temp = deck[from.Line, from.Col];
            deck[from.Line, from.Col] = null;
            deck[to.Line, to.Col] = temp;
        }
        public void Navigate()
        {
            //┌──┐└──┘│
            int cellWidth = 8, cellHeight = cellWidth / 2;
            char cellColor = '█';
            //Action ChangeColorCell = () => color = (color == '█') ? ' ' : '█';

            string[] cell = new string[cellHeight];
            Action<bool,bool> CreateCell = (select, CheckerColor) =>
            {
                if (!select)
                {
                    for (int i = 0; i < cell.GetLength(0); i++)
                            cell[i] = new string(cellColor, cellWidth);
                }
                else //Рамка выбора
                {
                    cell[0] = "┌" + new string('─', cellWidth - 2) + "┐";
                    for (int i = 1; i < cellHeight - 1; i++) cell[i] = "│" + new string(cellColor, cellWidth - 2) + "│";
                    cell[cellHeight - 1] = "└" + new string('─', cellWidth - 2) + "┘";
                }

                //ChangeColorCell();
                cellColor = (cellColor == '█') ? ' ' : '█';
            };
        }
        public override string ToString()
        {
            StringBuilder consoleDeck = new StringBuilder();
            int cellWidth = 8;
            int cellHeight = cellWidth / 2;

            bool blackWhite = true;
            Action BlackWhite = () => blackWhite = (blackWhite) ? false : true;

            consoleDeck.Append("╔" + new string('═', deck.GetLength(1) * 2) + "╗\n");
            for (int i = 0; i < deck.GetLength(0); i++)
            {
                consoleDeck.Append('║');
                BlackWhite();
                for (int j = 0; j < deck.GetLength(1); j++)
                {
                    BlackWhite();
                    string black = "  ";
                    if (deck[i, j] != null) black = (deck[i, j].Color == CheckerColor.Black) ? " ☻" : " ☺";
                    //Checker c = deck[i, j];
                    //if (c != null) black = (c.Color == CheckerColor.Black) ? $"{i}{j}" : $"{i}{j}";
                    consoleDeck.Append((blackWhite) ? "██" : black);
                }
                consoleDeck.Append('║');
                consoleDeck.Append('\n');
            }
            consoleDeck.Append("╚" + new string('═', deck.GetLength(1) * 2) + "╝\n");

            //consoleDeck.Append("╔" + new string('═', deck.GetLength(1) * cellWidth) + "╗\n");
            //for (int i = 0, line = i / cellHeight; i < deck.GetLength(0) * cellHeight; i++)
            //{
            //    consoleDeck.Append('║');
            //    if (i % cellHeight == 0) BlackWhite();
            //    for (int cell = 0; cell < deck.GetLength(1); cell++)
            //    {
            //        BlackWhite();
            //        string c = (blackWhite) ? "▀\b▄" : " ";
            //        consoleDeck.Append(c);
            //        //consoleDeck.Append(new string((blackWhite) ? '█' : ' ', cellWidth));
            //    }
            //    consoleDeck.Append('║');
            //    consoleDeck.Append('\n');
            //}
            //consoleDeck.Append("╚" + new string('═', deck.GetLength(1) * cellWidth) + "╝\n");

            return consoleDeck.ToString();
        }
    }
}
