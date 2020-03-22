using System;

using ValidatorLibrary;
using Xunit;

namespace ValidatorLibraryTests
{
    public class BaseValidatorTests
    {
        [Fact]
        public void IsNotEmptyArr_Null_False()
        {
            //arrange
            string[] arr = null;
            
            //act
            bool result = BaseValidator.IsNotEmptyArgs(arr);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void IsNotEmptyArr_NotNull_True()
        {
            //arrange
            string[] arr = new string[1];
            
            //act
            bool result = BaseValidator.IsNotEmptyArgs(arr);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void DoesNotContainNull_Null_False()
        {
            //arrange
            string[] arr = null;
            
            //act
            bool result = BaseValidator.DoesNotContainNull(arr);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void DoesNotContainNull_SecondItemIsNull_False()
        {
            //arrange
            string[] arr = { "Test", null, "Test2"};
            
            //act
            bool result = BaseValidator.DoesNotContainNull(arr);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void DoesNotContainNull_NotNullItems_True()
        {
            //arrange
            string[] arr = { "Test", "Test1", "Test2" };
            
            //act
            bool result = BaseValidator.DoesNotContainNull(arr);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void IsCorrectLength_NullLenght1_False()
        {
            //arrange
            string[] arr = null;
            int expected = 1;            

            //act
            bool result = BaseValidator.IsCorrectLength(arr, expected);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void IsCorrectLength_Length3Expected2_False()
        {
            //arrange
            string[] arr = { "Test", "Test1", "Test2" };
            int expected = 2;            

            //act
            bool result = BaseValidator.IsCorrectLength(arr, expected);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void IsCorrectLength_Length3Expected4_False()
        {
            //arrange
            string[] arr = { "Test", "Test1", "Test2" };
            int expected = 4;            

            //act
            bool result = BaseValidator.IsCorrectLength(arr, expected);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void IsCorrectLength_Length3Expected3_True()
        {
            //arrange
            string[] arr = { "Test", "Test1", "Test2" };
            int expected = 3;            

            //act
            bool result = BaseValidator.IsCorrectLength(arr, expected);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void IsCorrectLength_Length3Range2to4_True()
        {
            //arrange
            string[] arr = { "Test", "Test1", "Test2" };
            int start = 2;
            int end = 4;           

            //act
            bool result = BaseValidator.IsCorrectLength(arr, start, end);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void IsCorrectLength_Length3Range4to2_False()
        {
            //arrange
            string[] arr = { "Test", "Test1", "Test2" };
            int start = 4;
            int end = 2;            

            //act
            bool result = BaseValidator.IsCorrectLength(arr, start, end);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void IsCorrectLength_NullRange4to2_False()
        {
            //arrange
            string[] arr = null;
            int start = 2;
            int end = 4;            

            //act
            bool result = BaseValidator.IsCorrectLength(arr, start, end);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void CanParseToInt16_Null_False()
        {
            //arrange
            string line = null;
            bool onlyPositive = false;            

            //act
            bool result = BaseValidator.CanParseToInt16(line, onlyPositive);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void CanParseToInt16_OnlyPositiveNegativeNumber_False()
        {
            //arrange
            string line = "-10";
            bool onlyPositive = true;           

            //act
            bool result = BaseValidator.CanParseToInt16(line, onlyPositive);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void CanParseToInt16_TooBigNumber_False()
        {
            //arrange
            string line = (Int32.MaxValue).ToString() + "0";
            bool onlyPositive = false;

            //act
            bool result = BaseValidator.CanParseToInt16(line, onlyPositive);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void CanParseToInt16_CorrectNumber_True()
        {
            //arrange
            string line = Int16.MaxValue.ToString();
            bool onlyPositive = false;

            //act
            bool result = BaseValidator.CanParseToInt16(line, onlyPositive);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void CanParseToInt32_Null_False()
        {
            //arrange
            string line = null;
            bool onlyPositive = false;

            //act
            bool result = BaseValidator.CanParseToInt32(line, onlyPositive);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void CanParseToInt32_OnlyPositiveNegativeNumber_False()
        {
            //arrange
            string line = "-10";
            bool onlyPositive = true;

            //act
            bool result = BaseValidator.CanParseToInt32(line, onlyPositive);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void CanParseToInt32_TooBigNumber_False()
        {
            //arrange
            string line = (Int32.MaxValue).ToString() + "0";
            bool onlyPositive = false;

            //act
            bool result = BaseValidator.CanParseToInt32(line, onlyPositive);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void CanParseToInt32_CorrectNumber_True()
        {
            //arrange
            string line = Int32.MaxValue.ToString();
            bool onlyPositive = false;

            //act
            bool result = BaseValidator.CanParseToInt32(line, onlyPositive);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void CanParseToInt64_Null_False()
        {
            //arrange
            string line = null;
            bool onlyPositive = false;

            //act
            bool result = BaseValidator.CanParseToInt64(line, onlyPositive);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void CanParseToInt64_OnlyPositiveNegativeNumber_False()
        {
            //arrange
            string line = "-10";
            bool onlyPositive = true;

            //act
            bool result = BaseValidator.CanParseToInt64(line, onlyPositive);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void CanParseToInt64_TooBigNumber_False()
        {
            //arrange
            string line = (Int64.MaxValue).ToString() + "0";
            bool onlyPositive = false;

            //act
            bool result = BaseValidator.CanParseToInt64(line, onlyPositive);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void CanParseToInt64_CorrectNumber_True()
        {
            //arrange
            string line = Int64.MaxValue.ToString();
            bool onlyPositive = false;

            //act
            bool result = BaseValidator.CanParseToInt64(line, onlyPositive);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void CanParseToDouble_Null_False()
        {
            //arrange
            string line = null;
            bool onlyPositive = false;

            //act
            bool result = BaseValidator.CanParseToDouble(line, onlyPositive);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void CanParseToDouble_OnlyPositiveNegativeNumber_False()
        {
            //arrange
            string line = "-10";
            bool onlyPositive = true;

            //act
            bool result = BaseValidator.CanParseToDouble(line, onlyPositive);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void CanParseToDouble_TooBigNumber_False()
        {
            //arrange
            string line = (Double.MaxValue).ToString() + "0";
            bool onlyPositive = false;

            //act
            bool result = BaseValidator.CanParseToDouble(line, onlyPositive);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void CanParseToDouble_CorrectNumber_True()
        {
            //arrange
            string line = Double.MaxValue.ToString();
            bool onlyPositive = false;

            //act
            bool result = BaseValidator.CanParseToDouble(line, onlyPositive);

            //assert
            Assert.True(result);
        }


        enum TestEnum
        {
            firstItem = 1,
            secondItem = 2
        }
        [Fact]
        public void DoesContainEnum_NullStr_False()
        {
            //arrange
            string line = null;

            //act
            bool result = BaseValidator.DoesContainEnum(line, typeof(TestEnum));

            //assert
            Assert.False(result);
        }

        [Fact]
        public void DoesContainEnum_StrNullEnum_False()
        {
            //arrange
            string line = "Test";

            //act
            bool result = BaseValidator.DoesContainEnum(line, null);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void DoesContainEnum_NullStrNullEnum_False()
        {
            //arrange
            string line = null;

            //act
            bool result = BaseValidator.DoesContainEnum(line, null);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void DoesContainEnum_NullStrNotEnumType_False()
        {
            //arrange
            string line = null;

            //act
            bool result = BaseValidator.DoesContainEnum(line, typeof(string));

            //assert
            Assert.False(result);
        }

        [Fact]
        public void DoesContainEnum_AllCorrect_True()
        {
            //arrange
            string line = "firstItem";

            //act
            bool result = BaseValidator.DoesContainEnum(line, typeof(TestEnum));

            //assert
            Assert.True(result);
        }
    }
}
