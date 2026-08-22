using System;
using System.Collections.Generic;
using System.Text;

namespace Week_1.Day_2.Abstraction.Good_Example;

public class PaymentService
{
    private readonly IPaymentProcessor _paymentProcessor;
    public PaymentService(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }

    public void Pay(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount cannot be negative.");
        }
        _paymentProcessor.ProcessPayment(amount);
    }
}
