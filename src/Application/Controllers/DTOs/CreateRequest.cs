using System.Diagnostics.CodeAnalysis;

namespace Adapter.Controllers.DTOs;

[ExcludeFromCodeCoverage]
public record CreateRequest
(
    string? CustomerId, 
    IEnumerable<OrderItemRequest> Items
) { }