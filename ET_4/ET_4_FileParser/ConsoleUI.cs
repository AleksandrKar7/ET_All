using System;

using ConsoleUILibrary;
using ET_4_FileParser.Data;

namespace ET_4_FileParser
{
    public class ConsoleUI : BaseConsoleUI
    {
        public static void PrintArray(string message, string[] arr)
        {
            Console.WriteLine(message);
            foreach (string item in arr)
            {
                Console.WriteLine(item);
            }
        }

        public static string[] AskInputParams(int countParams)
        {
            string[] result = new string[countParams];

            Console.WriteLine("Enter the file path");
            result[0] = Console.ReadLine();
            Console.WriteLine("Enter the search string");
            result[1] = Console.ReadLine();
            if (countParams == InputData.MaxCountParams)
            {
                Console.WriteLine("Enter the string substitute");
                result[2] = Console.ReadLine();
            }

            return result;
        }
    }
}
