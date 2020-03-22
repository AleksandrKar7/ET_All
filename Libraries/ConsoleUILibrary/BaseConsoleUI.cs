using System;
using System.Linq;

namespace ConsoleUILibrary
{
    public class BaseConsoleUI
    {
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static int AskMenuItem(string message, string[] menuItems)
        {
            int i = 1;
            int result = 0;

            Console.WriteLine(message);
            foreach (string item in menuItems)
            {
                Console.WriteLine(i + " - " + item);
                i++;
            }

            while(result >= 1 && result <= menuItems.Length)
            {            
                if (!(result >= 1 && result <= menuItems.Length
                    || Int32.TryParse(Console.ReadLine(), out result)))
                {
                    Console.WriteLine("Wrong item. Choose again");
                }
            }

            return result;
        }

        public static int AskMenuItem(string message, Type enumType)
        {
            int result = 0;
            
            int[] values = (int[])Enum.GetValues(enumType); 
            string[] names = Enum.GetNames(enumType);

            Console.WriteLine(message);
            for(int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(values[i] + " - " + names[i]);
            }

            do
            {
                if (!Int32.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Wrong item. Choose again");
                }
            } while (!(values.Contains(result)));

            return result;          
        }

        public static bool? AskСonfirmation(string message)
        {
            string text;
            string insturction;
            string[] trueArray = { "T", "TRUE" };
            string[] falseArray = { "F", "FALSE" };

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

        public static bool AskСonfirmation(string message, string[] trueArray)
        {
            if (trueArray == null)
            {
                return false;
            }

            string text;
            string insturction;

            insturction = String.Format("For agree: {0}; For disagree: '{1}'",
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

        public static bool? AskСonfirmation(string message, string[] trueArray, string[] falseArray)
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
