using Trestlebridge.Equipments;

namespace Trestlebridge.Interfaces
{
    public interface ICompostProducing
    {
        double _compostProduced { get; }
        double Process(Composter x);
    }
}