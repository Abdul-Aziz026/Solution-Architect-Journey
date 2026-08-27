
namespace Week_2.Day_2.OCP.Good_Example;


public class PaymentService
{
    private readonly IPaymentProcessor _paymentProcessor;
    public PaymentService(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }
    public void ProcessPayment(decimal amount)
    {
        _paymentProcessor.Pay(amount);
    }
}

public interface IPaymentProcessor
{
    public void Pay(decimal amount);
}

public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Processing Credit Card payment: {amount}");
    }
}

public class PayPalPaymentProcessor : IPaymentProcessor
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment: {amount}");
    }
}

public class BankTransferPaymentProcessor : IPaymentProcessor
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Processing Bank Transfer: {amount}");
    }
}

public class MobileWalletPaymentProcessor : IPaymentProcessor
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Processing Mobile Wallet payment: {amount}");
    }
}