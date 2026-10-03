using System.ComponentModel.DataAnnotations;
using PaymentProcessor.Models.Enums;

namespace PaymentProcessor.Models.Entities;

public class Payment(
    Guid id,
    decimal amount,
    string currency,
    string customerId,
    PaymentMethod method = PaymentMethod.Cash,
    PaymentStatus status = PaymentStatus.Pending)
{
    public Guid Id { get; } = Guid.NewGuid();

    public decimal Amount { get; set; } = amount;

    public string Currency { get; set; } = currency;

    public string CustomerId { get; set; } = customerId;
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public PaymentMethod Method { get; set; } = method;

    public PaymentStatus Status { get; set; } = status;
}