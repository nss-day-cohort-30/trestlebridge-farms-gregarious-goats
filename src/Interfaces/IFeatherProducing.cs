using Trestlebridge.Equipments;
namespace Trestlebridge.Interfaces
{
    public interface IFeatherProducing
    {
        double _feathersProduced { get; }
        double Process(FeatherHarvester x);
    }
}