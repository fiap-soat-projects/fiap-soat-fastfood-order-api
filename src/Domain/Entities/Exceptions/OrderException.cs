using Business.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Business.Entities.Exceptions;

[ExcludeFromCodeCoverage]
public class OrderException : InvalidEntityPropertyException<Order>
{
    public OrderException(string propertyName) : base(propertyName)
    {

    }
}
