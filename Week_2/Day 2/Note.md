# Week 2 Day 2 — OCP (Open/Closed Principle)

## 1. What is OCP?

> **A class should be open for extension but closed for modification.**

In simple words:
**When new behavior is added, we should prefer adding new code instead of repeatedly changing existing stable code.**

---

## 2. The Problem

Suppose we have:

```csharp
public class NotificationService
{
    public void Send(string type, string message)
    {
        if (type == "Email")
        {
            // Send Email
        }
        else if (type == "SMS")
        {
            // Send SMS
        }
    }
}
```

Now we add WhatsApp:

```csharp
else if (type == "WhatsApp")
{
    // Send WhatsApp
}
```

We had to **modify** `NotificationService`.
If more notification types keep coming, this class keeps growing.
That's a **potential OCP problem**.

---

## 3. OCP Solution

Find the thing that changes.
Here:

> **Notification type/behavior changes.**

Create an abstraction:

```csharp
public interface INotificationSender
{
    void Send(string message);
}
```

Then create separate implementations:

```
INotificationSender
       │
       ├── EmailSender
       ├── SmsSender
       ├── PushSender
       └── WhatsAppSender
```

Now `NotificationService` depends on the abstraction:

```csharp
public class NotificationService
{
    private readonly INotificationSender _sender;

    public NotificationService(INotificationSender sender)
    {
        _sender = sender;
    }

    public void Send(string message)
    {
        _sender.Send(message);
    }
}
```

When WhatsApp is needed:

```csharp
public class WhatsAppSender : INotificationSender
{
    public void Send(string message)
    {
        // Send WhatsApp
    }
}
```

We **add a new class**.
We don't modify `NotificationService`.

---

## 4. The Core Idea

```
What changes?
     ↓
Separate the changing behavior
     ↓
Create abstraction
     ↓
Create implementations
     ↓
Stable class depends on abstraction
     ↓
New behavior = Add, not Modify
```

---

## 5. Connection to Week 1

OCP commonly uses concepts you've already learned:

```
Abstraction
     +
Composition
     +
Polymorphism
     ↓
     OCP
```

For example:

```csharp
private readonly INotificationSender _sender;
```

- **Abstraction** → `INotificationSender`
- **Composition** → `NotificationService` receives a sender
- **Polymorphism** → Email/SMS/Push can all be used through the interface
- **OCP** → new sender can be added without changing the service

---

## 6. What does "Open" mean?

**Open for extension** means:

> We can add new behavior.

Example:

```
EmailSender
SmsSender
PushSender
WhatsAppSender ← new
```

---

## 7. What does "Closed" mean?

**Closed for modification** means:

> Existing stable code should not need to change whenever a new variation is introduced.

For example:

```
NotificationService
       ↓
doesn't need modification
       ↓
WhatsAppSender added
```

---

## 8. Very Important ⚠️

OCP does **not** mean:

> "Never modify a class."

If the business rule inside `EmailSender` changes, modifying `EmailSender` is perfectly normal.
OCP mainly protects the **stable code from constantly changing because of new variations**.

---

## 🧠 Easy Example to Remember

Think about a **phone charger**.
You want your phone to work with different chargers through a standard:

```
Phone
  ↓
USB-C interface/standard
  ↓
Different chargers
```

You don't redesign the phone every time a new charger manufacturer appears.
Similarly:

```
NotificationService
        ↓
INotificationSender
        ↓
Email / SMS / Push / WhatsApp
```

The service doesn't need to know every possible notification type.

---

## 🎯 One-line memory

> **OCP = Identify what changes, put it behind an abstraction, and extend it without repeatedly modifying stable code.**