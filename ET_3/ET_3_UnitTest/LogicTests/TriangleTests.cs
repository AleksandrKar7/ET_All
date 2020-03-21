using System;

using ET_3_Triangles;
using Xunit;

namespace ET_3_UnitTest.Logics
{
    public class TriangleTests
    {
        [Fact]
        public void IsRealTriangel_NotRealTriangel_False()
        {
            //arrange
            Triangle triangel = new Triangle("Test", 1, 1, 3);
            bool result;

            //act
            result = triangel.IsRealTriangel();

            //assert
            Assert.False(result);
        }

        [Fact]
        public void IsRealTriangel_RealTriangel_True()
        {
            //arrange
            Triangle triangel = new Triangle("Test", 1, 1, 1);
            bool result;

            //act
            result = triangel.IsRealTriangel();

            //assert
            Assert.True(result);
        }

        [Fact]
        public void GetArea_NotRealTriangel_NaN()
        {
            //arrange
            Triangle triangel = new Triangle("Test", 1, 1, 3);
            double result;

            //act
            result = triangel.GetArea();

            //assert
            Assert.True(Double.IsNaN(result));
        }

        [Fact]
        public void GetArea_Triangel333_3p897()
        {
            //arrange
            Triangle triangel = new Triangle("Test", 3, 3, 3);
            double expected = 3.897;

            //act
            double actual = triangel.GetArea();
            actual = Math.Round(actual, 3);

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
