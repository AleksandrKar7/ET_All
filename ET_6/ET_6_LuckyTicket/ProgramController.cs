using ET_6_LuckyTicket.Data;
using ET_6_LuckyTicket.Logics;
using ET_6_LuckyTicket.Logics.Factory;

namespace ET_6_LuckyTicket
{
    class ProgramController
    {
        public static void ExecuteProgram(string[] args)
        {
            bool isNewTry = false;

            do
            {
                if (isNewTry)
                {
                    args = ConsoleUI.AskInputParams();
                    isNewTry = false;
                }

                if (!Validator.IsValid(args))
                {
                    Logger.Log.Info("ProgramController: "
                        + "Input data is not valid");

                    ConsoleUI.ShowMessage("Your data is not valid");

                    if (!ConsoleUI.AskСonfirmation("Do you want to retype them?",
                        new string[] { "YES", "Y" }))
                    {
                        Logger.Log.Info("ProgramController: "
                            + "Program completion. "
                            + "User refused to re-enter data");

                        break;
                    }

                    Logger.Log.Debug("ProgramController: "
                        + "Re-input data");

                    args = ConsoleUI.AskInputParams();

                    continue;
                }

                InputDTO inputData = Parser.Parse(args);
                if (inputData.Algorithm == 0)
                {
                    Logger.Log.Debug("ProgramController: "
                        + "The file doesn`t have key words");

                    ConsoleUI.ShowMessage("Your file doesn`t have key words");
                    if (!ConsoleUI.AskСonfirmation("Do you want to choose another file?",
                        new string[] { "YES", "Y" }))
                    {
                        break;
                    }

                    args = ConsoleUI.AskInputParams();

                    continue;
                }

                var factory = new LuckyTicketDeterminatorFactory();
                var counter = new LuckyTicketCounter(factory);

                ConsoleUI.ShowMessage("Number of lucky tickets: "
                    + inputData.Algorithm + " - " 
                    + counter.GetCountLuckyTickets(inputData.Algorithm.ToString()));


                if (ConsoleUI.AskСonfirmation("Do you want to continue?",
                    new string[] { "YES", "Y" }))
                {
                    Logger.Log.Info("ProgramController: "
                            + "Program continue. "
                            + "User confirmed continuation");

                    isNewTry = true;
                }
                else
                {
                    Logger.Log.Info("ProgramController: "
                            + "Program completion. "
                            + "User did't confirm continuation");

                    break;
                }
            } while (true);
        }
    }
}
