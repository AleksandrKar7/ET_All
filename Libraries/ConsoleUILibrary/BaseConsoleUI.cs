using System;
using System.Linq;

using log4net;

namespace ConsoleUILibrary
{
    public abstract class BaseConsoleUI
    {
        private readonly ILog log;

        public BaseConsoleUI(ILog logger)
        {
            log = logger;
        }

        public abstract string[] AskInputParams();

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public int AskMenuItem(string message, string[] menuItems)
        {
            log.DebugFormat("BaseConsoleUI.AskMenuItem: "
                + "Asking ({0}) from ({1})" , message
                , String.Join(", ", menuItems));

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
                    log.Debug("BaseConsoleUI.AskMenuItem: "
                        + "Wrong item. Choose again");

                    Console.WriteLine("Wrong item. Choose again");
                }
            }

            log.InfoFormat("BaseConsoleUI.AskMenuItem: "
                + "Was chosen item ({0} - {1})"
                , result, menuItems[result]);

            return result;
        }

        public int AskMenuItem(string message, Type enumType)
        {
            log.DebugFormat("BaseConsoleUI.AskMenuItem: "
                + "Asking ({0}) from ({1})", message
                , enumType.Name);

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
                    log.Debug("BaseConsoleUI.AskMenuItem: "
                        + "Wrong item. Choose again");

                    Console.WriteLine("Wrong item. Choose again");
                }
            } while (!(values.Contains(result)));

            log.InfoFormat("BaseConsoleUI.AskMenuItem: "
                + "Was chosen item ({0} - {1})"
                , result, names[result]);

            return result;          
        }

        public bool? AskСonfirmation(string message)
        {
            log.DebugFormat("BaseConsoleUI.AskСonfirmation: "
                + "Asking confirmation for ({0})", message);

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
                log.Info("BaseConsoleUI.AskСonfirmation: null "
                    + "Text is null, return null");

                return null;
            }

            if (trueArray.Contains(text))
            {
                log.InfoFormat("BaseConsoleUI.AskСonfirmation: true "
                    + "Was entered ({0})", text);

                return true;
            }
            if (falseArray.Contains(text))
            {
                log.InfoFormat("BaseConsoleUI.AskСonfirmation: false "
                    + "Was entered ({0})", text);

                return false;
            }

            return null;
        }

        public bool AskСonfirmation(string message, string[] trueArray)
        {
            if (trueArray == null)
            {
                log.Info("BaseConsoleUI.AskСonfirmation: false "
                    + "TrueArray is null");

                return false;
            }

            log.DebugFormat("BaseConsoleUI.AskСonfirmation: "
                + "Asking confirmation for ({0}) "
                + "Variants for true: ({1})"
                , message, String.Join(", ", trueArray));

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
                log.Info("BaseConsoleUI.AskСonfirmation: false "
                    + "Text is null, return false");

                return false;
            }

            if (trueArray.Contains(text))
            {
                log.InfoFormat("BaseConsoleUI.AskСonfirmation: true "
                    + "Was entered ({0})", text);

                return true;
            }
            else
            {
                log.InfoFormat("BaseConsoleUI.AskСonfirmation: false "
                    + "Was entered ({0})", text);

                return false;
            }
        }

        public bool? AskСonfirmation(string message, string[] trueArray, string[] falseArray)
        {
            if (trueArray == null)
            {
                log.Info("BaseConsoleUI.AskСonfirmation: false "
                    + "TrueArray is null");

                return null;
            }
            if (falseArray == null)
            {
                log.Info("BaseConsoleUI.AskСonfirmation: false "
                    + "FalseArray is null");

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
                log.Info("BaseConsoleUI.AskСonfirmation: false "
                    + "Text is null, return false");

                return null;
            }
            if (trueArray.Contains(text))
            {
                log.InfoFormat("BaseConsoleUI.AskСonfirmation: true "
                    + "Was entered ({0})", text);

                return true;
            }
            if (falseArray.Contains(text))
            {
                log.InfoFormat("BaseConsoleUI.AskСonfirmation: false "
                    + "Was entered ({0})", text);

                return false;
            }

            log.InfoFormat("BaseConsoleUI.AskСonfirmation: null "
                + "Nothing was chosen");
            return null;
        }
    }
}
