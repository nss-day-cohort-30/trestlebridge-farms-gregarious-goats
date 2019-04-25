using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Equipments;

namespace Trestlebridge.Models.Animals
{
    public class Ostrich : Animal, IResource, IGrazing, IMeatProducing, IEggProducing
    {
        // Properties:
        public double _eggsProduced { get; } = 3;
        public double _meatProduced { get; } = 2.6;

        // Constructor:
        public Ostrich()
        {
            Type = "Ostrich";
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
    }
}