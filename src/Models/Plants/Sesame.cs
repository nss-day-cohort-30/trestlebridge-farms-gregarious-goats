using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.BaseClasses;

namespace Trestlebridge.Models.Plants
{
    public class Sesame : Plant, IResource, ISeedProducing, IPlowedFieldDwelling
    {
        private int _seedsProduced = 40;

        public Sesame () :base ("Sesame") {   }
        public double Harvest () {
            return _seedsProduced;
        }
    }
}