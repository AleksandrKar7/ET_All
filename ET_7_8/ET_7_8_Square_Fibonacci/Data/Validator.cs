using System;

using ValidatorLibrary;

namespace ET_7_8_Square_Fibonacci.Data
{
    public class Validator : BaseValidator
    {
        public static bool IsValidArgs(string[] args)
        {
            return IsNotEmptyArgs(args)
                && DoesNotContainNull(args)
                && IsCorrectLength(args, InputData.MinCountParams, InputData.MaxCountParams)
                && CanParseToInt32(args[0], true)
                && (IsCorrectLength(args, InputData.MaxCountParams) 
                    ? CanParseToInt32(args[1], true) : true);
        }
    }
}
