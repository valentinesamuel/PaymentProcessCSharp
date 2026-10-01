using PaymentProcessor.Models.Entities;
using PaymentProcessor.Models.Enums;
using PaymentProcessor.Models.Interfaces;

namespace PaymentProcessor.Services;

public class TransactionService : ITransactionService
{
    private readonly List<Transaction> _transactions = [];

    public Transaction[] GetTransactions()
    {
        return Enumerable.ToArray(_transactions);
    }

    public Transaction[] GetTransactionsByFilter(GetPaymentsFilter filter)
    {
        return Enumerable.ToArray(_transactions);
    }

    public Transaction GetTransactionsById(string id)
    {
        return new Transaction(
            id: Guid.NewGuid().ToString(),
            paymentId: "2309303435",
            status: TransactionStatus.Pending,
            transactionDate: new DateTime(2024, 8, 1, 0, 0, 0, DateTimeKind.Utc)
        );
    }

    public Transaction[] GetTransactionsByPaymentId(string paymentId)
    {
        return Enumerable.ToArray(_transactions);
    }

    public Transaction[] GetTransactionsWithinRange(DateTime startDate, DateTime endDate)
    {
        return Enumerable.ToArray(_transactions);
    }
}