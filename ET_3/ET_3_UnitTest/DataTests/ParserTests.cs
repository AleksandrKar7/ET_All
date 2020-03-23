using System;

using ET_3_Triangles.Data;
using Xunit;

namespace ET_3_UnitTests.DataTests
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
                { "name", "3", "4", "1"};
            string expected = "name";

            //act
            string actual = Parser.Parse(args).Name;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_AllCorrect_CorrectHeightFirst3()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "name", "3", "4", "1"};
            double expected = 3;

            //act
            double actual = Parser.Parse(args).SideA;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_AllCorrect_CorrectLengthSecond4()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "name", "3", "4", "1"};
            double expected = 4;

            //act
            double actual = Parser.Parse(args).SideB;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_AllCorrect_CorrectHeightSecond1()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "name", "3", "4", "1"};
            double expected = 1;

            //act
            double actual = Parser.Parse(args).SideC;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ParseRange_Null_NullReferenceException()
        {
            //arrange
            string[] args = null;

            //act

            //assert
            Assert.Throws<NullReferenceException>(() =>Parser.ParseRange(args));
        }

        [Fact]
        public void ParseRange_IncorrectCountParams_ArgumentException()
        {
            //arrange
            string[] args = new string[InputData.CountParams + 1];

            //act

            //assert
            Assert.Throws<ArgumentException>(() => Parser.ParseRange(args));
        }

        [Fact]
        public void ParseRange_EmptyArr_ArgumentNullException()
        {
            //arrange
            string[] args = new string[InputData.CountParams];

            //act

            //assert
            Assert.Throws<ArgumentNullException>(() => Parser.ParseRange(args));
        }
    }
}
