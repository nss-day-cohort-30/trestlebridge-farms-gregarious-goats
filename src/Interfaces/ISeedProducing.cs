using Trestlebridge.Equipments;

namespace Trestlebridge.Interfaces
{
    public interface ISeedProducing
    {
        double _seedsProduced { get; }
        double Process(SeedHarvester x);
    }
}