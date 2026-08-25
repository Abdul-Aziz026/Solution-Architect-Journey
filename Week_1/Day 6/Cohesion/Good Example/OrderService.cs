namespace Week_1.Day_6.Coupling.Good_Example;

public class OrderService
{
    public void CreateOrder() { }

    public void CancelOrder() { }

    public void GenerateInvoice() { }
}

public class CalculatorService
{
    public void CalculateTotal() { }
}

public class EmailSender
{
    public void SendEmail() { }
}

public class PaymentProcessor
{
    public void ProcessPayment() { }
}

public class OrderManager
{
    private readonly OrderService _orderService;
    private readonly CalculatorService _calculatorService;
    private readonly EmailSender _emailSender;
    private readonly PaymentProcessor _paymentProcessor;
    public OrderManager(OrderService orderService,
        CalculatorService calculatorService,
        EmailSender emailSender,
        PaymentProcessor paymentProcessor)
    {
        _orderService = orderService;
        _calculatorService = calculatorService;
        _emailSender = emailSender;
        _paymentProcessor = paymentProcessor;
    }
    public void CreateOrder()
    {
        _orderService.CreateOrder();
        _calculatorService.CalculateTotal();
        _paymentProcessor.ProcessPayment();
        _emailSender.SendEmail();
    }
    public void CancelOrder()
    {
        _orderService.CancelOrder();
    }
    public void GenerateInvoice()
    {
        _orderService.GenerateInvoice();
    }
}
