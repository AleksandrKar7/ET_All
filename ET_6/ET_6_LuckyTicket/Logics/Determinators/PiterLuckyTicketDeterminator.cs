
namespace ET_6_LuckyTicket.Logics.Determinators
{
    public class PiterLuckyTicketDeterminator : LuckyTicketDeterminator
    {
        public override string Name { get; set; } = "Piter";

        public override bool IsLuckyTicket(Ticket ticket)
        {
            int[] digits = GetDigitsRange(ticket);

            int evenSum = 0;
            int oddSum= 0;

            for (int i = 0; i < digits.Length; i+=2)
            {
                evenSum += digits[i];
            }
            for (int i = 1; i < digits.Length; i+=2)
            {
                oddSum += digits[i];
            }

            return evenSum == oddSum;
        }        
    }
}
