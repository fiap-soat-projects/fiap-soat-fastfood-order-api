namespace Adapter.Controllers.DTOs;

public record UpdatePaymentRequest(string? Id, string? Method, string? Status) { }
