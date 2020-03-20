using System;

using ConsoleUILibrary;
using ET_5_NumberToText.Data;
using ET_5_NumberToText.Logics;
using ET_5_NumberToText.Logics.Translator;
using ValidatorLibrary;

namespace ET_5_NumberToText
{
    class ProgramController
    {
        private readonly Validator validator;
        private readonly ConsoleUI consoleUI;

        public ProgramController()
        {
            validator = new Validator(Logger.Log);
            consoleUI = new ConsoleUI(Logger.Log);
        }

        public void ExecuteProgramm(string[] args)
        {
            bool isNewTry = false;

            do
            {
                if (isNewTry)
                {
                    args = consoleUI.AskInputParams();
                    isNewTry = false;
                }

                if (!validator.IsValid(args))
                {
                    Console.WriteLine("Your data is not valid");
                    if (!consoleUI.AskСonfirmation("Do you want to retype them?",
                        new string[] { "YES", "Y" }))
                    {
                        break;
                    }

                    args = consoleUI.AskInputParams();

                    continue;
                }

                InputDTO inputDTO = Parser.Parse(args);
                NumberToTextConverter converter;

                switch (inputDTO.Algorithm)
                {
                    case InputDTO.Algorithms.English:
                        converter = new EnglishNumberToTextConverter();
                        break;
                    default:
                        converter = new EnglishNumberToTextConverter();
                        break;
                }

                Number number = new Number(inputDTO.Number, converter);

                if (number.CanConvertToText())
                {
                    Console.WriteLine(number.ConvertToText());
                }
                else
                {
                    Console.WriteLine(
                        "This converter can't convert the number. " +
                        "The number is too big.");
                }

                if (consoleUI.AskСonfirmation("Do you want to continue?",
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
    }
}
