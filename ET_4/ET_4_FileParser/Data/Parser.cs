using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidatorLibrary;

namespace ET_4_FileParser.Data
{
    static class Parser
    {
        public static InputData Parse(string[] args)
        {
            if (!BaseValidator.IsNotEmptyArgs(args))
            {
                throw new NullReferenceException("Array of parameters is null"); //81
            }
            if (!BaseValidator.IsCorrectLength(args
                , InputData.MinCountParams, InputData.MaxCountParams))
            {
                throw new ArgumentException(
                    "The number of parameters is incorrect. " +
                    "There must be: " + InputData.MinCountParams + " " +
                    "or " + InputData.MaxCountParams);
            }
            if (BaseValidator.DoesFileExist(args[0]))
            {
                throw new FileNotFoundException();
            }

            return new InputData
            {
                PathToFile = args[0],
                TargetStr = args[1],
                ReplaceStr = args.Length > InputData.MinCountParams ?
                    args[2] : null,
                Mode = args.Length == InputData.MaxCountParams ? 
                    InputData.ProgramMode.ReplaceStr :
                    InputData.ProgramMode.SearchStr
            };
        }
    }
}
