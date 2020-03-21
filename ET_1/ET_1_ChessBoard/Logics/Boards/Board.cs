
namespace ET_1_ChessBoard.Logics.Boards
{
    public class Board
    {
        private Cell[,] cells;

        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }
        public Cell this[int row, int column]
        {
            get
            {
                return cells[row, column];
            }
            set
            {
                cells[row, column] = value;
            }
        }


        public Board(int numberOfRows, int numberOfColumns)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
        }

        public virtual void InitCells()
        {
            int x = 0;
            int y = 0;
            bool isNextWhite = true;

            cells = new Cell[NumberOfRows, NumberOfColumns];
            while (y <= cells.GetLength(1))
            {
                if (x < cells.GetLength(0) && y == cells.GetLength(1))
                {
                    x++;
                    y = 0;
                }
                if (x == cells.GetLength(0))
                {
                    break;
                }

                if (x % 2 == 1 && y == 0)
                {
                    cells[x, y] = new Cell(x, y, Cell.CellColor.Black);
                    isNextWhite = true;
                    y++;
                }
                else if (x % 2 == 0 && y == 0)
                {
                    cells[x, y] = new Cell(x, y, Cell.CellColor.White);
                    isNextWhite = false;
                    y++;
                }

                if (isNextWhite)
                {
                    cells[x, y] = new Cell(x, y, Cell.CellColor.White);
                    isNextWhite = false;
                }
                else
                {
                    cells[x, y] = new Cell(x, y, Cell.CellColor.Black);
                    isNextWhite = true;
                }
                y++;
            }
        }
    }
}
