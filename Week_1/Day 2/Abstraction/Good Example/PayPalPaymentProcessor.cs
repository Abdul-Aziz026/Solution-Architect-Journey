namespace Week_1.Day_2.Abstraction.Good_Example;

public class PayPalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment: {amount}");

        // PayPal specific logic
        Console.WriteLine("Connecting to PayPal...");
        Console.WriteLine("Authenticating with PayPal...");
        Console.WriteLine("PayPal payment successful.");
    }
}
