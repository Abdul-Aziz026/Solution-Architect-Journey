## What is Polymorphism?

**Polymorphism means:** One common type/interface can represent different concrete objects, and the same operation can behave differently depending on the actual object.
```
The word comes from:  
	Poly → many  
	Morph → forms
So: 
	One contract, many implementations/behaviors.
```

Two kinds in C#:  
- **Compile-time (static)**: At compile time, mechanism: Method overloading, operator overloading  
- **Runtime (dynamic)**: At runtime, mechanism: Method overriding via `virtual`/`override`  


## 2. Compile-Time Polymorphism — Overloading

Same method name, different parameter list. Compiler picks the match based on arguments.

```csharp
public class Calculator
{
    public int Add(int a, int b) => a + b;
    public double Add(double a, double b) => a + b;
    public int Add(int a, int b, int c) => a + b + c;
}
```

**Operator overloading** is the same idea applied to operators:

```csharp
public struct Money
{
    public decimal Amount { get; }
    public Money(decimal amount) => Amount = amount;

    public static Money operator +(Money a, Money b) => new Money(a.Amount + b.Amount);
}
```

---

## 3. Runtime Polymorphism — Overriding

This is the important one architecturally. A base-typed reference points to a derived object; the **actual object's** method runs, not the base one.

```csharp
public abstract class Notification
{
    public abstract void Send();
}

public class EmailNotification : Notification
{
    public override void Send() => Console.WriteLine("Sending email...");
}

public class SmsNotification : Notification
{
    public override void Send() => Console.WriteLine("Sending SMS...");
}
```

```csharp
List<Notification> queue = new() { new EmailNotification(), new SmsNotification() };

foreach (var n in queue)
    n.Send();   // each object runs ITS OWN override automatically
```

---

## 4. Polymorphism Through Interfaces

```
Polymorphism
├── Inheritance-based
│   └── virtual / override
│
└── Interface-based
    └── interface implementations
```
```csharp
public interface IShape
{
    double Area();
}

public class Circle : IShape
{
    public double Radius { get; set; }
    public double Area() => Math.PI * Radius * Radius;
}

public class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }
    public double Area() => Width * Height;
}
```

```csharp
List<IShape> shapes = new() { new Circle { Radius = 2 }, new Rectangle { Width = 3, Height = 4 } };
foreach (var s in shapes)
    Console.WriteLine(s.Area());   // correct Area() runs per concrete type
```

This is the backbone of **dependency injection** and **plugin architectures**: code depends on `IShape`, not on which concrete shape it gets.

---

## 5. Covariance & Contravariance (generics + polymorphism)

Lets polymorphism extend to generic type parameters — common in real-world APIs like `IEnumerable<T>`.

```csharp
// Covariance (out) — a more derived type can be used where a less derived is expected
IEnumerable<string> strings = new List<string>();
IEnumerable<object> objects = strings;   // OK: IEnumerable<T> is covariant (out T)

// Contravariance (in) — a less derived type can be used where a more derived is expected
Action<object> objAction = obj => Console.WriteLine(obj);
Action<string> strAction = objAction;    // OK: Action<T> is contravariant (in T)
```

---

## 6. Why It Matters (Architecture)

- **Open/Closed Principle** — add new types (`PushNotification`, `TriangleShape`) without modifying existing calling code.
- **Plugin/strategy systems** — swap behavior at runtime via interface/base references.
- **Dependency Injection** — entire pattern relies on coding against abstractions, letting the DI container decide the concrete polymorphic type.
- **Testability** — mock/fake implementations substitute for real ones because both are polymorphic under the same interface.

---

# Contravariance — in, Convariance — out
Example:
```csharp
public class Animal { }









