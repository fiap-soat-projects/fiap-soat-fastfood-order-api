using System.Diagnostics.CodeAnalysis;

namespace Adapter.Presenters.DTOs;

[ExcludeFromCodeCoverage]
public record OrderItemResponse
(
    string? Name,
    string? Category,
    decimal Price,
    int Amount
) { }