# Abstraction & Encapsulation

## 1. Abstraction

**Abstraction = What an object can do, while hiding unnecessary implementation details.**

Example:

```csharp
public interface IPaymentProcessor
{
    Task ProcessPaymentAsync(decimal amount);
}
```

Caller শুধু জানে:

> The caller knows what it can do, not how it works.
---

## 2. Encapsulation

**Encapsulation = Object-এর internal state protect করা এবং state কীভাবে change হবে সেটা control করা।**

Example:

```csharp
public class BankAccount
{
    private decimal _balance;

    public decimal Balance => _balance;

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException();

        _balance += amount;
    }
}
```

External code `_balance` directly পরিবর্তন করতে পারে না।

### Important

Encapsulation শুধু `private` করা নয়।

Good encapsulation means:

```text
Object owns its state
        ↓
Object controls state changes
        ↓
Business rules are enforced
        ↓
Invalid states become difficult to create
```

---

## 3. Abstraction vs Encapsulation

| Abstraction                | Encapsulation                       |
| -------------------------- | ----------------------------------- |
| **What?**                  | **Protection?**                     |
| Hides complexity           | Protects internal state             |
| Focuses on behavior        | Focuses on state + rules            |
| Interface / abstract class | Private state + controlled behavior |

### Easy Memory Trick

> **Abstraction = What is does**
> **Encapsulation = Protection**

---

## 4. Depend on Abstractions

High-level code should depend on **abstractions**, not concrete implementations.

Prefer:

```csharp
public class PaymentService
{
    private readonly IPaymentProcessor _processor;
}
```

Instead of:

```csharp
private readonly CreditCardPaymentProcessor _processor;
```

Architecture:

```text
PaymentService
      ↓
IPaymentProcessor
      ↓
 ┌────┼─────────────┐
 ↓    ↓             ↓
Card PayPal     BankTransfer
```

### Benefit

* Lower coupling
* Easier testing
* Easier replacement of implementations
* Better flexibility

---

## 5. Business Rules & Invariants

The object that owns the state should usually control the rules related to that state.

Bad:

```csharp
public decimal Balance { get; set; }
```

Anyone can create an invalid state:

```csharp
account.Balance = -5000;
```

Better:

```csharp
public decimal Balance { get; private set; }

public void Withdraw(decimal amount)
{
    if (amount > Balance)
        throw new InvalidOperationException();

    Balance -= amount;
}
```

The object protects its **invariants**.

> **Invariant = A rule that must always remain valid.**

---

## 6. Don't Abstract Everything

An interface is not automatically good design.

```
// Avoid unnecessary abstractions like:
ICalculator
Calculator
```
Use abstraction when there is a meaningful:

* Contract
* Boundary
* Variation
* External dependency
* Policy
* Testing requirement

Avoid abstraction just because:

> "Interfaces are good."

---

## 7. Core Mental Model

```text
Abstraction
    ↓
What can this object do?
    ↓
Contract / public behavior
    ↓
Hide implementation details


Encapsulation
    ↓
Who can change my state?
    ↓
Protect state + enforce rules
    ↓
Prevent invalid states
```

## Final Takeaway

> **Good OOP design exposes meaningful behavior through abstraction, protects state through encapsulation, keeps business rules close to the state they protect, and reduces unnecessary coupling.**


## 8. Key Vocabulary

- Abstraction → Hide unnecessary complexity.
- Encapsulation → Protect internal state.
- Interface → Defines a contract.
- Implementation → Concrete behavior behind the abstraction.
- Coupling → How strongly components depend on each other.
- Invariant → A rule/state that must always remain valid.
- Contract → What an object promises to provide to its users.