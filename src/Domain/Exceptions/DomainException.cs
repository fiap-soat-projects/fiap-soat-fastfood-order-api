using System.Diagnostics.CodeAnalysis;

namespace Business.Exceptions;

[ExcludeFromCodeCoverage]
public abstract class DomainException(string message) : Exception(message)
{

}