//==========================================================
// Student Number	: S10259166
// Student Name	: John Gotinga

// Student Number	: S10259029
// Student Name	: Yap Jun Wei
//==========================================================

// John: 2, 3, 5, 6, & 9
// Jun Wei: 1, 4, 7 & 8

using Cool_people_only__Please_A__;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
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
        Airline tempAirline = terminal.GetAirlineFromFlight(tempFlight);

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
            tempFlight.FlightNumber, tempAirline.Name, tempFlight.Origin, tempFlight.Destination,
            tempFlight.ExpectedTime, tempFlight.Status, gateName);
    }
    Console.WriteLine();
}

//-------------------- End of John's Code ------------------------
// Task 4
//--------------------- Jun Wei's Code ---------------------------
void ListBoardingGates(Terminal terminal)
{
    Console.WriteLine("=============================================");
    Console.WriteLine("List of Boarding Gates for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine("{0,-15} {1,-22} {2,-22} {3,-22} {4}", "Gate Name", "DDJB", "CFFT", "LWTT", "Flights");
    foreach (var gate in terminal.BoardingGates.Values)
    {
        if (gate.Flight != null)
        {
            // Print the gate details, special request codes and flight numbers assigned
            Console.WriteLine($"{gate.GateName,-15} {gate.SupportsDDJB,-22} {gate.SupportsCFFT,-22} {gate.SupportsLWTT,-22} {gate.Flight.FlightNumber}");
        }
        // Print the gate details and special request codes
        Console.WriteLine($"{gate.GateName,-15} {gate.SupportsDDJB,-22} {gate.SupportsCFFT,-22} {gate.SupportsLWTT,-22} Unassigned");
    }
}
//------------------ End of Jun Wei's Code -----------------------
// Task 5
//----------------------- John's Code ----------------------------

bool ValidateInputFlight(string flightNum)
{
    if (flightNum == null)
    {
        Console.WriteLine("Empty inputs are not allowed.");
        return false;
    }
    else if (!flightNum.Replace(" ", "").All(c => Char.IsLetterOrDigit(c))) // Checks if input only contains letters and numbers
    {
        Console.WriteLine("Only letters and numbers are allowed.");
        return false;
    }
    else if (flightNum.Length < 6 || flightNum.Length > 6)
    {
        Console.WriteLine("Please follow the formatting (e.g. TR 786)");
        return false;
    }
    else if (!flightNum.Contains(" "))
    {
        Console.WriteLine("Please follow the formatting (e.g. TR 786)");
        return false;
    }
    return true;
}

bool ValidateInputGate(string gateName)
{
    if (gateName == null)
    {
        Console.WriteLine("Empty inputs are not allowed.");
        return false;
    }
    else if (!gateName.All(c => Char.IsLetterOrDigit(c))) // Checks if input only contains letters and numbers
    {
        Console.WriteLine("Only letters and numbers are allowed.");
        return false;
    }
    else if (gateName.Length < 2 || gateName.Length > 2)
    {
        Console.WriteLine("Please follow the formatting (e.g. A1)");
        return false;
    }
    else if (gateName.Contains(" "))
    {
        Console.WriteLine("Please follow the formatting (e.g. A1)");
        return false;
    }
    return true;
}

bool SetFlightStatus(Flight flight, BoardingGate boardingGate, string status)
{
    if (status == "1")
    {
        flight.Status = "Delayed";
        boardingGate.Flight = flight;
        return true;
    }
    else if (status == "2")
    {
        flight.Status = "Boarding";
        boardingGate.Flight = flight;
        return true;
    }
    else if (status == "3")
    {
        flight.Status = "On Time";
        boardingGate.Flight = flight;
        return true;
    }
    else
    {
        return false;
    }
}

void AssignBoardingGateToFlight(Terminal terminal)
{
    while (true)
    {
        // Inputs
        Console.WriteLine("Please enter your flight number (e.g. TR 786):");
        string? flightNum = Console.ReadLine();
        flightNum = flightNum.Trim().ToUpper();

        // Validate input
        bool validInput = ValidateInputFlight(flightNum);
        if (!validInput) continue;

        // Checks if flight number inputted is in the dictionary
        bool foundFlight = false;
        Flight tempFlight = new NORMFlight();
        if (!terminal.Flights.TryGetValue(flightNum, out tempFlight))
        {
            Console.WriteLine("Flight not found.");
            continue;
        }
        foundFlight = true;

        if (foundFlight)
        {
            while (true)
            {
                Console.WriteLine("Enter the boarding gate name:");
                string? gateName = Console.ReadLine();
                gateName = gateName.ToUpper();

                // Validate input
                validInput = false;
                validInput = ValidateInputGate(gateName);
                if (!validInput) continue;

                // Checks if gate name inputted is in the dictionary
                bool foundGate = false;
                BoardingGate tempGate = new BoardingGate();
                if (!terminal.BoardingGates.TryGetValue(gateName, out tempGate))
                {
                    Console.WriteLine("Gate name not found.");
                    continue;
                }
                foundGate = true;

                // If gate is found. Also checks if it has a flight assigned to it
                if (foundGate)
                {
                    if (!(tempGate.Flight == null))
                    {
                        Console.WriteLine("Gate already has a flight assigned to it.");
                        continue;
                    }

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
                        confirmation = confirmation.Trim().ToUpper();

                        if (confirmation == "Y")
                        {
                            // Select status of the flight
                            Console.WriteLine("1. Delayed");
                            Console.WriteLine("2. Boarding");
                            Console.WriteLine("3. On Time");
                            Console.WriteLine("Please select the new status of the flight");
                            string? status = Console.ReadLine();

                            bool assigned = SetFlightStatus(tempFlight, tempGate, status);
                            if (assigned)
                            {
                                Console.WriteLine("Flight {0} has been assigned to Boarding Gate {1}!",
                                    tempFlight.FlightNumber, tempGate.GateName);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid option.");
                                continue;
                            }
                        }
                        else if (confirmation == "N")
                        {
                            SetFlightStatus(tempFlight, tempGate, "3");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid option.");
                            continue;
                        }
                    }
                }
                break;
            }
        }
        break;
    }
}

