using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_3_Triangles
{
    public class Triangle : IFigure
    {
        public string Name { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(string name, double sideA, double sideB, double sideC)
        {
            Name = name;
            SideA = sideA;
            SideB = sideB;
            SideC = sideC; 
        }

        private const int Denominaotor = 2;
        public bool IsRealTriangel()
        {
            if(SideA + SideB > SideC &&
                SideB + SideC > SideA && 
                SideA + SideC > SideB)
            {
                return true;
            }
            return false;
        }

        public double GetArea()
        {
            if (!IsRealTriangel())
            {
                return Double.NaN;
            }
            double perimeter = SideA + SideB + SideC;
            double halfPerimeter = perimeter / Denominaotor;

            return Math.Sqrt(halfPerimeter *
                (halfPerimeter - SideA) *
                (halfPerimeter - SideB) *
                (halfPerimeter - SideC));
        }


    }
}
