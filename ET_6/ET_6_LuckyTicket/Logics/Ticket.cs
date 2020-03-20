using System;

namespace ET_6_LuckyTicket.Logics
{
    public class Ticket
    {
        public int Number { get; set; }
        public int CountDigits { get; set; }

        public Ticket(int num, int countDigitsInNumber)
        {
            Number = num;
            CountDigits = countDigitsInNumber;
        }

        public bool IsRealTicket()
        {
            return IsRealTicket(Number, CountDigits);
            
            
            //if (Number < 0)
            //{
            //    return false;
            //}
            //if (Number > Math.Pow(10, CountDigits))
            //{
            //    return false;
            //}
            //return true;
            
        }

        public static bool IsRealTicket(int number, int countDigits)
        {
            if (number < 0 || countDigits < 0)
            {
                return false;
            }
            if (number > Math.Pow(10, countDigits))
            {
                return false;
            }

            return true;
        }
    }
}
