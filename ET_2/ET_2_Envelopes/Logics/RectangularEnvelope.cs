using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_2_Envelopes
{
    public class RectangularEnvelope : IEnvelope
    {
        public double Length { get; set; }
        public double Height { get; set; }

        public RectangularEnvelope(double length, double height)
        {
            Length = length;
            Height = height;
        }

        public bool DoesFits(IEnvelope envelope)
        {
            return
                this.GetMaxSide() >= envelope.GetMaxSide() &&
                this.GetMinSide() >= envelope.GetMinSide();
        }

        public double GetMaxSide()
        {
            return (Length > Height) ? Length : Height;
        }

        public double GetMinSide()
        {
            return (Length < Height) ? Length : Height;
        }
    }
}