//-------------------- End of John's Code ------------------------
// Task 6
//----------------------- John's Code ----------------------------

bool CreateSpecialFlightDetails(Terminal terminal, Flight flight, string flightNumber, string origin, string destination, DateTime expectedTime, string sac)
{
    // Format input
    sac = sac.Trim().ToUpper();

    if (sac == "LWTT")
    {
        flight = new LWTTFlight(flightNumber, origin, destination, expectedTime, sac);
        terminal.Flights[flight.FlightNumber] = flight;
        Console.WriteLine("New flight, {0}, has been successfully added.", flight.FlightNumber);
        return true;
    }
    else if (sac == "DDJB")
    {
        flight = new DDJBFlight(flightNumber, origin, destination, expectedTime, sac);
        terminal.Flights[flight.FlightNumber] = flight;
        Console.WriteLine("New flight, {0}, has been successfully added.", flight.FlightNumber);
        return true;
    }
    else if (sac == "CFFT")
    {
        flight = new CFFTFlight(flightNumber, origin, destination, expectedTime, sac);
        terminal.Flights[flight.FlightNumber] = flight;
        Console.WriteLine("New flight, {0}, has been successfully added.", flight.FlightNumber);
        return true;
    }
    else
    {
        Console.WriteLine("Invalid special access code.");
        return false;
    }
}

bool CreateFlightDetails(Terminal terminal, Flight flight, string flightNumber, string origin, string destination, DateTime expectedTime)
{
    flight = new NORMFlight(flightNumber, origin, destination, expectedTime);
    terminal.Flights[flight.FlightNumber] = flight;
    Console.WriteLine("New flight, {0}, has been successfully added.", flight.FlightNumber);
    return true;
}

