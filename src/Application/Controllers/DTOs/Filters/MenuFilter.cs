using Business.Entities.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Adapter.Controllers.DTOs.Filters;

[ExcludeFromCodeCoverage]
public record MenuFilter(
    string? Name,
    ItemCategory? Category,
    int Skip,
    int Limit);