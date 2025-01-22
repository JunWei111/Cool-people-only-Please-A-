using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cool_people_only__Please_A__
{
    class Terminal
    {
        // Parameters
        public string TerminalName { get; set; }
        public Dictionary<string, Airline> Airlines { get; set; }
        public Dictionary<string, Flight> Flights { get; set; }
        public Dictionary<string, BoardingGate> BoardingGates { get; set; }
        public Dictionary<string, double> GateFees { get; set; }


        // Default Constructor
        public Terminal() { }

        // Constructors
        public Terminal(string terminalName, Dictionary<string, Airline> airlines, Dictionary<string, Flight> flights, Dictionary<string, BoardingGate> boardingGates)
        {
            TerminalName = terminalName;
            Airlines = airlines;
            Flights = flights;
            BoardingGates = boardingGates;
        }

        public Terminal(string terminalName, Dictionary<string, Airline> airlines, Dictionary<string, Flight> flights, Dictionary<string, BoardingGate> boardingGates, Dictionary<string, double> gateFees)
        {
            TerminalName = terminalName;
            Airlines = airlines;
            Flights = flights;
            BoardingGates = boardingGates;
            GateFees = gateFees;
        }

        // Methods
        public bool AddAirline(Airline airline)
        {
            throw new NotImplementedException();
        }

        public bool AddBoardingGate(BoardingGate boardingGate)
        {
            throw new NotImplementedException();
        }

        public Airline GetAirlineFromFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        public void PrintAirlineFees()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Terminal Name: " + TerminalName + "Airlines: " + Airlines + "Flights: " + Flights +
                "Boarding Gates: " + BoardingGates + "Gate Fees: " + GateFees;
        }
    }
}
