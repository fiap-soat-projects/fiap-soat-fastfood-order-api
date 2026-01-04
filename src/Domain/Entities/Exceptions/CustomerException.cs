using Business.Entities;
using Business.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Business.Entities.Exceptions;

[ExcludeFromCodeCoverage]
internal class CustomerException : InvalidEntityPropertyException<Customer>
{
    public CustomerException(string propertyName) : base(propertyName)
    {

    }
}