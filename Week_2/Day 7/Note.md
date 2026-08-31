# Week 2 — Day 7: SOLID Review — Order System Refactor (C#)

## 🔍 Step 1: The Bad Order System

```csharp
public class Order
{
    public List<OrderItem> Items { get; set; }
    public string OrderType { get; set; }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var item in Items)
            total += item.Price * item.Qty;
        return total;
    }

    public decimal ApplyDiscount(decimal total)
    {
        if (OrderType == "regular")
            return total;
        else if (OrderType == "vip")
            return total * 0.9m;
        else if (OrderType == "student")
            return total * 0.85m;
        // every new order type = another else-if here
        return total;
    }

    public void SaveToDatabase()
    {
        var db = new MySqlConnector();      // concrete class
        db.Connect();
        db.Execute("INSERT INTO orders VALUES (...)");
    }

    public void SendConfirmationEmail()
    {
        var smtp = new SmtpClientWrapper(); // concrete class
        smtp.Send("customer@mail.com", "Order confirmed");
    }

    public void PrintInvoice()
    {
        Console.WriteLine($"Invoice: {CalculateTotal()}");
    }
}
```

## 🚨 Step 2: Violations Identified

| Principle | Violation Found |
|---|---|
| **SRP** | `Order` does math, discounting, DB saving, emailing, *and* printing — 5 responsibilities in one class. |
| **OCP** | `ApplyDiscount` uses `if/else if` on `OrderType`. Adding a "student-vip" type means editing this method again. |
| **LSP** | If a `GiftOrder : Order` override threw `NotImplementedException` inside `CalculateTotal()`, any code looping over `List<Order>` would break — a subtype must never remove behavior the base type promises. |
| **ISP** | Bundling everything into one `IOrderOperations` interface (`Save`, `Email`, `Print`, `Discount`) forces a class that only needs persistence to also implement email/print methods. |
| **DIP** | `SaveToDatabase` and `SendConfirmationEmail` instantiate `MySqlConnector` and `SmtpClientWrapper` directly — high-level `Order` logic is welded to low-level tools. |

## ✅ Step 3: The Good Example

**Apply SRP** — split responsibilities into separate classes.
**Apply OCP** — replace `if/else if` with a discount *strategy* interface.
**Apply LSP** — every strategy/repository/notifier implementation is fully substitutable.
**Apply ISP** — small, single-purpose interfaces instead of one big one.
**Apply DIP** — high-level `OrderService` depends only on abstractions, injected in.

```csharp
// ---------- Data (SRP: only holds order data) ----------
public class OrderItem
{
    public decimal Price { get; set; }
    public int Qty { get; set; }
}

public class Order
{
    public List<OrderItem> Items { get; }

    public Order(List<OrderItem> items)
    {
        Items = items;
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var item in Items)
            total += item.Price * item.Qty;
        return total;
    }
}

// ---------- ISP + OCP: small, extensible discount interface ----------
public interface IDiscountStrategy
{
    decimal Apply(decimal total);
}

public class RegularDiscount : IDiscountStrategy
{
    public decimal Apply(decimal total) => total;
}

public class VipDiscount : IDiscountStrategy
{
    public decimal Apply(decimal total) => total * 0.9m;
}

public class StudentDiscount : IDiscountStrategy
{
    public decimal Apply(decimal total) => total * 0.85m;
}
// New discount type? Add a new class. No existing code touched. ✅ OCP

// ---------- ISP: focused, single-purpose interfaces ----------
public interface IOrderRepository
{
    void Save(Order order);
}

public interface INotifier
{
    void Notify(string message);
}

// ---------- LSP: concrete implementations, fully substitutable ----------
public class MySqlOrderRepository : IOrderRepository
{
    public void Save(Order order)
    {
        Console.WriteLine($"Saving order (total={order.CalculateTotal()}) to MySQL");
    }
}

public class EmailNotifier : INotifier
{
    public void Notify(string message)
    {
        Console.WriteLine($"Emailing customer: {message}");
    }
}

public class SmsNotifier : INotifier
{
    public void Notify(string message)
    {
        Console.WriteLine($"Texting customer: {message}");
    }
}
// Swap MySql↔Postgres, Email↔SMS freely — behavior contract stays intact ✅ LSP

// ---------- SRP + DIP: high-level logic depends on abstractions ----------
public class OrderService
{
    private readonly IOrderRepository _repository;
    private readonly INotifier _notifier;
    private readonly IDiscountStrategy _discount;

    // Dependencies injected, not created here
    public OrderService(IOrderRepository repository, INotifier notifier, IDiscountStrategy discount)
    {
        _repository = repository;
        _notifier = notifier;
        _discount = discount;
    }

    public decimal Process(Order order)
    {
        decimal total = _discount.Apply(order.CalculateTotal());
        _repository.Save(order);
        _notifier.Notify($"Order confirmed. Total: {total}");
        return total;
    }
}

// ---------- Usage: dependencies wired from outside (DI) ----------
class Program
{
    static void Main()
    {
        var order = new Order(new List<OrderItem>
        {
            new OrderItem { Price = 100, Qty = 2 }
        });

        var service = new OrderService(
            repository: new MySqlOrderRepository(),
            notifier: new EmailNotifier(),
            discount: new VipDiscount()
        );

        service.Process(order);
    }
}
```

## 🧩 Why This Is "Good"

- **Low coupling** — `OrderService` never says `new MySqlOrderRepository()` internally; it receives interfaces through its constructor. Swap the DB, the notifier, or the discount logic without touching `OrderService`.
- **High cohesion** — each class does one thing: `Order` holds data, each strategy computes one discount, each repository saves one way, each notifier sends one way.
- **Extensible by addition, not edition** — new order types, new discounts, new notification channels are all *new classes*, never edits to existing ones. In real C# apps, this is exactly the shape DI containers (like `IServiceCollection` in ASP.NET Core) expect: register interfaces → implementations, and let the container inject them.

## 🧠 Core Takeaway

The bad version breaks because one class tries to be *everything*. The fix isn't "add more code" — it's **drawing boundaries**: one responsibility per class, behavior swapped in through interfaces, and dependencies handed in from outside rather than hard-wired inside.