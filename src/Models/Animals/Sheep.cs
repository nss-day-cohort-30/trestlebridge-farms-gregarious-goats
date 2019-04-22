using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals
{
    public class Sheep : Animal, IGrazing, IMeatProducing
    {
        // Properties:
        public double _meatProduced { get; } = 5;
        public double GrassPerDay { get; set; } = 2.8;

        // Constructor:
        public Sheep()
        {
            Type = "Sheep";
        }

        // Methods
        public void Graze()
        {
            Console.WriteLine($"Sheep {ShortId} just ate {GrassPerDay}kg of grass");
        }

        public double Butcher()
        {
            return _meatProduced;
        }
    }
}