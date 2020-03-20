using System;

using ET_1_ChessBoard;
using ET_1_ChessBoard.Logics.Boards;
using NUnit.Framework;

namespace ET_1_UnitTests.BoardTest
{
    class BoardTests
    {
        [Test]
        public void InitBoard_LengthIsNegative_OverflowException()
        {
            //arrange
            Board board = new Board(-1, 1);
            Type expected = new OverflowException().GetType();

            //act
            TestDelegate actual = () => board.InitCells();

            //assert
            Assert.Throws(expected, actual);
        }
        [Test]
        public void InitBoard_HeightIsNegative_OverflowException()
        {
            //arrange
            Board board = new Board(1, -1);
            Type expected = new OverflowException().GetType();

            //act
            TestDelegate actual = () => board.InitCells();

            //assert
            Assert.Throws(expected, actual);
        }

        [Test]
        public void InitBoard_OneLineFiveCells_CorrectColor()
        {
            //arrange
            int rows = 1;
            int columns = 5;
            Cell[,] expected = new Cell[rows, columns];
            expected[0, 0] = new Cell(1, 1, Cell.CellColor.White);
            expected[0, 1] = new Cell(1, 2, Cell.CellColor.Black);
            expected[0, 2] = new Cell(1, 3, Cell.CellColor.White);
            expected[0, 3] = new Cell(1, 4, Cell.CellColor.Black);
            expected[0, 4] = new Cell(1, 5, Cell.CellColor.White);

            //act
            Board actual = new Board(rows, columns);
            actual.InitCells();

            //assert
            bool result = true;
            for (int i = 0; i < actual.Cells.GetLength(0); i++)
            {
                if (actual.Cells[0, i].Color != expected[0, i].Color)
                {
                    result = false;
                    break;
                }
            }
            Assert.IsTrue(result);
        }
    }
}
