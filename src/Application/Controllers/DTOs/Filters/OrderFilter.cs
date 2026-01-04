using System.Diagnostics.CodeAnalysis;

namespace Adapter.Controllers.DTOs.Filters;

[ExcludeFromCodeCoverage]
public record OrderFilter(string? Status, int Page, int Size)
{

}
