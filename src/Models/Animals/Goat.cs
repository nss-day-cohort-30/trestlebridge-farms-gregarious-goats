using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals
{
    public class Goat : Animal, IGrazing, ICompostProducing
    {
        // Properties:
        public double _compostProduced { get; } = 7.5;
        public double GrassPerDay { get; set; } = 2.0;

        // Constructor:
        public Goat()
        {
            Type = "Goat";
        }

        // Methods
        public void Graze()
        {
            Console.WriteLine($"Goat {ShortId} just ate {GrassPerDay}kg of grass");
        }

        public double CollectCompost()
        {
            return _compostProduced;
        }
    }
}