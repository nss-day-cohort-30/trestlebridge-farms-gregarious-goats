using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals {
    public class Cow: Animal, IGrazing, IMeatProducing {
        // Properties:
        // private double _meatProduced = 18.25;
        // public double GrassPerDay { get; set; } = 5.4;

        // Constructor:
        public Cow() {
            Type = "Cow";
        }

        // Methods
        // public void Graze () {
        //     Console.WriteLine($"Cow {this._shortId} just ate {this.GrassPerDay}kg of grass");
        // }

        // public double Butcher () {
        //     return _meatProduced;
        // }
    }
}