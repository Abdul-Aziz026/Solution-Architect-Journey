namespace Week_2.Day_3.LSP.Bad_Example;

public class PaymentProcessor
{
    public virtual void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment: {amount}");
    }

    public virtual void Refund(decimal amount)
    {
        Console.WriteLine($"Refunding payment: {amount}");
    }
}

public class CreditCardProcessor : PaymentProcessor
{
    public override void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment: {amount}");
    }

    public override void Refund(decimal amount)
    {
        Console.WriteLine($"Refunding credit card payment: {amount}");
    }
}

public class CashPaymentProcessor : PaymentProcessor
{
    public override void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing cash payment: {amount}");
    }

    public override void Refund(decimal amount)
    {
        throw new NotSupportedException("Cash payments cannot be refunded.");
    }
}


public class PaymentService
{
    public void RefundPayment(PaymentProcessor processor, decimal amount)
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

        service.RefundPayment(
            new CashPaymentProcessor(),
            100
        ); // ❌ Throws exception
    }
}

