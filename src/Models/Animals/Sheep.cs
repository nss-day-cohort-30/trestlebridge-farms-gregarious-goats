using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals {
    public class Sheep : Animal, IGrazing, IMeatProducing {
        // Properties:

        // Constructor:
        public Sheep() {
            Type = "Sheep";
        }

        // Methods
    }
}