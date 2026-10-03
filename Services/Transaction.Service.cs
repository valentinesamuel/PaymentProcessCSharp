using PaymentProcessor.Models.Entities;
using PaymentProcessor.Models.Enums;
using PaymentProcessor.Models.Interfaces;

namespace PaymentProcessor.Services;

public class TransactionService : ITransactionService
{
    private readonly List<Transaction> _transactions = [];


    public Transaction CreateTransaction(Payment payment)
    {
        if (payment.Status == PaymentStatus.Pending)
        {
            throw new InvalidOperationException("Cannot create a transaction with a pending payment");
        }

        if (!string.IsNullOrWhiteSpace(payment.CustomerId))
        {
            throw new InvalidOperationException("Cannot create a transaction without a customer id");
        }

        if (!string.IsNullOrWhiteSpace(payment.Currency))
        {
            throw new InvalidOperationException("Cannot create a transaction without a currency");
        }

        if (payment.Amount <= 0)
        {
            throw new InvalidOperationException("Cannot create a transaction with 0 or  negative amount");
        }

        newTrnx = new Transaction(
            id: Guid.NewGuid().ToString(),
            paymentId: payment.Id,
            amount: payment.Amount,
            currency: payment.Currency,
            status: payment.Status,
            transactionDate: DateTime.Now
        )
    }

    public Transaction[] GetTransactions()
    {
        return Enumerable.ToArray(_transactions);
    }

    public Transaction[] GetTransactionsByFilter(GetPaymentsFilter filter)
    {
        return Enumerable.ToArray(_transactions);
    }

    public Transaction? GetTransactionById(string id)
    {
        var transaction = _transactions.FirstOrDefault(t => t.Id == id);
        return transaction;
    }

    public Transaction? GetTransactionByPaymentId(string paymentId)
    {
        var transaction = _transactions.FirstOrDefault(t => t.PaymentId == paymentId);
        return transaction;
    }
}