using ET_6_LuckyTicket.Logics.Determinators;

namespace ET_6_LuckyTicket.Logics.Factory
{
    public class LuckyTicketDeterminatorFactory : ILuckyTicketDeterminatorFactory
    {
        public LuckyTicketDeterminator CreateDeterminator(string name)
        {
            if(name == null)
            {
                return null;
            }

            name = name.ToLower();
            if(name == "moskow")
            {
                return new MoskowLuckyTicketDeterminator();
            }
            if (name == "piter")
            {
                return new PiterLuckyTicketDeterminator();
            }

            return null;
        }
    }
}
