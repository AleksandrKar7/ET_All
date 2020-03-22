using ValidatorLibrary;

namespace ET_1_ChessBoard.Data
{
    public class Validator : BaseValidator
    {
        public static bool IsValid(string[] args)
        {
            return IsNotEmptyArgs(args)
                && IsCorrectLength(args, InputData.CountParams)
                && CanParseToInt32(args[0], true)
                && CanParseToInt32(args[1], true);
        }
    }
}
