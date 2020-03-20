using System;

namespace ET_1_ChessBoard.Logics.Figures
{
    public class ChessFigure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public FigureType Type { get; set; }

        [Flags]
        public enum FigureType
        {
            White = 1,
            Black = 2,
            Pawn = 4,
            Rook = 8,
            Knight = 16,
            Bishop = 32,
            King = 64,
            Queen = 128
        }

        public ChessFigure(int x, int y, FigureType type)
        {
            X = x;
            Y = y;
            Type = type;
        }
    }
}
