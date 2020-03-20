using System;

using ET_3_Triangles.Data;
using NUnit.Framework;

namespace ET_3_UnitTests.Data
{
    class ValidatorTests
    {
        [Test]
        public void IsValid_Null_False()
        {
            //arrange
            bool result;
            string[] args = null;

            //act
            result = Validator.IsValid(args);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_IncorrectCountParams_False()
        {
            //arrange
            bool result;
            string[] args = new string[InputData.CountParams + 1];

            //act
            result = Validator.IsValid(args);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_EmptyArr_False()
        {
            //arrange
            bool result;
            string[] args = new string[InputData.CountParams];

            //act
            result = Validator.IsValid(args);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_NegativeNumber_False()
        {
            //arrange
            bool result;
            string[] args = new string[InputData.CountParams]
                { "name", "-3", "4", "1"};

            //act
            result = Validator.IsValid(args);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_NotNumber_False()
        {
            //arrange
            bool result;
            string[] args = new string[InputData.CountParams]
                { "name", "das", "4", "1"};

            //act
            result = Validator.IsValid(args);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_AllCorrect_True()
        {
            //arrange
            bool result;
            string[] args = new string[InputData.CountParams]
                { "name", "3", "4", "1"};

            //act
            result = Validator.IsValid(args);

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidRange_Null_False()
        {
            //arrange
            bool result;
            string[] args = null;

            //act
            result = Validator.IsValidRange(args);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidRange_IncorrectCountParams_False()
        {
            //arrange
            bool result;
            string[] args = new string[InputData.CountParams + 1];

            //act
            result = Validator.IsValidRange(args);

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidRange_EmptyArr_False()
        {
            //arrange
            bool result;
            string[] args = new string[InputData.CountParams];

            //act
            result = Validator.IsValidRange(args);

            //assert
            Assert.IsFalse(result);
        }
    }
}
