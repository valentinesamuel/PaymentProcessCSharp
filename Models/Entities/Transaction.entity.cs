using PaymentProcessor.Models.Enums;

namespace PaymentProcessor.Models.Entities;

public class Transaction(string id, string paymentId, TransactionStatus status, DateTime transactionDate)
{
    public string Id { get; set; } = id;

    public string PaymentId { get; set; } = paymentId;

    public TransactionStatus Status { get; set; } = status;

    public DateTime TransactionDate { get; set; } = transactionDate;
}