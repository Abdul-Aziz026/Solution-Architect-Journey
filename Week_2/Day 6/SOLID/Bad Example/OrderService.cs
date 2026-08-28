namespace Week_2.Day_6.SOLID.Bad_Example;

public class Order
{
    public int Id { get; set; }
    public string CustomerEmail { get; set; } = "";
    public string PaymentMethod { get; set; } = "";
    public List<OrderItem> Items { get; set; } = new();
}

public class OrderItem
{
    public string ProductName { get; set; } = "";
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public class OrderService
{
    public void ProcessOrder(Order order)
    {
        // 1. Validation
        if (order.Items.Count == 0)
        {
            throw new Exception("Order must contain at least one item.");
        }

        // 2. Calculate total
        decimal total = 0;

        foreach (var item in order.Items)
        {
            total += item.Price * item.Quantity;
        }

        // 3. Save to database
        var database = new MySqlDatabase();
        database.Save(order);

        // 4. Payment
        if (order.PaymentMethod == "CreditCard")
        {
            Console.WriteLine($"Processing credit card: {total}");
        }
        else if (order.PaymentMethod == "PayPal")
        {
            Console.WriteLine($"Processing PayPal: {total}");
        }

        // 5. Send notification
        Console.WriteLine($"Sending email to {order.CustomerEmail}");

        // 6. Generate invoice
        Console.WriteLine($"Generating PDF invoice for order {order.Id}");

        // 7. Logging
        Console.WriteLine($"Order {order.Id} processed.");
    }
}

public class MySqlDatabase
{
    public void Save(Order order)
    {
        Console.WriteLine($"Saving order {order.Id} to MySQL.");
    }
}
