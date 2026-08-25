namespace Week_1.Day_6.Coupling.Bad_Example;

public class OrderService
{
    public void CreateOrder() { }

    public void CancelOrder() { }

    public void CalculateTotal() { }

    public void SendEmail() { }

    public void ProcessPayment() { }

    public void GenerateInvoice() { }
}
