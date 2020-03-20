using System;
using System.Linq;

using ET_6_LuckyTicket.Data;
using ET_6_LuckyTicket.Logics;
using ET_6_LuckyTicket.Logics.Factory;

namespace ET_6_LuckyTicket
{
    static class ConsoleMenu
    {
        public static void ShowConsoleMenu(string[] inputParams)
        {
            bool isNewTry = false;

            do
            {
                if (isNewTry)
                {
                    inputParams = AskInputParams(InputData.CountParams);
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

                    inputParams = AskInputParams(InputData.CountParams);

                    continue;
                }

                InputData inputData = Parser.Parse(inputParams);
                if(inputData.AlgorithmsArr.Length == 0)
                {
                    Console.WriteLine("Your file doesn`t have key words?");
                    if (!AskBoolValue("Do you want to choose another file?",
                        new string[] { "YES", "Y" }))
                    {
                        break;
                    }

                    inputParams = AskInputParams(InputData.CountParams);

                    continue;
                }

                var factory = new LuckyTicketDeterminatorFactory();
                var counter = new LuckyTicketCounter(factory);

                PrintKeyValueArr("Number of lucky tickets: ",
                    inputData.AlgorithmsArr,
                    counter.GetRangeCountLuckyTickets(inputData.AlgorithmsArr));

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

        private static void PrintArray(string message, string[] arr)
        {
            Console.WriteLine(message);
            foreach (string item in arr)
            {
                Console.WriteLine(item);
            }
        }

        private static void PrintArray(string message, int[] arr)
        {
            Console.WriteLine(message);
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
        }

        private static void PrintKeyValueArr(string message,
            string[] key, int[] value)
        {
            Console.WriteLine(message);
            for(int i = 0; i < key.Length; i++)
            {
                Console.WriteLine(key[i] + " : " + value[i]);
            }
        }

        public static string[] AskInputParams(int countParams)
        {
            string[] result = new string[countParams];

            Console.WriteLine("Enter the file path");
            result[0] = Console.ReadLine();

            return result;
        }

        public static int AskMenuItem(string message, string[] menuItems)
        {
            int i = 1;
            int result;
            Console.WriteLine(message);
            foreach (string item in menuItems)
            {
                Console.WriteLine(i + " - " + item);
                i++;
            }

            do
            {
                Int32.TryParse(Console.ReadLine(), out result);
                if (result >= 1 && result <= menuItems.Length)
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
