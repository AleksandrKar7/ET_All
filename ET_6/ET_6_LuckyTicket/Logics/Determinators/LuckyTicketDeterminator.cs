using System;
using System.Collections.Generic;

namespace ET_6_LuckyTicket.Logics.Determinators
{
    public abstract class LuckyTicketDeterminator
    {
        public abstract string Name { get; set; }
        //public abstract string[] Names { get; set; }
        //public abstract string GetNames();
        //public abstract bool IsHisName(string name);
        //{
        //    return Names.Contains(name);
        //}

        public abstract bool IsLuckyTicket(Ticket ticket);

        public int[] GetDigitsRange(Ticket ticket)
        {
            if(ticket == null)
            {
                throw new NullReferenceException("Ticket is null");
            }
            if (!ticket.IsRealTicket())
            {
                throw new ArgumentException("Ticket is not valid. " +
                    "Use IsRealTicket() to check");
            }

            int[] result  = new int[ticket.CountDigits];
            List<int> temp = new List<int>();
            int num = ticket.Number;
         
            while (num > 0)
            {
                temp.Add(num % 10);
                num /= 10;
            }
            temp.Reverse();

            //aligns number to count of digits e.g. 00ХХХХ 
            temp.CopyTo(result, ticket.CountDigits - temp.Count);

            return result;
        }
    }
}
