using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.BaseClasses;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models
{
    public class Farm
    {
        public List<Facility> GrazingFields { get; } = new List<Facility>();
        public List<Facility> PlowedFields { get; } = new List<Facility>();
        public List<Facility> NaturalFields { get; } = new List<Facility>();
        public List<Facility> ChickenHouses { get; } = new List<Facility>();
        public List<Facility> DuckHouses { get; } = new List<Facility>();

        /*
            This method must specify the correct product interface of the
            resource being purchased.
         */
        // public void PurchaseResource<T> (IResource resource, int index)
        // {
        //     Console.WriteLine(typeof(T).ToString());
        //     switch (typeof(T).ToString())
        //     {
        //         case "Cow":
        //             GrazingFields[index].AddResource(farm, (IGrazing)resource);
        //             break;
        //         default:
        //             break;
        //     }
        // }

        public void AddGrazingField (GrazingField field)
        {
            GrazingFields.Add(field);
        }
        public void AddPlowedField (PlowedField field)
        {
            PlowedFields.Add(field);
        }
        public void AddNaturalField (NaturalField field)
        {
            NaturalFields.Add(field);
        }
        public void AddChickenHouse (ChickenHouse house)
        {
            ChickenHouses.Add(house);
        }
        public void AddDuckHouse (DuckHouse house)
        {
            DuckHouses.Add(house);
        }

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();

            GrazingFields.ForEach(gf => report.Append(gf));
            PlowedFields.ForEach(pf => report.Append(pf));
            NaturalFields.ForEach(nf => report.Append(nf));
            ChickenHouses.ForEach(ch => report.Append(ch));
            DuckHouses.ForEach(dh => report.Append(dh));

            return report.ToString();
        }
    }
}