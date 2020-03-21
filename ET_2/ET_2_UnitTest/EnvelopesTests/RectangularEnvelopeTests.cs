using ET_2_Envelopes;
using Xunit;

namespace ET_2_UnitTest.EnvelopesTests
{
    public class RectangularEnvelopeTests
    {
        [Fact]
        public void DoesFits_TryPutSmallToBig_True()
        {
            //arrange
            int length = 10;
            int height = 5;
            double increaser = 0.1;

            var small = new RectangularEnvelope(length, height);
            var big = new RectangularEnvelope(length + increaser, height + increaser);
            bool result;

            //act
            result = big.DoesFits(small);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void DoesFits_TryPutBigToSmall_False()
        {
            //arrange
            int length = 10;
            int height = 5;
            double increaser = 0.1;

            var small = new RectangularEnvelope(length, height);
            var big = new RectangularEnvelope(length + increaser, height + increaser);
            bool result;

            //act
            result = small.DoesFits(big);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void DoesFits_TryPutSmallRoundToBigRectangular_True()
        {
            //arrange
            int length = 10;
            int height = 5;

            double radius = 2.5;
            var small = new RoundEnvelope(radius);
            var big = new RectangularEnvelope(length, height);
            bool result;

            //act
            result = big.DoesFits(small);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void DoesFits_TryPutBigRoundToSmallRectangular_False()
        {
            //arrange
            int length = 10;
            int height = 5;

            double radius = 2.6;
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