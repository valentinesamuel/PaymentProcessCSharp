namespace PaymentProcessor.Models.Enums;

public enum TransactionStatus
{
    Pending,
    Completed,
    Failed,
}

public enum TransactionType
{
    Debit,
    Credit
}