using ET_7_8_Square_Fibonacci.Data;
using Xunit;

namespace ET_7_8_UnitTests.DataTests
{
    public class ValidatorTests
    {
        [Fact]
        public void IsValidArgs_Null_NullReferenceException()
        {
            //arrange
            string[] args = null;

            //act
            bool actual = Validator.IsValidArgs(args);

            //assert
            Assert.False(actual);
        }

        [Fact]
        public void IsValidArgs_LessThanMinimumCountParams_False()
        {
            //arrange
            string[] args = new string[InputData.MinCountParams - 1];

            //act
            bool actual = Validator.IsValidArgs(args);

            //assert
            Assert.False(actual);
        }

        [Fact]
        public void IsValidArgs_MoreThanMaximumCountParams_False()
        {
            //arrange
            string[] args = new string[InputData.MaxCountParams + 1];

            //act
            bool actual = Validator.IsValidArgs(args);

            //assert
            Assert.False(actual);
        }

        [Fact]
        public void IsValidArgs_EmptyArrMinimumCountParams_False()
        {
            //arrange
            string[] args = new string[InputData.MinCountParams];

            //act
            bool actual = Validator.IsValidArgs(args);

            //assert
            Assert.False(actual);
        }

        [Fact]
        public void IsValidArgs_EmptyArrMaximumCountParams_False()
        {
            //arrange
            string[] args = new string[InputData.MaxCountParams];

            //act
            bool actual = Validator.IsValidArgs(args);

            //assert
            Assert.False(actual);
        }

        [Fact]
        public void IsValidArgs_NegativeNumberMinimumCountParams_False()
        {
            //arrange
            string[] args = new string[InputData.MinCountParams]
                { "-1"};

            //act
            bool actual = Validator.IsValidArgs(args);

            //assert
            Assert.False(actual);
        }

        [Fact]
        public void IsValidArgs_NegativeNumberMaximumCountParams_False()
        {
            //arrange
            string[] args = new string[InputData.MaxCountParams]
                { "2", "-1"};

            //act
            bool actual = Validator.IsValidArgs(args);

            //assert
            Assert.False(actual);
        }

        [Fact]
        public void IsValidArgs_AllCorrectMinimumCountParams_True()
        {
            //arrange
            string[] args = new string[InputData.MinCountParams]
                { "2"};

            //act
            bool actual = Validator.IsValidArgs(args);

            //assert
            Assert.True(actual);
        }

        [Fact]
        public void IsValidArgs_AllCorrectMaximumCountParams_True()
        {
            //arrange
            string[] args = new string[InputData.MaxCountParams]
                { "2", "3"};

            //act
            bool actual = Validator.IsValidArgs(args);

            //assert
            Assert.True(actual);
        } 
    }
}
