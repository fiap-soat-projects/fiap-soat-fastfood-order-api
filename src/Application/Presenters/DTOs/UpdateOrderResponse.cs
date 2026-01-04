using Business.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Adapter.Presenters.DTOs;

[ExcludeFromCodeCoverage]
public record UpdateOrderResponse
(
    string Id,
    string CustomerId,
    string CustomerName,
    IEnumerable<OrderItemResponse> Items,
    string Status,
    decimal TotalPrice
)
{ }
