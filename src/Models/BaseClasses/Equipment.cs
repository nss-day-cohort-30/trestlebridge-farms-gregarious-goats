using System;
using System.Collections.Generic;

namespace Trestlebridge.Models
{
    public class Equipment
    {
        public string Type {get;}
        public double Capacity {get;}

        public Equipment (string type, double capacity) {
            Type = type;
            Capacity = capacity;
        }
    }
}