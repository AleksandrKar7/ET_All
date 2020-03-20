using Xunit;

using ET_6_LuckyTicket.Logics.Determinators;
using ET_6_LuckyTicket.Logics.Factory;

namespace ET_6_UnitTests.Factory
{
    public class LuckyTicketDeterminatorFactoryTests
    {
        [Fact]
        public void CreateDeterminator_NullStr_Null()
        {
            //arrange          
            var factory = new LuckyTicketDeterminatorFactory();
            
            //act
            var actual = factory.CreateDeterminator(null);

            //assert
            Assert.Null(actual);
        }

        [Fact]
        public void CreateDeterminator_StrMoskow_MoskowLuckyTicketDeterminator()
        {
            //arrange          
            var factory = new LuckyTicketDeterminatorFactory();

            //act
            var actual = factory.CreateDeterminator("Moskow");

            //assert
            Assert.IsType<MoskowLuckyTicketDeterminator>(actual);
        }

        [Fact]
        public void CreateDeterminator_StrPiter_PiterLuckyTicketDeterminator()
        {
            //arrange          
            var factory = new LuckyTicketDeterminatorFactory();

            //act
            var actual = factory.CreateDeterminator("Piter");

            //assert
            Assert.IsType<PiterLuckyTicketDeterminator>(actual);
        }
    }
}
