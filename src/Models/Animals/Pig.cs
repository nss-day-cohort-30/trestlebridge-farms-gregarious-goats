using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Equipments;

namespace Trestlebridge.Models.Animals
{
    public class Pig : Animal, IResource, IGrazing, IMeatProducing
    {
        // Properties:
        public double _meatProduced { get; } = 8.4;

        // Constructor:
        public Pig()
        {
            Type = "Pig";
        }

        // Methods
        public double Process(MeatProcessor x)
        {
            return _meatProduced;
        }
    }
}