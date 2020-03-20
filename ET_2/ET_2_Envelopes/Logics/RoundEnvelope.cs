using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_2_Envelopes
{
    public class RoundEnvelope : IEnvelope
    {
        private const int DiameterMultiplier = 2;
        private const int Degree = 2;
        private const int Denominator = 2;
        public double Radius { get; set; }
        public RoundEnvelope(double radius)
        {
            Radius = radius;
        }

        public bool DoesFits(IEnvelope envelope)
        {
            double expectedCircleSize = Math.Sqrt(Math.Pow(envelope.GetMinSide(), Degree) + Math.Pow(envelope.GetMaxSide(), Degree)) / Denominator;
            return Radius >= expectedCircleSize;
        }

        public double GetMaxSide()
        {
            return 0;
        }

        public double GetMinSide()
        {
            return Radius * DiameterMultiplier;
        }
    }
}
