using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_2_Envelopes.Data
{
    public static class Parser
    {
        public static InputData Parse(string[] args)
        {
            if(args == null)
            {
                throw new NullReferenceException("Array of parameters is null"); //81
            }
            if(args.Length != InputData.CountParams)
            {
                throw new ArgumentException(
                    "The number of parameters is incorrect. " +
                    "There must be: " + InputData.CountParams);
            }

            return new InputData {
                LengthFirst = Double.Parse(args[0]),
                HeightFirst = Double.Parse(args[1]),
                LengthSecond = Double.Parse(args[2]),
                HeightSecond = Double.Parse(args[3])
            };
        }
    }
}
