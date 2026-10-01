using PaymentProcessor.Models.Entities;
using PaymentProcessor.Models.Enums;
using PaymentProcessor.Models.Interfaces;

namespace PaymentProcessor.Services;

public class PaymentService
{
    public Payment[] GetPayments()
    {
        return
        [
            new Payment(
                id: Guid.NewGuid().ToString(),
                amount: 23.99m,
                currency: "EUR",
                customerId: Guid.NewGuid().ToString(),
                method: PaymentMethod.Card,
                status: PaymentStatus.Pending
            )
        ];
    }

    public Payment[] GetPaymentsByFilter(GetPaymentsFilter filter)
    {
        return
        [
            new Payment(
                id: Guid.NewGuid().ToString(),
                amount: 23.99m,
                currency: "EUR",
                customerId: Guid.NewGuid().ToString(),
                method: PaymentMethod.Card,
                status: PaymentStatus.Pending
            )
        ];
    }

    public Payment GetPaymentsById(string id)
    {
        return new Payment(
            id: Guid.NewGuid().ToString(),
            amount: 23.99m,
            currency: "EUR",
            customerId: Guid.NewGuid().ToString(),
            method: PaymentMethod.Card,
            status: PaymentStatus.Pending);
    }

    public Payment[] GetPaymentsByCustomerId(string customerId)
    {
        return
        [
            new Payment(
                id: Guid.NewGuid().ToString(),
                amount: 23.99m,
                currency: "EUR",
                customerId: Guid.NewGuid().ToString(),
                method: PaymentMethod.Card,
                status: PaymentStatus.Pending
            )
        ];
    }

    public Payment[] GetPaymentsWithinRange(DateTime startDate, DateTime endDate)
    {
        return
        [
            new Payment(
                id: Guid.NewGuid().ToString(),
                amount: 23.99m,
                currency: "EUR",
                customerId: Guid.NewGuid().ToString(),
                method: PaymentMethod.Card,
                status: PaymentStatus.Pending
            )
        ];
    }
}