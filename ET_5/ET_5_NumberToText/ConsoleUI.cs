using System;

using ConsoleUILibrary;
using ET_5_NumberToText.Data;
using log4net;

namespace ET_5_NumberToText
{
    public class ConsoleUI : BaseConsoleUI
    {
        public ConsoleUI(ILog logger) : base(logger)
        {
        }

        public override string[] AskInputParams()
        {
            string[] result = new string[InputDTO.CountParams];

            Console.WriteLine("Enter a number");
            result[0] = Console.ReadLine();

            result[1] = ((InputDTO.Algorithms)
                AskMenuItem("Choose language"
                , typeof(InputDTO.Algorithms))).ToString();

            return result;
        }
    }
}
