using System;

using ValidatorLibrary;

namespace ET_3_Triangles.Data
{
    public class Validator : BaseValidator
    {
        public static bool IsValidRange(string[] args)
        {
            if (!IsNotEmptyArgs(args))
            {
                return false;
            }
            if (args.Length == 0 || args.Length % InputData.CountParams != 0)
            {
                return false;
            }

            for(int i = 0; i < args.Length; i += InputData.CountParams)
            {
                if (!IsValid(new string[]{ 
                    args[i], args[i + 1], args[i + 2], args[i + 3] }))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsValid(string[] args)
        {
            return IsNotEmptyArgs(args)
                && IsCorrectLength(args, InputData.CountParams)
                && CanParseToDouble(args[1], true)
                && CanParseToDouble(args[2], true)
                && CanParseToDouble(args[3], true);
        }
    }
}
