using PaymentProcessor.Models.Entities;
using PaymentProcessor.Models.Enums;

namespace PaymentProcessor.Models.Interfaces;

public record GetPaymentsFilter(
    string? CustomerId,
    DateTime? StartDate,
    DateTime? EndDate,
    PaymentMethod? Method,
    PaymentStatus? Status);

public interface IPaymentService
{
    Payment CreatePayment(string customerId, decimal amount, string currency, PaymentMethod paymentMethod,
        PaymentStatus status);

    IEnumerable<Payment> GetPayments();
    IEnumerable<Payment?> GetPaymentsByFilter(GetPaymentsFilter filter);
    Payment? GetPaymentsById(Guid paymentId);
    IEnumerable<Payment> GetPaymentsByCustomerId(string customerId);
}