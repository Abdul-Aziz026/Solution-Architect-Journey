
namespace Week_3.Day_2.Simple_Factory_V1;

public class SimpleFactory
{
    public IPayment Create(string type)
    {

        return type switch
        {
            "bkash" => new BkashPayment(),
            "nagad" => new NagadPayment(),
            _ => throw new InvalidOperationException()
        };
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
        var factory = new SimpleFactory();

        var payment = factory.Create("bkash");
        payment.Pay(100);
    }
}