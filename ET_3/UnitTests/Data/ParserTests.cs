using System;

using ET_3_Triangles.Data;
using NUnit.Framework;

namespace ET_3_UnitTests.Data
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
                { "name", "3", "4", "1"};
            string expected = "name";

            //act
            string actual = Parser.Parse(args).Name;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Parse_AllCorrect_CorrectHeightFirst3()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "name", "3", "4", "1"};
            double expected = 3;

            //act
            double actual = Parser.Parse(args).SideA;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Parse_AllCorrect_CorrectLengthSecond4()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "name", "3", "4", "1"};
            double expected = 4;

            //act
            double actual = Parser.Parse(args).SideB;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Parse_AllCorrect_CorrectHeightSecond1()
        {
            //arrange
            string[] args = new string[InputData.CountParams]
                { "name", "3", "4", "1"};
            double expected = 1;

            //act
            double actual = Parser.Parse(args).SideC;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ParseRange_Null_NullReferenceException()
        {
            //arrange
            string[] args = null;
            Type expected = new NullReferenceException().GetType();

            //act
            TestDelegate actual = () => Parser.ParseRange(args);

            //assert
            Assert.Throws(expected, actual);
        }
        [Test]
        public void ParseRange_IncorrectCountParams_ArgumentException()
        {
            //arrange
            string[] args = new string[InputData.CountParams + 1];
            Type expected = new ArgumentException().GetType();

            //act
            TestDelegate actual = () => Parser.ParseRange(args);

            //assert
            Assert.Throws(expected, actual);
        }
        [Test]
        public void ParseRange_EmptyArr_ArgumentNullException()
        {
            //arrange
            string[] args = new string[InputData.CountParams];
            Type expected = new ArgumentNullException().GetType();

            //act
            TestDelegate actual = () => Parser.ParseRange(args);

            //assert
            Assert.Throws(expected, actual);
        }
    }
}
