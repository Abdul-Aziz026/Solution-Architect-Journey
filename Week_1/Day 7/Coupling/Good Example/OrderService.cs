using Week_1.Day_6.Coupling.Good_Example;

namespace Week_1.Day_7.Coupling.Good_Example;

public class OrderService
{
    private readonly IPriceCalculator _priceCalculator;
    private readonly IPaymentProcessor _paymentProcessor;
    private readonly IInvoiceGenerator _invoice;
    private readonly IEmailSender _emailSender;
    public OrderService(IPriceCalculator priceCalculator, 
        IPaymentProcessor paymentProcessor,
        IInvoiceGenerator invoice,
        IEmailSender emailSender)
    {
        _priceCalculator = priceCalculator;
        _paymentProcessor = paymentProcessor;
        _invoice = invoice;
        _emailSender = emailSender;
    }
    public void CreateOrder()
    {
        var total = _priceCalculator.CalculateTotal();
        _paymentProcessor.ProcessPayment(total);

        _invoice.GenerateInvoice();
        _emailSender.SendEmail();
    }
}

public interface IInvoiceGenerator
{
    void GenerateInvoice();
}

public class InvoiceGenerator : IInvoiceGenerator
{
    public void GenerateInvoice() { }
}

public interface IEmailSender
{
    void SendEmail();
}

public class EmailSender : IEmailSender
{
    public void SendEmail() { }
}

public interface IPaymentProcessor
{
    void ProcessPayment(decimal total);
}

public class StripePaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal total) { }
}

public interface IPriceCalculator
{
    decimal CalculateTotal();
}

public class PriceCalculator : IPriceCalculator
{
    public decimal CalculateTotal() { return 10; }
}