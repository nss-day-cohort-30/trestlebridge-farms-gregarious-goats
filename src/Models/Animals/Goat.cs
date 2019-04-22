using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals {
    public class Goat : Animal, IGrazing, ICompostProducing {
        // Properties:

        // Constructor:
        public Goat() {
            Type = "Goat";
        }

        // Methods
    }
}