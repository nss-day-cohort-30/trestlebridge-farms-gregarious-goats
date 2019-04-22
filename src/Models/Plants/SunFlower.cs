using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.BaseClasses;

namespace Trestlebridge.Models.Plants
{
    public class SunFlower : Plant, IResource, ISeedProducing
    {
        private int _seedsProduced = 40;

        public SunFlower () :base ("SunFlower") {   }
        public double Harvest () {
            return _seedsProduced;
        }
    }
}