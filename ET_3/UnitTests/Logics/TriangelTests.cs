using System;

using ET_3_Triangles;
using NUnit.Framework;

namespace ET_3_UnitTests.Logics
{
    class TriangelTests
    {
        [Test]
        public void IsRealTriangel_NotRealTriangel_False()
        {
            //arrange
            Triangle triangel = new Triangle("Test", 1, 1, 3);
            bool result;

            //act
            result = triangel.IsRealTriangel();

            //assert
            Assert.IsFalse(result);
        }
        [Test]
        public void IsRealTriangel_RealTriangel_True()
        {
            //arrange
            Triangle triangel = new Triangle("Test", 1, 1, 1);
            bool result;

            //act
            result = triangel.IsRealTriangel();

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void GetArea_NotRealTriangel_NaN()
        {
            //arrange
            Triangle triangel = new Triangle("Test", 1, 1, 3);
            double result;

            //act
            result = triangel.GetArea();

            //assert
            Assert.IsTrue(Double.IsNaN(result));
        }
        [Test]
        public void GetArea_Triangel333_3p89()
        {
            //arrange
            Triangle triangel = new Triangle("Test", 3, 3, 3);
            double expected = 3.897;

            //act
            double actual = triangel.GetArea();

            //assert
            Assert.AreEqual(expected, actual, 0.01);
        }
    }
}
