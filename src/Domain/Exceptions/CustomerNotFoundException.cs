using Business.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Business.Exceptions;

[ExcludeFromCodeCoverage]
public class CustomerNotFoundException : EntityNotFoundException<Customer>
{
    public CustomerNotFoundException(string id) : base(id)
    {

    }
}
