using System;

using ET_1_ChessBoard;
using ET_1_ChessBoard.Logics.Boards;
using Xunit;

namespace ET_1_UnitTest
{
    public class BoardTests
    {
        [Fact]
        public void InitBoard_LengthIsNegative_OverflowException()
        {
            //arrange
            Board board = new Board(-1, 1);
            Type expected = new OverflowException().GetType();

            //act

            //assert
            Assert.Throws<OverflowException>(() => board.InitCells());
        }

        [Fact]
        public void InitBoard_HeightIsNegative_OverflowException()
        {
            //arrange
            Board board = new Board(1, -1);
            Type expected = new OverflowException().GetType();

            //act

            //assert
            Assert.Throws<OverflowException>(() => board.InitCells());
        }

        [Fact]
        public void InitBoard_OneLineFiveCells_CorrectColor()
        {
            //arrange
            int rows = 1;
            int columns = 5;
            Cell[,] expected = new Cell[rows, columns];
            expected[0, 0] = new Cell(0, 0, Cell.CellColor.White);
            expected[0, 1] = new Cell(0, 1, Cell.CellColor.Black);
            expected[0, 2] = new Cell(0, 2, Cell.CellColor.White);
            expected[0, 3] = new Cell(0, 3, Cell.CellColor.Black);
            expected[0, 4] = new Cell(0, 4, Cell.CellColor.White);

            //act
            Board actual = new Board(rows, columns);
            actual.InitCells();

            //assert
            bool result = true;
            for (int column = 0; column < columns; column++)
            {
                if (actual[0, column].Color != expected[0, column].Color)
                {
                    result = false;
                    break;
                }
            }

            Assert.True(result);
        }
    }
}
