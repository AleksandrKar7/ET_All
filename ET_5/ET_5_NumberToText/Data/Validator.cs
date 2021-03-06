﻿using ValidatorLibrary;

namespace ET_5_NumberToText.Data
{
    public class Validator : BaseValidator
    {
        public static bool IsValid(string[] args)
        {
            return IsNotEmptyArgs(args)
                && IsCorrectLength(args, InputDTO.CountParams)
                && DoesNotContainNull(args)
                && CanParseToInt64(args[0], false)
                && DoesContainEnum(args[1], typeof(InputDTO.Algorithms));
        }
    }
}
