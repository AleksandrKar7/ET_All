using System;
using System.IO;

using log4net;

namespace ValidatorLibrary
{
    public abstract class BaseValidator
    {
        private readonly ILog log;

        public BaseValidator(ILog logger)
        {
            log = logger;
        }

        public abstract bool IsValid(string[] args);

        public bool IsEmptyArr(string[] args)
        {
            log.Debug("Validator.IsEmptyArr: " +
                "Checking for a null array of arguments");

            if(args == null)
            {
                log.Info("Validator.IsEmptyArr: False " +
                    "Array is null");

                return false;
            }

            log.Info("Validator.IsEmptyArr: True " +
                "Array is not null");

            return true;
        }

        public bool DoesNotContainNull(string[] args)
        {
            log.Debug("Validator.DoesContainNull: " +
                "Checking for a null item in the array of arguments");

            for(int i = 0; i < args.Length; i++)
            {
                if (args[i] == null)
                {
                    log.InfoFormat("Validator.DoesContainNull: False " +
                        "Item {0} in the array is null", i);

                    return false;
                }
            }

            log.Info("Validator.DoesContainNull: True " +
                "All items in the array are not null");

            return true;
        }

        public bool IsCorrectLength(string[] args, int expectedLength)
        {
            log.DebugFormat("Validator.IsCorrectLength: " +
                "Comparing array length with expected length ({0})",
                expectedLength);

            if (args.Length != expectedLength)
            {
                log.InfoFormat("Validator.IsCorrectLength: False " +
                    "The array length ({0}) is not equal to the expected ({1})",
                    args.Length, expectedLength);

                return false;
            }

            log.InfoFormat("Validator.IsCorrectLength: True " +
                "The array length is equal to the expected ({1})",
                expectedLength);

            return true;
        }

        public bool IsCorrectLength(string[] args, int minLength, int maxLength)
        {
            log.DebugFormat("Validator.IsCorrectLength: " +
                "Comparing array length with expected range ({0} - {1})",
                minLength, maxLength);

            if (args.Length < minLength)
            {
                log.InfoFormat("Validator.IsCorrectLength: False " +
                    "The array length ({0}) is less than ({1})",
                    args.Length, minLength);

                return false;
            }
            if (args.Length > maxLength)
            {
                log.InfoFormat("Validator.IsCorrectLength: False " +
                    "The array length ({0}) is greater than ({1})",
                    args.Length, maxLength);

                return false;
            }

            log.InfoFormat("Validator.IsCorrectLength: True " +
                "The array length is equal to the expected range ({0} - {1})",
                 minLength, maxLength);

            return true;
        }

        public bool DoesFileExist(string filePath)
        {
            log.DebugFormat("Validator.DoesFileExist: " +
                "Checking for existing the file ({0})",
                 filePath);

            if (!File.Exists(filePath))
            {
                log.InfoFormat("Validator.DoesFileExist: False " +
                    "The file ({0}) does not exist",
                    filePath);

                return false;
            }

            log.InfoFormat("Validator.DoesFileExist: True " +
                "The file ({0}) does exist",
                filePath);

            return true;
        }

        public bool CanParseToInt16(string str, bool onlyPositive)
        {
            log.DebugFormat("Validator.CanParseToInt16: " +
                "Checking for possibility to parse ({0}) to Int16",
                 str);

            Int16 temp;
            if (!Int16.TryParse(str, out temp))
            {
                log.InfoFormat("Validator.CanParseToInt16: False " +
                    "The string ({0}) in not a number",
                    str);

                return false;
            }
            if(onlyPositive && temp < 0)
            {
                log.InfoFormat("Validator.CanParseToInt16: False " +
                    "The string ({0}) contains a negative number ({1})",
                    str, temp);

                return false;
            }

            log.InfoFormat("Validator.CanParseToInt16: True " +
                "The string ({0}) can be parsed to ({1})",
                str, temp);

            return true;
        }

        public bool CanParseToInt32(string str, bool onlyPositive)
        {
            log.DebugFormat("Validator.CanParseToInt32: " +
                "Checking for possibility to parse ({0}) to Int16",
                 str);

            Int32 temp;
            if (!Int32.TryParse(str, out temp))
            {
                log.InfoFormat("Validator.CanParseToInt32: False " +
                    "The string ({0}) in not a number",
                    str);

                return false;
            }
            if (onlyPositive && temp < 0)
            {
                log.InfoFormat("Validator.CanParseToInt32: False " +
                    "The string ({0}) contains a negative number ({1})",
                    str, temp);

                return false;
            }

            log.InfoFormat("Validator.CanParseToInt32: True " +
                "The string ({0}) can be parsed to ({1})",
                str, temp);

            return true;
        }

        public bool CanParseToInt64(string str, bool onlyPositive)
        {
            log.DebugFormat("Validator.CanParseToInt64: " +
                "Checking for possibility to parse ({0}) to Int16",
                 str);

            Int64 temp;
            if (!Int64.TryParse(str, out temp))
            {
                log.InfoFormat("Validator.CanParseToInt64: False " +
                    "The string ({0}) in not a number",
                    str);

                return false;
            }
            if (onlyPositive && temp < 0)
            {
                log.InfoFormat("Validator.CanParseToInt64: False " +
                    "The string ({0}) contains a negative number ({1})",
                    str, temp);

                return false;
            }

            log.InfoFormat("Validator.CanParseToInt64: True " +
                "The string ({0}) can be parsed to ({1})",
                str, temp);

            return true;
        }

        public bool CanParseToDouble(string str, bool onlyPositive)
        {
            log.DebugFormat("Validator.CanParseToDouble: " +
                "Checking for possibility to parse ({0}) to Int16",
                 str);

            Double temp;
            if (!Double.TryParse(str, out temp))
            {
                log.InfoFormat("Validator.CanParseToDouble: False " +
                    "The string ({0}) in not a number",
                    str);

                return false;
            }
            if (onlyPositive && temp < 0)
            {
                log.InfoFormat("Validator.CanParseToDouble: False " +
                    "The string ({0}) contains a negative number ({1})",
                    str, temp);

                return false;
            }

            log.InfoFormat("Validator.CanParseToDouble: True " +
                "The string ({0}) can be parsed to ({1})",
                str, temp);

            return true;
        }

        public bool DoesContainEnum(string str, Type enumType)
        {
            return DoesContainEnum(str, Enum.GetValues(enumType));
        }

        public bool DoesContainEnum(string str, Array enumArr)
        {
            log.DebugFormat("Validator.DoesContainEnum: " +
                "Checking for a emum item in string ({0}) ",
                 str);

            foreach (var item in enumArr)
            {
                if(str == item.ToString())
                {
                    log.InfoFormat("Validator.DoesContainEnum: True " +
                        "The enum have ({0})", str);

                    return true;
                }
            }

            log.InfoFormat("Validator.DoesContainEnum: True " +
                "The enum  does not have ({0})", str);

            return false;
        }
    }
}
