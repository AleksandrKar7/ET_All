using System;

using ET_7_8_Square_Fibonacci.Data;
using ET_7_8_Square_Fibonacci.Logics;

namespace ET_7_8_Square_Fibonacci
{
    static class ProgramController
    {
        public static void ExecuteProgram(string[] args)
        {
            bool isNewTry = false;
            int result;

            do
            {
                if (isNewTry)
                {
                    result = ConsoleUI.AskMenuItem("Choose program mode",
                       new string[] { InputData.Mode.Square.ToString(),
                            InputData.Mode.Fibonacci.ToString() });

                    args = ConsoleUI.AskInputParams((InputData.Mode)result);
                    isNewTry = false;
                }

                if (!Validator.IsValidArgs(args))
                {
                    Console.WriteLine("Your data is not valid");
                    if (!ConsoleUI.AskСonfirmation("Do you want to retype them?",
                        new string[] { "YES", "Y" }))
                    {
                        break;
                    }

                    result = ConsoleUI.AskMenuItem("Choose program mode",
                        new string[] { InputData.Mode.Square.ToString(),
                            InputData.Mode.Fibonacci.ToString() });

                    args = ConsoleUI.AskInputParams((InputData.Mode)result);

                    continue;
                }

                InputData inputData = Parser.ParseArgs(args);

                switch (inputData.ProgramMode)
                {
                    case InputData.Mode.Square:
                        ISquareSeriesFinder square = new MathFinder();
                        int[] squareSeries = square.GetSquareSeries(
                            inputData.SquaryValue);
                        ConsoleUI.PrintArray("Square series: "
                            , squareSeries);
                        break;

                    case InputData.Mode.Fibonacci:
                        IFibonacciSeriesMaker fibonacci = new MathFinder();
                        int[] fibonacciSeries = fibonacci.GetFibonacciSeries(
                            inputData.StartFibonacciRange
                            , inputData.EndFibonacciRange);
                        ConsoleUI.PrintArray("Fibonacci series: "
                            , fibonacciSeries);
                        break;
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
