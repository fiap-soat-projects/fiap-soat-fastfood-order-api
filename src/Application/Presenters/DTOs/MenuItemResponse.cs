using Business.Entities.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Adapter.Presenters.DTOs;

[ExcludeFromCodeCoverage]
public record MenuItemResponse(
    string Id,
    string Name,
    decimal Price,
    ItemCategory Category,
    string Description,
    bool IsActive)
{
    public ItemCategory Category { get; init; } = Category;
}