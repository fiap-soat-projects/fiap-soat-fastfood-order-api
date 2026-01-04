using System.Diagnostics.CodeAnalysis;

namespace Adapter.Controllers.DTOs;

[ExcludeFromCodeCoverage]
public record OrderItemRequest
(
    string? Id,
    int Amount
)
{ }