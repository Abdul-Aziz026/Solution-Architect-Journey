namespace Week_2.Day_3.LSP.Good_Example;

public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}

public interface IRefundProcessor
{
    void Refund(decimal amount);
}

public class CreditCardProcessor : IPaymentProcessor, IRefundProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment: {amount}");
    }

    public void Refund(decimal amount)
    {
        Console.WriteLine($"Refunding credit card payment: {amount}");
    }
}

public class CashPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing cash payment: {amount}");
    }
}


public class PaymentService
{
    public void Payment(IPaymentProcessor processor, decimal amount)
    {
        processor.ProcessPayment(amount);
    }
    public void RefundPayment(IRefundProcessor processor, decimal amount)
    {
        processor.Refund(amount);
    }
}

public class DemoRunner
{
    public void Run()
    {
        var service = new PaymentService();

        service.RefundPayment(
            new CreditCardProcessor(),
            100
        ); // ✅ Works
    }
}

