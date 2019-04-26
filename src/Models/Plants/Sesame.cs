using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.BaseClasses;
using Trestlebridge.Equipments;

namespace Trestlebridge.Models.Plants
{
    public class Sesame : Plant, IResource, ISeedProducing, IPlowedFieldDwelling
    {
        public double _seedsProduced { get; } = 520;

        public Sesame () :base ("Sesame") {   }

        // Methods
        public double Process(SeedHarvester x)
        {
            return _seedsProduced;
        }
    }
}