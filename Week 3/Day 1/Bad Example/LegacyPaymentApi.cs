namespace Week_3.Day_1.Bad_Example;

public interface IPaymentGateway
{
    void Pay(decimal amount);
}
/*
 * 
 * Application
 *     |
 * IPaymentGateway
 *     |
 *    ???
 *     |
 * LegacyPaymentApi
 * 
 * */

public class LegacyPaymentApi
{
    public void MakePayment(double value)
    {
        // payment...
    }
}
