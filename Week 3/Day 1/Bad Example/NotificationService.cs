
using Week_3.Day_1.Good_Example;

namespace Week_3.Day_1.Bad_Example;

public class NotificationService
{
    public void Send(string type, string message)
    {
        if (type.ToLowerInvariant() == "email")
        {
            // send email
            var notification = new EmailNotification();
            notification.Send(message);
        }
        else if (type.ToLowerInvariant() == "sms")
        {
            // send sms
            var notification = new SmsNotification();
            notification.Send(message);
        }
    }
}


public class EmailNotification
{
    public void Send(string message)
    {
        Console.WriteLine("Send Email...!!!");
    }
}

public class SmsNotification
{
    public void Send(string message)
    {
        Console.WriteLine("Send Sms...!!!");
    }
}

