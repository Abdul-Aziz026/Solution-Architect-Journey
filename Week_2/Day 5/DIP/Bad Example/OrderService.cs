namespace Week_2.Day_5.DIP.Bad_Example;

public class MySqlDatabase
{
    public void Save(string data)
    {
        Console.WriteLine($"Saving to MySQL: {data}");
    }
}

public class EmailSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

public class OrderService
{
    private readonly MySqlDatabase _database;
    private readonly EmailSender _emailSender;

    public OrderService()
    {
        _database = new MySqlDatabase();
        _emailSender = new EmailSender();
    }

    public void CreateOrder(string orderId)
    {
        Console.WriteLine($"Creating order: {orderId}");

        _database.Save(orderId);

        _emailSender.Send(
            $"Order {orderId} has been created."
        );
    }
}


