using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class NaturalField : IFacility<INaturalFieldDwelling>
    {
        private double _capacity = 10;
        private Guid _id = Guid.NewGuid();

        public List<INaturalFieldDwelling> _plants = new List<INaturalFieldDwelling>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource (Farm farm, INaturalFieldDwelling plant)
        {
                _plants.Add(plant);
        }

        public void AddResource (Farm farm, List<INaturalFieldDwelling> plants)
        {
            if (_plants.Count + plants.Count <= _capacity) {
                _plants.AddRange(plants);
            }
            else {
                for (int i =  _plants.Count; i < _capacity; i++)
                {
                    _plants.Add(plants[0]);
                    plants.Remove(plants[0]);
                }
                ChooseNaturalField.CollectInput(farm, plants);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Natural field {shortId} has {this._plants.Count} plants\n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}