using System.IO;

using ValidatorLibrary;

namespace ET_4_FileParser.Data
{
    class Validator : BaseValidator
    {
        public static bool IsValid(string[] args)
        {
            return IsNotEmptyArgs(args)
                && DoesNotContainNull(args)
                && IsCorrectLength(args
                    , InputData.MinCountParams, InputData.MaxCountParams)
                && DoesFileExist(args[0]);
        }
    }
}
