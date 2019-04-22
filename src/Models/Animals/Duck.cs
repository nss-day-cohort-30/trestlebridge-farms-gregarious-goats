using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals
{
    public class Duck : Animal, IHouseDwelling, IEggProducing, IFeatherProducing
    {
        // Properties:
        public double _eggsProduced { get; } = 6;
        public double _feathersProduced { get; } = 0.75;

        // Constructor:
        public Duck()
        {
            Type = "Duck";
        }

        // Methods
        public double CollectEggs()
        {
            return _eggsProduced;
        }
        public double CollectFeathers()
        {
            return _feathersProduced;
        }
    }
}