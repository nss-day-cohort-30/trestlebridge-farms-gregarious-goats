using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.BaseClasses;

namespace Trestlebridge.Models.Plants
{
    public class Sesame : Plant, IResource, ISeedProducing, IPlowedFieldDwelling
    {
        private double _seedsProduced = 520;

        public Sesame () :base ("Sesame") {   }

        // Methods
        public double Process(SeedHarvester x)
        {
            return _seedsProduced;
        }
    }
}