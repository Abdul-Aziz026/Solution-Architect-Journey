# Week 3 Day 1 — Design Patterns Fundamentals

> **Goal:** Learn the small set of Design Pattern fundamentals that gives you the most practical value as a Solution Architect.

---

## 1. What Is a Design Pattern?

A **Design Pattern** is a proven, reusable way to structure code for a **recurring design problem**.

It is:

- Not a framework
- Not a library
- Not copy-paste code
- Not mandatory

Think of it as a **design blueprint**.

```text
Recurring Problem
       ↓
Known Design Approach
       ↓
Design Pattern
       ↓
Concrete Implementation
```

---

## 2. The 80/20 Rule

You do **not** need to memorize every Design Pattern.

Focus first on:

1. Recognizing the problem
2. Understanding the pattern's intent
3. Knowing the trade-offs
4. Knowing when to use it
5. Knowing when NOT to use it

As an architect, **pattern recognition is more valuable than pattern memorization**.

---

## 3. The Three Pattern Categories

### Creational

**Question:** How should objects be created?

Common patterns:

- Factory Method
- Abstract Factory
- Builder
- Singleton
- Prototype

High-value patterns to learn first:

> **Factory Method + Builder**

> **Note:** "Factory" is often used loosely to mean two different things — **Factory Method** (a GoF pattern where subclasses decide which class to instantiate) and **Simple Factory** (a common idiom where one method creates objects based on input, but which isn't officially one of the 23 GoF patterns). Knowing the distinction matters in interviews.

---

### Structural

**Question:** How should objects/classes be composed?

Common patterns:

- Adapter
- Decorator
- Facade
- Composite
- Proxy

High-value patterns to learn first:

> **Adapter + Decorator + Facade**

---

### Behavioral

**Question:** How should objects communicate or vary their behavior?

Common patterns:

- Strategy
- Observer
- Command
- State
- Chain of Responsibility
- Template Method

High-value patterns to learn first:

> **Strategy + Observer + Chain of Responsibility**

---

## 4. Pattern vs SOLID

This distinction is critical.

### SOLID

SOLID gives you **design principles**.

Example:

```text
OCP
↓
Open for extension
Closed for modification
```

### Design Pattern

A pattern gives you a **proven approach** for a recurring problem.

Example:

```text
Strategy Pattern
↓
Encapsulate interchangeable behavior
```

They work together:

```text
SOLID Principle
      ↓
Design Goal
      ↓
Suitable Pattern
      ↓
Implementation
```

---

## 5. The Most Important Skill: Recognize the Problem

Do not start with:

> "Which pattern should I use?"

Start with:

> **"What design problem am I trying to solve?"**

### Quick Recognition Guide

| Problem | Think About |
|---|---|
| Object creation is becoming complicated | Factory Method / Builder |
| Need different algorithms or behaviors | Strategy |
| Need to connect incompatible interfaces | Adapter |
| Need to add behavior without modifying a class | Decorator |
| Complex subsystem needs a simple entry point | Facade |
| Multiple objects need notifications | Observer |
| Request should pass through multiple handlers | Chain of Responsibility |

---

## 6. Patterns and Coupling

Many patterns exist because we want to **control coupling**.

Bad:

```csharp
public class OrderService
{
    public void Pay()
    {
        var payment = new CreditCardPayment();
        payment.Process();
    }
}
```

The service directly depends on a concrete implementation. `OrderService` knows about `CreditCardPayment` specifically — if you need to support PayPal or bank transfer later, you have to modify `OrderService` itself, which violates OCP.

Better:

```csharp
public interface IPaymentStrategy
{
    void Process();
}

public class OrderService
{
    private readonly IPaymentStrategy _payment;

    public OrderService(IPaymentStrategy payment)
    {
        _payment = payment;
    }

    public void Pay()
    {
        _payment.Process();
    }
}
```

Now `OrderService` depends only on the `IPaymentStrategy` abstraction. The concrete payment method (credit card, PayPal, bank transfer) is decided outside the class and passed in — the behavior can vary without changing `OrderService`.

This connects directly to what you learned about:

- DIP
- OCP
- Polymorphism
- Coupling

---

## 7. Don't Overuse Patterns

A pattern is useful only when it solves a real problem.

### Bad mindset

```text
"I know Factory,
so I should use Factory."
```

### Better mindset

```text
"What problem exists?"
        ↓
"Is the complexity justified?"
        ↓
"Would a pattern make the design better?"
```

Patterns can introduce:

- More classes
- More interfaces
- More abstraction
- More cognitive complexity
- More maintenance

Therefore:

> **Use the simplest design that satisfies the requirements.**

---

## 8. Pattern Selection Flow

Use this mental model:

```text
Start
  ↓
What is changing?
  ↓
────────────────────────────
Object creation?
→ Creational

Object composition?
→ Structural

Behavior/communication?
→ Behavioral
────────────────────────────
  ↓
Does a pattern reduce complexity?
  ↓
Yes → Consider it
No  → Keep the simpler design
```

---

## 9. Architecture Mindset

A Solution Architect should think in terms of:

```text
Business Requirement
        ↓
Design Problem
        ↓
Constraints
        ↓
Possible Solutions
        ↓
Trade-offs
        ↓
Design Pattern (if appropriate)
```

A pattern is **not the goal**.

The goal is:

> **A maintainable, understandable, adaptable solution to the business problem.**

---

## 10. The 20% You Should Remember

If you remember only these points, you have captured most of today's value:

### #1
**Pattern = reusable solution to a recurring design problem.**

### #2
Three major categories:

```text
Creational → Creation
Structural → Composition
Behavioral → Interaction
```

### #3
Start with the **problem**, not the pattern.

### #4
SOLID principles and Design Patterns complement each other.

### #5
Patterns often help manage **coupling, change, and complexity**.

### #6
**Don't use patterns just because they exist.**

### #7
A good architect understands **trade-offs**, not just implementations.

---

# Quick Revision

```text
Design Patterns
│
├── Creational
│   ├── Factory Method
│   └── Builder
│
├── Structural
│   ├── Adapter
│   ├── Decorator
│   └── Facade
│
└── Behavioral
    ├── Strategy
    ├── Observer
    └── Chain of Responsibility
```

### Golden Rule

> **Don't ask: "Which pattern can I use?"**
>
> Ask: **"What problem do I have, what is changing, and what is the simplest design that solves it?"**

---

## Day 1 Practice

Before implementing patterns, practice recognizing the category.

### Scenario 1

You need to create Email, SMS, and Push notification objects.

**Category:** Creational

### Scenario 2

An existing third-party API has an incompatible interface.

**Category:** Structural

### Scenario 3

You need to switch between different discount calculation algorithms.

**Category:** Behavioral

### Scenario 4

You need to add logging around an existing service without changing the service itself.

**Category:** Structural

### Scenario 5

An order status change should notify several independent components.

**Category:** Behavioral

---

## Interview Questions

1. What is a Design Pattern?
2. Why do we use Design Patterns?
3. What are the three major categories?
4. Difference between a Design Pattern and a Framework?
5. How do Design Patterns relate to SOLID?
6. Can using a Design Pattern make code worse?
7. How do you decide whether to use a pattern?
8. Give examples of Creational, Structural, and Behavioral patterns.
9. What's the difference between Factory Method and Simple Factory?

---

## One-Line Summary

> **Design Patterns are proven ways to solve recurring design problems; learn to recognize problems and trade-offs rather than blindly applying patterns.**
