namespace Flight_Management;

public class AirlineCoordinator
{
    List<Flights> flight = new List<Flights>();
    List<Customers> customer = new List<Customers>();
    List<Bookings> bookingsList = new List<Bookings>();

    public void MainMenu()
    {
        Console.WriteLine("OZCAN AIRLINES LIMITED");
        

        bool running = true;
        while (running)
        {
            bool backToMainMenu = true;
            Console.WriteLine("1- Customers");
            Console.WriteLine("2- Flights");
            Console.WriteLine("3- Bookings");
            Console.WriteLine("4- Exit");
            
            int userInput = Int32.Parse(Console.ReadLine());
            Console.Clear();
            switch (userInput)
            {
                
                case 1:
                    Customers.getCustomerMenu(customer);
                    break;
                
                case 2:
                    Flights.getFlightMenu(flight);
                    break;
                case 3:
                    Bookings.getBookingMenu(bookingsList, customer, flight);
                    break;
            }
        }
    }
}