using System;

using ET_2_Envelopes.Data;
using Xunit;

namespace ET_2_UnitTest.DataTests
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
            Assert.Throws<NullReferenceException>(() => Parser.Parse(args));
        }

        [Fact]
        public void Parse_IncorrectCountParams_ArgumentException()
        {
            //arrange
            string[] args = new string[InputData.CountParams + 1];

            //act

            //assert
            Assert.Throws<ArgumentException>(() => Parser.Parse(args));
        }

        [Fact]
        public void Parse_EmptyArr_ArgumentNullException()
        {
            //arrange
            string[] args = new string[InputData.CountParams];

            //act

            //assert
            Assert.Throws<ArgumentNullException>(() => Parser.Parse(args));
        }

        [Fact]
        public void Parse_AllCorrect_CorrectLengthFirst2()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "2", "3", "4", "1"};
            double expected = 2;

            //act
            double actual = Parser.Parse(args).LengthFirst;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_AllCorrect_CorrectHeightFirst3()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "2", "3", "4", "1"};
            double expected = 3;

            //act
            double actual = Parser.Parse(args).HeightFirst;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_AllCorrect_CorrectLengthSecond4()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "2", "3", "4", "1"};
            double expected = 4;

            //act
            double actual = Parser.Parse(args).LengthSecond;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_AllCorrect_CorrectHeightSecond1()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "2", "3", "4", "1"};
            double expected = 1;

            //act
            double actual = Parser.Parse(args).HeightSecond;

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
