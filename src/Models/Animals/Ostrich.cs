using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals {
    public class Ostrich : Animal, IGrazing, IMeatProducing, IEggProducing {
        // Properties:

        // Constructor:
        public Ostrich() {
            Type = "Ostrich";
        }

        // Methods
    }
}