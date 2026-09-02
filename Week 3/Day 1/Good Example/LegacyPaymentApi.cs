// Adapter pattern...

using System.ComponentModel;

namespace Week_3.Day_1.Good_Example;

public interface IPaymentGateway
{
    void Pay(decimal amount);
}

public class LegacyPayment : IPaymentGateway
{
    public void Pay(decimal amount)
    {
        double value = (double)amount;
        var paymentApi = new LegacyPaymentApi();
        paymentApi.MakePayment(value);
    }
}

public class LegacyPaymentApi
{
    public void MakePayment(double value)
    {
        // payment...
    }
}
