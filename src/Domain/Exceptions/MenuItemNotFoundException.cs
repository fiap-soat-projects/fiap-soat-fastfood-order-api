using Business.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Business.Exceptions;

[ExcludeFromCodeCoverage]
public class MenuItemNotFoundException : EntityNotFoundException<MenuItem>
{
    public MenuItemNotFoundException(string id) : base(id)
    {

    }
}
