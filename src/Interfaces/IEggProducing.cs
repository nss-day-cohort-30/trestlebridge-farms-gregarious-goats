using Trestlebridge.Equipments;
namespace Trestlebridge.Interfaces
{
    public interface IEggProducing
    {
        double _eggsProduced { get; }
        double Process(EggGatherer x);
    }
}