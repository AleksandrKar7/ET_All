using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ET_3_Triangles.Data;

namespace ET_3_Triangles
{
    static class ConsoleMenu
    {
        public static void ShowConsoleMenu(string[] inputParams)
        {
            bool isNewTry = false;
            inputParams = Parser.ReseparateArgs(inputParams,
                Parser.GetSeparators());
            do
            {
                if (isNewTry)
                {
                    inputParams = AskInputRangeParams();
                    isNewTry = false;
                }

                if (!Validator.IsValidRange(inputParams))
                {
                    Console.WriteLine("Your data is not valid");
                    if (!AskBoolValue("Do you want to retype them?",
                        new string[] { "YES", "Y" }))
                    {
                        break;
                    }

                    inputParams = AskInputRangeParams();
                    continue;
                }

                InputData[] inputData = Parser.ParseRange(inputParams);

                IFigure[] figures = Parser.GetArrayTriangel(inputData);
                FiguresSorter.SortByArea(ref figures);
                foreach (IFigure figure in figures)
                {
                    Console.WriteLine(String.Format("[{0}]: {1}",
                        figure.Name,
                        Double.IsNaN(figure.GetArea()) ? "not real triangel" : figure.GetArea().ToString()));
                }

                if (AskBoolValue("Do you want to continue?", new string[] { "YES", "Y" }))
                {
                    isNewTry = true;
                }
                else
                {
                    break;
                }
            } while (true);
        }

        public static string[] AskInputRangeParams()
        {
            List<string> result = new List<string>();

            do
            {
                result.AddRange(AskInputParams());
                if (!AskBoolValue("Do you want to add a new triangel?", new string[] { "YES", "Y" }))
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

