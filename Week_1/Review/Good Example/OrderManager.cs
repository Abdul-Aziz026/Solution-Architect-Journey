namespace Week_1.Review.Good_Example;

public class OrderManager
{
    // Encapsulation
    private List<Order> _orders = new();

    // prevent external modification
    public IReadOnlyList<Order> Orders => _orders.AsReadOnly();

    private readonly IDatabase _database;
    private readonly INotificationSender _notificationSender;
    private readonly IPaymentProcessor _paymentProcessor;
    private readonly IInvoiceGenerator _invoiceGenerator;
    private readonly CalculatorService _calculatorService;
    private readonly ILogger _logger;

    public OrderManager(IDatabase database,
        INotificationSender notificationSender,
        IPaymentProcessor paymentProcessor,
        IInvoiceGenerator invoiceGenerator,
        CalculatorService calculatorService,
        ILogger logger)
    {
        _database = database;
        _notificationSender = notificationSender;
        _paymentProcessor = paymentProcessor;
        _invoiceGenerator = invoiceGenerator;
        _calculatorService = calculatorService;
        _logger = logger;
    }

    public void CreateOrder(
        string customerName,
        string email,
        decimal price)
    {
        // Create order 
        var order = new Order();
        order.SetCustomerName(customerName);
        order.SetEmail(email);
        order.SetPrice(price);
        order.Create();

        _orders.Add(order);

        // Calculate price
        var total = _calculatorService.CalculateTotal(price);

        // Payment
        _paymentProcessor.ProcessPayment(total);

        // Invoice
        _invoiceGenerator.GenerateInvoice(order);

        // Notification
        _notificationSender.SendNotification(email,
            "Your order has been created");

        // Database
        _database.Save(order);

        // Logging
        _logger.Write("Order created");
    }

    public void CancelOrder(Order order)
    {
        order.Cancel();
    }

    public void ChangePrice(Order order, decimal price)
    {
        order.SetPrice(price);
    }
}

public class Order
{
    public string CustomerName { get; private set; }
    public string Email { get; private set; }
    public decimal Price { get; private set; }
    public string Status { get; private set; }


    public void SetCustomerName(string customerName)
    {
        if (string.IsNullOrWhiteSpace(customerName))
        {
            throw new ArgumentException("Customer name cannot be empty");
        }
        CustomerName = customerName;
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email)
            || !email.Contains("@"))
        {
            throw new ArgumentException("Invalid email address");
        }
        Email = email;
    }

    public void SetPrice(decimal price)
    {
        if (price < 0)
        {
            throw new ArgumentException("Price cannot be negative");
        }
        Price = price;
    }
    public void Create()
    {
        Status = "Created";
    }

    public void Cancel()
    {
        if (Status == "Cancelled")
            throw new InvalidOperationException("Order is already cancelled.");

        Status = "Cancelled";
    }
}

public class CalculatorService
{
    public decimal CalculateTotal(decimal price)
    {
        return price + (price * 0.15m);
    }
}

    // abstraction, Polymorphism, cohesion, coupling
    public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}

public class StripePaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount) { }
}

public class PayPalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount) { }
}

public interface IInvoiceGenerator
{
    void GenerateInvoice(Order order);
}

public class InvoiceGenerator : IInvoiceGenerator
{
    public void GenerateInvoice(Order order) { }
}

// abstraction, Polymorphism, cohesion, coupling
public interface INotificationSender
{
    void SendNotification(string email, string message);
}

public class EmailSender : INotificationSender
{
    public void SendNotification(string email, string message) {
        Console.WriteLine("Send Email: " + email + " - " + message);
    }
}

// abstraction, Polymorphism, cohesion, coupling
public interface IDatabase
{
    void Save(Order order);
    void Backup();
}

public class SqlDatabase : IDatabase
{
    public void Save(Order order) { }

    public void Backup() { }
}

public interface ILogger
{
    void Write(string message);
}

public class FileLogger : ILogger
{
    public void Write(string message) { }
}

