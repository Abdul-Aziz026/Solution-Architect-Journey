
namespace Week_3.Day_5.Decorator_Pattern.Good_Example;

public interface INotification
{
    void Send(string message);
}

public class Notification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending notification: {message}");
    }
}

public class NotificationDecorator : INotification
{
    private readonly INotification _notification;
    public NotificationDecorator(INotification notification)
    {
        _notification = notification;
    }
    public virtual void Send(string message)
    {
        _notification.Send(message);
    }
}

public class EmailNotificationDecorator : NotificationDecorator
{
    public EmailNotificationDecorator(INotification notification)
        : base(notification)
    {
    }
    public override void Send(string message)
    {
        Console.WriteLine("Sending Email");
        base.Send(message);
    }
}

public class SmsNotificationDecorator : NotificationDecorator
{
    public SmsNotificationDecorator(INotification notification)
        : base(notification)
    {
    }
    public override void Send(string message)
    {
        Console.WriteLine("Sending SMS");
        base.Send(message);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        INotification notification = new Notification();
        notification = new EmailNotificationDecorator(notification);
        notification = new SmsNotificationDecorator(notification);
        notification.Send("Hello, World!");
    }
}
