﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_4_FileParser.Logics
{
    public class FileParser : IFileLinesSearcher
        , IFileLinesReplacer, IDisposable
    {
        #region private

        private StreamReader reader;
        private StreamWriter writer;
        private string mainFilePath;
        private string tempFilePath = "Test";

        #endregion

        public void Dispose()
        {
            reader.Dispose();
            writer.Dispose();
        }

        public void OpenFile(string filePath)
        {
            Logger.Log.DebugFormat("FileParser.OpenFile " +
                "Start opening a file ({0})", filePath);

            if (!File.Exists(filePath))
            {
                Logger.Log.ErrorFormat("FileParser.OpenFile " +
                    "File not found ({0})", filePath);

                throw new FileNotFoundException("File not found");
            }
            mainFilePath = filePath;
            reader = new StreamReader(mainFilePath);
            writer = new StreamWriter(tempFilePath, false);

            Logger.Log.InfoFormat("FileParser.OpenFile " +
                "File open ({0})", filePath);
        }

        public string[] FindLines(string target)
        {
            return FindLines(reader, target);
        }

        public string[] FindLines(StreamReader reader, string target)
        {
            Logger.Log?.DebugFormat("FileParser.OpenFile " +
                "Start finding a line ({0}) in file ", target);

            if (reader == null)
            {
                Logger.Log?.Error("FileParser.FindLines " +
                    "File not open");

                throw new InvalidOperationException("The file not open. " +
                    "Use OpenFile() first");
            }
            if (reader.EndOfStream)
            {
                Logger.Log.Info("FileParser.ReplaceLines " +
                    "File already read. Set reader.BaseStream.Position = 0");

                reader.BaseStream.Position = 0;
            }

            List<string> matchStrs = new List<string>();
            string temp;

            while (!reader.EndOfStream)
            {
                temp = reader.ReadLine();
                if (temp.Contains(target))
                {
                    matchStrs.Add(temp);
                }
            }

            Logger.Log?.InfoFormat("FileParser.OpenFile " +
                "({0}) lines found", matchStrs.Count);

            return matchStrs.ToArray();
        }

        public void ReplaceLines(string target, string newStr)
        {
            ReplaceLines(reader, writer, target, newStr);
        }

        public void ReplaceLines(StreamReader reader, StreamWriter writer, string target, string newStr)
        {
            Logger.Log.DebugFormat("FileParser.ReplaceLines " 
                + "Start replacing a line ({0}) to ({1}) in file ",
                target, newStr);

            if (reader == null || writer == null)
            {
                Logger.Log.Error("FileParser.ReplaceLines " +
                    "File not open");

                throw new InvalidOperationException("The file is not open. " +
                    "Use OpenFile() first");
            }
            if (reader.EndOfStream)
            {
                Logger.Log.Error("FileParser.ReplaceLines " +
                    "File already read. Set reader.BaseStream.Position = 0");
                reader.BaseStream.Position = 0;
            }

            string temp;
            while (!reader.EndOfStream)
            {
                temp = reader.ReadLine();
                temp = temp.Replace(target, newStr);
                writer.WriteLine(temp);
            }

            reader.Close();
            writer.Close();

            Logger.Log.Info("FileParser.OpenFile " +
                "strings replaced successfully");
        }

        public void ReplaceAndDeleteTempFile()
        {
            File.Copy(tempFilePath, mainFilePath, true);
            File.Delete(tempFilePath);
        }
    }
}
