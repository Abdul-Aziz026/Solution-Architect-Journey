namespace Week_3.Day_3.Bad_Example;

public class PaymentService
{
    public void Pay(string paymentType, decimal amount)
    {
        if (paymentType == "Card")
        {
            Console.WriteLine($"Paying {amount} using Card");
        }
        else if (paymentType == "Bkash")
        {
            Console.WriteLine($"Paying {amount} using Bkash");
        }
        else if (paymentType == "PayPal")
        {
            Console.WriteLine($"Paying {amount} using PayPal");
        }
    }
}
