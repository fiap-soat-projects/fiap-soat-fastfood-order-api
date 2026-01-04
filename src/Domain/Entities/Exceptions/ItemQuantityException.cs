using Business.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Business.Entities.Exceptions;

[ExcludeFromCodeCoverage]
public class ItemQuantityException : InvalidEntityPropertyException<ItemQuantity>
{
    protected ItemQuantityException(string propertyName) : base(propertyName)
    {

    }
}
