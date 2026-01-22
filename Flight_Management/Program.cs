namespace Flight_Management;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ABC AIRLINES LIMITED");
        
        List<Customers> customer = new List<Customers>();

        bool running = true;
        while (running)
        {
            Console.WriteLine("1- Customers");
            Console.WriteLine("2- Flights");
            Console.WriteLine("3- Bookings");
            Console.WriteLine("4- Exit");
            
            int userInput = Int32.Parse(Console.ReadLine());
            Console.Clear();
            switch (userInput)
            {
                
                case 1:
                    bool backToMainMenu = true;
                    while (backToMainMenu)
                    {
                        Console.WriteLine("1 - Add Customer");
                        Console.WriteLine("2 - View Customers");
                        Console.WriteLine("3 - Delete Customers");
                        Console.WriteLine("4 - Back to Main Menu");

                        int userInput2 = Int32.Parse(Console.ReadLine());

                        switch (userInput2)
                        {
                            case 1:
                                Console.WriteLine("1 - Add Customer");
                                Console.Clear();
                                Console.WriteLine("Enter Your Name:");
                                string customerName = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Enter Your Email:");
                                string customerEmail = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Enter Your Phone:");
                                long customerPhone = Int64.Parse(Console.ReadLine());
                                Console.Clear();

                                Random rndm = new Random();
                                int customer_id = rndm.Next(1000, 9999);

                                Customers newCustomers = new Customers(customerName, customerEmail, customerPhone,
                                    customer_id);

                                bool isSameCustomer = false;

                                foreach (var customers in customer)
                                {
                                    if (customers.customerEmail == customerEmail || customers.customerPhone == customerPhone)
                                    {
                                        isSameCustomer = true;
                                        break;
                                    }
                                }

                                if (isSameCustomer)
                                {
                                    Console.WriteLine(
                                        $"This E-Mail ({customerEmail}) or Phone Number ({customerPhone}) already in the system!");
                                }
                                else
                                {
                                    customer.Add(newCustomers);
                                    Console.WriteLine("Successfully Added!");
                                }

                                break;

                            case 2:
                                if (customer.Count != 0)
                                {
                                    foreach (var customers in customer)
                                    {
                                        Console.WriteLine(customers.summary());
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("There is no Customer found");
                                }

                                break;
                            case 3:
                                Console.WriteLine("Enter Customer ID for deleting:");

                                int searchId = Int32.Parse(Console.ReadLine());

                                Customers deleteCustomer = null;
                                foreach (Customers customers in customer)
                                {
                                    if (customers.customer_id == searchId)
                                    {
                                        deleteCustomer = customers;
                                        break;
                                    }
                                }

                                if (deleteCustomer != null)
                                {
                                    foreach (var customers in customer)
                                    {
                                        customer.Remove(deleteCustomer);
                                        Console.WriteLine(customers.removedCustumers());
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Customer ID ({searchId},) does not exist");
                                }

                                break;

                            case 4:
                                backToMainMenu = false;
                                Console.Clear();
                                break;
                        }
                    }break;
                
                
                case 2: 
                    
                    break;
            }
        }
    }
}