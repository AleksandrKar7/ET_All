
namespace ET_6_LuckyTicket.Data
{
    class InputDTO
    {
        public enum Algorithms
        {
            Moskow = 1,
            Piter = 2
        }       

        public string FilePath { get; set; }
        public Algorithms Algorithm { get; set; }

        public const int CountParams = 1;
    }
}
