using ET_5_NumberToText.Logics.Translators;
using Xunit;

namespace ET_5_UnitTests.TranslatorTests
{
    public class NumberToTextConverterTests
    {
        [Fact]
        public void DivideNumberIntoParts_Number546Quantity1_Correct()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            int number = 546;
            int quantity = 1;
            int[] expected = { 5, 4, 6 };

            //act
            var actual = converter.DivideNumberIntoParts(
                number, quantity);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DivideNumberIntoParts_Number1456872Quantity3_Correct()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            int number = 1456872;
            int quantity = 3;
            int[] expected = { 1, 456, 872 };

            //act
            var actual = converter.DivideNumberIntoParts(
                number, quantity);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DivideNumberIntoParts_Number0Quantity3_EmptyArr()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            int number = 0;
            int quantity = 3;
            int[] expected = { };

            //act
            var actual = converter.DivideNumberIntoParts(
                number, quantity);

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
