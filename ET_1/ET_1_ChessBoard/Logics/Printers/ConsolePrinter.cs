using System;
using System.Collections.Generic;

using ET_1_ChessBoard.Logics.Boards;

namespace ET_1_ChessBoard.Logics.Printers
{
    static class ConsolePrinter
    {
        #region private 

        private static Dictionary<Cell.CellColor, ConsoleColor>
            standardCellsColor =
            new Dictionary<Cell.CellColor, ConsoleColor>()
            {
                { Cell.CellColor.Black, ConsoleColor.DarkGray },
                { Cell.CellColor.White, ConsoleColor.White}
            };

        #endregion

        public static void PrintEmptyBoard(Board board)
        {
            PrintEmptyBoard(board, standardCellsColor);
        }
        public static void PrintEmptyBoard(Board board,
            Dictionary<Cell.CellColor, ConsoleColor> cellsColor)
        {
            if (board == null)
            {
                throw new NullReferenceException("Board is null");
            }

            int x = 0;
            int y = 0;
            while (y < board.NumberOfColumns)
            {
                Console.BackgroundColor = cellsColor[board[x, y].Color];
                Console.Write(" ");

                y++;
                if (x < board.NumberOfRows &&
                    y == board.NumberOfColumns)
                {
                    x++;
                    y = 0;
                    Console.WriteLine();
                }
                if (x == board.NumberOfRows)
                {
                    break;
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        } 
    }
}
