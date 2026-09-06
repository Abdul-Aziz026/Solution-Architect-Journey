
namespace Week_3.Day_6.Adapter_Pattern.Bad_Example;

public class LegacyPaymentGateway
{
    public void MakePayment(int amountInCents, string currency) { /* 0=ok, 1=declined */ }
}

public class OrderService
{
    private readonly LegacyPaymentGateway _gateway = new();

    public void Checkout(double amount)
    {
        _gateway.MakePayment((int)(amount * 100), "USD"); // conversion + gateway leak into every caller
    }
}
