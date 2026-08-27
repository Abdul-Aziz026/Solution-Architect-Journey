
namespace Week_2.Day_2.OCP.Bad_Example;


public class PaymentService
{
    public void ProcessPayment(string paymentMethod, decimal amount)
    {
        if (paymentMethod == "CreditCard")
        {
            Console.WriteLine($"Processing Credit Card payment: {amount}");
        }
        else if (paymentMethod == "PayPal")
        {
            Console.WriteLine($"Processing PayPal payment: {amount}");
        }
        else if (paymentMethod == "BankTransfer")
        {
            Console.WriteLine($"Processing Bank Transfer: {amount}");
        }
        else if (paymentMethod == "MobileWallet")
        {
            Console.WriteLine($"Processing Mobile Wallet payment: {amount}");
        }
        else
        {
            throw new ArgumentException("Unsupported payment method.");
        }
    }
}
