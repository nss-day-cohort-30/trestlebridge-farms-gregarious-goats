using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Models.BaseClasses;
using Trestlebridge.Interfaces;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class ChickenHouse : Facility, IFacility<IResource>
    {
        public ChickenHouse() : base(15) { }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append($"Chicken house {ShortId} has {this.Resources.Count} animals\n");
            this.Resources.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}