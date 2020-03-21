using System;
using System.IO;

using log4net;

namespace ValidatorLibrary
{
    public abstract class BaseValidator
    {
        public abstract bool IsValid(string[] args);

        public bool IsEmptyArr(string[] args)
        {
            if(args == null)
            {
                return false;
            }

            return true;
        }

        public bool DoesNotContainNull(string[] args)
        {
            for(int i = 0; i < args.Length; i++)
            {
                if (args[i] == null)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsCorrectLength(string[] args, int expectedLength)
        {
            if (args.Length != expectedLength)
            {
                return false;
            }

            return true;
        }

        public bool IsCorrectLength(string[] args, int minLength, int maxLength)
        {
            if (args.Length < minLength)
            {
                return false;
            }
            if (args.Length > maxLength)
            {
                return false;
            }

            return true;
        }

        public bool DoesFileExist(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            return true;
        }

        public bool CanParseToInt16(string str, bool onlyPositive)
        {
            Int16 temp;
            if (!Int16.TryParse(str, out temp))
            {
                return false;
            }
            if(onlyPositive && temp < 0)
            {
                return false;
            }

            return true;
        }

        public bool CanParseToInt32(string str, bool onlyPositive)
        {
            Int32 temp;
            if (!Int32.TryParse(str, out temp))
            {
                return false;
            }
            if (onlyPositive && temp < 0)
            {
                return false;
            }

            return true;
        }

        public bool CanParseToInt64(string str, bool onlyPositive)
        {
            Int64 temp;
            if (!Int64.TryParse(str, out temp))
            {
                return false;
            }
            if (onlyPositive && temp < 0)
            {
                return false;
            }

            return true;
        }

        public bool CanParseToDouble(string str, bool onlyPositive)
        {
            Double temp;
            if (!Double.TryParse(str, out temp))
            {
                return false;
            }
            if (onlyPositive && temp < 0)
            {
                return false;
            }

            return true;
        }

        public bool DoesContainEnum(string str, Type enumType)
        {
            return DoesContainEnum(str, Enum.GetValues(enumType));
        }

        public bool DoesContainEnum(string str, Array enumArr)
        {
            foreach (var item in enumArr)
            {
                if(str == item.ToString())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
