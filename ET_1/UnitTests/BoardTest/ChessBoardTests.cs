using System;

using ET_1_ChessBoard;
using ET_1_ChessBoard.Logics.Boards;
using ET_1_ChessBoard.Logics.Figures;
using NUnit.Framework;

namespace ET_1_UnitTests.BoardTest
{
    class ChessBoardTests
    {
        [Test]
        public void InitBoard_LengthIsNegative_OverflowException()
        {
            //arrange
            ChessBoard board = new ChessBoard(-1, 1);
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
            ChessBoard board = new ChessBoard(1, -1);
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
            expected[0, 0] = new Cell(0, 0, Cell.CellColor.White);
            expected[0, 1] = new Cell(0, 1, Cell.CellColor.Black);
            expected[0, 2] = new Cell(0, 2, Cell.CellColor.White);
            expected[0, 3] = new Cell(0, 3, Cell.CellColor.Black);
            expected[0, 4] = new Cell(0, 4, Cell.CellColor.White);

            //act
            ChessBoard actual = new ChessBoard(rows, columns);
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

        //[Test]
        //public void SetStandardFiguresPlacement_OneLineEightCells_CorrectFigures()
        //{
        //    //arrange
        //    int rows = 1;
        //    int columns = 8;
        //    ChessFigure[,] expected = new ChessFigure[rows, columns];
        //    expected[0, 0] = new ChessFigure(0, 0,
        //        ChessFigure.FigureType.White | ChessFigure.FigureType.Rook);
        //    expected[0, 1] = new ChessFigure(0, 1,
        //        ChessFigure.FigureType.White | ChessFigure.FigureType.Knight);
        //    expected[0, 2] = new ChessFigure(0, 2,
        //        ChessFigure.FigureType.White | ChessFigure.FigureType.Bishop);
        //    expected[0, 3] = new ChessFigure(0, 3,
        //        ChessFigure.FigureType.White | ChessFigure.FigureType.King);
        //    expected[0, 4] = new ChessFigure(0, 4,
        //        ChessFigure.FigureType.White | ChessFigure.FigureType.Queen);
        //    expected[0, 5] = new ChessFigure(0, 5,
        //        ChessFigure.FigureType.White | ChessFigure.FigureType.Bishop);
        //    expected[0, 6] = new ChessFigure(0, 6,
        //        ChessFigure.FigureType.White | ChessFigure.FigureType.Knight);
        //    expected[0, 7] = new ChessFigure(0, 7,
        //        ChessFigure.FigureType.White | ChessFigure.FigureType.Rook);


        //    //act
        //    ChessBoard actual = new ChessBoard(rows, columns);
        //    actual.InitChessFigures();

        //    //assert
        //    bool result = true;
        //    for (int i = 0; i < actual.Figures.GetLength(0); i++)
        //    {
        //        if (actual.Figures[0, i].Type != expected[0, i].Type)
        //        {
        //            result = false;
        //            break;
        //        }
        //    }
        //    Assert.IsTrue(result);
        //}
    }
}
