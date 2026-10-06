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
        if (string.IsNullOrWhiteSpace(customerId))
        {
            throw new ArgumentException("CustomerId can't be empty");
        }

        if (amount < 0)
        {
            throw new ArgumentException("Amount must be greater than zero");
        }

        if (string.IsNullOrWhiteSpace(currency))
        {
            throw new ArgumentException("Currency can't be empty");
        }

        if (!Enum.IsDefined(typeof(PaymentMethod), paymentMethod))
        {
            throw new ArgumentException($"{paymentMethod} is not a valid payment method");
        }

        var payment = new Payment(
            id: Guid.NewGuid(),
            amount: amount,
            currency: currency,
            customerId: customerId,
            method: paymentMethod,
            status: PaymentStatus.Pending
        );

        _payments.Add(payment);
        return payment;
    }

    public IEnumerable<Payment> GetPayments()
    {
        return _payments;
    }

    public IEnumerable<Payment?> GetPaymentsByFilter(GetPaymentsFilter filter)
    {
        IEnumerable<Payment> payments = _payments;

        if (string.IsNullOrWhiteSpace(filter.CustomerId))
        {
            throw new ArgumentException("CustomerId can't be empty");
        }

        payments = payments.Where(p => p.CustomerId == filter.CustomerId);

        if (filter.Method.HasValue && !Enum.IsDefined(typeof(PaymentMethod), filter.Method))
        {
            throw new ArgumentException($"{filter.Method} is not a valid payment method");
        }

        if (filter.Status.HasValue && !Enum.IsDefined(typeof(PaymentStatus), filter.Status))
        {
            throw new ArgumentException($"{filter.Status} is not a valid payment status");
        }


        if (filter.StartDate.HasValue && filter.EndDate.HasValue)
        {
            if (filter.StartDate > filter.EndDate)
            {
                throw new ArgumentException("Start date can't be before end date");
            }
        }

        payments = payments.Where(p => p.Method == filter.Method);

        payments = payments.Where(p => p.Status == filter.Status);
        if (filter.StartDate.HasValue)
        {
            payments = payments.Where(p => p.CreatedAt >= filter.StartDate.Value);
        }

        if (filter.EndDate.HasValue)
        {
            payments = payments.Where(p => p.CreatedAt >= filter.EndDate.Value);
        }


        return payments.ToArray();
    }

    public Payment? GetPaymentsById(Guid paymentId)
    {
        var payment = _payments.FirstOrDefault(p => p.Id == paymentId);
        return payment;
    }

    public IEnumerable<Payment> GetPaymentsByCustomerId(string customerId)
    {
        var payments = _payments.Where(p => p.CustomerId == customerId);
        return payments.ToArray();
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