# Coupling

Coupling = how much one class depends on another class.
### 🔴 High Coupling
```
public class OrderService
{
    public void CreateOrder()
    {
        var payment = new StripePaymentProcessor();
        var email = new EmailSender();

        payment.ProcessPayment();
        email.SendEmail();
    }
}
```
OrderService directly depends on:

StripePaymentProcessor
EmailSender

If you replace Stripe with PayPal, you must modify OrderService.
That's high coupling.

### 🟢 Low Coupling

Use abstractions:
```
public interface IPaymentProcessor
{
    void ProcessPayment();
}

public interface IEmailSender
{
    void SendEmail();
}
```
**Then:**
```
public class OrderService
{
    private readonly IPaymentProcessor _payment;
    private readonly IEmailSender _email;

    public OrderService(
        IPaymentProcessor payment,
        IEmailSender email)
    {
        _payment = payment;
        _email = email;
    }

    public void CreateOrder()
    {
        _payment.ProcessPayment();
        _email.SendEmail();
    }
}
```
Now OrderService doesn't care whether payment is:

```
IPaymentProcessor
       ↓
 ┌─────┴─────┐
Stripe      PayPal
```
**You can replace the implementation without changing OrderService.**

## Easy Mental Model

Think of a phone charger.

High coupling
```
Phone is permanently connected to one specific charger.
Phone ───── Specific Charger
Change the charger → modify the phone.
```
Low coupling
```
Phone uses a standard interface:
Phone → USB-C → Any compatible charger
The phone depends on the interface/contract, not a specific charger.
```


## How to Identify Coupling

When reviewing code, ask:

"If I change Class B, how much of Class A must I change?"

- If changing B frequently forces changes in A → high coupling.
- If A depends on an abstraction and B can be replaced easily → low coupling.

**Key rule**
```
Good design aims for low coupling + high cohesion.
```
