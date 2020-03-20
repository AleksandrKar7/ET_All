﻿using System;
using System.Linq;

using ET_4_FileParser.Data;
using ET_4_FileParser.Logics;

namespace ET_4_FileParser
{
    static class ConsoleMenu
    {
        public static void ShowConsoleMenu(string[] inputParams)
        {
            bool isNewTry = false;
            int result;

            do
            {
                if (isNewTry)
                {
                    result = AskMenuItem("Choose mode",
                        new string[] { "Search string in file",
                            "replacing a line in a file" });

                    switch (result)
                    {
                        case 1:
                            inputParams = AskInputParams(
                                InputData.MinCountParams);
                            break;
                        case 2:
                            inputParams = AskInputParams(
                                InputData.MaxCountParams);
                            break;
                    }
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

                    result = AskMenuItem("Choose board type",
                        new string[] { "Search string in file",
                            "replacing a line in a file" });

                    switch (result)
                    {
                        case 1:
                            inputParams = AskInputParams(
                                InputData.MinCountParams);
                            break;
                        case 2:
                            inputParams = AskInputParams(
                                InputData.MaxCountParams);
                            break;
                    }
                    continue;
                }

                InputData inputData = Parser.Parse(inputParams);
                using (FileParser parser = new FileParser())
                {
                    parser.OpenFile(inputData.PathToFile);

                    switch (inputData.Mode)
                    {
                        case InputData.ProgramMode.SearchStr:
                            string[] match = 
                                parser.FindLines(inputData.TargetStr);
                            PrintArray("Found strings: ", match);
                            break;

                        case InputData.ProgramMode.ReplaceStr:
                            parser.ReplaceLines(inputData.TargetStr, 
                                inputData.ReplaceStr);
                            break;
                    }
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

        private static void PrintArray(string message, string[] arr)
        {
            Console.WriteLine(message);
            foreach(string item in arr)
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
            if(countParams == InputData.MaxCountParams)
            {
                Console.WriteLine("Enter the string substitute");
                result[2] = Console.ReadLine();
            }

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
