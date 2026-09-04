
namespace Week_3.Day_4.Observer_Pattern.Bad_Example;

public class OrderService
{
    public void CompleteOrder()
    {
        SendEmail();
        SendSms();
        UpdateLogger();
    }
    private void SendEmail() { }
    private void SendSms() { }
    private void UpdateLogger() { }
}
