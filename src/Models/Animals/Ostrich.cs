using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals
{
    public class Ostrich : Animal, IGrazing, IMeatProducing, IEggProducing
    {
        // Properties:
        public double _eggsProduced { get; } = 3;
        public double _meatProduced { get; } = 2.6;
        public double GrassPerDay { get; set; } = 4.8;

        // Constructor:
        public Ostrich()
        {
            Type = "Ostrich";
        }

        // Methods
        public void Graze()
        {
            Console.WriteLine($"Ostrich {ShortId} just ate {GrassPerDay}kg of grass");
        }

        public double Butcher()
        {
            return _meatProduced;
        }

        public double CollectEggs()
        {
            return _eggsProduced;
        }
    }
}