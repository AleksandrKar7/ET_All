
using Xunit;
using ET_6_LuckyTicket.Logics;


namespace ET_6_UnitTests
{
    public class TicketTests
    {
        [Fact]
        public void IsRealTicket_99Number1Digit_False()
        {
            //arrange          
            int number = 99;
            int digit = 1;

            //act
            var actual = Ticket.IsRealTicket(number, digit);

            //assert
            Assert.False(actual);
        }

        [Fact]
        public void IsRealTicket_Minus99Number2Digit_False()
        {
            //arrange          
            int number = -99;
            int digit = 2;

            //act
            var actual = Ticket.IsRealTicket(number, digit);

            //assert
            Assert.False(actual);
        }

        [Fact]
        public void IsRealTicket_99NumberMinus2Digit_False()
        {
            //arrange          
            int number = 99;
            int digit = -2;

            //act
            var actual = Ticket.IsRealTicket(number, digit);

            //assert
            Assert.False(actual);
        }

        [Fact]
        public void IsRealTicket_99Number2Digit_True()
        {
            //arrange          
            int number = 99;
            int digit = 2;

            //act
            var actual = Ticket.IsRealTicket(number, digit);

            //assert
            Assert.True(actual);
        }  
    }
}
