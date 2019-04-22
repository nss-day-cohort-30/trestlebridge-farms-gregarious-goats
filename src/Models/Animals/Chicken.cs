using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals {
    public class Chicken : Animal, IHouseDwelling, IEggProducing, IFeatherProducing, IMeatProducing {
        // Properties:

        // Constructor:
        public Chicken() {
            Type = "Chicken";
        }

        // Methods
    }
}