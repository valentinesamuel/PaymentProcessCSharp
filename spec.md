# Payment Processor — C# Learning Project

## Goal

Build a console-based payment processing system in C#.

The purpose of this project is to practice core C# concepts before moving into ASP.NET Core.

Do NOT use:

- ASP.NET Core
- Entity Framework Core
- External NuGet packages
- A real database

Use in-memory collections instead.

---

# 1. Project Structure

Organize the application roughly like this:
```
PaymentProcessor/
│
├── Models/
│   ├── Payment.cs
│   └── Transaction.cs
│
├── Enums/
│   ├── PaymentStatus.cs
│   ├── PaymentMethod.cs
│   └── TransactionStatus.cs
│
├── Services/
│   └── PaymentService.cs
│
├── Exceptions/
│   └── PaymentException.cs
│
└── Program.cs

```
The exact structure is up to you.

---

# 2. Payment

Create a `Payment` class.

It should contain:

- Id
- CustomerId
- Amount
- Currency
- PaymentMethod
- Status
- CreatedAt

Requirements:

- Id should be a `Guid`
- Amount should be `decimal`
- CreatedAt should use an appropriate date/time type
- Status should use `PaymentStatus`
- PaymentMethod should use `PaymentMethod`

A payment starts as:

`Pending`

---

# 3. PaymentStatus

Create an enum:

- Pending
- Processing
- Completed
- Failed
- Cancelled

---

# 4. PaymentMethod

Create an enum:

- Card
- BankTransfer
- Wallet

---

# 5. Transaction

Create a `Transaction` class.

It should contain:

- Id
- PaymentId
- Status
- Amount
- Currency
- CreatedAt
- CompletedAt
- FailureReason

Requirements:

- Transaction Id should be a `Guid`
- PaymentId should reference the payment
- Amount should be `decimal`
- FailureReason should be nullable
- CompletedAt should be nullable

---

# 6. TransactionStatus

Create an enum:

- Pending
- Successful
- Failed

---

# 7. PaymentService

Create a `PaymentService`.

The service is responsible for all payment-related business logic.

It should maintain payments and transactions in memory.

For example, you could use:

- `List<Payment>`
- `List<Transaction>`

Do not expose the internal lists directly.

---

# 8. CreatePayment
🟢🟢🟢🟢🟢
Implement:

`CreatePayment()`

It should:

1. Validate the input.
2. Generate a payment ID.
3. Create a payment.
4. Set its status to `Pending`.
5. Set `CreatedAt`.
6. Store the payment.
7. Return the payment.

Validation:

- Customer ID cannot be empty.
- Amount must be greater than zero.
- Currency cannot be empty.
- Payment method must be valid.

---

# 9. GetPayment

Implement:

`GetPayment(Guid paymentId)`

It should:

- Find the payment.
- Return the payment if found.
- Return `null` if it doesn't exist.

Use LINQ.

---

# 10. GetPayments

Implement:

`GetPayments()`

It should return all payments.

Do not expose the internal mutable `List<Payment>` directly.

Consider returning:

`IEnumerable<Payment>`

---

# 11. ProcessPayment

Implement:

`ProcessPayment(Guid paymentId)`

It should:

1. Find the payment.
2. Throw an appropriate exception if it doesn't exist.
3. Verify that the payment is `Pending`.
4. Change the status to `Processing`.
5. Simulate payment processing.
6. Create a transaction.
7. Mark the payment as `Completed` when successful.
8. Mark the transaction as `Successful`.
9. Set `CompletedAt`.
10. Store the transaction.
11. Return the transaction.

A payment that has already been:

- Completed
- Failed
- Cancelled

must not be processed again.

---

# 12. Simulate Payment Failure

The application should be able to simulate a failed payment.

You don't need a real payment provider.

For example, you could define a simple rule such as:

- amounts above a certain threshold fail

OR

- randomly succeed/fail

The important thing is that your system handles both outcomes.

When payment processing fails:

- Payment status → `Failed`
- Transaction status → `Failed`
- FailureReason should be populated
- CompletedAt should remain `null`

---

# 13. GetTransaction

Implement:

`GetTransaction(Guid transactionId)`

It should:

- Find the transaction.
- Return it if found.
- Return `null` if it doesn't exist.

Use LINQ.

---

# 14. GetTransactionForPayment

Implement:

`GetTransactionForPayment(Guid paymentId)`

It should:

- Find the transaction associated with the payment.
- Return `null` if no transaction exists.

---

# 15. Get Transactions

Implement:

`GetTransactions()`

Return all transactions.

Prefer returning:

`IEnumerable<Transaction>`

instead of exposing your internal `List<Transaction>`.

---

# 16. CancelPayment

Implement:

`CancelPayment(Guid paymentId)`

Rules:

A payment can only be cancelled while:

`Pending`

A payment cannot be cancelled after:

- Processing
- Completed
- Failed
- Already Cancelled

When cancelled:

`Payment.Status = Cancelled`

---

# 17. RefundPayment

Add support for refunds.

Implement:

`RefundPayment(Guid paymentId)`

Rules:

- Payment must exist.
- Payment must be `Completed`.
- A payment cannot be refunded twice.

You may introduce:

`Refunded`

to `PaymentStatus`.

A successful refund should update the payment appropriately.

---

# 18. Payment History

Implement:

`GetPaymentHistory(Guid paymentId)`

It should return all relevant transactions/events associated with a payment.

This is an opportunity to practice:

- `IEnumerable<T>`
- LINQ
- filtering
- ordering

For example, transactions should be returned newest-first.

---

# 19. Search Payments

Implement a search method.

Example:

`SearchPayments(...)`

It should allow filtering by things such as:

- CustomerId
- Currency
- Status
- PaymentMethod
- Minimum amount
- Maximum amount

Not every filter needs to be supplied.

Example conceptually:

```text
SearchPayments(
    customerId: "customer-123",
    status: Completed
)