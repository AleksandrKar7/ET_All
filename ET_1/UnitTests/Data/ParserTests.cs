using System;

using ET_1_ChessBoard.Data;
using NUnit.Framework;

namespace ET_1_UnitTests.Data
{
    class ParserTests
    {
        [Test]
        public void Parse_Null_NullReferenceException()
        {
            //arrange
            string[] args = null;
            Type expected = new NullReferenceException().GetType();

            //act
            TestDelegate actual = () => Parser.Parse(args);

            //assert
            Assert.Throws(expected, actual);
        }
        [Test]
        public void Parse_IncorrectCountParams_ArgumentException()
        {
            //arrange
            string[] args = new string[InputData.CountParams + 1];
            Type expected = new ArgumentException().GetType();

            //act
            TestDelegate actual = () => Parser.Parse(args);

            //assert
            Assert.Throws(expected, actual);
        }
        [Test]
        public void Parse_EmptyArr_ArgumentNullException()
        {
            //arrange
            string[] args = new string[InputData.CountParams];
            Type expected = new ArgumentNullException().GetType();

            //act
            TestDelegate actual = () => Parser.Parse(args);

            //assert
            Assert.Throws(expected, actual);
        }

        [Test]
        public void Parse_AllCorrect_CorrectLength2()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "2", "3"};
            double expected = 2;

            //act
            double actual = Parser.Parse(args).NumberOfRows;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Parse_AllCorrect_CorrectHeight3()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "2", "3"};
            double expected = 3;

            //act
            double actual = Parser.Parse(args).NumberOfColumns;

            //assert
            Assert.AreEqual(expected, actual);
        }
        
    }
}
