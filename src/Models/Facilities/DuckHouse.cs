using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Actions;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models;


namespace Trestlebridge.Models.Facilities {
    public class DuckHouse : IFacility<IHouseDwelling>
    {
        private double _capacity = 12;
        private Guid _id = Guid.NewGuid();

        public List<IHouseDwelling> _animals = new List<IHouseDwelling>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource (Farm farm, IHouseDwelling animal)
        {
                _animals.Add(animal);
        }

        public void AddResource(Farm farm, List<IHouseDwelling> animals)
        {
            if (_animals.Count + animals.Count <= _capacity) {
                _animals.AddRange(animals);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Duck house {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }

    }
}