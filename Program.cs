using PaymentProcessor.Models.Enums;
using PaymentProcessor.Services;

var paymentService = new PaymentService();


paymentService.CreatePayment(customerId: Guid.NewGuid().ToString(), amount: paymentService.GenerateRandomAmount(),
    currency: paymentService.GenerateRandomCurrency(),
    status: PaymentStatus.Pending, paymentMethod: PaymentMethod.Card);
paymentService.CreatePayment(customerId: Guid.NewGuid().ToString(), amount: paymentService.GenerateRandomAmount(),
    currency: paymentService.GenerateRandomCurrency(),
    status: PaymentStatus.Pending, paymentMethod: PaymentMethod.Card);
paymentService.CreatePayment(customerId: Guid.NewGuid().ToString(), amount: paymentService.GenerateRandomAmount(),
    currency: paymentService.GenerateRandomCurrency(),
    status: PaymentStatus.Pending, paymentMethod: PaymentMethod.Card);
paymentService.CreatePayment(customerId: Guid.NewGuid().ToString(), amount: paymentService.GenerateRandomAmount(),
    currency: paymentService.GenerateRandomCurrency(),
    status: PaymentStatus.Pending, paymentMethod: PaymentMethod.Card);
paymentService.CreatePayment(customerId: Guid.NewGuid().ToString(), amount: paymentService.GenerateRandomAmount(),
    currency: paymentService.GenerateRandomCurrency(),
    status: PaymentStatus.Pending, paymentMethod: PaymentMethod.Card);
paymentService.CreatePayment(customerId: Guid.NewGuid().ToString(), amount: paymentService.GenerateRandomAmount(),
    currency: paymentService.GenerateRandomCurrency(),
    status: PaymentStatus.Pending, paymentMethod: PaymentMethod.Card);
paymentService.CreatePayment(customerId: Guid.NewGuid().ToString(), amount: paymentService.GenerateRandomAmount(),
    currency: paymentService.GenerateRandomCurrency(),
    status: PaymentStatus.Pending, paymentMethod: PaymentMethod.Card);

var payments = paymentService.GetPayments();
foreach (var payment in payments)
{
    Console.WriteLine(payment.ToString());
}