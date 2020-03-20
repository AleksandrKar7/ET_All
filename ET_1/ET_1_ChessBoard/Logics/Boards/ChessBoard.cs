using ET_1_ChessBoard.Logics.Figures;

namespace ET_1_ChessBoard.Logics.Boards
{
    public class ChessBoard : Board
    {
        public const int LengthRowOfPieces = 8;
        public const int StandardChessBoardSize = 8;
        #region private fields

        private ChessFigure.FigureType[] standardFigurePieces =
            new ChessFigure.FigureType[LengthRowOfPieces]
            {
                ChessFigure.FigureType.Rook,
                ChessFigure.FigureType.Knight,
                ChessFigure.FigureType.Bishop,
                ChessFigure.FigureType.Queen,
                ChessFigure.FigureType.King,
                ChessFigure.FigureType.Bishop,
                ChessFigure.FigureType.Knight,
                ChessFigure.FigureType.Rook,
            };

        #endregion

        public Cell this[int x, int y]
        {
            get
            {
                return Cells[x, y];
            }
        }
        public ChessFigure[,] Figures { get; protected set; }

        public ChessBoard(int numberOfRows = LengthRowOfPieces, int numberOfColumns = LengthRowOfPieces) 
            : base(numberOfRows, numberOfColumns)
        {
            
        }

        public void InitChessFigures()
        {
            Figures = new ChessFigure[NumberOfRows, NumberOfColumns];
            int x = 0;
            int y = 0;

            while (y <= Figures.GetLength(1))
            {
                if (x < Figures.GetLength(0) && y == Figures.GetLength(1))
                {
                    x++;
                    y = 0;
                }
                if (x == Figures.GetLength(0))
                {
                    break;
                }
                //Set white main figures
                if (x == 0 && y < LengthRowOfPieces)
                {
                    Figures[x, y] = new ChessFigure(x, y,
                        ChessFigure.FigureType.White |
                        standardFigurePieces[y]);
                }
                //Set white pawns
                if (x == 1 && y < StandardChessBoardSize &&
                    y < LengthRowOfPieces)
                {
                    Figures[x, y] = new ChessFigure(x, y,
                       ChessFigure.FigureType.White | 
                       ChessFigure.FigureType.Pawn);
                }

                //Set black pawns
                if (x == Figures.GetLength(0) - 2 && Figures.GetLength(0) >= 3 &&
                    y < LengthRowOfPieces)
                {
                    Figures[x, y] = new ChessFigure(x, y,
                       ChessFigure.FigureType.Black | 
                       ChessFigure.FigureType.Pawn);
                }
                //Set black main figures
                if (x == Figures.GetLength(0) - 1 && Figures.GetLength(0) >= 4 &&
                    y < LengthRowOfPieces)
                {
                    Figures[x, y] = new ChessFigure(x, y,
                        ChessFigure.FigureType.Black |
                        standardFigurePieces[y]);
                }

                y++;
            }
        }
    }
}
