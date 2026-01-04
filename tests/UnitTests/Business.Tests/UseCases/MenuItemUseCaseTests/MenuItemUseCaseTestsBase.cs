using Business.Gateways.Repositories.Interfaces;
using Business.UseCases;
using NSubstitute;

namespace Business.Tests.UseCases.MenuItemUseCaseTests;

public abstract class MenuItemUseCaseTestsBase
{
    internal readonly IMenuItemRepository _menuItemRepository;
    internal readonly MenuItemUseCase _sut;

    protected MenuItemUseCaseTestsBase()
    {
        _menuItemRepository = Substitute.For<IMenuItemRepository>();

        _sut = new MenuItemUseCase(_menuItemRepository);
    }
}
