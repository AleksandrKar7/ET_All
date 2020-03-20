using System;
using System.Collections.Generic;
using System.IO;

namespace ET_6_LuckyTicket.Data
{
    static class Parser
    {
        public static InputData Parse(string[] args)
        {
            if (args == null)
            {
                throw new NullReferenceException("Array of parameters is null"); //81
            }
            if(args.Length != InputData.CountParams)
            {
                throw new ArgumentException(
                    "The number of parameters is incorrect. " +
                    "There must be: " + InputData.CountParams);
            }
            if (!File.Exists(args[0]))
            {
                throw new FileNotFoundException();
            }

            StreamReader reader = new StreamReader(args[0]);
            var algorithms = new List<string>();
            string str;
            while (!reader.EndOfStream)
            {
                str = reader.ReadLine();
                var item = FindAlgorithmInLine(str);
                if (item != 0)
                {
                    algorithms.Add(item.ToString());
                }
            }

            return new InputData
            {
                FilePath = args[0],
                AlgorithmsArr = algorithms.ToArray()
            };
        }

        public static InputData.Algorithms FindAlgorithmInLine(string line)
        {
            foreach(InputData.Algorithms item in Enum.GetValues(typeof(InputData.Algorithms)))
            {
                if (line.Contains(item.ToString()))
                {
                    return item;
                }
            }
            return 0;
        }
    }
}
