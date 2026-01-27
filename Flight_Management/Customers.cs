using System.Text.RegularExpressions;

namespace Flight_Management;

public class Customers
{

    public string customerName;
    public string customerEmail;
    public long customerPhone;
    public int customer_id;

    public Customers(string customerName, string customerEmail, long customerPhone, int customer_id)
    {
        this.customerName = customerName;
        this.customerEmail = customerEmail;
        this.customerPhone = customerPhone;
        this.customer_id = customer_id;
    }

    public string summary()
    {
        return $"ID: {customer_id}, Name: {customerName}, Email: {customerEmail}, Phone: {customerPhone}";
    }

    public string removedCustumers()
    {
        return $"Customer Named {customerName} - ID: {customer_id} Successfully removed";
    }

    public static void getCustomerMenu(List<Customers> customer)
    {

        bool backToMainMenu = true;
        while (backToMainMenu)
        {
            Console.WriteLine("1 - Add Customer");
            Console.WriteLine("2 - View Customers");
            Console.WriteLine("3 - Delete Customers");
            Console.WriteLine("4 - Back to Main Menu");
            
            int userInput;
            while (true)
            {
                try
                {
                    userInput = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please select a valid number on the menu!");
                }
            }

            switch (userInput)
            {
                case 1:
                    Console.WriteLine("Enter Your Name:");
                    string customerName = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Enter Your Email:");
                    string customerEmail = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Enter Your Phone:");

                    long customerPhone;
                    while (true)
                    {
                        try
                        {
                            customerPhone = Int64.Parse(Console.ReadLine());
                            Console.Clear();
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Please Enter a number");
                        }
                    }
                    
                    Random rndm = new Random();
                    int customer_id;

                    while (true)
                    {
                        customer_id = rndm.Next(1000, 9999);
                        bool isSameId = false;
                        foreach (var id in customer)
                        {
                            if (id.customer_id == customer_id)
                            {
                                isSameId = true;
                                break;
                            }
                        }

                        if (isSameId == false)
                        {
                            break;
                        }
                    }

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
                        Customers newCustomer = new Customers(customerName, customerEmail, customerPhone, customer_id);
                        customer.Add(newCustomer);
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
                        Console.WriteLine(deleteCustomer.removedCustumers());
                        customer.Remove(deleteCustomer);
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
        }
    }
}
