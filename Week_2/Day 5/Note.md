# DIP — Dependency Inversion Principle

## 80/20 Rule

> **High-level business logic should not depend directly on low-level implementation details. Both should depend on abstractions.**

### Core Idea

```text
High-Level Policy
       ↓
  Abstraction
       ↑
Low-Level Detail
```

### Remember These 4 Points

1. **Depend on abstractions, not concrete implementations.**
2. **Keep business logic independent from infrastructure details.**
3. **Use dependency injection to provide implementations from outside.**
4. **Make implementation details replaceable without changing business logic.**

### Bad

```csharp
public class OrderService
{
    private readonly MySqlDatabase _database = new();

    public void SaveOrder()
    {
        _database.Save();
    }
}
```

```text
OrderService → MySqlDatabase
```

The high-level service is tightly coupled to MySQL.

### Good

```csharp
public interface IOrderRepository
{
    void Save();
}

public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public void SaveOrder()
    {
        _repository.Save();
    }
}
```

```text
OrderService
     ↓
IOrderRepository
     ↑
MySqlOrderRepository
```

### DIP ≠ Dependency Injection

* **DIP** → Design principle
* **Dependency Injection** → Technique used to supply dependencies

### Architect's Question

Ask:

> **"Does my business logic know about implementation details?"**

If yes, consider introducing an abstraction.

### One-Line Memory

> **Business policy depends on abstractions; implementation details depend on those abstractions.**
