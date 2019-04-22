using System;
using System.Collections.Generic;

namespace Trestlebridge.Models
{
    public class Animal
    {
        // Properties:
        private string _type { get; set; }

        private Guid _id = Guid.NewGuid();

        private string _shortId
        {
            get
            {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        // Public getter/setter for private properties:
        public string Type
        {
            set { _type = value; }
            get { return Type; }
        }
        public string ShortId
        {
            get { return _shortId; }
        }

        // Methods:
        public override string ToString()
        {
            return $"Type:{Type} - ID:{this._shortId}";
        }
    }
}