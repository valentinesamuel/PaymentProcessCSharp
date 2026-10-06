using PaymentProcessor.Models.Entities;
using PaymentProcessor.Models.Enums;
using PaymentProcessor.Models.Interfaces;

namespace PaymentProcessor.Services;

public class TransactionService : ITransactionService
{
    private readonly List<Transaction> _transactions = [];


    public (Transaction debitTrnx, Transaction creditTrnx) CreateTransaction(Payment payment)
    {
        if (payment.Status != PaymentStatus.Completed)
        {
            throw new InvalidOperationException("Cannot create a transaction with a non-completed payment");
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


        var debitTrnx = new Transaction(
            id: Guid.NewGuid().ToString(),
            paymentId: payment.Id,
            amount: payment.Amount,
            currency: payment.Currency,
            status: TransactionStatus.Completed,
            transactionDate: DateTime.Now,
            type: TransactionType.Debit
        );
        var creditTrnx = new Transaction(
            id: Guid.NewGuid().ToString(),
            paymentId: payment.Id,
            amount: payment.Amount,
            currency: payment.Currency,
            status: TransactionStatus.Completed,
            transactionDate: DateTime.Now,
            type: TransactionType.Credit
        );

        _transactions.Add(debitTrnx);
        _transactions.Add(creditTrnx);

        return (debitTrnx, creditTrnx);
    }

    public IEnumerable<Transaction> GetTransactions()
    {
        return Enumerable.ToArray(_transactions);
    }

    public IEnumerable<Transaction?> GetTransactionsByFilter(GetTransactionsFilter filter)
    {
        IEnumerable<Transaction> transactions = _transactions;


        if (filter.Status.HasValue && !Enum.IsDefined(typeof(TransactionStatus), filter.Status))
        {
            throw new ArgumentException("Invalid transaction status");
        }


        if (!string.IsNullOrWhiteSpace(filter.PaymentId))
        {
            transactions = transactions.Where(t => t.PaymentId == new Guid(filter.PaymentId));
        }

        if ((filter.StartDate.HasValue && filter.EndDate.HasValue) && filter.StartDate > filter.EndDate)
        {
            throw new ArgumentException("Start date can't be before end date");
        }

        if (filter.StartDate.HasValue)
        {
            transactions = transactions.Where(t => t.CreatedAt >= filter.StartDate.Value);
        }

        if (filter.EndDate.HasValue)
        {
            transactions = transactions.Where(t => t.CreatedAt <= filter.EndDate.Value);
        }

        return transactions.ToArray();
    }

    public Transaction? GetTransactionById(string id)
    {
        var transaction = _transactions.FirstOrDefault(t => t.Id == id);
        return transaction;
    }

    public Transaction[] GetTransactionByPaymentId(Guid paymentId)
    {
        var transactions = _transactions.Where(t => t.PaymentId == paymentId);
        return Enumerable.ToArray(transactions);
    }
}