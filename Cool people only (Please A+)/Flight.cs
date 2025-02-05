﻿//==========================================================
// Student Number	: S10259166
// Student Name	: John Gotinga
// Partner Name	: Yap Jun Wei
//==========================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cool_people_only__Please_A__
{
    abstract class Flight : IComparable<Flight>
    {
        // Create parameters
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ExpectedTime { get; set; }
        public string Status { get; set; }
        public string SAC { get; set; } // Special Acces Code shortened to SAC

        // Default Constructor
        public Flight() { }

        // Constructors
        public Flight(string flightNumber, string origin, string destination, DateTime expectedTime, string status)
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            Status = status;
        }

        public Flight(string flightNumber, string origin, string destination, DateTime expectedTime, string sac, string status)
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            Status = status;
            SAC = sac;
        }

        // Methods
        public abstract double CalculateFees();

        public int CompareTo(Flight flight)
        {
            return ExpectedTime.CompareTo(flight.ExpectedTime);
        }

        public override string ToString()
        {
            return "Flight Number: " + FlightNumber + "Origin: " + Origin + "Destination: " + Destination +
                "Expected time: " + ExpectedTime + "Status: " + Status;
        }
    }

    class NORMFlight : Flight
    {
        // No parameters made because it's only using inherited stuff from 'Flight'
        // Default Constructor
        public NORMFlight() { }

        // Constructors
        public NORMFlight(string flightNumber, string origin, string destination, DateTime expectedTime) : base(flightNumber, origin, destination, expectedTime, "Scheduled")
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
        }

        // Methods
        public override double CalculateFees()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    class LWTTFlight : Flight
    {
        // Parameters
        public double RequestFee { get; set; }

        // Default Constructor
        public LWTTFlight() { }

        // Constructors
        public LWTTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string sac) : base(flightNumber, origin, destination, expectedTime, sac, "Scheduled")
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            SAC = sac;
            RequestFee = 500.0;
        }

        // Methods
        public override double CalculateFees()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString() + "Request fee: " + RequestFee;
        }
    }

    class DDJBFlight : Flight
    {
        // Parameters
        public double RequestFee { get; set; }

        // Default Constructor
        public DDJBFlight() { }

        // Constructors
        public DDJBFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string sac) : base(flightNumber, origin, destination, expectedTime, sac, "Scheduled")
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            SAC = sac;
            RequestFee = 300.0;
        }

        // Methods
        public override double CalculateFees()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString() + "Request fee: " + RequestFee;
        }
    }

    class CFFTFlight : Flight
    {
        // Parameters
        public double RequestFee { get; set; }

        // Default Constructor
        public CFFTFlight() { }

        // Constructors
        public CFFTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string sac) : base(flightNumber, origin, destination, expectedTime, sac, "Scheduled")
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
            SAC = sac;
            RequestFee = 150.0;
        }

        // Methods
        public override double CalculateFees()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString() + "Request fee: " + RequestFee;
        }
    }
}
