using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_3_Triangles.Data
{
    public static class Parser
    {
        public static char[] GetSeparators()
        {
            return new char[] { ',', ';' };
        }

        public static InputData[] ParseRange(string[] args)
        {
            if (args == null)
            {
                throw new NullReferenceException("Array of parameters is null"); //81
            }
            if (args.Length == 0 || args.Length % InputData.CountParams != 0)
            {
                throw new ArgumentException(
                    "The number of parameters is incorrect. " +
                    "There must be multiple of: " + InputData.CountParams);
            }

            List<InputData> result = new List<InputData>();

            for (int i = 0; i < args.Length; i += InputData.CountParams)
            {
                result.Add(Parse(new string[]{
                    args[i], args[i + 1], args[i + 2], args[i + 3] }));
            }

            return result.ToArray();
        }

        public static InputData Parse(string[] args)
        {
            if (args == null)
            {
                throw new NullReferenceException("Array of parameters is null"); //81
            }
            if (args.Length != InputData.CountParams)
            {
                throw new ArgumentException(
                    "The number of parameters is incorrect. " +
                    "There must be: " + InputData.CountParams);
            }

            return new InputData
            {
                Name = args[0],
                SideA = Double.Parse(args[1]),
                SideB = Double.Parse(args[2]),
                SideC = Double.Parse(args[3])
            };
        }

        public static IFigure[] GetArrayTriangel(InputData[] inputData)
        {
            List<Triangle> result = new List<Triangle>();

            foreach (InputData data in inputData)
            {
                result.Add(new Triangle(
                    data.Name, data.SideA, data.SideB, data.SideC));
            }

            return result.ToArray();
        }

        public static string[] ReseparateArgs(string[] args, params char[] separators)
        {
            string line = String.Join("", args);
            string[] arr = line.Split(separators);
            Array.Resize(ref arr, arr.Length - 1);
            return arr;
        }
    }
}
