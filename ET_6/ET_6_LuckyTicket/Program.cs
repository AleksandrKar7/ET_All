using System;

namespace ET_6_LuckyTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Logger.Log.Debug("Program started");

                ProgramController.ExecuteProgram(args);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong: " + e.Message);
                Logger.Log.Fatal(e.ToString());

                Console.WriteLine("Press enter to exit");
                Console.ReadKey();
            }
            
        }
    }
}
