//using ET_5_NumberToText.Data;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xunit;

//namespace UnitTests.DataTests
//{
//    public class ValidatorTests
//    {
//        [Fact]
//        public void IsValid_Null_False()
//        {
//            //arrange
//            bool result;
//            string[] args = null;

//            //act
//            result = Validator.IsValid(args);

//            //assert
//            Assert.False(result);
//        }

//        [Fact]
//        public void IsValid_IncorrectCountParams_False()
//        {
//            //arrange
//            bool result;
//            string[] args = new string[InputDTO.CountParams + 1];

//            //act
//            result = Validator.IsValid(args);

//            //assert
//            Assert.False(result);
//        }

//        [Fact]
//        public void IsValid_EmptyArr_False()
//        {
//            //arrange
//            bool result;
//            string[] args = new string[InputDTO.CountParams];

//            //act
//            result = Validator.IsValid(args);

//            //assert
//            Assert.False(result);
//        }

//        [Fact]
//        public void IsValid_NegativeNumber_True()
//        {
//            //arrange
//            bool result;
//            string[] args = new string[InputDTO.CountParams]
//                { "-5", InputDTO.Algorithms.English.ToString()};

//            //act
//            result = Validator.IsValid(args);

//            //assert
//            Assert.True(result);
//        }

//        [Fact]
//        public void IsValid_NotNumber_False()
//        {
//            //arrange
//            bool result;
//            string[] args = new string[InputDTO.CountParams]
//                { "asd", InputDTO.Algorithms.English.ToString()};

//            //act
//            result = Validator.IsValid(args);

//            //assert
//            Assert.False(result);
//        }
//        [Fact]
//        public void IsValid_IncorrectAlgorithm_False()
//        {
//            //arrange
//            bool result;
//            string[] args = new string[InputDTO.CountParams]
//                { "123", "dsa"};

//            //act
//            result = Validator.IsValid(args);

//            //assert
//            Assert.False(result);
//        }

//        [Fact]
//        public void IsValid_AllCorrect_True()
//        {
//            //arrange
//            bool result;
//            string[] args = new string[InputDTO.CountParams]
//                { "2", InputDTO.Algorithms.English.ToString()};

//            //act
//            result = Validator.IsValid(args);

//            //assert
//            Assert.True(result);
//        }
//    }
//}
