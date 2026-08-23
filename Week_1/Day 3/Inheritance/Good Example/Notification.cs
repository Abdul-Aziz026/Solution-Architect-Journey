
namespace Week_1.Day_3.Inheritance.Good_Example
    ;

public class GNotification
{
    public virtual void Send()
    {
        Console.WriteLine("Sending generic notification...");
    }

    public void Log()
    {
        Console.WriteLine("Logging notification...");
    }
}

public class GEmailNotification : GNotification
{
    public override void Send()
    {
        Console.WriteLine("Sending email...");
    }
}

public class GSmsNotification : GNotification
{
    public override void Send()
    {
        Console.WriteLine("Sending SMS...");
    }
}
