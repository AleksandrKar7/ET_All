using ET_6_LuckyTicket.Logics.Determinators;

namespace ET_6_LuckyTicket.Logics.Factory
{
    public class LuckyTicketDeterminatorFactory : ILuckyTicketDeterminatorFactory
    {
        public LuckyTicketDeterminator CreateDeterminator(string name)
        {
            if(name == "Moskow")
            {
                return new MoskowLuckyTicketDeterminator();
            }
            if (name == "Piter")
            {
                return new PiterLuckyTicketDeterminator();
            }

            return null;

            //LuckyTicketDeterminator result;
            //if (MoskowLuckyTicketDeterminator.IsHisName(name))
            //{
            //    return new MoskowLuckyTicketDeterminator();
            //}
            //if (PiterLuckyTicketDeterminator.IsHisName(name))
            //{
            //    return new PiterLuckyTicketDeterminator();
            //}
        }
    }
}
