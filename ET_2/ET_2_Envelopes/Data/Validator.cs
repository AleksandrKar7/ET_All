using ValidatorLibrary;

namespace ET_2_Envelopes.Data
{
    public class Validator : BaseValidator
    {
        public static bool IsValid(string[] args)
        {
            return IsNotEmptyArgs(args)
                && IsCorrectLength(args, InputData.CountParams)
                && CanParseToDouble(args[0], true)
                && CanParseToDouble(args[1], true)
                && CanParseToDouble(args[2], true)
                && CanParseToDouble(args[3], true);
        }
    }
}
