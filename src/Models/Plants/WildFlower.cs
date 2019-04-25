using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.BaseClasses;

namespace Trestlebridge.Models.Plants
{
    public class WildFlower : Plant, IResource, ISeedProducing, INaturalFieldDwelling
    {
        private int _compostProduced = 30.3;

        public WildFlower () :base ("WildFlower") {   }
        // Methods
        public double Process(Composter x)
        {
            return _compostProduced;
        }
    }
}