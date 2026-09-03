
namespace Week_3.Day_2.Simple_Factory_V2;

public class SimpleFactory_V2
{
    private readonly Dictionary<string, Func<IPayment>> _containers = new();
    public void Register(string type, Func<IPayment> factory)
    {
        _containers.TryAdd(type, factory);
    }
    public IPayment Create(string type)
    {
        if (!_containers.TryGetValue(type, out var factory))
        {
            throw new ArgumentException("Unsupported Payment type");
        }
        return factory();
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
        var factory = new SimpleFactory_V2();
        factory.Register("bkash", () => new BkashPayment());
        factory.Register("nagad", () => new NagadPayment());

        var payment = factory.Create("bkash");
        payment.Pay(100);
    }
}