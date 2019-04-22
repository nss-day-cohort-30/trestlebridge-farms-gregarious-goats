using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals {
    public class Pig : Animal, IGrazing, IMeatProducing {
        // Properties:

        // Constructor:
        public Pig() {
            Type = "Pig";
        }

        // Methods
    }
}