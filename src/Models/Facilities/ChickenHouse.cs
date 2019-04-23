using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Actions;


namespace Trestlebridge.Models.Facilities {
    public class ChickenHouse : IFacility<IHouseDwelling>
    {
        private int _capacity = 15;
        private Guid _id = Guid.NewGuid();

        public List<IHouseDwelling> _animals = new List<IHouseDwelling>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource (Farm farm, IHouseDwelling animal)
        {
            if (_animals.Count < _capacity) {
                _animals.Add(animal);
            } else {
                Console.WriteLine(@"**** That facililty is not large enough ****
****     Please choose another one      ****");
                ChooseChickenHouse.CollectInput(farm, animal);
            }
        }

        public void AddResource (Farm farm, List<IHouseDwelling> animals)
        {
            if (_animals.Count + animals.Count <= _capacity) {
                _animals.AddRange(animals);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Chicken house {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}