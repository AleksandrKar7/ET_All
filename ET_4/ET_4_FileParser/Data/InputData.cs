using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_4_FileParser.Data
{
    class InputData
    {
        public enum ProgramMode
        {
            SearchStr = 1,
            ReplaceStr = 2
        }

        public string PathToFile { get; set; }
        public string TargetStr { get; set; }
        public string ReplaceStr { get; set; }
        public ProgramMode Mode { get; set; }

        public const int MinCountParams = 2;
        public const int MaxCountParams = 3;
    }
}
