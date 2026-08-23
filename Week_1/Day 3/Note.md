## What is Inheritance?

Inheritance means creating a new class based on an existing class.
- The existing class is called the base class (or parent class).
- The new class is called the derived class (or child class).

For example:
```
       Animal
       /    \
     Dog    Cat
```

## "Is-A" Relationship

One of the most important rules for inheritance:
```text
Inheritance should represent an "is-a" relationship.
```
- **Manager IS-A Employee → good.**  
- **Car HAS-A Engine → that's composition, not inheritance**

## Constructors and base()
Constructors are not inherited. A derived class must either implicitly or explicitly call a base constructor before its own body runs.

## virtual, override, and new — Know the Difference
virtual means:
"A child class is allowed to provide its own implementation."
override means:
"A child class is providing its own implementation of a base class method."
new means:
"A child class is providing its own implementation of a base class method, but the base class method
```
Animal {
    // This method can be overridden by derived classes
    public virtual void Eat() { Console.WriteLine("Animal is eating."); }
    public void Sound() { Console.WriteLine("Animal sound."); }
}

Dog : Animal {
    // This method overrides the base class method
    public override void Eat() { Console.WriteLine("Dog is eating."); }
    // This method hides the base class method
    public new void Sound() { Console.WriteLine("Dog sound."); }
}

```

## sealed — Closing the Hierarchy
Sealed classes cannot be inherited. Sealed methods cannot be overridden.
```
sealed class SealedClass {
    // This class cannot be inherited
}

class BaseClass {
    // This method cannot be overridden
    public sealed void SealedMethod() { Console.WriteLine("Sealed method."); }
}

```

## Key Points
- Base class: The class being inherited from.
- Derived class: The class that inherits from the base class.
- What is inheritance?
  - A mechanism where a derived class gets accessible behavior and state from a base class and can add or specialize its own behavior.
- What is protected?
  - A member accessible inside the declaring class and its derived classes.
- What does virtual mean?
  - A base-class member can be overridden by a derived class.
- What does override mean?
  - derived class provides a new implementation for an overridable base member.
- What does new mean?
  - derived class provides a new implementation for a base member that is not overridable.
- What is an "is-a" relationship?
  - It is the relationship inheritance should generally model.
- What is "has-a"?
  - It is the relationship composition should generally model.



## Quick Review
```
class Base            { }               // can be inherited
sealed class Base      { }              // cannot be inherited
abstract class Base    { }              // cannot be instantiated, may have abstract members
class Derived : Base   { }              // single inheritance
class Derived : Base, IFoo, IBar { }    // 1 base class + N interfaces

public virtual void M() { }             // overridable, resolved at runtime
public override void M() { }            // provides the derived implementation
public new void M() { }                 // hides (avoid — resolved at compile time)
public sealed override void M() { }     // final override, cannot be overridden further
public abstract void M();              // must be implemented by non-abstract derived classes
```

