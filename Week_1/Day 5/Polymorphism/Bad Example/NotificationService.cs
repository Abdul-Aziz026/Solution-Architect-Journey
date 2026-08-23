
namespace Week_1.Day_5.Polymorphism.Bad_Example;

public class NotificationService
{
    public void Send(string type, string message)
    {
        if (type == "Email")
        {
            Console.WriteLine($"Sending Email: {message}");
        }
        else if (type == "SMS")
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
        else if (type == "Push")
        {
            Console.WriteLine($"Sending Push Notification: {message}");
        }
        else
        {
            throw new ArgumentException("Unknown notification type.");
        }
    }
}
