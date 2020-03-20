using log4net;
using ValidatorLibrary;

namespace ET_5_NumberToText.Data
{
    public class Validator : BaseValidator
    {
        public Validator(ILog logger) : base(logger)
        {

        }

        public override bool IsValid(string[] args)
        {
            return IsEmptyArr(args)
                && IsCorrectLength(args, InputDTO.CountParams)
                && DoesNotContainNull(args)
                && CanParseToInt64(args[0], false)
                && DoesContainEnum(args[1], typeof(InputDTO.Algorithms));
        }
    }
}
