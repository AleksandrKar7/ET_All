using System;

using ConsoleUILibrary;
using ET_1_ChessBoard.Data;

namespace ET_1_ChessBoard
{
    class ConsoleUI : BaseConsoleUI
    {
        public static string[] AskInputParams()
        {
            string[] result = new string[InputData.CountParams];

            Console.WriteLine("Enter the number of rows for board");
            result[0] = Console.ReadLine();
            Console.WriteLine("Enter the number of columns for board");
            result[1] = Console.ReadLine();

            return result;
        }
    }
}
