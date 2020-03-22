using System;
using ValidatorLibrary;

namespace ET_1_ChessBoard.Data
{
    public class Parser
    {
        public static InputData Parse(string[] args)
        {
            if (!BaseValidator.IsNotEmptyArgs(args))
            {
                throw new NullReferenceException("Array of parameters is null"); //81
            }
            if (!BaseValidator.IsCorrectLength(args, InputData.CountParams))
            {
                throw new ArgumentException(
                    "The number of parameters is incorrect. " +
                    "There must be: " + InputData.CountParams);
            }

            return new InputData
            {
                NumberOfRows = Int32.Parse(args[0]),
                NumberOfColumns = Int32.Parse(args[1]),
            };
        }
    }
}
