using System;

using NUnit.Framework;
using ET_2_Envelopes;

namespace ET_2_UnitTests.EnvelopesTests
{
    class RectangularEnvelopeTests
    {
        [Test]
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
            Assert.IsTrue(result);
        }
        [Test]
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
            Assert.IsFalse(result);
        }

        [Test]
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
            Assert.IsTrue(result);
        }
        [Test]
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
            Assert.IsFalse(result);
        }
    }
}
