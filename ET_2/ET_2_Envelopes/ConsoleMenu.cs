using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ET_2_Envelopes.Data;

namespace ET_2_Envelopes
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
                    inputParams = AskInputParams();
                    isNewTry = false;
                }

                if (!Validator.IsValid(inputParams))
                {
                    Console.WriteLine("Your data is not valid");
                    if(!AskBoolValue("Do you want to retype them?",
                        new string[] { "YES", "Y" }))
                    {
                        break;
                    }

                    inputParams = AskInputParams();
                    continue;
                }

                InputData inputData = Parser.Parse(inputParams);
                IEnvelope first = new RectangularEnvelope(
                    inputData.LengthFirst, inputData.HeightFirst);

                IEnvelope second = new RectangularEnvelope(
                    inputData.LengthSecond, inputData.HeightSecond);

                if(first.DoesFits(second) && second.DoesFits(first))
                {
                    Console.WriteLine("Both envelopes fit together");
                }
                else if (first.DoesFits(second))
                {
                    Console.WriteLine("The second envelope fits into the first envelope");
                }
                else if (second.DoesFits(first))
                {
                    Console.WriteLine("The first envelope fits into the second envelope");
                }
                else
                {
                    Console.WriteLine("None of the envelopes fit together");
                }

                if(AskBoolValue("Do you want to continue?", new string[] { "YES", "Y" }))
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

            if(text == null)
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
