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
    Transaction[] GetTransactions();
    Transaction[] GetTransactionsByFilter(GetPaymentsFilter filter);
    Transaction GetTransactionsById(string id);
    Transaction[] GetTransactionsByPaymentId(string paymentId);
    Transaction[] GetTransactionsWithinRange(DateTime startDate, DateTime endDate);
}