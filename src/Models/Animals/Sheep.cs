using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Equipments;

namespace Trestlebridge.Models.Animals
{
    public class Sheep : Animal, IResource, IGrazing, IMeatProducing
    {
        // Properties:
        public double _meatProduced { get; } = 5;

        // Constructor:
        public Sheep()
        {
            Type = "Sheep";
        }

        // Methods
        public double Process(MeatProcessor x)
        {
            return _meatProduced;
        }
    }
}