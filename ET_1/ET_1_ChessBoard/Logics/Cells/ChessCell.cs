using ET_1_ChessBoard.Logics.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_1_ChessBoard.Logics.Cells
{
    public class ChessCell : Cell
    {
        public ChessFigure Figure { get; set; }
        public ChessCell(int x, int y, CellColor color) : base(x, y, color)
        {
        }

        public ChessCell(int x, int y, CellColor color,
            ChessFigure.FigureType figureType) : base(x, y, color)
        {
            Figure = new ChessFigure(x, y, figureType);
        }
    }
}
