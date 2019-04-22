using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;


namespace Trestlebridge.Models.Facilities {
    public class ChickenHouse : IFacility<IHouseDwelling>
    {
        private int _capacity = 15;
        private Guid _id = Guid.NewGuid();

        private List<IHouseDwelling> _animals = new List<IHouseDwelling>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource (IHouseDwelling animal)
        {
            if (_animals.Count < _capacity) {
                _animals.Add(animal);
            }
        }

        public void AddResource (List<IHouseDwelling> animals)
        {
            if (_animals.Count + animals.Count <= _capacity) {
                _animals.AddRange(animals);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Chicken house field {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}