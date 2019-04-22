using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;


namespace Trestlebridge.Models.Facilities {
    public class PlowedField : IFacility<IPlowedFieldDwelling>
    {
        private int _capacity = 13;
        private Guid _id = Guid.NewGuid();

        private List<IPlowedFieldDwelling> _plants = new List<IPlowedFieldDwelling>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource (IPlowedFieldDwelling plant)
        {
            if (_plants.Count < _capacity) {
                _plants.Add(plant);
            }
        }

        public void AddResource (List<IPlowedFieldDwelling> plants)
        {
            if (_plants.Count + plants.Count <= _capacity) {
                _plants.AddRange(plants);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Plowed field {shortId} has {this._plants.Count} plants\n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}