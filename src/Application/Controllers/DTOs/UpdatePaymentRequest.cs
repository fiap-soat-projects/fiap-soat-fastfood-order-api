namespace Adapter.Controllers.DTOs;

public record UpdatePaymentRequest(string? PaymentId, string? PaymentMethod, string? PaymentStatus) { }
