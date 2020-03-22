
using ET_1_ChessBoard.Data;
using ET_1_ChessBoard.Logics.Boards;
using ET_1_ChessBoard.Logics.Printers;

namespace ET_1_ChessBoard
{
    static class ProgramController
    {
        public static void ExecuteProgram(string[] args)
        {
            bool isNewTry = false;
            do
            {
                if (isNewTry)
                {
                    args = ConsoleUI.AskInputParams();
                    isNewTry = false;
                }

                if (!Validator.IsValid(args))
                {
                    ConsoleUI.ShowMessage("Your data is not valid");
                    if (!ConsoleUI.AskСonfirmation("Do you want to retype them?",
                        new string[] { "YES", "Y" }))
                    {
                        break;
                    }

                    args = ConsoleUI.AskInputParams();
                    continue;
                }

                InputData inputData = Parser.Parse(args);

                Board board = new Board(inputData.NumberOfRows,
                    inputData.NumberOfColumns);
                board.InitCells();
                ConsolePrinter.PrintEmptyBoard(board);

                if (ConsoleUI.AskСonfirmation("Do you want to continue?",
                    new string[] { "YES", "Y" }))
                {
                    isNewTry = true;
                }
                else
                {
                    break;
                }
            } while (true);
        }
    }
}
