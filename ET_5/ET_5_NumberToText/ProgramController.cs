﻿using System;

using ConsoleUILibrary;
using ET_5_NumberToText.Data;
using ET_5_NumberToText.Logics;
using ET_5_NumberToText.Logics.Translators;
using ValidatorLibrary;

namespace ET_5_NumberToText
{
    class ProgramController
    {
        public void ExecuteProgram(string[] args)
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

                InputDTO inputDTO = Parser.Parse(args);
                NumberToTextConverter converter;

                Logger.Log.Debug("ProgramController: "
                    + "Type of translator selected: " 
                    + inputDTO.Algorithm.ToString());

                switch (inputDTO.Algorithm)
                {
                    case InputDTO.Algorithms.English:
                        converter = new EnglishNumberToTextConverter();
                        break;
                    default:
                        converter = new EnglishNumberToTextConverter();
                        break;
                }

                NumberTranslator translator = new NumberTranslator(converter);

                if (translator.CanConvertToText(inputDTO.Number))
                {
                    ConsoleUI.ShowMessage(
                        translator.ConvertToText(inputDTO.Number));
                }
                else
                {
                    Logger.Log.InfoFormat("ProgramController: "
                        + "translator {0} can't convert {1}"
                        , inputDTO.Algorithm.ToString()
                        , inputDTO.Number);

                    ConsoleUI.ShowMessage(
                        "This converter can't convert the number. " +
                        "The number is too big.");
                }

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
