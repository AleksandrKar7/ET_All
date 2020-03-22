using System;

using ET_4_FileParser.Data;
using ET_4_FileParser.Logics;

namespace ET_4_FileParser
{
    public static class ProgramController
    {
        public static void ExecuteProgram(string[] args)
        {
            bool isNewTry = false;
            int result;

            do
            {
                if (isNewTry)
                {
                    result = ConsoleUI.AskMenuItem("Choose mode",
                        new string[] { "Search string in file",
                            "replacing a line in a file" });

                    switch (result)
                    {
                        case 1:
                            args = ConsoleUI.AskInputParams(
                                InputData.MinCountParams);
                            break;
                        case 2:
                            args = ConsoleUI.AskInputParams(
                                InputData.MaxCountParams);
                            break;
                    }
                    isNewTry = false;
                }

                if (!Validator.IsValid(args))
                {
                    ConsoleUI.ShowMessage("Your data is not valid");
                    if (!ConsoleUI.AskСonfirmation("Do you want to retype them?"
                        , new string[] { "YES", "Y" }))
                    {
                        break;
                    }

                    result = ConsoleUI.AskMenuItem("Choose board type",
                        new string[] { "Search string in file",
                            "replacing a line in a file" });

                    switch (result)
                    {
                        case 1:
                            args = ConsoleUI.AskInputParams(
                                InputData.MinCountParams);
                            break;
                        case 2:
                            args = ConsoleUI.AskInputParams(
                                InputData.MaxCountParams);
                            break;
                    }
                    continue;
                }

                InputData inputData = Parser.Parse(args);
                using (FileParser parser = new FileParser())
                {
                    parser.OpenFile(inputData.PathToFile);

                    switch (inputData.Mode)
                    {
                        case InputData.ProgramMode.SearchStr:
                            string[] match =
                                parser.FindLines(inputData.TargetStr);
                            ConsoleUI.PrintArray("Found strings: ", match);
                            break;

                        case InputData.ProgramMode.ReplaceStr:
                            parser.ReplaceLines(inputData.TargetStr,
                                inputData.ReplaceStr);
                            parser.ReplaceAndDeleteTempFile();
                            break;
                    }
                }

                if (ConsoleUI.AskСonfirmation("Do you want to continue?",
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
