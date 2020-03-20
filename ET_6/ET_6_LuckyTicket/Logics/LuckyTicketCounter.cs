using System;
using System.Collections.Generic;

using ET_6_LuckyTicket.Logics.Factory;

namespace ET_6_LuckyTicket.Logics
{
    public class LuckyTicketCounter
    {
        public const int DefaultCountDigits = 6;
        public const int DefaultStart = 1;
        public const int DefaultEnd = 999999;

        private LuckyTicketDeterminatorFactory factory;
        public LuckyTicketCounter(
            LuckyTicketDeterminatorFactory factory)
        {
            this.factory = factory;
        }

        public int[] GetRangeCountLuckyTickets(string[] algorithmNames,
            int start = DefaultStart, int end = DefaultEnd,
            int countDigits = DefaultCountDigits)
        {
            List<int> result = new List<int>();

            foreach(string algorithm in algorithmNames)
            {
                result.Add(GetCountLuckyTickets(algorithm,
                    start, end, countDigits));
            }

            return result.ToArray();
        }

        public int GetCountLuckyTickets(string algorithmName,
            int start = DefaultStart, int end = DefaultEnd,
            int countDigits = DefaultCountDigits)
        {
            if(start > end)
            {
                throw new ArgumentException("End can't be less than start");
            }
            if(!Ticket.IsRealTicket(start, DefaultCountDigits) || 
                !Ticket.IsRealTicket(end, DefaultCountDigits))
            {
                throw new ArgumentException("");
            }

            var determinator = factory.CreateDeterminator(algorithmName);
            int count = 0;

            for(int i = start; i <= end; i++)
            {
                if(determinator.IsLuckyTicket(new Ticket(i, countDigits)))
                {
                    ++count;
                }
            }

            return count;
        }
    }
}
