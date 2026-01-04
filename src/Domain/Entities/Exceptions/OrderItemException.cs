using Business.Entities;
using Business.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Business.Entities.Exceptions;

[ExcludeFromCodeCoverage]
public class OrderItemException : InvalidEntityPropertyException<OrderItem>
{
    public OrderItemException(string propertyName) : base(propertyName)
    {

    }
}
