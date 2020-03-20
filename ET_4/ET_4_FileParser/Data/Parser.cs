using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_4_FileParser.Data
{
    static class Parser
    {
        public static InputData Parse(string[] args)
        {
            Logger.Log.Debug("Parser.Parse: " +
                "Start parsing an array of arguments");

            if (args == null)
            {
                Logger.Log.Error("Parser.Parse: Array of parameters is null");

                throw new NullReferenceException("Array of parameters is null"); //81
            }
            if (args.Length < InputData.MinCountParams ||
                args.Length > InputData.MaxCountParams)
            {
                Logger.Log.ErrorFormat(
                    "Parser.Parse: " +
                    "The number of parameters is incorrect ({0})",
                    args.Length);

                throw new ArgumentException(
                    "The number of parameters is incorrect. " +
                    "There must be: " + InputData.MinCountParams + " " +
                    "or " + InputData.MaxCountParams);
            }
            if (!File.Exists(args[0]))
            {
                Logger.Log.ErrorFormat(
                    "Parser.Parse: File not found ({0})" + args[0]);

                throw new FileNotFoundException();
            }

            Logger.Log.InfoFormat(
                "Parser.Parse: args successfully parsed ({0}, {1}, {2})"
                , args[0], args[1], args[2]);

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
