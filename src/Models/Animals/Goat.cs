using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Equipments;

namespace Trestlebridge.Models.Animals
{
    public class Goat : Animal, IResource, IGrazing, ICompostProducing
    {
        // Properties:
        public double _compostProduced { get; } = 7.5;

        // Constructor:
        public Goat()
        {
            Type = "Goat";
        }

        // Methods
        public double Process(Composter x)
        {
            return _compostProduced;
        }
    }
}