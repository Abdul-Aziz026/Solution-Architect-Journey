# 🔑 Interface Segregation Principle (ISP)

Clients should not be forced to depend on methods they don't use.

**In short:** prefer small, focused, role-based interfaces over large, general-purpose ones.

---

## ❌ The Problem: Fat Interfaces

```csharp
public interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
}

public class Robot : IWorker
{
    public void Work() => Console.WriteLine("Working...");
    public void Eat() => throw new NotImplementedException();
    public void Sleep() => throw new NotImplementedException();
}
```

A `Robot` doesn't eat or sleep, but it's still forced to implement those methods. This leads to:

- meaningless implementations
- `NotImplementedException`
- tighter coupling and harder maintenance

---

## ✅ The Fix: Split by Capability

```csharp
public interface IWorkable { void Work(); }
public interface IEatable  { void Eat(); }
public interface ISleepable { void Sleep(); }

public class Robot : IWorkable
{
    public void Work() => Console.WriteLine("Working...");
}

public class Employee : IWorkable, IEatable, ISleepable
{
    public void Work() => Console.WriteLine("Working...");
    public void Eat() => Console.WriteLine("Eating...");
    public void Sleep() => Console.WriteLine("Sleeping...");
}
```

Each class implements only what it actually supports.

**Mental model:** think of interfaces as *capabilities*, not entire systems.

```
IPrinter          → Printing capability
IScanner          → Scanning capability
IPaymentProcessor → Payment capability
```

---

## 🚩 Warning Signs

| Sign | Example |
|---|---|
| `NotImplementedException` in an override | `void Scan() => throw new NotImplementedException();` |
| Empty implementations | `void Fax() { }` |
| Bloated interfaces with unrelated methods | `IService { Create(); Delete(); SendEmail(); ProcessPayment(); ... }` |
| Client only uses a fraction of the interface | Depends on `IOrderService` but only calls `CreateOrder()` |

---

## 🧠 Important Nuance

ISP does **not** mean "one method per interface." This is perfectly fine:

```csharp
public interface IOrderRepository
{
    Order GetById(int id);
    void Add(Order order);
    void Delete(Order order);
}
```

These methods belong together — they're all part of one coherent capability: **order persistence**.

The real question is:

> Are the methods logically related and actually relevant to the client using them?

---

## ISP vs SRP

| Principle | Focus |
|---|---|
| SRP | A **class** should have one reason to change |
| ISP | A **client** shouldn't depend on methods it doesn't use |

```
SRP → focus the class
ISP → focus the interface
```

---

## 🛠️ Practical Test

When designing or reviewing an interface, ask:

1. What capability does this interface represent?
2. Would every implementing class genuinely support every method?
3. Does any implementation throw `NotImplementedException` or leave a method empty?
4. Does a client depend on methods it never calls?

If yes to 3 or 4 — split the interface.

---

## 🎯 One-Line Memory

**ISP = Don't force clients to depend on what they don't need.**

Or even shorter:

> Small, focused interfaces — designed around what consumers actually use.