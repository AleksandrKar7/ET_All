using System;
using System.IO;
using ValidatorLibrary;

namespace ET_6_LuckyTicket.Data
{
    class Validator : BaseValidator
    {
        public static bool IsValid(string[] args)
        {
            return IsNotEmptyArgs(args)
                && IsCorrectLength(args, InputDTO.CountParams)
                && DoesNotContainNull(args)
                && DoesFileExist(args[0])
                && DoesFileContainsSingleEnum(args[0]);
        }

        public static bool DoesFileContainsSingleEnum(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            string str;
            InputDTO.Algorithms algorithm = 0;
            bool doesFoundItem = false;

            while (!reader.EndOfStream)
            {
                str = reader.ReadLine().Trim();
                if (Enum.TryParse(str, out algorithm))
                {
                    if (doesFoundItem)
                    {
                        return false;
                    }
                    doesFoundItem = true;
                }
            }

            return doesFoundItem;
        }
    }
}
