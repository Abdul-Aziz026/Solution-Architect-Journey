// Decorator pattern...

namespace Week_3.Day_1.Good_Example;

public interface IOrderService
{
    void CreateOrder();
}
public class OrderService : IOrderService
{
    public void CreateOrder()
    {
        Console.WriteLine("Order Creating...");
    }
}

public class LoggingOrderService
{
    private readonly IOrderService _orderService;
    public LoggingOrderService(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public void CreateOrder()
    {
        // log before
        Console.WriteLine("Order Process...");
        // execute order service
        _orderService.CreateOrder();
        // log after
        Console.WriteLine("Order Processed.");
    }
}

