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
            Console.WriteLine("Customers");
            int userInput = Int32.Parse(Console.ReadLine());
            
            switch (userInput)
            {
                case 1:
                    while (running)
                    {
                        Console.WriteLine("1- Add Customer: ");
                        Console.WriteLine("2 - View Customers");
                        Console.WriteLine("3 - Delete Customers");
                        Console.WriteLine("4 - Back to Main Menu");
                        
                        int userInput2 = Int32.Parse(Console.ReadLine());

                        switch (userInput2)
                        {
                            case 1:
                                Console.WriteLine("1 - Add Customer");
                                
                                Console.WriteLine("Enter Your Name:");
                                string customerName = Console.ReadLine();
                                Console.WriteLine("Enter Your Email:");
                                string customerEmail = Console.ReadLine();
                                Console.WriteLine("Enter Your Phone:");
                                long customerPhone = Int64.Parse(Console.ReadLine());
                    
                                Random rndm = new Random();
                                int customer_id = rndm.Next(1000, 9999);
                    
                                Customers newCustomers = new Customers(customerName, customerEmail, customerPhone, customer_id);

                                customer.Add(newCustomers);
                    
                                Console.WriteLine("Customer successfully added");
                                Console.WriteLine(newCustomers.summary());
                                break;
                            
                            case 2:
                                foreach (var customers in customer)
                                {
                                    Console.WriteLine(customers.summary());
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
                                    customer.Remove(deleteCustomer);
                                    Console.WriteLine($"Customer Named ({deleteCustomer.customerName} - {deleteCustomer.customer_id})successfully removed");
                                }
                                else
                                {
                                    Console.WriteLine($"Customer ID ({searchId},) does not exist");
                                }
                                break;
                        }
                    }
                    break;
            }
        }
    }
}