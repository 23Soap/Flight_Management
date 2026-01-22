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
               $"Name: {customers.customerName}, Flight NO: {flight.flightNumber}";
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
                    
                    break;
            }
        }
    }
}
    