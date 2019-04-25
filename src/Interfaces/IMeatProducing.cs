using Trestlebridge.Equipments;
namespace Trestlebridge.Interfaces
{
    public interface IMeatProducing
    {
        double _meatProduced { get; }
        double Process(MeatProcessor x);
    }
}