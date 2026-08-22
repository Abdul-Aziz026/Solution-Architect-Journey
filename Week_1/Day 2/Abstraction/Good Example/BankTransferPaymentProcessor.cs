namespace Week_1.Day_2.Abstraction.Good_Example;

public class BankTransferPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing bank transfer: {amount}");

        // Bank transfer specific logic
        Console.WriteLine("Connecting to bank...");
        Console.WriteLine("Creating bank transfer...");
        Console.WriteLine("Bank transfer successful.");
    }
}
