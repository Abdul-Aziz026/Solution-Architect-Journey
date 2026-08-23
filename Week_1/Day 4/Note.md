# Composition over Inheritance

**Today's topic:** Build the same feature using inheritance and then using composition, and feel the difference.

## What is Composition?

**Composition means:** A class contains another object and delegates some responsibility to it.
```
public class EmailSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

public class NotificationService
{
    private readonly EmailSender _emailSender;

    public NotificationService(EmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public void Notify(string message)
    {
        _emailSender.Send(message);
    }
}
```
So, That's the composition
```
NotificationService
       |
       | HAS-A
       ↓
   EmailSender
```








