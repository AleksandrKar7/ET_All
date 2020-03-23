using System;

using ET_1_ChessBoard.Data;
using Xunit;

namespace ET_1_UnitTests.DataTests
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
        public void Parse_AllCorrect_CorrectLength2()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "2", "3"};
            double expected = 2;

            //act
            double actual = Parser.Parse(args).NumberOfRows;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_AllCorrect_CorrectHeight3()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "2", "3"};
            double expected = 3;

            //act
            double actual = Parser.Parse(args).NumberOfColumns;

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
