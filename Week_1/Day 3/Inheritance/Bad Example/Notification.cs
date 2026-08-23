using System;
using System.Collections.Generic;
using System.Text;

namespace Week_1.Day_3.Inheritance.Bad_Example;

public class Notification
{
    public void Send()
    {
        Console.WriteLine("Sending generic notification...");
    }

    public void Log()
    {
        Console.WriteLine("Logging notification...");
    }
}

public class EmailNotification : Notification
{
    public new void Send()
    {
        Console.WriteLine("Sending email...");
    }

    public new void Log()
    {
        Console.WriteLine("Logging email...");
    }
}

public class SmsNotification : Notification
{
    public new void Send()
    {
        Console.WriteLine("Sending SMS...");
    }

    public new void Log()
    {
        Console.WriteLine("Logging SMS...");
    }
}
