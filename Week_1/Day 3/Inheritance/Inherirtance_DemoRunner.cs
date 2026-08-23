using System;
using System.Collections.Generic;
using System.Text;
using Week_1.Day_3.Inheritance.Good_Example;

namespace Week_1.Day_3.Inheritance.Bad_Example;

public class Inherirtance_DemoRunner
{
    public static void Run()
    {
        // Bad Example
        Console.WriteLine("Bad Example:");
        Notification notification1 = new EmailNotification();
        Notification notification2 = new SmsNotification();

        notification1.Send();
        notification2.Send();

        notification1.Log();
        notification2.Log();

        // Good Example
        Console.WriteLine("\nGood Example:");
        GNotification notification3 = new GEmailNotification();
        GNotification notification4 = new GSmsNotification();

        notification3.Send();
        notification4.Send();

        notification3.Log();
        notification4.Log();
    }
}
