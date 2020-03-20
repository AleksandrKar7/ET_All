using System;

using ET_5_NumberToText.Logics.Translator;
using Xunit;

namespace ET_5_UnitTests.TranslatorTests
{
    public class EnglishNumberToTextConverterTests
    {
        [Fact]
        public void CanConvertNumber_Number0_True()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 0;

            //act
            var actual = converter.CanConvertNumber(number);

            //assert
            Assert.True(actual);
        }

        [Fact]
        public void CanConvertNumber_NumberInt32Max_False()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = Int64.MaxValue;

            //act
            var actual = converter.CanConvertNumber(number);

            //assert
            Assert.False(actual);
        }

        [Fact]
        public void CanConvertNumber_NumberInt32Min_False()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = Int64.MinValue + 1;

            //act
            var actual = converter.CanConvertNumber(number);

            //assert
            Assert.False(actual);
        }

        [Fact]
        public void CanConvertNumber_Number100_True()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 100;

            //act
            var actual = converter.CanConvertNumber(number);

            //assert
            Assert.True(actual);
        }

        [Fact]
        public void CanConvertNumber_Number100000_True()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 100000;

            //act
            var actual = converter.CanConvertNumber(number);

            //assert
            Assert.True(actual);
        }

        [Fact]
        public void CanConvertNumber_Number100000000_True()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 100000000;

            //act
            var actual = converter.CanConvertNumber(number);

            //assert
            Assert.True(actual);
        }

        [Fact]
        public void ConvertNumber_0_Zero()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 0;
            string expected = "zero";

            //act
            var actual = converter.ConvertNumber(number);
            actual = actual.Trim();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertNumber_Minus1_CorrectString()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = -1;
            string expected = "minus one";

            //act
            var actual = converter.ConvertNumber(number);
            actual = actual.Trim();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertNumber_12_CorrectString()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 12;
            string expected = "twelve";

            //act
            var actual = converter.ConvertNumber(number);
            actual = actual.Trim();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertNumber_112_CorrectString()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 112;
            string expected = "one hundred twelve";

            //act
            var actual = converter.ConvertNumber(number);
            actual = actual.Trim();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertNumber_123_CorrectString()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 123;
            string expected = "one hundred twenty three";

            //act
            var actual = converter.ConvertNumber(number);
            actual = actual.Trim();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertNumber_999_CorrectString()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 999;
            string expected = "nine hundred ninety nine";

            //act
            var actual = converter.ConvertNumber(number);
            actual = actual.Trim();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertNumber_1000_CorrectString()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 1000;
            string expected = "one thousand";

            //act
            var actual = converter.ConvertNumber(number);
            actual = actual.Trim();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertNumber_10000_CorrectString()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 10000;
            string expected = "ten thousand";

            //act
            var actual = converter.ConvertNumber(number);
            actual = actual.Trim();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertNumber_100000_CorrectString()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 100000;
            string expected = "one hundred thousand";

            //act
            var actual = converter.ConvertNumber(number);
            actual = actual.Trim();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertNumber_999999_CorrectString()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 999999;
            string expected = "nine hundred ninety nine thousand " + 
                "nine hundred ninety nine";

            //act
            var actual = converter.ConvertNumber(number);
            actual = actual.Trim();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertNumber_1000000_CorrectString()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 1000000;
            string expected = "one million";

            //act
            var actual = converter.ConvertNumber(number);
            actual = actual.Trim();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertNumber_10000000_CorrectString()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 10000000;
            string expected = "ten million";

            //act
            var actual = converter.ConvertNumber(number);
            actual = actual.Trim();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertNumber_100000000_CorrectString()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 100000000;
            string expected = "one hundred million";

            //act
            var actual = converter.ConvertNumber(number);
            actual = actual.Trim();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertNumber_999999999_CorrectString()
        {
            //arrange          
            var converter = new EnglishNumberToTextConverter();
            long number = 999999999;
            string expected = "nine hundred ninety nine million "
                + "nine hundred ninety nine thousand " +
                "nine hundred ninety nine";

            //act
            var actual = converter.ConvertNumber(number);
            actual = actual.Trim();

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
