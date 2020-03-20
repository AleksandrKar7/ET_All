
namespace ET_1_ChessBoard
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CellColor Color { get; set; }

        public enum CellColor
        {
            White = 1,
            Black = 2
        }

        public Cell(int x, int y, CellColor color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
}
