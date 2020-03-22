using System;
using System.Collections.Generic;

using ConsoleUILibrary;
using ET_3_Triangles.Data;

namespace ET_3_Triangles
{
    class ConsoleUI : BaseConsoleUI
    {
        public static string[] AskInputRangeParams()
        {
            List<string> result = new List<string>();

            do
            {
                result.AddRange(AskInputParams());
                if (!BaseConsoleUI.AskСonfirmation("Do you want to add a new triangel?"
                    , new string[] { "YES", "Y" }))
                {
                    break;
                }
            } while (true);

            return result.ToArray();
        }

        public static string[] AskInputParams()
        {
            string[] result;
            string line;

            Console.WriteLine("Input format (separator - comma):");
            Console.WriteLine("<name>, <side A length>, <side B length>" +
                ", <side C length>");

            line = Console.ReadLine();
            result = line.Split(Parser.GetSeparators());

            return result;
        }
    }
}
