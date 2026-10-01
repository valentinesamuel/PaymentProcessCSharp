using PaymentProcessor.Models.Entities;
using PaymentProcessor.Models.Enums;
using PaymentProcessor.Models.Interfaces;

namespace PaymentProcessor.Services;

public class PaymentService : IPaymentService
{
    private readonly List<Payment> _payments = [];

    public Payment CreatePayment(string customerId, decimal amount, string currency, PaymentMethod paymentMethod,
        PaymentStatus status)
    {
        var payment = new Payment(
            id: Guid.NewGuid().ToString(),
            amount: amount,
            currency: currency,
            customerId: customerId,
            method: paymentMethod,
            status: status
        );
        _payments.Add(payment);
        return payment;
    }

    public Payment[] GetPayments()
    {
        return Enumerable.ToArray(_payments);
    }

    public Payment[] GetPaymentsByFilter(GetPaymentsFilter filter)
    {
        return Enumerable.ToArray(_payments);
    }

    public Payment GetPaymentsById(string id)
    {
        return new Payment(
            id: Guid.NewGuid().ToString(),
            amount: 23.99m,
            currency: "EUR",
            customerId: Guid.NewGuid().ToString(),
            method: PaymentMethod.Card,
            status: PaymentStatus.Pending);
    }

    public Payment[] GetPaymentsByCustomerId(string customerId)
    {
        return Enumerable.ToArray(_payments);
    }

    public Payment[] GetPaymentsWithinRange(DateTime startDate, DateTime endDate)
    {
        return Enumerable.ToArray(_payments);
    }

    public string GenerateRandomCurrency()
    {
        string[] currencyList = ["Pending", "Completed", "Failed"];

        var randomIndex = Random.Shared.Next(currencyList.Length);

        var randomCurrency = currencyList[randomIndex];
        return randomCurrency;
    }

    public decimal GenerateRandomAmount()
    {
        var randomPriceDouble = Random.Shared.NextDouble() * (100.0 - 5.0) + 5.0;
        decimal randomPrice = (decimal)Math.Round(randomPriceDouble, 2);

        return randomPrice;
    }
}