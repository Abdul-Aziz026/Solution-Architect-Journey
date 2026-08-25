## What is Cohesion?

Cohesion = how closely related the responsibilities inside a class/module are.

High cohesion → one clear purpose.
Low cohesion → many unrelated responsibilities.

**❌ Low Cohesion**
```
public class UserManager
{
    public void CreateUser() { }

    public void SendEmail() { }

    public void GeneratePdf() { }

    public void BackupDatabase() { }
}
```
These responsibilities are unrelated.

**✅ High Cohesion**
```
public class UserService
{
    public void CreateUser() { }
    public void DeleteUser() { }
    public void UpdateUser() { }
}
```
## 2. Important Rule

Ask: "Do these responsibilities belong together?"

If yes → keep them together.
If no → consider separating them.

## 3. Cohesion ≠ One Method Per Class

Don't over-split:
```
public class Order
{
    public void AddItem() { }
    public void RemoveItem() { }
    public decimal CalculateTotal() => 0;
}
```
**These behaviors all belong naturally to an Order, so this is cohesive.**

## Cohesion vs SRP

They are closely related, but not the same thing.
- Cohesion: Are the responsibilities closely related?
- SRP: Does the class have one reason to change?



