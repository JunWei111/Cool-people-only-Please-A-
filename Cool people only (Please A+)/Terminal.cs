﻿//==========================================================
// Student Number	: S10259166
// Student Name	: John Gotinga

// Student Number	: S10259029
// Student Name	: Yap Jun Wei
//==========================================================

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

            string[] parts = flight.FlightNumber.Split(' ');
            if (parts.Length < 1)
            {
                Console.WriteLine($"Error: Invalid flight number format: {flight.FlightNumber}");
                return null;
            }
            string airlinePrefix = parts[0];

            // Lookup the airline using the prefix
            if (Airlines.TryGetValue(airlinePrefix, out Airline airline))
            {
                return airline;
            }
            return null;
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
