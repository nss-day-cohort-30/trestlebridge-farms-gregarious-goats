using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Equipments;

namespace Trestlebridge.Models.Animals
{
    public class Duck : Animal, IResource, IHouseDwelling, IEggProducing, IFeatherProducing
    {
        // Properties:
        public double _eggsProduced { get; } = 6;
        public double _feathersProduced { get; } = 175.0;

        // Constructor:
        public Duck()
        {
            Type = "Duck";
        }

        // Methods
        public double Process(EggGatherer x)
        {
            return _eggsProduced;
        }
        public double Process(FeatherHarvester x)
        {
            return _feathersProduced;
        }
    }
}