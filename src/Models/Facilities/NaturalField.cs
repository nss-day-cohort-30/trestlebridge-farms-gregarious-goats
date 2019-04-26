using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Models.BaseClasses;
using Trestlebridge.Interfaces;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class NaturalField : Facility, IFacility<IResource>
    {
        public NaturalField() : base(10) { }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append($"Natural field {ShortId} has {this.Resources.Count} rows of plants\n");
            this.Resources.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}