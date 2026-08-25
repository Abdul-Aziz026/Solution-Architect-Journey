namespace Week_1.Review.Bad_Example;

public class OrderManager
{
    public List<Order> Orders { get; set; }

    public void CreateOrder(
        string customerName,
        string email,
        string paymentType,
        decimal price)
    {
        // Create order
        var order = new Order();
        order.CustomerName = customerName;
        order.Email = email;
        order.Price = price;
        order.Status = "Created";

        Orders.Add(order);

        // Calculate price
        var total = price + (price * 0.15m);

        // Payment
        if (paymentType == "Stripe")
        {
            var stripe = new StripePaymentProcessor();
            stripe.ProcessPayment(total);
        }
        else if (paymentType == "PayPal")
        {
            var paypal = new PayPalPaymentProcessor();
            paypal.ProcessPayment(total);
        }

        // Invoice
        var invoice = new InvoiceGenerator();
        invoice.GenerateInvoice(order);

        // Email
        var emailSender = new EmailSender();
        emailSender.SendEmail(
            email,
            "Your order has been created"
        );

        // Database
        var database = new SqlDatabase();
        database.Save(order);

        // Logging
        var logger = new FileLogger();
        logger.Write("Order created");
    }

    public void CancelOrder(Order order)
    {
        order.Status = "Cancelled";
    }

    public void ChangePrice(Order order, decimal price)
    {
        order.Price = price;
    }

    public void SendEmail(string email)
    {
        var emailSender = new EmailSender();
        emailSender.SendEmail(email, "Hello");
    }

    public void BackupDatabase()
    {
        var database = new SqlDatabase();
        database.Backup();
    }
}

public class Order
{
    public string CustomerName { get; set; }
    public string Email { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
}

public class StripePaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
    }
}

public class PayPalPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
    }
}

public class InvoiceGenerator
{
    public void GenerateInvoice(Order order)
    {
    }
}

public class EmailSender
{
    public void SendEmail(string email, string message)
    {
    }
}

public class SqlDatabase
{
    public void Save(Order order)
    {
    }

    public void Backup()
    {
    }
}

public class FileLogger
{
    public void Write(string message)
    {
    }
}
