using ET_6_LuckyTicket.Logics.Determinators;

namespace ET_6_LuckyTicket.Logics.Factory
{
    interface ILuckyTicketDeterminatorFactory
    {
        LuckyTicketDeterminator CreateDeterminator(string name);
    }
}
