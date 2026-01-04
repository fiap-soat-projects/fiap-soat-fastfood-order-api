using Business.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Business.Exceptions;

[ExcludeFromCodeCoverage]
public class OrderNotFoundException : EntityNotFoundException<Order>
{
    protected OrderNotFoundException(string id) : base(id)
    {

    }
}

