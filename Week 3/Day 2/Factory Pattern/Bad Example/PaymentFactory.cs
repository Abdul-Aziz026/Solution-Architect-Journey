
namespace Week_3.Day_2.Factory_Pattern.Bad_Example;

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
    public IPayment Create(string type) => type switch
    {
        "bkash" => new BkashPayment(),
        "nagad" => new NagadPayment(),
        _ => throw new ArgumentException($"Unsupported type: {type}")
    };
}