
namespace Week_3.Day_1.Bad_Example;

public class PaymentService
{
    public void Process(string type, decimal amount)
    {
        if (type.ToLowerInvariant() == "card")
        {
            // Card payment
        }
        else if (type.ToLowerInvariant() == "paypal")
        {
            // Paypal payment
        }
        else if (type.ToLowerInvariant() == "bank")
        {
            // Bank payment
        }
    }
}

public class CardPayment
{
    public void Pay(decimal amount)
    {
        // Card payment
    }
}

public class PaypalPayment
{
    public void Pay(decimal amount)
    {
        // Paypal payment
    }
}

public class BankPayment
{
    public void Pay(decimal amount)
    {
        // Bank payment
    }
}