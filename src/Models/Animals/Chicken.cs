using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Equipments;

namespace Trestlebridge.Models.Animals
{
    public class Chicken : Animal, IResource, IHouseDwelling, IEggProducing, IFeatherProducing, IMeatProducing
    {
        // Properties:
        public double _eggsProduced { get; } = 7;
        public double _feathersProduced { get; } = 0.5;
        public double _meatProduced { get; } = 1.7;


        // Constructor:
        public Chicken()
        {
            Type = "Chicken";
        }

        // Methods
        public double Process(MeatProcessor x)
        {
            return _meatProduced;
        }
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