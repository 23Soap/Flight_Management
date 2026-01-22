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
        return $" ID: {customer_id} ,Name: {customerName}, Email: {customerEmail}, Phone: {customerPhone},";
    }

    public string removedCustumers()
    {
        return $" Custumer Named {customerName} - ID: {customer_id} Successfully  removed";
    }
}