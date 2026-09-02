
namespace Week_3.Day_2.Factory_Pattern.Good_Example;

public interface IPayment
{
    void Pay(decimal amount);
}

public class BkashPayment : IPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Paid {amount} via bKash.");
}

public class NagadPayment : IPayment
{
    public void Pay(decimal amount) => Console.WriteLine($"Paid {amount} via Nagad.");
}

public class PaymentFactory
{
    private readonly Dictionary<string, Func<IPayment>> _providers = new();

    public void Register(string type, Func<IPayment> obj)
    {
        _providers[type] = obj;
    }

    public IPayment Create(string type)
    {
        if (!_providers.TryGetValue(type, out var obj))
        {
            throw new ArgumentException($"Unsupported type: {type}");
        }
        return obj();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var factory = new PaymentFactory();
        factory.Register("bkash", () => new BkashPayment());
        factory.Register("nagad", () => new NagadPayment());

        IPayment payment = factory.Create("bkash");
        payment.Pay(100);

        payment = factory.Create("nagad");
        payment.Pay(120);
    }
}