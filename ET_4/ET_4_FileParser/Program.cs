using ET_4_FileParser.Logics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_4_FileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.InitLogger();
            Logger.Log.Info("Program started");
            ConsoleMenu.ShowConsoleMenu(args);
        }
    }
}
