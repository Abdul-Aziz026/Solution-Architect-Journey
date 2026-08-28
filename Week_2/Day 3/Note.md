# 🔑 Liskov Substitution Principle (LSP)

A child/subtype must be safely usable wherever its parent/base type is expected, without breaking the expected behavior.

## Simple meaning

If:

```csharp
Bird bird = new Sparrow();
bird.Fly();
```

works, then replacing `Sparrow` with another `Bird` subtype should not break the caller's assumptions.

---

## 🧠 The Core Idea: Behavioral Contract

A base class creates a contract.

```
Base Type
   ↓
Promises certain behavior
   ↓
Child Type
   ↓
Must honor that behavior
```

The child should not weaken, break, or contradict the parent's contract.

---

## ❌ Common LSP Violations

Watch for these:

### 1. Unsupported inherited behavior

```csharp
public override void Fly()
{
    throw new NotSupportedException();
}
```

The subtype cannot fulfill something the parent promises.

### 2. Unexpected behavior

The parent says:

```csharp
void Withdraw(decimal amount)
```

but a child silently behaves differently in a way the caller doesn't expect.

### 3. New restrictions

Parent:

```
Can process any valid payment
```

Child:

```
Can process only payments under $100
```

The child has strengthened the requirements.

### 4. Caller needs subtype checks

```csharp
if (bird is Penguin)
{
    // special handling
}
else
{
    bird.Fly();
}
```

This is a strong warning sign that the abstraction may be wrong.

---

## ✅ Good LSP Design

```
              Bird
               │
        ┌──────┴──────┐
        ↓             ↓
     Sparrow       Penguin

     Sparrow implements IFlyingBird
     Penguin does not
```

Don't put capabilities into a base type when not every subtype supports them.

Instead:

```csharp
public interface IFlyingBird
{
    void Fly();
}
```

Only flying birds implement it.

---

## 🔥 LSP vs "IS-A"

Don't think only:

> "Is Child an instance of Parent?"

Think:

> "Can Child fulfill everything Parent promises?"

A relationship can be logically true in the real world but still be a bad software abstraction.

**Example:**

```
Penguin IS-A Bird       ✅
Penguin IS-A FlyingBird ❌
```

---

## 🚨 LSP Warning Signs

Remember:

```
❌ NotSupportedException
❌ Override breaks expected behavior
❌ Child needs special handling
❌ Child adds unexpected restrictions
❌ Parent contract doesn't make sense for every child
```

---

## 🛠️ Practical LSP Test

Whenever you see inheritance, ask:

1. What does the parent promise?
2. Can every child fulfill that promise?
3. Can I replace the parent with any child safely?
4. Will the caller's assumptions remain valid?
5. Do I need `if`/`switch` checks for specific subtypes?

If the answer is no, reconsider the abstraction.

---

## 🎯 One-Line Memory

**LSP = "Subtypes should keep the promises of their base types."**

Or even shorter:

> Parent's contract → Child must honor it.