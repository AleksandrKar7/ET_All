using System.IO;

namespace ET_4_FileParser.Logics
{
    interface IFileLinesReplacer
    {
        void ReplaceLines(string target, string newStr);
    }
}
