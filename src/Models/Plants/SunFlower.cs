using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.BaseClasses;

namespace Trestlebridge.Models.Plants
{
    public class SunFlower : Plant, IResource, ISeedProducing, IAnyFieldDwelling, IPlowedFieldDwelling, INaturalFieldDwelling
    {
        private int _seedsProduced = 650;

        private double _compostProduced = 21.6;

        public SunFlower() : base("SunFlower") { }

        // Methods
        public double Process(SeedHarvester x)
        {
            return _seedsProduced;
        }
        public double Process(Composter x)
        {
            return _compostProduced;
        }
    }
}