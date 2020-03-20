using System.IO;

namespace ET_6_LuckyTicket.Data
{
    static class Validator
    {
        public static bool IsValid(string[] args)
        {
            if (args == null)
            {
                return false;
            }
            if (args.Length != InputData.CountParams)
            {
                return false;
            }

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == null)
                {
                    return false;
                }
            }

            if (!File.Exists(args[0]))
            {
                return false;
            }

            return true;
        }
    }
}
