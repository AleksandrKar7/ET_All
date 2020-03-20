using ET_1_ChessBoard.Data;
using ET_1_ChessBoard.Logics.Boards;
using ET_1_ChessBoard.Logics.Printers;
using System;
using System.Linq;

namespace ET_1_ChessBoard
{
    class ConsoleMenu
    {
        public static void ShowConsoleMenu(string[] inputParams)
        {
            bool isNewTry = false;
            do
            {
                if (isNewTry)
                {
                    inputParams = AskInputParams();
                    isNewTry = false;
                }

                if (!Validator.IsValid(inputParams))
                {
                    Console.WriteLine("Your data is not valid");
                    if (!AskBoolValue("Do you want to retype them?",
                        new string[] { "YES", "Y" }))
                    {
                        break;
                    }

                    inputParams = AskInputParams();
                    continue;
                }

                InputData inputData = Parser.Parse(inputParams);

                int result = AskMenuItem("Choose board type",
                    new string[]{ "Empty board", "Chess board with pieces"});

                switch (result)
                {
                    case 1:
                        Board board = new Board(inputData.NumberOfRows,
                            inputData.NumberOfColumns);
                        board.InitCells();
                        ConsolePrinter.PrintEmptyBoard(board);
                        break;

                    case 2:
                        ChessBoard chessBoard = new ChessBoard(
                            inputData.NumberOfRows, inputData.NumberOfColumns);
                        chessBoard.InitCells();
                        chessBoard.InitChessFigures();
                        ConsolePrinter.PrintChessBoard(chessBoard);
                        break;
                }   

                if (AskBoolValue("Do you want to continue?", 
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

        public static string[] AskInputParams()
        {
            string[] result = new string[InputData.CountParams];

            Console.WriteLine("Enter the number of rows for board");
            result[0] = Console.ReadLine();
            Console.WriteLine("Enter the number of columns for board");
            result[1] = Console.ReadLine();

            return result;
        }

        public static int AskMenuItem(string message, string[] menuItems)
        {
            int i = 1;
            int result;
            Console.WriteLine(message);
            foreach(string item in menuItems)
            {
                Console.WriteLine(i + " - " + item);
                i++;
            }

            do
            {
                Int32.TryParse(Console.ReadLine(), out result);
                if(result >= 1 && result <= menuItems.Length)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong item. Choose again");
                }
            } while (true);

            return result;
        }

        public static bool? AskBoolValue(string message)
        {
            string text;
            string insturction;
            string[] trueArray = { "T", "TRUE" };
            string[] falseArray = { "F", "FALSE" };

            insturction = String.Format("For true: {0}; For false: '{1}'",
                String.Join("', ", trueArray), String.Join("', ", falseArray));

            Console.WriteLine(message);
            Console.WriteLine(insturction);

            text = Console.ReadLine();
            text.Trim();
            text = text.ToUpper();

            if (text == null)
            {
                return null;
            }

            if (trueArray.Contains(text))
            {
                return true;
            }
            if (falseArray.Contains(text))
            {
                return false;
            }

            return null;
        }

        public static bool AskBoolValue(string message, string[] trueArray)
        {
            if (trueArray == null)
            {
                return false;
            }
            string text;
            string insturction;


            insturction = String.Format("For true: {0}; For false: '{1}'",
                String.Join("', ", trueArray), "Press enter");

            Console.WriteLine(message);
            Console.WriteLine(insturction);

            text = Console.ReadLine();
            text.Trim();
            text = text.ToUpper();

            if (text == null)
            {
                return false;
            }

            if (trueArray.Contains(text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool? AskBoolValue(string message, string[] trueArray, string[] falseArray)
        {
            if (trueArray == null)
            {
                return null;
            }
            if (falseArray == null)
            {
                return null;
            }
            string text;
            string insturction;

            insturction = String.Format("For agree: {0}; For disagree: '{1}'",
                String.Join("', ", trueArray), String.Join("', ", falseArray));

            Console.WriteLine(message);
            Console.WriteLine(insturction);

            text = Console.ReadLine();
            text.Trim();
            text = text.ToUpper();

            if (text == null)
            {
                return null;
            }
            if (trueArray.Contains(text))
            {
                return true;
            }
            if (falseArray.Contains(text))
            {
                return false;
            }

            return null;
        }
    }
}
