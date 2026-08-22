
# Object-Oriented Design Fundamentals

---

## 1. What is Object-Oriented Design?

**Object-Oriented Design (OOD)** means designing software around **objects**.

An object contains:

- **State** → What it knows
- **Behavior** → What it can do

Example:

```text
BankAccount
├── State
│   ├── AccountNumber
│   └── Balance
│
└── Behavior
    ├── Deposit()
    └── Withdraw()
```

## 2. Class vs Object
- Class: A blueprint/template.
- Object: An actual instance of a class.



## 3. State vs Behavior

When designing a class, ask:
- What does it know? → State
- What can it do? → Behavior

```text
Order
├── State
│   ├── Id
│   ├── Items
│   └── Status
│
└── Behavior
    ├── AddItem()
    ├── RemoveItem()
    ├── CalculateTotal()
    └── Cancel()
```

## 4. Encapsulation

Encapsulation = protect an object's internal state and control how it changes.
**Key idea:**
- An object should protect its own rules and maintain a valid state.

```
// ❌ Bad:
public decimal Balance { get; set; }
// Anyone can do:
account.Balance = -50000;
```

```
// ✅ Better:
public decimal Balance { get; private set; }

public void Withdraw(decimal amount)
{
    if (amount > Balance)
        throw new InvalidOperationException();

    Balance -= amount;
}
```
**Now the object controls its own state.**

## Behavior Should Live Near Its Data
```
// ❌ Bad:
account.Balance -= amount;

// ✅ Better:
account.Withdraw(amount);
```


## OOD Design Process
**Memorize this flow:**

```
1. Requirement
     ↓
2. Find important objects
     ↓
3. Identify State
     ↓
4. Identify Behavior
     ↓
5. Protect State & Rules
     ↓
6. Define Relationships
```



## Important Questions for OOD and Example
**Example: Bank Account**

**1. Requirement:**
```text
"A customer should be able to deposit and withdraw money from their bank account. A customer cannot withdraw more money than the account balance."
```
### Now let's think like an Object-Oriented Designer.

**2 Find important objects**
Look for nouns in the requirement: Nouns → candidate objects
```
Nouns: Customer, Bank Account, Money
Objects: BankAccount, Customer
```
**3. Identify State**
What information belongs to a BankAccount and Customer?
```
BankAccount State: AccountNumber, Balance
Customer State: Name, Address, PhoneNumber

```

**4. Identify Behavior**
What actions are related to a BankAccount and Customer
```
BankAccount: Deposit(), Withdraw()
Customer: SetName(), SetAddress(), SetPhoneNumber()
```

**5. Protect State & Rules**
The requirement says:
```
A customer cannot withdraw more money than the account balance.
Customer should not be able to set a negative balance.
Customer should not be able to set an invalid phone number.
Customer name should not be empty.
```
**6. Define Relationships**
```
Customer
   │
   │ owns
   ↓
BankAccount
```
