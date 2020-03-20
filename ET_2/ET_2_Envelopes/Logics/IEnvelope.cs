using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_2_Envelopes
{
    public interface IEnvelope
    {
        bool DoesFits(IEnvelope envelope);
        double GetMaxSide();
        double GetMinSide();
    }
}
