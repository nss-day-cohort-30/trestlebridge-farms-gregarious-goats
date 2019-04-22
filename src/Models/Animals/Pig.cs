using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals
{
    public class Pig : Animal, IGrazing, IMeatProducing
    {
        // Properties:
        public double _meatProduced { get; } = 8.4;
        public double GrassPerDay { get; set; } = 3.9;

        // Constructor:
        public Pig()
        {
            Type = "Pig";
        }

        // Methods
        public void Graze()
        {
            Console.WriteLine($"Pig {ShortId} just ate {GrassPerDay}kg of grass");
        }

        public double Butcher()
        {
            return _meatProduced;
        }
    }
}