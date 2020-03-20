
namespace ET_6_LuckyTicket.Data
{
    class InputData
    {
        public enum Algorithms
        {
            Moskow = 1,
            Piter = 2
        }
        

        public string FilePath { get; set; }
        public string[] AlgorithmsArr { get; set; }

        public const int CountParams = 1;
    }
}
