using Business.Entities.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Adapter.Controllers.DTOs;

[ExcludeFromCodeCoverage]
public record RegisterMenuItemRequest(
    string? Name,
    decimal Price,
    ItemCategory Category,
    string? Description)
{
    public ItemCategory Category { get; init; } = Category;
}