using PaymentProcessor.Models.Enums;

namespace PaymentProcessor.Models.Entities;

public class Transaction(
    string id,
    Guid paymentId,
    TransactionStatus status,
    decimal amount,
    string currency,
    DateTime transactionDate,
    TransactionType type
)
{
    public string Id { get; } = Guid.NewGuid().ToString();

    public Guid PaymentId { get; set; } = paymentId;
    public decimal Amount { get; set; } = amount;
    public string Currency { get; set; } = currency;
    public TransactionStatus Status { get; set; } = status;
    public TransactionType Type { get; set; } = type;
    public DateTime CreatedAt { get; } = new DateTime();
    public DateTime CompletedAt { get; set; }
    public string FailureReason { get; set; } = string.Empty;
}