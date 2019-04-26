using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Models.BaseClasses;
using Trestlebridge.Interfaces;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class GrazingField : Facility, IFacility<IResource>
    {
        public GrazingField() : base(20) { }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append($"Grazing field {ShortId} has {this.Resources.Count} animals\n");
            this.Resources.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}