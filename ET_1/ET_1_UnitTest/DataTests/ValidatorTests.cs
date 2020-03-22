
using ET_1_ChessBoard.Data;
using Xunit;

namespace ET_1_UnitTests.DataTests
{
    public class ValidatorTests
    {
        [Fact]
        public void IsValid_Null_False()
        {
            //arrange
            bool result;
            string[] args = null;

            //act
            result = Validator.IsValid(args);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void IsValid_IncorrectCountParams_False()
        {
            //arrange
            bool result;
            string[] args = new string[InputData.CountParams + 1];

            //act
            result = Validator.IsValid(args);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void IsValid_EmptyArr_False()
        {
            //arrange
            bool result;
            string[] args = new string[InputData.CountParams];

            //act
            result = Validator.IsValid(args);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void IsValid_NegativeNumber_False()
        {
            //arrange
            bool result;
            string[] args = new string[InputData.CountParams]
                { "-5", "3"};

            //act
            result = Validator.IsValid(args);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void IsValid_NotNumber_False()
        {
            //arrange
            bool result;
            string[] args = new string[InputData.CountParams]
                { "asd", "3"};

            //act
            result = Validator.IsValid(args);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void IsValid_AllCorrect_True()
        {
            //arrange
            bool result;
            string[] args = new string[InputData.CountParams]
                { "2", "3"};

            //act
            result = Validator.IsValid(args);

            //assert
            Assert.True(result);
        }
    }
}
