using PaymentProcessor.Models.Entities;
using PaymentProcessor.Models.Enums;

namespace PaymentProcessor.Models.Interfaces;

public record GetTransactionsFilter(
    string? PaymentId,
    DateTime? StartDate,
    DateTime? EndDate,
    TransactionStatus? Status);

public interface ITransactionService
{
    (Transaction debitTrnx, Transaction creditTrnx) CreateTransaction(Payment payment);
    IEnumerable<Transaction> GetTransactions();
    IEnumerable<Transaction?> GetTransactionsByFilter(GetTransactionsFilter filter);
    Transaction? GetTransactionById(string id);
    Transaction[] GetTransactionByPaymentId(Guid paymentId);
}