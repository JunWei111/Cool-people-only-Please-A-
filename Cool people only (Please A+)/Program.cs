//==========================================================
// Student Number	: S10259166
// Student Name	: John Gotinga
// Partner Name	: Yap Jun Wei
//==========================================================

// John: 2, 3, 5, 6, & 9
// Jun Wei: 1, 4, 7 & 8

using Cool_people_only__Please_A__;
using System.Collections.Generic;

void DisplayMenu()
{
    Console.WriteLine("=============================================");
    Console.WriteLine("Welcome to Changi Airport Terminal a5");
    Console.WriteLine("=============================================");
    Console.WriteLine("1. List All Flights");
    Console.WriteLine("2. List Boarding Gates");
    Console.WriteLine("3. Assign a Boarding Gate to a Flight");
    Console.WriteLine("4. Create Flight");
    Console.WriteLine("5. Display Airline Flights");
    Console.WriteLine("6. Modify Flight Details");
    Console.WriteLine("7. Display Flight Schedule");
    Console.WriteLine("0. Exit");

    Console.WriteLine("\nPlease select your option:");
}

//Task 1
//--------------------- Jun Wei's Code ---------------------------
void LoadFiles(Dictionary<string, Airline> airline, Dictionary<string, BoardingGate> boardingGate)
{
    using (StreamReader work = new StreamReader("airlines.csv"))
    {
        // Skip header
        string? please = work.ReadLine();

        while ((please = work.ReadLine()) != null)
        {
            //string initialise
            string[] daddy = please.Split(",");
            //ensure data has the expected columns
            if (daddy.Length >= 2)
            {
                string code = daddy[1];
                string name = daddy[0];
                Airline airlineobj = new Airline(code, name);
                // Add the Airline object to the dictionary using its code as the key
                if (!airline.ContainsKey(code))
                {
                    airline.Add(code, airlineobj);
                }
                else
                {
                    Console.WriteLine($"Airline with code {code} already exists in the dictionary.");
                }
            }
        }
    }
    using (StreamReader work = new StreamReader("boardinggates.csv"))
    {
        // Skip header
        string? please = work.ReadLine();

        while ((please = work.ReadLine()) != null)
        {
            //string initialise
            string[] babygrunk = please.Split(",");
            //ensure data has the expected columns
            if (babygrunk.Length >= 4)
            {
                string gate = babygrunk[0];
                bool DDJB = Convert.ToBoolean(babygrunk[1]);
                bool CFFT = Convert.ToBoolean(babygrunk[2]);
                bool LWTT = Convert.ToBoolean(babygrunk[3]);
                BoardingGate boardingobj = new BoardingGate(gate, DDJB, CFFT, LWTT);
                // Add the boardingGate object to the dictionary using its code as the key
                if (!boardingGate.ContainsKey(gate))
                {
                    boardingGate.Add(gate, boardingobj);
                }
                else
                {
                    Console.WriteLine($"BoardingGate with code {gate} already exists in the dictionary.");
                }
            }
        }
    }
}

// Make the dictionaries to store data


//------------------ End of Jun Wei's Code -----------------------
// Task 2
//----------------------- John's Code ----------------------------
void InitData(Dictionary<string, Flight> flights)
{
    using (StreamReader work = new StreamReader("flights.csv"))
    {
        // Skip header
        string? please = work.ReadLine();

        while ((please = work.ReadLine()) != null)
        {
            // Splits commas and checks the special request code to make a object
            string[] daddy = please.Split(",");
            if (daddy[4] == "NORM")
            {
                NORMFlight tempFlight = new NORMFlight(daddy[0], daddy[1], daddy[2], Convert.ToDateTime(daddy[3]));
                flights[tempFlight.FlightNumber] = tempFlight;
            }
            else if (daddy[4] == "LWTT")
            {
                LWTTFlight tempFlight = new LWTTFlight(daddy[0], daddy[1], daddy[2], Convert.ToDateTime(daddy[3]));
                flights[tempFlight.FlightNumber] = tempFlight;
            }
            else if (daddy[4] == "DDJB")
            {
                DDJBFlight tempFlight = new DDJBFlight(daddy[0], daddy[1], daddy[2], Convert.ToDateTime(daddy[3]));
                flights[tempFlight.FlightNumber] = tempFlight;
            }
            else if (daddy[4] == "CFFT")
            {
                CFFTFlight tempFlight = new CFFTFlight(daddy[0], daddy[1], daddy[2], Convert.ToDateTime(daddy[3]));
                flights[tempFlight.FlightNumber] = tempFlight;
            }
        }
    }
}

//-------------------- End of John's Code ------------------------
// Task 3
//----------------------- John's Code ----------------------------
void DisplayFlight(Dictionary<string, Flight> flights, Dictionary<string, Airline> airline)
{
    Console.WriteLine("=============================================");
    Console.WriteLine("List of Flights for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine("{0, -15} {1, -20} {2, -18} {3} {4}",
        "Flight Number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival");

    foreach (KeyValuePair<string, Flight> crashOut in flights)
    {
        Flight tempFlight = crashOut.Value;

        // Checks airline name based on flight number
        string airlineName = "";
        foreach (KeyValuePair<string, Airline> dietzNutz in airline)
        {
            Airline tempAirline = dietzNutz.Value;
            if (tempFlight.FlightNumber.Contains(tempAirline.Code))
            {
                airlineName = tempAirline.Name;
                break;
            }
        }

        Console.WriteLine("{0, -15} {1, -20} {2, -18} {3} {4}",
            tempFlight.FlightNumber, airlineName, tempFlight.Origin, tempFlight.Destination, tempFlight.ExpectedTime);
    }
}

//-------------------- End of John's Code ------------------------
// Program
//--------------------- Jun Wei's Code ---------------------------

Dictionary<string, Airline> airline = new Dictionary<string, Airline>();
Dictionary<string, BoardingGate> boardingGate = new Dictionary<string, BoardingGate>();
LoadFiles(airline, boardingGate);

//------------------ End of Jun Wei's Code -----------------------
//----------------------- John's Code ----------------------------

//Make the dictionaries to store data
Dictionary<string, Flight> flights = new Dictionary<string, Flight>();
InitData(flights);

// Display Flights
DisplayFlight(flights, airline);

//-------------------- End of John's Code ------------------------