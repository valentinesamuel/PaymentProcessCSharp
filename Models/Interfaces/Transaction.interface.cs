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
    Transaction CreateTransaction(Payment payment);
    Transaction[] GetTransactions();
    Transaction[] GetTransactionsByFilter(GetPaymentsFilter filter);
    Transaction? GetTransactionById(string id);
    Transaction? GetTransactionByPaymentId(string paymentId);
}