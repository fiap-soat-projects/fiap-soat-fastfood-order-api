using System.Diagnostics.CodeAnalysis;

namespace Adapter.Controllers.DTOs;

[ExcludeFromCodeCoverage]
public record UpdatePaymentRequest(string? PaymentId, string? PaymentMethod, string? PaymentStatus) { }
