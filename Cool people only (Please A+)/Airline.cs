using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cool_people_only__Please_A__
{
    internal class Airline
    {
        // Parameters
        public string Name { get; set; }
        public string Code { get; set; }
        public Dictionary<string, Flight> Flights { get; set; }

        // Default Constructor
        public Airline() { }
        public Airline(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
