using System;
using ValidatorLibrary;

namespace ET_5_NumberToText.Data
{
    public class Parser
    {
        public static InputDTO Parse(string[] args)
        {
            if (!BaseValidator.IsNotEmptyArgs(args))
            {
                throw new NullReferenceException("Array of parameters is null");
            }
            if (!BaseValidator.IsCorrectLength(args, InputDTO.CountParams))
            {
                throw new ArgumentException(
                    "The number of parameters is incorrect. " 
                    + "There must be: " + InputDTO.CountParams);
            }

            return new InputDTO()
            {
                Number = Int64.Parse(args[0]),
                Algorithm = (InputDTO.Algorithms)
                    Enum.Parse(typeof(InputDTO.Algorithms), args[1])
            };
        }

    }
}
