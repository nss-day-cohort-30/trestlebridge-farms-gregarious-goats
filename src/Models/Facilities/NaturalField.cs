using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Actions;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities {
    public class NaturalField : IFacility<IResource> {
        private double _capacity = 10;
        private Guid _id = Guid.NewGuid ();

        public List<IResource> _plants = new List<IResource> ();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource (Farm farm, IResource plant) {
            _plants.Add (plant);
        }

        public void AddResource (Farm farm, List<IResource> plants) {
            if (_plants.Count + plants.Count <= _capacity) {
                _plants.AddRange (plants);
            } else {
                for (int i = _plants.Count; i < _capacity; i++) {
                    _plants.Add (plants[0]);
                    plants.Remove (plants[0]);
                }
                ChooseNaturalField.CollectInput (farm, plants);
            }
        }
         public void RemoveResource (Farm farm, IResource plant) {
            if (_plants.Count - 1 > 0) {
                    _plants.Remove (plant);
            }
        }
        public void RemoveResource (Farm farm, List<IResource> plants) {
            if (_plants.Count - plants.Count > 0) {
                for (int i = 0; i < plants.Count; i++)
                    _plants.Remove (plants[0]);
            }
        }
        public override string ToString () {
            StringBuilder output = new StringBuilder ();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append ($"Natural field {shortId} has {this._plants.Count} plants\n");
            this._plants.ForEach (a => output.Append ($"   {a}\n"));

            return output.ToString ();
        }
    }
}