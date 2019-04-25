using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals
{
    public class Cow : Animal, IGrazing, IMeatProducing
    {
        // Properties:
        public double _meatProduced { get; } = 18.25;

        // Constructor:
        public Cow()
        {
            Type = "Cow";
        }

        // Methods
        public double Process(MeatProcessor x)
        {
            return _meatProduced;
        }
    }
}