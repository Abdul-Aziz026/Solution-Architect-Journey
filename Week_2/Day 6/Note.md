# Week 2 — Day 6: SOLID Principles

> Five design principles that keep object-oriented code flexible, testable, and easy to change.

---

## S — Single Responsibility Principle (SRP)

**Rule:** A class should have only one reason to change. One class = one job.

**Why it matters:** When a class does two things, changing one breaks the other.

```csharp
// ❌ Bad: report building + file I/O in one class
class Report
{
    public string Generate() { /* build report */ }
    public void SaveToFile(string path) { /* file I/O */ }
}

// ✅ Good: split responsibilities
class Report
{
    public string Generate() { /* build report */ }
}

class ReportSaver
{
    public void Save(string content, string path) { /* file I/O */ }
}
```

**Smell:** class name contains "And", or a class has methods from unrelated layers (DB + validation + formatting).

---

## O — Open/Closed Principle (OCP)

**Rule:** Software entities should be **open for extension, closed for modification**. Add new behavior by adding new code, not editing tested code.

```csharp
interface IDiscount
{
    decimal Apply(decimal price);
}

class NoDiscount : IDiscount
{
    public decimal Apply(decimal price) => price;
}

class TenPercentDiscount : IDiscount
{
    public decimal Apply(decimal price) => price * 0.9m;
}

// New discount type = new class. Existing classes stay untouched.
```

**Smell:** a growing `switch`/`if-else` chain on a type or enum that you edit every time a new case appears.

---

## L — Liskov Substitution Principle (LSP)

**Rule:** Subtypes must be substitutable for their base type without breaking the program's correctness.

```csharp
// ❌ Classic violation
class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }
}

class Square : Rectangle
{
    // Forcing Width == Height breaks callers that expect
    // independent sides: setting Width silently changes Height.
}
```

**Fix:** don't model an "is-a" relationship that violates the base type's expected behavior. Use a shared abstraction (e.g. `IShape` with `Area()`) instead.

**Smell:** an override that throws `NotSupportedException`, or one that tightens preconditions / loosens postconditions.

---

## I — Interface Segregation Principle (ISP)

**Rule:** No client should be forced to depend on methods it does not use. Prefer several small, focused interfaces over one fat one.

```csharp
// ❌ Bad: fat interface
interface IWorker
{
    void Work();
    void Eat();
}
// A RobotWorker must implement Eat() — meaningless.

// ✅ Good: segregated
interface IWorkable { void Work(); }
interface IFeedable { void Eat(); }

class HumanWorker : IWorkable, IFeedable { /* ... */ }
class RobotWorker : IWorkable { /* ... */ }
```

**Smell:** empty method bodies or `throw new NotImplementedException()` in implementations.

---

## D — Dependency Inversion Principle (DIP)

**Rule:**
1. High-level modules should not depend on low-level modules. Both should depend on abstractions.
2. Abstractions should not depend on details. Details should depend on abstractions.

```csharp
// ❌ Bad: high-level class hard-wired to a concrete implementation
class Notifier
{
    private readonly EmailSender _sender = new EmailSender();
    public void Notify(string msg) => _sender.Send(msg);
}

// ✅ Good: depend on an abstraction, inject the implementation
interface IMessageSender
{
    void Send(string message);
}

class EmailSender : IMessageSender
{
    public void Send(string message) { /* SMTP */ }
}

class Notifier
{
    private readonly IMessageSender _sender;
    public Notifier(IMessageSender sender) => _sender = sender;
    public void Notify(string msg) => _sender.Send(msg);
}
```

**Payoff:** you can swap `EmailSender` for `SmsSender` or a fake in unit tests without touching `Notifier`.

---

## Quick Recap Table

| Letter | Principle | One-line rule |
|--------|-----------|---------------|
| **S** | Single Responsibility | One class, one reason to change |
| **O** | Open/Closed | Extend without editing existing code |
| **L** | Liskov Substitution | Subtypes must be safely swappable |
| **I** | Interface Segregation | Many small interfaces > one fat one |
| **D** | Dependency Inversion | Depend on abstractions, not concretions |

---

## Where these show up in Clean Architecture + MediatR

- **SRP** — one handler per command/query keeps each unit of work isolated.
- **DIP** — handlers depend on repository/service *interfaces* defined in the Application layer; Infrastructure supplies the implementations.
- **OCP** — pipeline behaviors (validation, logging, retry) add cross-cutting behavior without editing handlers.
- **ISP** — narrow repository interfaces per aggregate instead of one giant `IRepository`.
- **LSP** — any `IValidator<T>` or `IRequestHandler<T>` implementation must honor the contract the pipeline expects.

---

*Week 2 · Day 6 · SOLID*