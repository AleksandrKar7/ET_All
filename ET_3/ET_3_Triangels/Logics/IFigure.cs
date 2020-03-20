using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_3_Triangles
{
    public interface IFigure
    {
        string Name { get; set; }
        double GetArea();
    }
}
