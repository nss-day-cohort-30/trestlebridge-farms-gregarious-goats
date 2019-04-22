using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals {
    public class Duck : Animal, IHouseDwelling, IEggProducing, IFeatherProducing {
        // Properties:

        // Constructor:
        public Duck() {
            Type = "Duck";
        }

        // Methods
    }
}