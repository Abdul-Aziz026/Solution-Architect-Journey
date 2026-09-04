
namespace Week_3.Day_4.Observer_Pattern.Good_Example;

public interface IOrderObserver
{
    void Update(string status);
}

public class EmailObserver : IOrderObserver
{
    public void Update(string status)
    {
        Console.WriteLine($"Email sent for order status: {status}");
    }
}

public class SmsObserver : IOrderObserver
{
    public void Update(string status)
    {
        Console.WriteLine($"SMS sent for order status: {status}");
    }
}

public class LoggerObserver : IOrderObserver
{
    public void Update(string status)
    {
        Console.WriteLine($"Order status logged: {status}");
    }
}

public class OrderService
{
    private readonly List<IOrderObserver> _observers = new();

    public void RegisterObserver(IOrderObserver observer)
    {
        _observers.Add(observer);
    }

    public void UnregisterObserver(IOrderObserver observer)
    {
        _observers.Remove(observer);
    }

    public void CompleteOrder()
    {
        var status = "Order completed";
        Console.WriteLine(status);
        foreach (var observer in _observers)
        {
            observer.Update(status);
        }
    }
}
