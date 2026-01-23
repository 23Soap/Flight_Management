namespace Flight_Management;

public class Flights
{
    public int flightNumber;
    public string origin;
    public string destination;
    public int maxSeats;
    public int numberOfPassengers;


    public Flights(int flightNumber, string origin, string destination, int maxSeats, int numberOfPassengers)
    {
        this.flightNumber = flightNumber;
        this.origin = origin;
        this.destination = destination;
        this.maxSeats = maxSeats;
        this.numberOfPassengers = numberOfPassengers;
    }

    public string getFlightSummary()
    {
        return $"Flight Number: {flightNumber} - From: {origin} - To: {destination} - Max Seats: {maxSeats} -  Number of Passengers: {numberOfPassengers}";
    }
    
    public string getDeleteFlightSummary()
    {
        return $"Delete Flight Number: {flightNumber} Origin: {origin} To {destination}";
    }

    public static void getFlightMenu(List<Flights> flight )
    {

        bool backToMainMenu = true;
        
        while (backToMainMenu)
                    {
                        Console.WriteLine("\n1 - Add Flight");
                        Console.WriteLine("2 - View Flights");
                        Console.WriteLine("3 - View Particular Flights");
                        Console.WriteLine("4 - Delete Flights");
                        Console.WriteLine("5 - Back to Main Menu");
                        
                        int userInput = Int32.Parse(Console.ReadLine());
                        Console.Clear();

                        switch (userInput)
                        {
                            case 1 :
                                Console.WriteLine("Add Origin");
                                string origin = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Enter Destination:");
                                string destination = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Enter Max Seats:");
                                int maxSeats = Int32.Parse(Console.ReadLine());
                                Console.Clear();
                                Console.WriteLine("Enter Number of Passengers:");
                                int numberOfPassengers = Int32.Parse(Console.ReadLine());
                                
                                Random rndm = new Random();
                                int flightNumber = rndm.Next(1000, 9999);
                                
                                
                                Flights newFlight = new Flights(flightNumber, origin, destination, maxSeats,numberOfPassengers);
                                newFlight.getFlightSummary();
                                
                                bool isSameFlight = false;
                                foreach (var flights in flight)
                                {
                                    if (flights.flightNumber == flightNumber)
                                    {
                                        isSameFlight = true;
                                        break;
                                    }
                                }
                                
                                if (isSameFlight)
                                {
                                    
                                }
                                else
                                {
                                    Flights newFlights = new Flights(flightNumber, origin, destination, maxSeats, numberOfPassengers);
                                    flight.Add(newFlights);
                                }
                                break;
                            
                            case 2:
                                
                                if (flight.Count != 0)
                                {
                                    foreach (var flights in flight)
                                    {
                                        Console.WriteLine(flights.getFlightSummary());
                                        
                                    }
                                }
                                break;
                                
                        
                            case 3:
                                Console.WriteLine("Enter Flight ID for searching Flights:");
                                int searchId = Int32.Parse(Console.ReadLine());
                                foreach (Flights f in flight)
                                {
                                    if (searchId == f.flightNumber)
                                    {
                                        Console.WriteLine(f.getFlightSummary());
                                    }
                                    else
                                    {
                                        Console.Write("There's no Flight found.");
                                    }
                                }
                                break;
                            
                            
                            case 4:
                                Console.WriteLine("Enter Flight ID for DELETING Flights:");
                                int deleteFlightId = Int32.Parse(Console.ReadLine());
                                
                                Flights deleteFlight = null;
                                foreach (Flights f in flight)
                                {
                                    if (deleteFlightId == f.flightNumber)
                                    {
                                        deleteFlight = f;
                                        break;
                                    }
                                }

                                if (deleteFlight != null)
                                {
                                    Console.WriteLine(deleteFlight.getDeleteFlightSummary());
                                    flight.Remove(deleteFlight);
                                }
                                break;
                            
                            case 5:
                                backToMainMenu = false;
                                Console.Clear();
                                break;
                        }
                    }
    }
}