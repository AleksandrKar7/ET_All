using System;

using ET_3_Triangles.Data;

namespace ET_3_Triangles
{
    static class ProgramController
    {
        public static void ExecuteProgram(string[] args)
        {
            bool isNewTry = false;
            args = Parser.ReseparateArgs(args,
                Parser.GetSeparators());
            do
            {
                if (isNewTry)
                {
                    args = ConsoleUI.AskInputRangeParams();
                    isNewTry = false;
                }

                if (!Validator.IsValidRange(args))
                {
                    Console.WriteLine("Your data is not valid");
                    if (!ConsoleUI.AskСonfirmation("Do you want to retype them?",
                        new string[] { "YES", "Y" }))
                    {
                        break;
                    }

                    args = ConsoleUI.AskInputRangeParams();
                    continue;
                }

                InputData[] inputData = Parser.ParseRange(args);

                IFigure[] figures = Parser.GetArrayTriangel(inputData);
                figures.SortByArea();

                foreach (IFigure figure in figures)
                {
                    Console.WriteLine(String.Format("[{0}]: {1}",
                        figure.Name,
                        Double.IsNaN(figure.GetArea()) ? "not real triangel" : figure.GetArea().ToString()));
                }

                if (ConsoleUI.AskСonfirmation("Do you want to continue?"
                    , new string[] { "YES", "Y" }))
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
