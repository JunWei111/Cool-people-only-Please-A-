//==========================================================
// Student Number	: S10259029
// Student Name	: Yap Jun Wei
// Partner Name	: John Gotinga
//==========================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cool_people_only__Please_A__
{
    internal class BoardingGate
    {
        // Parameters
        public string GateName { get; set; }
        public bool SupportsCFFT { get; set; }
        public bool SupportsDDJB { get; set; }
        public bool SupportsLWTT { get; set; }
        public Flight Flight { get; set; }

        // Default Constructor
        public BoardingGate() { }

        // Constructors
        public BoardingGate(string gateName, bool supportsCFFT, bool supportsDDJB, bool supportsLWTT, Flight flight)
        {
            GateName = gateName;
            SupportsCFFT = supportsCFFT;
            SupportsDDJB = supportsDDJB;
            SupportsLWTT = supportsLWTT;
            Flight = flight;
        }
        public BoardingGate(string gateName, bool supportsCFFT, bool supportsDDJB, bool supportsLWTT)
        {
            GateName = gateName;
            SupportsCFFT = supportsCFFT;
            SupportsDDJB = supportsDDJB;
            SupportsLWTT = supportsLWTT;
        }
        public BoardingGate(string gateName)
        {
            GateName = gateName;
        }
        // Methods
        public double CalculateFees()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Gate Name: " + GateName + "Supports CFFT: " + SupportsCFFT +
                "Supports DDJB: " + SupportsDDJB + "Supports LWTT: " + SupportsLWTT;
        }
    }
}
