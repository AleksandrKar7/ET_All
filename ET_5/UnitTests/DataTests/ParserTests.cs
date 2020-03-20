using System;

using ET_5_NumberToText.Data;
using Xunit;

namespace ET_5_UnitTests.DataTests
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
            string[] args = new string[InputDTO.CountParams + 1];

            //act

            //assert
            Assert.Throws<ArgumentException>(() => Parser.Parse(args));
        }
        [Fact]
        public void Parse_EmptyArr_ArgumentNullException()
        {
            //arrange
            string[] args = new string[InputDTO.CountParams];

            //act

            //assert
            Assert.Throws<ArgumentNullException>(() => Parser.Parse(args));
        }

        [Fact]
        public void Parse_IncorrectNumber_FormatException()
        {
            //arrange
            string[] args = new string[InputDTO.CountParams]
                { "dsa", InputDTO.Algorithms.English.ToString()};

            //act

            //assert
            Assert.Throws<FormatException>(() => Parser.Parse(args));
        }
        [Fact]
        public void Parse_IncorrectAlgorithm_ArgumentException()
        {
            //arrange
            string[] args = new string[InputDTO.CountParams]
                { "123", "dsaasd"};

            //act

            //assert
            Assert.Throws<ArgumentException>(() => Parser.Parse(args));
        }


        [Fact]
        public void Parse_AllCorrect_CorrectNumber()
        {
            //arrange
            string[] args = new string[InputDTO.CountParams]
                { "123", InputDTO.Algorithms.English.ToString()};
            var expected = 123;

            //act
            var actual = Parser.Parse(args);

            //assert
            Assert.Equal(expected, actual.Number);
        }

        [Fact]
        public void Parse_AllCorrect_CorrectAlgorithm()
        {
            //arrange
            string[] args = new string[InputDTO.CountParams]
                { "123", InputDTO.Algorithms.English.ToString()};
            var expected = InputDTO.Algorithms.English;

            //act
            var actual = Parser.Parse(args);

            //assert
            Assert.Equal(expected, actual.Algorithm);
        }
    }
}
