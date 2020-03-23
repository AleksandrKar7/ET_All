using System;

using ET_3_Triangles;
using Xunit;

namespace ET_3_UnitTests.LogicTests
{
    public class FiguresSorterTests
    {
        [Fact]
        public void SortByArea_Null_Sorted()
        {
            //arrange
            IFigure[] actual = null;

            //act            

            //assert
            Assert.Throws<NullReferenceException>(() => actual.SortByArea());
        }

        [Fact]
        public void SortByArea_CorrectTriangels_Sorted()
        {
            //arrange
            IFigure[] actual = new Triangle[]
            {
                new Triangle("Second", 2, 2, 2),
                new Triangle("Third", 3, 3, 3),
                new Triangle("First", 1, 1, 1)
            };
            IFigure[] expected = new IFigure[] {
                actual[1], actual[0], actual[2] };

            //act
            actual.SortByArea();

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
