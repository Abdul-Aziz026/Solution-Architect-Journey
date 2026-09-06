
namespace Week_3.Day_5.Decorator_Pattern.Bad_Example;

public class NotificationService
{
    public void Send(string message, bool sendEmail, bool sendSms)
    {
        Console.WriteLine($"Sending notification: {message}");

        if (sendEmail)
        {
            Console.WriteLine("Sending Email");
        }

        if (sendSms)
        {
            Console.WriteLine("Sending SMS");
        }
    }
}
