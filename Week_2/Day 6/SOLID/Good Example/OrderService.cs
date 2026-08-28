
namespace Week_2.Day_6.SOLID.Good_Example;

public class Order
{
    public int Id { get; set; }
    public string CustomerEmail { get; set; } = "";
    public List<OrderItem> Items { get; set; } = new();
}

public class OrderItem
{
    public string ProductName { get; set; } = "";
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public class OrderService
{
    private readonly OrderValidator _validator;
    private readonly CalculatorService _calculatorService;
    private readonly InvoiceService _invoiceService;
    private readonly ILogger _logger;
    private readonly IOrderRepository _orderRepository;
    private readonly IPaymentProcessor _paymentProcessor;
    private readonly INotificationSender _notificationSender;
    public OrderService(OrderValidator validator,
        CalculatorService calculatorService,
        InvoiceService invoiceService,
        ILogger logger,
        IOrderRepository orderRepository,
        IPaymentProcessor paymentProcessor,
        INotificationSender notificationSender)
    {
        _validator = validator;
        _calculatorService = calculatorService;
        _invoiceService = invoiceService;
        _logger = logger;
        _orderRepository = orderRepository;
        _paymentProcessor = paymentProcessor;
        _notificationSender = notificationSender;
    }

    public void ProcessOrder(Order order)
    {
        // 1. Validation
        _validator.Validate(order);

        // 2. Calculate total
        decimal total = _calculatorService.Calculate(order);

        // 3. Save to database
        _orderRepository.Save(order);

        // 4. Payment
        _paymentProcessor.ProcessPayment(total);

        // 5. Send notification
        _notificationSender.Send(order.CustomerEmail, "Hello world...!!!");

        // 6. Generate invoice
        _invoiceService.GenerateInvoice(order);

        // 7. Logging
        _logger.Log($"Order {order.Id} processed.");
    }
}

public class OrderValidator
{
    public void Validate( Order order )
    {
        if (order.Items.Count == 0)
        {
            throw new Exception("Order must contain at least one item.");
        }
    }
}

public class CalculatorService
{
    public decimal Calculate( Order order )
    {
        decimal total = 0;

        foreach (var item in order.Items)
        {
            total += item.Price * item.Quantity;
        }
        return total;
    }
}
public interface IOrderRepository
{
    void Save( Order order );
}
public class OrderRepository : IOrderRepository
{
    public void Save(Order order)
    {
        Console.WriteLine("Order Saved");
    }
}

public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}


public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card: {amount}");
    }
}

public class PaypalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing Paypal: {amount}");
    }
}

public interface INotificationSender
{
    void Send(string reciepient, string message);
}

public class EmailNotificationSender : INotificationSender
{
    public void Send(string recipient, string message)
    {
        Console.WriteLine($"Sending email to {recipient}: {message}");
    }
}

public class InvoiceService
{
    public void GenerateInvoice(Order order)
    {
        Console.WriteLine($"Generating PDF invoice for order {order.Id}");
    }
}

public interface ILogger
{
    void Log(string message);
}

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}