using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class GrazingField : IFacility<IResource>
    {
        private double _capacity = 20;
        private Guid _id = Guid.NewGuid();

        public List<IResource> _animals = new List<IResource>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource (Farm farm, IResource animal)
        {
                _animals.Add(animal);
        }

        public void AddResource (Farm farm, List<IResource> animals)
        {
            if (_animals.Count + animals.Count <= _capacity) {
                _animals.AddRange(animals);
            }
        }

        public void RemoveResource (Farm farm, IResource animal)
        {
                _animals.Remove(animal);
        }

        public void RemoveResource (Farm farm, List<IResource> animals)
        {
            if (_animals.Count - animals.Count > 0) {
                for(int i = 0; i < animals.Count; i++)
                    _animals.Remove(animals[i]);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Grazing field {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}