
using ET_2_Envelopes;
using Xunit;

namespace ET_2_UnitTest.EnvelopesTests
{
    public class RoundEnvelopeTests
    {
        [Fact]
        public void DoesFits_TryPutSmallRoundToBigRound_True()
        {
            //arrange
            int radius = 5;
            double increaser = 0.1;

            var small = new RoundEnvelope(radius);
            var big = new RoundEnvelope(radius + increaser);
            bool result;

            //act
            result = big.DoesFits(small);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void DoesFits_TryPutBigRoundToSmallRound_False()
        {
            //arrange
            int radius = 5;
            double increaser = 0.1;

            var small = new RoundEnvelope(radius);
            var big = new RoundEnvelope(radius + increaser);
            bool result;

            //act
            result = small.DoesFits(big);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void DoesFits_TryPutSmallRectangular_True()
        {
            //arrange
            int length = 10;
            int height = 5;

            double radius = 5.6;
            var small = new RectangularEnvelope(length, height);
            var big = new RoundEnvelope(radius);
            bool result;

            //act
            result = big.DoesFits(small);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void DoesFits_TryPutBigRectangular_False()
        {
            //arrange
            int length = 10;
            int height = 5;

            double radius = 5.5;
            var small = new RectangularEnvelope(length, height);
            var big = new RoundEnvelope(radius);
            bool result;

            //act
            result = small.DoesFits(big);

            //assert
            Assert.False(result);
        }
    }
}