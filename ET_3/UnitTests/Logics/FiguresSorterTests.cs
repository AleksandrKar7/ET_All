using System;

using ET_3_Triangles;
using NUnit.Framework;

namespace ET_3_UnitTests.Logics
{
    class FiguresSorterTests
    {
        [Test]
        public void SortByArea_Triangels_Sorted()
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
            
            bool result = true;

            //act
            FiguresSorter.SortByArea(ref actual);

            //assert
            for(int i = 0; i < actual.Length; i++)
            {
                if(actual[i] != expected[i])
                {
                    result = false;
                    break;
                }
            }

            Assert.IsTrue(result);
        }
    }
}
