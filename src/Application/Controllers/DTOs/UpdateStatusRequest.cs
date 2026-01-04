using System.Diagnostics.CodeAnalysis;

namespace Adapter.Controllers.DTOs;

[ExcludeFromCodeCoverage]
public record UpdateStatusRequest(string? Status) { }
