
namespace Week_1.Day_5.Polymorphism.Good_Example;

public class NotificationService
{
    private readonly INotification _notification;
    public NotificationService(INotification notification)
    {
        _notification = notification;
    }
    public void Send(string message)
    {
        _notification.Send(message);
    }
}

public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}

public class SMSNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

public class PushNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Push Notification: {message}");
    }
}
