using System;
using System.IO;

namespace ET_6_LuckyTicket.Data
{
    static class Parser
    {
        public static InputDTO Parse(string[] args)
        {
            if (args == null)
            {
                throw new NullReferenceException("Array of parameters is null"); //81
            }
            if(args.Length != InputDTO.CountParams)
            {
                throw new ArgumentException(
                    "The number of parameters is incorrect. " +
                    "There must be: " + InputDTO.CountParams);
            }
            if (!File.Exists(args[0]))
            {
                throw new FileNotFoundException();
            }

            StreamReader reader = new StreamReader(args[0]);
            string str;
            InputDTO.Algorithms algorithm = 0;
            bool doesFoundItem = false;
            
            while (!reader.EndOfStream)
            {
                str = reader.ReadLine().Trim();
                if(Enum.TryParse(str, out algorithm))
                {
                    if (doesFoundItem)
                    {
                        throw new ArgumentException(
                            "File contains several algorithms");
                    }
                    doesFoundItem = true;
                }
            }

            if(doesFoundItem == false)
            {
                throw new ArgumentException(
                    "The file dosen't contain an algorithm");
            }

            return new InputDTO
            {
                FilePath = args[0],
                Algorithm = algorithm
            };
        }
    }
}
