using System;

using ConsoleUILibrary;
using ET_7_8_Square_Fibonacci.Data;

namespace ET_7_8_Square_Fibonacci
{
    public class ConsoleUI : BaseConsoleUI
    {
        public static string[] AskInputParams(InputData.Mode mode)
        {
            string[] result;
            if (mode == InputData.Mode.Square)
            {
                result = new string[InputData.MinCountParams];
                Console.WriteLine("Enter the end of range: ");
                result[0] = Console.ReadLine();

                return result;
            }
            if (mode == InputData.Mode.Fibonacci)
            {
                result = new string[InputData.MaxCountParams];
                Console.WriteLine("Enter the start of fibonacci series: ");
                result[0] = Console.ReadLine();
                Console.WriteLine("Enter the end of fibonacci series: ");
                result[1] = Console.ReadLine();

                return result;
            }

            throw new InvalidOperationException("Unsupported InputData.Mode");
        }

        public static void PrintArray(string message, int[] arr)
        {
            Console.WriteLine(message);
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
