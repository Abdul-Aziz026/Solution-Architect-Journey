namespace Week_1.Day_2.Abstraction.Good_Example;

public class CreditCardPaymentService : IPaymentService
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment: {amount}");

        // Credit card specific logic
        Console.WriteLine("Connecting to credit card provider...");
        Console.WriteLine("Charging credit card...");
        Console.WriteLine("Credit card payment successful.");
    }
}
