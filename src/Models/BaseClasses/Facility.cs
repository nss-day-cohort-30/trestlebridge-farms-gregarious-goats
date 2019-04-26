using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;


namespace Trestlebridge.Models.BaseClasses
{
    public class Facility
    {
        // Properties
        private double _capacity { get; set; }

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }
        public List<IResource> Resources = new List<IResource>();
        private Guid _id = Guid.NewGuid();
        public string ShortId
        {
            get
            {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }


        // Constructor
        public Facility(double x)
        {
            _capacity = x;
        }

        // Methods
        public void AddResource(Farm farm, IResource x)
        {
            Resources.Add(x);
        }

        public void AddResource(Farm farm, List<IResource> x)
        {
            if (Resources.Count + x.Count <= _capacity)
            {
                Resources.AddRange(x);
            }
        }

        // *********************************************************
        public void RemoveResource(Farm farm, IResource x)
        {
            if (Resources.Count - 1 > 0)
            {
                Resources.Remove(x);
            }
        }
        public void RemoveResource(Farm farm, List<IResource> x)
        {
            if (Resources.Count - x.Count > 0)
            {
                for (int i = 0; i < x.Count; i++)
                    Resources.Remove(x[0]);
            }
        }
        // **********************************************************
    }
}