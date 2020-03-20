using System.IO;


namespace ET_4_FileParser.Data
{
    static class Validator
    {
        public static bool IsValid(string[] args)
        {
            Logger.Log.Debug("Validator.IsValid: " +
                "Start validating an array of arguments");

            if (args == null)
            {
                Logger.Log.Info("Validator.IsValid: False - " + 
                    "Array of parameters is null");

                return false;
            }
            if (args.Length < InputData.MinCountParams ||
                args.Length > InputData.MaxCountParams)
            {
                Logger.Log.InfoFormat(
                    "Validator.IsValid: False - " +
                    "The number of parameters is incorrect ({0})",
                    args.Length);

                return false;
            }

            for (int i = 0; i < InputData.MinCountParams; i++)
            {
                if(args[i] == null)
                {
                    Logger.Log.InfoFormat(
                        "Validator.IsValid: False - " +
                        "Parameter number {0} is null", i);

                    return false;
                }
            }

            if(!File.Exists(args[0]))
            {
                Logger.Log.InfoFormat(
                    "Validator.IsValid: False - " +
                    "File not found", args[0]);

                return false;
            }

            Logger.Log.InfoFormat(
                "Validator.IsValid: True");

            return true;
        }
    }
}
