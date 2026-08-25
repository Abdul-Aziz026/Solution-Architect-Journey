using Week_1.Day_6.Coupling.Good_Example;

namespace Week_1.Day_7.Coupling.Bad_Example;

public class OrderService
{
    public void CreateOrder()
    {
        var calculator = new PriceCalculator();
        var payment = new StripePaymentProcessor();
        var email = new EmailSender();
        var invoice = new InvoiceGenerator();

        var total = calculator.CalculateTotal();

        payment.ProcessPayment(total);
        invoice.GenerateInvoice();
        email.SendEmail();
    }
}

public class InvoiceGenerator
{
    public void GenerateInvoice() { }
}

public class StripePaymentProcessor
{
    public void ProcessPayment(decimal total) { }
}

public class PriceCalculator
{
    public decimal CalculateTotal() { return 10; }
}