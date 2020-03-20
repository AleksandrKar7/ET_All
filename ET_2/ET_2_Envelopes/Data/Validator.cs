using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_2_Envelopes.Data
{
    public static class Validator
    {
        public static bool IsValid(string[] args)
        {
            if (args == null)
            {
                return false;
            }
            if(args.Length != InputData.CountParams)
            {
                return false;
            }

            double temp;
            for(int i = 0; i < args.Length; i++)
            {
                if(Double.TryParse(args[i], out temp))
                {
                    if(temp < 0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
