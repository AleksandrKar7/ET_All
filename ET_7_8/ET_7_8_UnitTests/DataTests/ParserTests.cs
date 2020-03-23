using System;

using ET_7_8_Square_Fibonacci.Data;
using Xunit;

namespace ET_7_8_UnitTests.DataTests
{
    public class ParserTests
    {
        [Fact]
        public void Parse_Null_NullReferenceException()
        {
            //arrange
            string[] args = null;

            //act

            //assert
            Assert.Throws<NullReferenceException>(() => Parser.ParseArgs(args));
        }

        [Fact]
        public void Parse_LessThanMinimumCountParams_ArgumentException()
        {
            //arrange
            string[] args = new string[InputData.MinCountParams - 1];

            //act

            //assert
            Assert.Throws<ArgumentException>(() => Parser.ParseArgs(args));
        }

        [Fact]
        public void Parse_MoreThanMaximumCountParams_ArgumentException()
        {
            //arrange
            string[] args = new string[InputData.MaxCountParams + 1];

            //act

            //assert
            Assert.Throws<ArgumentException>(() => Parser.ParseArgs(args));
        }

        [Fact]
        public void Parse_EmptyArrMinimumCountParams_ArgumentNullException()
        {
            //arrange
            string[] args = new string[InputData.MinCountParams];

            //act

            //assert
            Assert.Throws<ArgumentNullException>(() => Parser.ParseArgs(args));
        }

        [Fact]
        public void Parse_EmptyArrMaximumCountParams_ArgumentNullException()
        {
            //arrange
            string[] args = new string[InputData.MaxCountParams];

            //act

            //assert
            Assert.Throws<ArgumentNullException>(() => Parser.ParseArgs(args));
        }

        [Fact]
        public void Parse_AllCorrectMinimumCountParams_SquareMode()
        {
            //arrange
            string[] args = new string[InputData.MinCountParams]
                { "2"};
            InputData.Mode expected = InputData.Mode.Square;

            //act
            var actual = Parser.ParseArgs(args).ProgramMode;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_AllCorrectMinimumCountParams_CorrectSquaryValue()
        {
            //arrange
            string[] args = new string[InputData.MinCountParams]
                { "2"};
            double expected = 2;

            //act
            int actual = Parser.ParseArgs(args).SquaryValue;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_AllCorrectMaximumCountParams_FibonacciMode()
        {
            //arrange
            string[] args = new string[InputData.MaxCountParams]
                { "2", "3"};
            InputData.Mode expected = InputData.Mode.Fibonacci;

            //act
            var actual = Parser.ParseArgs(args).ProgramMode;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_AllCorrectMaximumCountParams_CorrectStartFibonacciRange()
        {
            //arrange
            string[] args = new string[InputData.MaxCountParams]
                { "2", "3"};
            double expected = 2;

            //act
            double actual = Parser.ParseArgs(args).StartFibonacciRange;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_AllCorrectMaximumCountParams_CorrectEndFibonacciRange()
        {
            //arrange
            string[] args = new string[InputData.MaxCountParams]
                { "2", "3"};
            double expected = 3;

            //act
            double actual = Parser.ParseArgs(args).EndFibonacciRange;

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
