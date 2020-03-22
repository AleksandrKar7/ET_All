
using ET_2_Envelopes.Data;

namespace ET_2_Envelopes
{
    static class ProgramController
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
                    ConsoleUI.ShowMessage("Your data is not valid");
                    if (!ConsoleUI.AskСonfirmation("Do you want to retype them?"
                        , new string[] { "YES", "Y" }))
                    {
                        break;
                    }

                    args = ConsoleUI.AskInputParams();
                    continue;
                }

                InputData inputData = Parser.Parse(args);
                IEnvelope first = new RectangularEnvelope(
                    inputData.LengthFirst, inputData.HeightFirst);

                IEnvelope second = new RectangularEnvelope(
                    inputData.LengthSecond, inputData.HeightSecond);

                if (first.DoesFits(second) && second.DoesFits(first))
                {
                    ConsoleUI.ShowMessage("Both envelopes fit together");
                }
                else if (first.DoesFits(second))
                {
                    ConsoleUI.ShowMessage("The second envelope fits into the first envelope");
                }
                else if (second.DoesFits(first))
                {
                    ConsoleUI.ShowMessage("The first envelope fits into the second envelope");
                }
                else
                {
                    ConsoleUI.ShowMessage("None of the envelopes fit together");
                }

                if (ConsoleUI.AskСonfirmation("Do you want to continue?"
                    , new string[] { "YES", "Y" }))
                {
                    isNewTry = true;
                }
                else
                {
                    break;
                }
            } while (true);
        }
    }
}
