using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class PlowedField : IFacility<IPlowedFieldDwelling>
    {
        private double _capacity = 13;
        private Guid _id = Guid.NewGuid();

        public List<IPlowedFieldDwelling> _plants = new List<IPlowedFieldDwelling>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource (Farm farm, IPlowedFieldDwelling plant)
        {
                _plants.Add(plant);
        }

        public void AddResource (Farm farm, List<IPlowedFieldDwelling> plants)
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
                //if(plants[0].Type == "SunFlower")
                //     ChooseBothField.CollectInput(farm,plants);
                // else
                    ChoosePlowedField.CollectInput(farm, plants);
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