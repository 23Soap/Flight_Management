namespace Flight_Management;

public class Bookings
{
    public int bookingNumber;
    public string bookingDate;
    public Customers customers;
    public Flights flight;

    public Bookings(int bookingNumber, string bookingDate, Customers customers, Flights flight)
    {
        this.bookingNumber = bookingNumber;
        this.bookingDate = DateTime.Now.ToString("dd/MM/yyyy");
        this.customers = customers;
        this.flight = flight;
    }

    public string getBookingSummary()
    {
        return $"Booking #{bookingNumber} on {bookingDate}\n" +
               $"Name: {customers.customerName}, Flight NO: {flight.flightNumber}\n" +
               $"Booking Date: {bookingDate}";
    }

    public string getBookingDate()
    {
        return $"Booking Date is: {bookingDate} ";
    }

    public static void getBookingMenu(List<Bookings> bookingsList, List<Customers> customersList, List<Flights> flightsList)
    {
        Console.Clear();
        Console.WriteLine("BOOKING MENU");
        Console.WriteLine("Please Select a choice from the menu below:");
        bool backToMainMenu = true;
        while (backToMainMenu)
        {
            Console.WriteLine("1 - Make Booking");
            Console.WriteLine("2 - View Bookings");
            Console.WriteLine("3 - Back to Main Menu");
            int userInput = Convert.ToInt32(Console.ReadLine());
            switch (userInput)
            {

                case 1:
                    Console.Clear();
                    Console.WriteLine("Add Booking");
                    
                    //
                    foreach (var f in flightsList)
                    {
                        Console.WriteLine("---Flights---");
                        Console.WriteLine(f.getFlightSummary());
                    }
                    
                    foreach (var c in customersList)
                    {
                        Console.WriteLine("---Customer---");
                        Console.WriteLine(c.summary());
                    }
                    
                    Console.WriteLine("Enter Unique Customer ID");
                    int customerIdInput = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Unique Flight Number");
                    int flightNumberInput = Int32.Parse(Console.ReadLine());
                    
                    Random rndm = new Random();
                    int bookingNumber = rndm.Next(1000, 9999);
                    
                    string bookingDate = null;
                    
                    
                    bool isTheSameCustomer = false;
                    Customers selectedCustomer = null;
                    foreach (var id in customersList)
                    {
                        if (id.customer_id == customerIdInput )
                        {
                            isTheSameCustomer = true;
                            selectedCustomer = id;
                            Console.WriteLine($"Customer ID: #{selectedCustomer.customer_id} is found\n" +
                                              $"Name : {selectedCustomer.customerName}\n" +
                                              $"E-Mail : {selectedCustomer.customerEmail}\n" +
                                              $"Phone Number: {selectedCustomer.customerPhone}");
                            break;
                        }
                    }
                    
                    bool isTheSameFlight = false;
                    Flights selectedFlight = null;
                    foreach (var id in flightsList)
                    {
                        if (id.flightNumber == flightNumberInput )
                        {
                            isTheSameFlight = true;
                            selectedFlight = id;
                            Console.WriteLine($"Flight ID: #{selectedFlight.flightNumber} is found\n" +
                                              $"From : {selectedFlight.origin} -----> {selectedFlight.destination}\n");
                            break;
                        }
                    }
                    
                    Bookings newBooking = new Bookings(bookingNumber,bookingDate,selectedCustomer,selectedFlight);
                    bookingsList.Add(newBooking);
                    selectedFlight.numberOfPassengers++;
                    break;
                    
                    
                case 2:

                    foreach (var booking in bookingsList)
                    {
                        Console.WriteLine(booking.getBookingSummary());
                        Console.WriteLine(booking.getBookingDate());
                    }
                    
                    break;
                case 3:
                    backToMainMenu = false;
                    break;
            }
        }
    }
}
    