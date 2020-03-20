
using ET_6_LuckyTicket.Logics;
using ET_6_LuckyTicket.Logics.Determinators;
using Xunit;

namespace ET_6_UnitTests.Determinators
{
    public class MoskowLuckyTicketDeterminatorTests
    {
        [Fact]
        public void IsLuckyTicket_NotLuckyTicketNumber555000Digit6_False()
        {
            //arrange          
            var determinator = new MoskowLuckyTicketDeterminator();
            int number = 555000;
            int digit = 6;

            //act
            var actual = determinator.IsLuckyTicket(new Ticket(number, digit));

            //assert
            Assert.False(actual);
        }

        [Fact]
        public void IsLuckyTicket_LuckyTicketNumber123123Digit6_True()
        {
            //arrange          
            var determinator = new MoskowLuckyTicketDeterminator();
            int number = 123123;
            int digit = 6;

            //act
            var actual = determinator.IsLuckyTicket(new Ticket(number, digit));

            //assert
            Assert.True(actual);
        }
    }
}
