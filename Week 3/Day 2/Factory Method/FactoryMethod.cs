
namespace Week_3.Day_2.Factory_Method;

public abstract class PaymentProcessor
{
    protected abstract IPayment CreatePayment();

    public void ProcessPayment(decimal amount)
    {
        var payment = CreatePayment();
        payment.Pay(amount);
    }
}

public class BkashPaymentProcessor : PaymentProcessor
{
    protected override IPayment CreatePayment()
    {
        return new BkashPayment();
    }
}

public class NagadPaymentProcessor : PaymentProcessor
{
    protected override IPayment CreatePayment()
    {
        return new NagadPayment();
    }
}

public interface IPayment
{
    void Pay(decimal amount);
}

public class BkashPayment : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Bkash payment: {amount} Taka");
    }
}

public class NagadPayment : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Nagad payment: {amount} Taka");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        PaymentProcessor f = new BkashPaymentProcessor();
        f.ProcessPayment(100);
    }
}
