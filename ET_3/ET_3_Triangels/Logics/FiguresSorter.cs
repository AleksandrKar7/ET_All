using ET_3_Triangles.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_3_Triangles
{
    public static class FiguresSorter
    {
        public static void SortByArea(ref IFigure[] figures)
        {
            int i = 0;
            int j = 0;
            IFigure temp;

            while(i < figures.Length)
            {
                if (j == figures.Length - 1)
                {
                    j = 0;
                    i++;
                    continue;
                }
                if (figures[j].GetArea() < figures[j + 1].GetArea())
                {
                    temp = figures[j + 1];
                    figures[j + 1] = figures[j];
                    figures[j] = temp;
                }

                j++;
            }
        }
    }
}
