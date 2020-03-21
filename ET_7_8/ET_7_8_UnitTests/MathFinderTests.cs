
using ET_7_8_Square_Fibonacci.Logics;
using Xunit;

namespace ET_7_8_UnitTests
{
    public class MathFinderTests
    {
        [Fact]
        public void GetSquareSeries_NegativeNumber_EmptyArr()
        {
            //arrange          
            int number = -10;
            MathFinder mathFinder = new MathFinder();

            //act
            var actual = mathFinder.GetSquareSeries(number);

            //assert
            Assert.Empty(actual);
        }

        [Fact]
        public void GetSquareSeries_Number8_3Items()
        {
            //arrange          
            int number = 8;
            MathFinder mathFinder = new MathFinder();

            int expected = 3;

            //act
            var actual = mathFinder.GetSquareSeries(number);

            //assert
            Assert.Equal(expected, actual.Length);
        }

        [Fact]
        public void GetSquareSeries_Number0_NoItems()
        {
            //arrange          
            int number = 0;
            MathFinder mathFinder = new MathFinder();

            //act
            var actual = mathFinder.GetSquareSeries(number);

            //assert
            Assert.Empty(actual);
        }

        [Fact]
        public void GetFibonacciSeries_StartNegativeEndNegative_NoItems()
        {
            //arrange          
            int start = -10;
            int end = -10;
            MathFinder mathFinder = new MathFinder();

            //act
            var actual = mathFinder.GetFibonacciSeries(start, end);

            //assert
            Assert.Empty(actual);
        }

        [Fact]
        public void GetFibonacciSeries_EndLessThanStart_NoItems()
        {
            //arrange          
            int start = 10;
            int end = 5;
            MathFinder mathFinder = new MathFinder();

            //act
            var actual = mathFinder.GetFibonacciSeries(start, end);

            //assert
            Assert.Empty(actual);
        }

        [Fact]
        public void GetFibonacciSeries_Start0End3_3Items()
        {
            //arrange          
            int start = 0;
            int end = 3;
            MathFinder mathFinder = new MathFinder();

            int expected = 3;

            //act
            var actual = mathFinder.GetFibonacciSeries(start, end);

            //assert
            Assert.Equal(expected, actual.Length);
        }
    }
}
