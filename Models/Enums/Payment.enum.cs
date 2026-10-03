namespace PaymentProcessor.Models.Enums;

public enum PaymentStatus
{
    Pending,
    Completed,
    Failed,
    Processing,
    Cancelled,
}

public enum PaymentMethod
{
    Cash,
    Transfer,
    Wallet,
    Card,
}