﻿//==========================================================
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
    Console.WriteLine("Welcome to Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine("1. List All Flights");
    Console.WriteLine("2. List Boarding Gates");
    Console.WriteLine("3. Assign a Boarding Gate to a Flight");
    Console.WriteLine("4. Create Flight");
    Console.WriteLine("5. Display Airline Flights");
    Console.WriteLine("6. Modify Flight Details");
    Console.WriteLine("7. Display Flight Schedule");
    Console.WriteLine("0. Exit");
}

//Task 1
//--------------------- Jun Wei's Code ---------------------------

void LoadFiles(Dictionary<string, Airline> airlines, Dictionary<string, BoardingGate> boardingGates)
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
                Airline airlineobj = new Airline(name, code);
                // Add the Airline object to the dictionary using its code as the key
                if (!airlines.ContainsKey(code))
                {
                    airlines.Add(code, airlineobj);
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
                if (!boardingGates.ContainsKey(gate))
                {
                    boardingGates.Add(gate, boardingobj);
                }
                else
                {
                    Console.WriteLine($"BoardingGate with code {gate} already exists in the dictionary.");
                }
            }
        }
    }
}

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
            if (daddy[4] != "")
            {
                if (daddy[4] == "LWTT")
                {
                    LWTTFlight tempFlight = new LWTTFlight(daddy[0], daddy[1], daddy[2], Convert.ToDateTime(daddy[3]), daddy[4]);
                    flights[tempFlight.FlightNumber] = tempFlight;
                    continue;
                }
                else if (daddy[4] == "DDJB")
                {
                    DDJBFlight tempFlight = new DDJBFlight(daddy[0], daddy[1], daddy[2], Convert.ToDateTime(daddy[3]), daddy[4]);
                    flights[tempFlight.FlightNumber] = tempFlight;
                    continue;
                }
                else if (daddy[4] == "CFFT")
                {
                    CFFTFlight tempFlight = new CFFTFlight(daddy[0], daddy[1], daddy[2], Convert.ToDateTime(daddy[3]), daddy[4]);
                    flights[tempFlight.FlightNumber] = tempFlight;
                    continue;
                }
            }
            else
            {
                NORMFlight tempFlight = new NORMFlight(daddy[0], daddy[1], daddy[2], Convert.ToDateTime(daddy[3]));
                flights[tempFlight.FlightNumber] = tempFlight;
                continue;
            }
        }
    }
}

//-------------------- End of John's Code ------------------------
// Task 3
//----------------------- John's Code ----------------------------

void DisplayFlight(Terminal terminal)
{
    Console.WriteLine("=============================================");
    Console.WriteLine("List of Flights for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine("{0, -15} {1, -20} {2, -20} {3, -17} {4, -28} {5, -14} {6}",
        "Flight Number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival", "Status", "Boarding Gate");

    foreach (KeyValuePair<string, Flight> crashOut in terminal.Flights)
    {
        Flight tempFlight = crashOut.Value;

        // Checks airline name based on flight number
        string airlineName = "";
        foreach (KeyValuePair<string, Airline> dietzNutz in terminal.Airlines)
        {
            Airline tempAirline = dietzNutz.Value;
            if (tempFlight.FlightNumber.Contains(tempAirline.Code))
            {
                airlineName = tempAirline.Name;
                break;
            }
        }

        // Checks to see if flight is assigned to a boarding gate
        string gateName = "Unassigned";
        foreach (KeyValuePair<string, BoardingGate> boardBoard in terminal.BoardingGates)
        {
            BoardingGate tempGate = boardBoard.Value;
            if (tempGate.Flight == tempFlight)
            {
                gateName = tempGate.GateName;
            }
        }

        Console.WriteLine("{0, -15} {1, -20} {2, -20} {3, -17} {4, -28} {5, -14} {6}",
            tempFlight.FlightNumber, airlineName, tempFlight.Origin, tempFlight.Destination, 
            tempFlight.ExpectedTime, tempFlight.Status, gateName);
    }
    Console.WriteLine();
}

