// Strategy pattern...
namespace Week_3.Day_1.Good_Example;

public class PaymentService
{
    private readonly IPayment _payment;
    public PaymentService(IPayment payment)
    {
        _payment = payment;
    }
    public void Process(string type, decimal amount)
    {
        _payment.Pay(amount);
    }
}

public interface IPayment
{
    void Pay(decimal amount);
}

public class  CardPayment : IPayment
{
    public void Pay(decimal amount)
    {
        // Card payment
    }
}

public class PaypalPayment : IPayment
{
    public void Pay(decimal amount)
    {
        // Paypal payment
    }
}

public class BankPayment : IPayment
{
    public void Pay(decimal amount)
    {
        // Bank payment
    }
}