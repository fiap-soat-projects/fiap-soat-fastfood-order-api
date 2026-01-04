using Adapter.Controllers;
using Business.UseCases.Interfaces;
using NSubstitute;

namespace Adapter.Tests.Controllers.MenuControllerTests;

public abstract class MenuControllerTestsBase
{
    internal readonly IMenuItemUseCase _menuItemUseCase;
    internal readonly MenuController _sut;

    protected MenuControllerTestsBase()
    {
        _menuItemUseCase = Substitute.For<IMenuItemUseCase>();
        _sut = new MenuController(_menuItemUseCase);
    }
}