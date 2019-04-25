using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.BaseClasses;
using Trestlebridge.Equipments;

namespace Trestlebridge.Models.Plants
{
    public class WildFlower : Plant, IResource, ICompostProducing, INaturalFieldDwelling
    {
        public double _compostProduced { get; } = 30.3;

        public WildFlower () :base ("WildFlower") {   }
        // Methods
        public double Process(Composter x)
        {
            return _compostProduced;
        }
    }
}