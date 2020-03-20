
namespace ET_6_LuckyTicket.Logics.Determinators
{
    public class MoskowLuckyTicketDeterminator : LuckyTicketDeterminator
    {
        public override string Name { get; set; } = "Moskow";

        public override bool IsLuckyTicket(Ticket ticket)
        {
            int[] digits = GetDigitsRange(ticket);

            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < digits.Length / 2; i++)
            {
                leftSum += digits[i];
            }
            for (int i = digits.Length / 2; i < digits.Length; i++)
            {
                rightSum += digits[i];
            }

            return leftSum == rightSum;
        }
    }
}
