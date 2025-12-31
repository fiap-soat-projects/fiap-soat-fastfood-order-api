namespace Adapter.Controllers.DTOs;

public record CreateRequest
(
    string? CustomerId, 
    IEnumerable<OrderItemRequest> Items
) { }