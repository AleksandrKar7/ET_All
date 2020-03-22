
namespace ET_2_Envelopes
{
    public interface IEnvelope
    {
        bool DoesFits(IEnvelope envelope);
        double GetMaxSide();
        double GetMinSide();
    }
}
