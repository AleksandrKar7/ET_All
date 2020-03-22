using System;
using System.IO;


namespace ValidatorLibrary
{
    public class BaseValidator
    {
        public static bool IsNotEmptyArgs(string[] args)
        {
            return args != null;
        }

        public static bool DoesNotContainNull(string[] args)
        {
            if(args == null)
            {
                return false;
            }

            for(int i = 0; i < args.Length; i++)
            {
                if (args[i] == null)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsCorrectLength(string[] args, int expectedLength)
        {
            if(args == null)
            {
                return false;
            }
            return args.Length == expectedLength;
        }

        public static bool IsCorrectLength(string[] args, int minLength, int maxLength)
        {
            if (args == null)
            {
                return false;
            }
            return args.Length >= minLength && args.Length <= maxLength;
        }

        public static bool DoesFileExist(string filePath)
        {
            return File.Exists(filePath);
        }

        public static bool CanParseToInt16(string str, bool onlyPositive)
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

        public static bool CanParseToInt32(string str, bool onlyPositive)
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

        public static bool CanParseToInt64(string str, bool onlyPositive)
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

        public static bool CanParseToDouble(string str, bool onlyPositive)
        {
            Double temp;
            if (!Double.TryParse(str, out temp))
            {
                return false;
            }
            if (Double.IsInfinity(temp))
            {
                return false;
            }
            if (onlyPositive && temp < 0)
            {
                return false;
            }

            return true;
        }

        public static bool DoesContainEnum(string str, Type enumType)
        {
            if(str == null || enumType == null 
                || enumType.BaseType.Name != "Enum")
            {
                return false;
            }

            return Enum.IsDefined(enumType, str);
        }
    }
}
