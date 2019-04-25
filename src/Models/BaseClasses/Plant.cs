using System;

namespace Trestlebridge.Models.BaseClasses
{
    public class Plant
    {
        private string _type { get; set; }
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        public Plant(string type)
        {
            _type = type;
        }
        public override string ToString()
        {
            return $"{Type}!";
        }
    }
}