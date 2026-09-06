namespace Week_3.Day_6.Adapter_Pattern.Good_Example;

public interface IPaymentProcessor
{
    void Pay(decimal amount);
}

public class LegacyPaymentAdapter : IPaymentProcessor
{
    private readonly LegacyPaymentGateway _gateway = new();

    public void Pay(decimal amount)
    {
        _gateway.MakePayment(amount);
    }
}

public class LegacyPaymentGateway
{
    public void MakePayment(decimal amount)
    {
        Console.WriteLine("Legacy payment...");
    }
}

public class OrderService
{
    private readonly IPaymentProcessor _processor;
    public OrderService(IPaymentProcessor processor) => _processor = processor;

    public void Checkout(decimal amount) => _processor.Pay(amount);
}

public class Program
{
    public static void Main(string[] args)
    {
        var paymentGateWay = new LegacyPaymentAdapter();
        var orderService = new OrderService(paymentGateWay);

        orderService.Checkout(100);
    }
}
