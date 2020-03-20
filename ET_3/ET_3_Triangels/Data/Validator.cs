using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_3_Triangles.Data
{
    public static class Validator
    {
        public static bool IsValidRange(string[] args)
        {
            if (args == null)
            {
                return false;
            }
            if (args.Length == 0 || args.Length % InputData.CountParams != 0)
            {
                return false;
            }

            for(int i = 0; i < args.Length; i += InputData.CountParams)
            {
                if (!IsValid(new string[]{ 
                    args[i], args[i + 1], args[i + 2], args[i + 3] }))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsValid(string[] args)
        {
            if (args == null)
            {
                return false;
            }
            if (args.Length == 0 || args.Length % InputData.CountParams != 0)
            {
                return false;
            }

            double temp;
            for (int i = 1; i < args.Length; i++)
            {
                if (Double.TryParse(args[i], out temp))
                {
                    if (temp < 0)
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
