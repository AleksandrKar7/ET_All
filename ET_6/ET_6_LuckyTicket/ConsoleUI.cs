using ConsoleUILibrary;
using System;

using ET_6_LuckyTicket.Data;

namespace ET_6_LuckyTicket
{
    class ConsoleUI : BaseConsoleUI
    {
        public static string[] AskInputParams()
        {
            string[] result = new string[InputDTO.CountParams];

            Console.WriteLine("Enter the file path");
            result[0] = Console.ReadLine();

            return result;
        }
    }
}
