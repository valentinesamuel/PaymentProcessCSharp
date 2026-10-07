using PaymentProcessor.Models.Enums;
using PaymentProcessor.Services;

var transactionService = new TransactionService();
var paymentService = new PaymentService(transactionService);


paymentService.CreatePayment(customerId: Guid.NewGuid().ToString(), amount: paymentService.GenerateRandomAmount(),
    currency: paymentService.GenerateRandomCurrency(),
    status: PaymentStatus.Completed, paymentMethod: PaymentMethod.Card);
paymentService.CreatePayment(customerId: Guid.NewGuid().ToString(), amount: paymentService.GenerateRandomAmount(),
     currency: paymentService.GenerateRandomCurrency(),
     status: PaymentStatus.Completed, paymentMethod: PaymentMethod.Card);
paymentService.CreatePayment(customerId: Guid.NewGuid().ToString(), amount: paymentService.GenerateRandomAmount(),
     currency: paymentService.GenerateRandomCurrency(),
     status: PaymentStatus.Completed, paymentMethod: PaymentMethod.Card);
// paymentService.CreatePayment(customerId: Guid.NewGuid().ToString(), amount: paymentService.GenerateRandomAmount(),
//     currency: paymentService.GenerateRandomCurrency(),
//     status: PaymentStatus.Pending, paymentMethod: PaymentMethod.Card);
// paymentService.CreatePayment(customerId: Guid.NewGuid().ToString(), amount: paymentService.GenerateRandomAmount(),
//     currency: paymentService.GenerateRandomCurrency(),
//     status: PaymentStatus.Pending, paymentMethod: PaymentMethod.Card);
// paymentService.CreatePayment(customerId: Guid.NewGuid().ToString(), amount: paymentService.GenerateRandomAmount(),
//     currency: paymentService.GenerateRandomCurrency(),
//     status: PaymentStatus.Pending, paymentMethod: PaymentMethod.Card);
// paymentService.CreatePayment(customerId: Guid.NewGuid().ToString(), amount: paymentService.GenerateRandomAmount(),
//     currency: paymentService.GenerateRandomCurrency(),
//     status: PaymentStatus.Pending, paymentMethod: PaymentMethod.Card);

var payments = paymentService.GetPayments();
foreach (var payment in payments)
{
    Console.WriteLine(payment);
    var (debit, credit) = await paymentService.ProcessPayment(payment.Id);
    Console.WriteLine(debit);
    Console.WriteLine(credit);
}
