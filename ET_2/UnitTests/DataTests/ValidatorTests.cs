using System;

using NUnit.Framework;
using ET_2_Envelopes;
using ET_2_Envelopes.Data;

namespace ET_2_UnitTests.DataTests
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
                { "-5", "3", "4", "1"};

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
                { "asd", "3", "4", "1"};

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
                { "2", "3", "4", "1"};

            //act
            result = Validator.IsValid(args);

            //assert
            Assert.IsTrue(result);
        }
    }
}
