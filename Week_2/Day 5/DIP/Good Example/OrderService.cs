namespace Week_2.Day_5.DIP.Good_Example;

public interface IOrderRepository
{
    void Save(string data);
}

public class MySqlDatabase : IOrderRepository
{
    public void Save(string data)
    {
        Console.WriteLine($"Saving to MySQL: {data}");
    }
}

public interface INotificationSender
{
    void Send(string message);
}

public class EmailSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly INotificationSender _emailSender;

    public OrderService (IOrderRepository orderRepository,
        INotificationSender notificationSender)
    {
        _orderRepository = orderRepository;
        _emailSender = notificationSender;
    }

    public void CreateOrder(string orderId)
    {
        Console.WriteLine($"Creating order: {orderId}");

        _orderRepository.Save(orderId);

        _emailSender.Send(
            $"Order {orderId} has been created."
        );
    }
}


