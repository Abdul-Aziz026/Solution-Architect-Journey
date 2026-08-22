namespace Week_1.Day_2.Abstraction.Bad_Example;

public class PaymentService
{
    public void ProcessPayment(string paymentType, decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        if (paymentType == "CreditCard")
        {
            Console.WriteLine($"Processing credit card payment: {amount}");

            // Credit card specific logic
            Console.WriteLine("Connecting to credit card provider...");
            Console.WriteLine("Charging credit card...");
            Console.WriteLine("Credit card payment successful.");
        }
        else if (paymentType == "PayPal")
        {
            Console.WriteLine($"Processing PayPal payment: {amount}");

            // PayPal specific logic
            Console.WriteLine("Connecting to PayPal...");
            Console.WriteLine("Authenticating with PayPal...");
            Console.WriteLine("PayPal payment successful.");
        }
        else if (paymentType == "BankTransfer")
        {
            Console.WriteLine($"Processing bank transfer: {amount}");

            // Bank transfer specific logic
            Console.WriteLine("Connecting to bank...");
            Console.WriteLine("Creating bank transfer...");
            Console.WriteLine("Bank transfer successful.");
        }
        else
        {
            throw new ArgumentException("Unsupported payment type.");
        }
    }
}