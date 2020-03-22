using System;

using ET_6_LuckyTicket.Logics.Determinators;
using ET_6_LuckyTicket.Logics;
using Xunit;

namespace ET_6_UnitTests.DeterminatorsTests
{
    public class LuckyTicketDeterminatorTests
    {
        [Fact]
        public void GetDigitsRange_Null_NullReferenceException()
        {
            //arrange          
            var determinator = new MoskowLuckyTicketDeterminator();

            //act

            //assert
            Assert.Throws<NullReferenceException>(
                () => determinator.GetDigitsRange(null));
        }

        [Fact]
        public void GetDigitsRange_NotRealTicket_ArgumentException()
        {
            //arrange          
            var determinator = new MoskowLuckyTicketDeterminator();

            //act

            //assert
            Assert.Throws<ArgumentException>(
                () => determinator.GetDigitsRange(new Ticket(-10, -10)));
        }

        [Fact]
        public void GetDigitsRange_1Number6Digits_6Length()
        {
            //arrange          
            var determinator = new MoskowLuckyTicketDeterminator();
            int number = 1;
            int digits = 6;
            int expected = 6;

            //act
            var actual = determinator.GetDigitsRange(
                new Ticket(number, digits));

            //assert
            Assert.Equal(expected, actual.Length);
        }
        [Fact]
        public void GetDigitsRange_1Number6Digits_LastItem1()
        {
            //arrange          
            var determinator = new MoskowLuckyTicketDeterminator();
            int number = 1;
            int digits = 6;
            int expected = 1;

            //act
            var actual = determinator.GetDigitsRange(
                new Ticket(number, digits));

            //assert
            Assert.Equal(expected, actual[actual.Length - 1]);
        }
    }
}
