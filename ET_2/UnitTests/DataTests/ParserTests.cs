using System;

using NUnit.Framework;
using ET_2_Envelopes;
using ET_2_Envelopes.Data;

namespace ET_2_UnitTests.DataTests
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
        public void Parse_AllCorrect_CorrectLengthFirst2()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "2", "3", "4", "1"};
            double expected = 2;

            //act
            double actual = Parser.Parse(args).LengthFirst;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Parse_AllCorrect_CorrectHeightFirst3()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "2", "3", "4", "1"};
            double expected = 3;

            //act
            double actual = Parser.Parse(args).HeightFirst;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Parse_AllCorrect_CorrectLengthSecond4()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "2", "3", "4", "1"};
            double expected = 4;

            //act
            double actual = Parser.Parse(args).LengthSecond;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Parse_AllCorrect_CorrectHeightSecond1()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "2", "3", "4", "1"};
            double expected = 1;

            //act
            double actual = Parser.Parse(args).HeightSecond;

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
