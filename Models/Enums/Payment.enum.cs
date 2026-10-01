namespace PaymentProcessor.Models.Enums;

public enum PaymentStatus
{
    Pending,
    Completed,
    Failed,
}

public enum PaymentMethod
{
    Cash,
    P2P,
    Card,
}