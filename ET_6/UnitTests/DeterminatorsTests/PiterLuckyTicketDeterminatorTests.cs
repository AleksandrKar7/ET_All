using ET_6_LuckyTicket.Logics;
using ET_6_LuckyTicket.Logics.Determinators;

using Xunit;

namespace ET_6_UnitTests.DeterminatorsTests
{
    public class PiterLuckyTicketDeterminatorTests
    {
        [Fact]
        public void IsLuckyTicket_NotLuckyTicketNumber505050Digit6_False()
        {
            //arrange          
            var determinator = new PiterLuckyTicketDeterminator();
            int number = 505050;
            int digit = 6;

            //act
            var actual = determinator.IsLuckyTicket(new Ticket(number, digit));

            //assert
            Assert.False(actual);
        }

        [Fact]
        public void IsLuckyTicket_LuckyTicketNumber112233Digit6_True()
        {
            //arrange          
            var determinator = new PiterLuckyTicketDeterminator();
            int number = 112233;
            int digit = 6;

            //act
            var actual = determinator.IsLuckyTicket(new Ticket(number, digit));

            //assert
            Assert.True(actual);
        }
    }
}
