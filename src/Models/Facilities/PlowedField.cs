using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Models.BaseClasses;
using Trestlebridge.Interfaces;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class PlowedField : Facility, IFacility<IResource>
    {
        public PlowedField() : base(13) { }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append($"Plowed field {ShortId} has {this.Resources.Count} rows of plants\n");
            this.Resources.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}