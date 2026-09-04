namespace Week_3.Day_3.Good_Example;

// context
public class PaymentService
{
    // composition
    private readonly IPayment _payment;
    public PaymentService(IPayment payment)
    {
        _payment = payment;
    }
    public void Pay(string paymentType, decimal amount)
    {
        _payment.Pay(amount);
    }
}


// interface
public interface IPayment
{
    void Pay(decimal amount);
}

public class CardPayment : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paying {amount} using Card");
    }
}

public class BkashPayment : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paying {amount} using Bkash");
    }
}

public class PayPalPayment : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paying {amount} using PayPal");
    }
}


