using Business.Entities.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Business.UseCases.DTOs;

[ExcludeFromCodeCoverage]

internal record MenuItemFilter(
    string? Name,
    ItemCategory? Category,
    int Skip,
    int Limit);