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
    Payment[] GetPayments();
    Payment[] GetPaymentsByFilter(GetPaymentsFilter filter);
    Payment GetPaymentsById(string id);
    Payment[] GetPaymentsByCustomerId(string customerId);
    Payment[] GetPaymentsWithinRange(DateTime startDate, DateTime endDate);
}