//-------------------- End of John's Code ------------------------
// Task 5
//----------------------- John's Code ----------------------------

void AssignBoardingGateToFlight(Terminal terminal)
{
    while (true)
    {
        // Inputs
        Console.WriteLine("Please enter your Flight Number:");
        string? flightNum = Console.ReadLine();

        flightNum = flightNum.Trim();
        // Checks to see if whitespace is present. If none, adds in whitespace
        if (!flightNum.Contains(" "))
        {
            flightNum = flightNum.Substring(0, 2) + " " + flightNum.Substring(2);
        }
        flightNum = flightNum.ToUpper();

        // Checks if flight number inputted is in the dictionary
        bool foundFlight = false;
        Flight tempFlight = new NORMFlight();
        foreach (KeyValuePair<string, Flight> flight in terminal.Flights)
        {
            tempFlight = flight.Value;
            if (flightNum == tempFlight.FlightNumber)
            {
                foundFlight = true;
                break;
            }
        }

        if (foundFlight)
        {
            while (true)
            {
                Console.WriteLine("Enter Boarding Gate Name:");
                string? gateName = Console.ReadLine();
                gateName = gateName.ToUpper();

                // Checks if gate name inputted is in the dictionary
                bool foundGate = false;
                BoardingGate tempGate = new BoardingGate();
                foreach (KeyValuePair<string, BoardingGate> grrrr in terminal.BoardingGates)
                {
                    tempGate = grrrr.Value;
                    if (gateName == tempGate.GateName)
                    {
                        foundGate = true;
                        break;
                    }
                }

                // If gate is found. Checks if it has a flight assigned to it
                if (foundGate)
                {
                    if (tempGate.Flight == null)
                    {
                        while (true)
                        {
                            // Flight details
                            Console.WriteLine("Flight Number: {0}", tempFlight.FlightNumber);
                            Console.WriteLine("Flight Number: {0}", tempFlight.Origin);
                            Console.WriteLine("Flight Number: {0}", tempFlight.Destination);
                            Console.WriteLine("Flight Number: {0}", tempFlight.ExpectedTime);
                            if (tempFlight.SAC != null)
                            {
                                Console.WriteLine("Special Request Code: {0}", tempFlight.SAC);
                            }
                            else
                            {
                                Console.WriteLine("Special Request Code: None");
                            }
                            // Gate details
                            Console.WriteLine("Boarding Gate Name: {0}", tempGate.GateName);
                            Console.WriteLine("Supports DDJB: {0}", tempGate.SupportsDDJB);
                            Console.WriteLine("Supports CFFT: {0}", tempGate.SupportsCFFT);
                            Console.WriteLine("Supports LWTT: {0}", tempGate.SupportsLWTT);
                            
                            // Inputs
                            Console.WriteLine("Would you like to update the status of the flight? (Y/N)");
                            string? confirmation = Console.ReadLine();
                            confirmation = confirmation.ToUpper();

                            if (confirmation == "Y")
                            {
                                Console.WriteLine("1. Delayed");
                                Console.WriteLine("2. Boarding");
                                Console.WriteLine("3. On Time");
                                Console.WriteLine("Please select the new status of the flight");
                                string? status = Console.ReadLine();

                                if (status == "1")
                                {
                                    tempFlight.Status = "Delayed";
                                    tempGate.Flight = tempFlight;
                                    Console.WriteLine("Flight {0} has been assigned to Boarding Gate {1}!",
                                        tempFlight.FlightNumber, tempGate.GateName);
                                    break;
                                }
                                else if (status == "2")
                                {
                                    tempFlight.Status = "Boarding";
                                    tempGate.Flight = tempFlight;
                                    Console.WriteLine("Flight {0} has been assigned to Boarding Gate {1}!",
                                        tempFlight.FlightNumber, tempGate.GateName);
                                    break;
                                }
                                else if (status == "3")
                                {
                                    tempFlight.Status = "On Time";
                                    tempGate.Flight = tempFlight;
                                    Console.WriteLine("Flight {0} has been assigned to Boarding Gate {1}!",
                                        tempFlight.FlightNumber, tempGate.GateName);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid option.");
                                }
                            }
                            else if (confirmation == "N")
                            {
                                tempFlight.Status = "On Time";
                                tempGate.Flight = tempFlight;
                                Console.WriteLine(tempFlight.Status);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid option.");
                                continue;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("This boarding gate already has a flight assigned to it.");
                        continue;
                    }
                }
                else if (!foundGate)
                {
                    Console.WriteLine("Gate not found.");
                    continue;
                }

                break;
            }
        }
        else if (!foundFlight)
        {
            Console.WriteLine("Flight not found.");
            continue;
        }

        break;
    }
}

//-------------------- End of John's Code ------------------------
// Task 6
//----------------------- John's Code ----------------------------

void AddNewFlight(Terminal terminal)
{
    while (true)
    {
        Console.Write("Please enter the flight number: ");
        string flightNumber = Console.ReadLine();

        // Formats flight number
        flightNumber = flightNumber.Trim();
        if (!flightNumber.Contains(" "))
        {
            flightNumber = flightNumber.Substring(0, 2) + " " + flightNumber.Substring(2);
        }
        flightNumber = flightNumber.ToUpper();


        // Checks if input is valid
        Boolean valid = false;
        if (flightNumber.Length < 7)
        {
            // Checks if flight number has a valid airline code
            foreach (KeyValuePair<string, Airline> fortnite in terminal.Airlines)
            {
                if (flightNumber.Contains(fortnite.Key))
                {
                    // Checks if flight number already exists
                    if (!terminal.Flights.ContainsKey(flightNumber))
                    {
                        valid = true;
                    }

                    break;
                }
            }
        }

        if (valid)
        {
            Console.Write("Please enter the origin of the flight: ");
            string origin = Console.ReadLine();
            
            Console.Write("Please enter the destination of the flight: ");
            string destination = Console.ReadLine();
            
            // Need to setup input validation for DateTime
            Console.Write("Please enter the expected departure/arrival time (hour:minute am/pm): ");
            DateTime expectedTime = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Is there additional information you would like to add? (Y/N): ");
            string option = Console.ReadLine();
            option = option.ToUpper();

            if (option == "Y")
            {
                Console.Write("Please enter the special request code of the flight: ");
                string sac = Console.ReadLine();

                // Make if statements to check what class the flight should be
            }
            else if (option == "N")
            {
                Flight flight = new NORMFlight(flightNumber, origin, destination, expectedTime);
                terminal.Flights[flight.FlightNumber] = flight;
                Console.WriteLine("New flight, {0}, has been successfully added.", flight.FlightNumber);
            }
            else
            {
                Console.WriteLine("Please enter a valid option.");
            }

            // Still need to make code write into flights.csv file
        }
        else if (!valid)
        {
            Console.WriteLine("Invalid flight number or flight already exists.");
            continue;
        }

        break;
    }
}

//-------------------- End of John's Code ------------------------
// Program

//Make the dictionaries to store data
Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();
Dictionary<string, BoardingGate> boardingGates = new Dictionary<string, BoardingGate>();
LoadFiles(airlines, boardingGates);
Dictionary<string, Flight> flights = new Dictionary<string, Flight>();
InitData(flights);

// Store all Dictionaries into a Terminal class
Terminal terminal = new Terminal("Terminal 5", airlines, flights, boardingGates);

// Display menu
while (true)
{
    DisplayMenu();

    int option = 0;
    try
    {
        Console.WriteLine("\nPlease select your option:");
        option = Convert.ToInt32(Console.ReadLine());
    }
    catch (FormatException ex)
    {
        Console.WriteLine("Please enter a number");
        continue;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        continue;
    }

    if (option == 1)
    {
        DisplayFlight(terminal);
    }
    else if (option == 3)
    {
        AssignBoardingGateToFlight(terminal);
    }
    else if (option == 4)
    {
        AddNewFlight(terminal);
    }
    else if (option == 0)
    {
        Console.WriteLine("Goodbye!");
        break;
    }
    else
    {
        Console.WriteLine("Please enter a valid option");
    }
}
