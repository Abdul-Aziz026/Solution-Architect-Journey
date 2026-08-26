# SRP --- Single Responsibility Principle

## Definition

> **A class should have one reason to change.**

## What does it mean?

A class should have **one clear responsibility** and should not combine
unrelated concerns.

## Why?

SRP helps you achieve:

-   **High cohesion** --- related behavior stays together.
-   **Low coupling** --- unrelated concerns are separated.
-   **Easier maintenance** --- changes stay localized.
-   **Easier testing** --- classes have fewer responsibilities.

## Bad Example

``` csharp
public class OrderService
{
    public void CreateOrder() { }
    public void SaveToDatabase() { }
    public void SendEmail() { }
    public void GenerateInvoice() { }
}
```

**Problem:** The class has multiple reasons to change:

-   Order rules
-   Database changes
-   Email changes
-   Invoice changes

## Good Example

``` csharp
public class OrderService
{
    public void CreateOrder() { }
}

public class OrderRepository
{
    public void Save() { }
}

public class EmailSender
{
    public void Send() { }
}

public class InvoiceGenerator
{
    public void Generate() { }
}
```

Each class has a **focused responsibility**.

## Important Rule

SRP does **not** mean:

> One class = one method.

It means:

> **Group things that change for the same reason, and separate things
> that change for different reasons.**

## Quick Test

When reviewing a class, ask:

> **"What could cause this class to change?"**

If the answer contains several **unrelated reasons**, consider splitting
the class.

## Remember

``` text
SRP
 ↓
One responsibility
 ↓
One reason to change
 ↓
Higher cohesion
 ↓
Easier maintenance
```
