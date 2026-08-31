
using System.Collections;

namespace Week_3.Day_1.Good_Example;

public class NotificationService
{
    private readonly NotificationFactory _notificationFactory;
    public NotificationService(NotificationFactory notificationFactory)
    {
        _notificationFactory = notificationFactory;
    }

    public void Send(string type, string message)
    {
        var notification = _notificationFactory.Create(type);
        notification.Send(message);
    }
}

public class NotificationFactory
{
    public INotification Create(string type)
    {
        type = type.ToLowerInvariant();
        return type switch
        {
            "email" => new EmailNotification(),
            "sms" => new SmsNotification(),
            _ => new NotSupportedException("")
        };
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
        Console.WriteLine("Send Email...!!!");
    }
}

public class SmsNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Send Sms...!!!");
    }
}

