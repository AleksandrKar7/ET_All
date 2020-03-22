using System;

using ConsoleUILibrary;
using ET_2_Envelopes.Data;

namespace ET_2_Envelopes
{
    class ConsoleUI : BaseConsoleUI
    {
        public static string[] AskInputParams()
        {
            string[] result = new string[InputData.CountParams];

            Console.WriteLine("Enter the length for the first envelope");
            result[0] = Console.ReadLine();
            Console.WriteLine("Enter the height for the first envelope");
            result[1] = Console.ReadLine();

            Console.WriteLine("Enter the length for the second envelope");
            result[2] = Console.ReadLine();
            Console.WriteLine("Enter the height for the second envelope");
            result[3] = Console.ReadLine();

            return result;
        }
    }
}
