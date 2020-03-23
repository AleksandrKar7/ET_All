using System;
using ValidatorLibrary;

namespace ET_7_8_Square_Fibonacci.Data
{
    public static class Parser
    {
        public static InputData ParseArgs(string[] args)
        {
            if (!BaseValidator.IsNotEmptyArgs(args))
            {
                throw new NullReferenceException("Array of parameters is null"); //81
            }
            if (!BaseValidator.IsCorrectLength(args
                , InputData.MinCountParams, InputData.MaxCountParams))
            {
                throw new ArgumentException(
                    "The number of parameters is incorrect. " +
                    "There must be: " + InputData.MinCountParams + " " +
                    "or " + InputData.MaxCountParams);
            }

            if(BaseValidator.IsCorrectLength(args, InputData.MaxCountParams))
            {
                return new InputData
                {
                    ProgramMode = InputData.Mode.Fibonacci,
                    StartFibonacciRange = Int32.Parse(args[0]),
                    EndFibonacciRange = Int32.Parse(args[1]),                   
                };
            }
            else
            {
                return new InputData
                {
                    ProgramMode = InputData.Mode.Square,
                    SquaryValue = Int32.Parse(args[0]),                
                };
            }

        }
    }
}
