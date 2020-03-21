using System.IO;

namespace ET_4_FileParser.Logics
{
    interface IFileLinesSearcher
    {
        string[] FindLines(string target);
    }
}