void AddNewFlight(Terminal terminal)
{
    while (true)
    {
        Console.Write("Please enter the flight number: ");
        string flightNumber = Console.ReadLine();

        // Formats flight number
        flightNumber = flightNumber.Trim().ToUpper();
        if (flightNumber.Length < 5)
        {
            Console.WriteLine("Invalid flight number or flight already exists.");
            continue;
        }
        else if (!flightNumber.Contains(" "))
        {
            flightNumber = flightNumber.Substring(0, 2) + " " + flightNumber.Substring(2);
        }
        flightNumber = flightNumber.ToUpper();

        // Validates input
        bool validInput = ValidateInputFlight(flightNumber);
        if (!validInput) continue;

        // Checks if input has a valid airline code
        bool validCode = false;
        bool flightExists = false;
        foreach (Airline airline in terminal.Airlines.Values)
        {
            if (flightNumber.StartsWith(airline.Code))
            {
                validCode = true;
                if (terminal.Flights.ContainsKey(flightNumber))
                {
                    flightExists = true;
                    break;
                }
                break;
            }
        }

        if (!validCode)
        {
            Console.WriteLine("Airline code does not exist.");
            continue;
        }
        else if (flightExists)
        {
            Console.WriteLine("Flight already exists.");
            continue;
        }

        // Origin and Destination details
        string? origin;
        while (true)
        {
            Console.Write("Please enter the origin of the flight: ");
            origin = Console.ReadLine();

            // Format input
            origin = origin.Trim();

            if (origin == null)
            {
                Console.WriteLine("Input cannot be empty.");
                continue;
            }
            else break;
        }

        string? destination;
        while (true)
        {
            Console.Write("Please enter the origin of the flight: ");
            destination = Console.ReadLine();

            // Format input
            destination = destination.Trim();

            if (destination == null)
            {
                Console.WriteLine("Input cannot be empty.");
                continue;
            }
            else break;
        }

        while (true)
        {
            Console.Write("Please enter the expected departure/arrival time (e.g. \"10:10 pm\"): ");
            string? input = Console.ReadLine();

            // Checks if user input matches format. Basically input validation
            DateTime expectedTime;
            if (!DateTime.TryParseExact(input, "h:mm tt", null, System.Globalization.DateTimeStyles.None, out expectedTime))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            // Creates flight object
            Flight flight = new NORMFlight();
            Console.Write("Is there additional information you would like to add? (Y/N): ");
            string option = Console.ReadLine();
            option = option.ToUpper();

            bool created = false;
            if (option == "Y")
            {
                Console.Write("Please enter the special request code of the flight (LWTT/DDJB/CFFT) : ");
                string? sac = Console.ReadLine();

                created = CreateSpecialFlightDetails(terminal, flight, flightNumber, origin, destination, expectedTime, sac);
            }
            else if (option == "N")
            {
                created = CreateFlightDetails(terminal, flight, flightNumber, origin, destination, expectedTime);
            }

            // If flight object not created, repeat input prompt
            if (!created) continue;

            // Checks if there's a special access code, and writes data to flights.csv
            using (StreamWriter diddy = new StreamWriter("flights.csv", true))
            {
                if (flight.SAC == null)
                {
                    diddy.WriteLine(flight.FlightNumber + "," + flight.Origin + "," + flight.Destination + "," +
                        flight.ExpectedTime.ToString("h:mm tt"));
                }
                else
                {
                    diddy.WriteLine(flight.FlightNumber + "," + flight.Origin + "," + flight.Destination + "," +
                        flight.ExpectedTime.ToString("h:mm tt") + "," + flight.SAC);
                }
            }
            break;
        }
        break;
    }
}
//-------------------- End of John's Code ------------------------
// Task 7
//--------------------- Jun Wei's Code ---------------------------
void DisplayAirlineFlights(Terminal terminal)
{
    try
    {
        Console.WriteLine("=============================================");
        Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
        Console.WriteLine("=============================================");
        foreach (var airline in terminal.Airlines.Values)
        {
            Console.WriteLine("{0,-15} {1,-25}", airline.Code, airline.Name);
        }
        Console.Write("Enter Airline Code: ");
        string code = Console.ReadLine();

        if (terminal.Airlines.ContainsKey(code))
        {
            Airline airline = terminal.Airlines[code];
            Console.WriteLine("=============================================");
            Console.WriteLine("List of Flights for {0}", airline.Name);
            Console.WriteLine("=============================================");
            Console.WriteLine("{0,-15} {1,-20} {2,-20} {3,-17} {4}", "Flight Number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival Time");
            foreach (var flight in terminal.Flights.Values)
            {
                if (flight.FlightNumber.Contains(airline.Code))
                {
                    Console.WriteLine("{0,-15} {1,-20} {2,-20} {3,-17} {4}", flight.FlightNumber, airline.Name, flight.Origin, flight.Destination, flight.ExpectedTime);
                }
            }
        }
        else
        {
            Console.WriteLine("Airline not found.");
        }
    }
    catch (KeyNotFoundException ex)
    {
        Console.WriteLine($"Error: Airline code not found. {ex.Message}");
    }
    catch (FormatException ex)
    {
        Console.WriteLine($"Error: Invalid format encountered. {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
//------------------ End of Jun Wei's Code -----------------------
// Task 8
//--------------------- Jun Wei's Code ---------------------------


//------------------ End of Jun Wei's Code -----------------------
// Task 9
//----------------------- John's Code ----------------------------

void DisplayFlightOrdered(Terminal terminal)
{
    SortedList<DateTime, Flight> sortedFlight = new SortedList<DateTime, Flight>();

    foreach (Flight tempFlight in terminal.Flights.Values)
    {
        sortedFlight[tempFlight.ExpectedTime] = tempFlight;
    }

    Console.WriteLine("=============================================");
    Console.WriteLine("List of Flights for Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine("{0, -15} {1, -20} {2, -20} {3, -17} {4, -28} {5, -14} {6}",
        "Flight Number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival", "Status", "Boarding Gate");

    foreach (Flight tempFlight in sortedFlight.Values)
    {
        // Checks airline name based on flight number
        Airline tempAirline = terminal.GetAirlineFromFlight(tempFlight);

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
            tempFlight.FlightNumber, tempAirline.Name, tempFlight.Origin, tempFlight.Destination,
            tempFlight.ExpectedTime, tempFlight.Status, gateName);
    }
    Console.WriteLine();
}

//-------------------- End of John's Code ------------------------
// Program

//Make the dictionaries to store data
Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();
Dictionary<string, BoardingGate> boardingGates = new Dictionary<string, BoardingGate>();
Dictionary<string, Flight> flights = new Dictionary<string, Flight>();
InitData(flights);
LoadFiles(airlines, boardingGates);
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
    else if (option == 2)
    {
        ListBoardingGates(terminal);
    }
    else if (option == 3)
    {
        AssignBoardingGateToFlight(terminal);
    }
    else if (option == 5)
    {
        DisplayAirlineFlights(terminal);
    }
    else if (option == 7)
    {
        DisplayFlightOrdered(terminal);
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
