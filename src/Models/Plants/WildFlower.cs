using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.BaseClasses;

namespace Trestlebridge.Models.Plants
{
    public class WildFlower : Plant, IResource, ISeedProducing
    {
        private int _seedsProduced = 40;

        public WildFlower () :base ("WildFlower") {   }
        public double Harvest () {
            return _seedsProduced;
        }
    }
}