using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals
{
    public class Chicken : Animal, IHouseDwelling, IEggProducing, IFeatherProducing, IMeatProducing
    {
        // Properties:
        public double _eggsProduced { get;  } = 7;
        public double _feathersProduced { get;  } = 0.5;
        public double _meatProduced { get;  } = 1.7;


        // Constructor:
        public Chicken()
        {
            Type = "Chicken";
        }

        // Methods
        public double CollectEggs()
        {
            return _eggsProduced;
        }
        public double CollectFeathers()
        {
            return _feathersProduced;
        }
        public double Butcher()
        {
            return _meatProduced;
        }
    }
}