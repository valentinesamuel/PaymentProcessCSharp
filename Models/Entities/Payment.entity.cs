using System.ComponentModel.DataAnnotations;
using PaymentProcessor.Models.Enums;

namespace PaymentProcessor.Models.Entities;

public class Payment(
    string id,
    decimal amount,
    string currency,
    string customerId,
    PaymentMethod method = PaymentMethod.Cash,
    PaymentStatus status = PaymentStatus.Pending)
{
    // [Key]
    public string Id { get; set; } = id;

    // [Required]
    // [Range(0.01, 10000.00, ErrorMessage = "Amount must be between 0.01 and 10,000.00")]
    public decimal Amount { get; set; } = amount;

    // [Required]
    // [StringLength(10, ErrorMessage = "Currency cannot exceed 10 characters")]
    public string Currency { get; set; } = currency;

    // [Required]
    // [MinLength(1, ErrorMessage = "CustomerId must be at least one character")]
    public string CustomerId { get; set; } = customerId;

    // [Required(ErrorMessage = "PaymentMethod is required")]
    // [EnumDataType(typeof(PaymentMethod), ErrorMessage = "Invalid method. The value must be one of: Cash, P2P, Card.")]
    public PaymentMethod Method { get; set; } = method;

    // [Required]
    // [EnumDataType(typeof(PaymentStatus), ErrorMessage = "Invalid status. The value must be one of: Pending, Completed, Failed.")]
    public PaymentStatus Status { get; set; } = status;
}