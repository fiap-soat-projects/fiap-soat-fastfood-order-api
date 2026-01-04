using Adapter.Gateways.Repositories;
using Infrastructure.Repositories.Interfaces;
using NSubstitute;

namespace Adapter.Tests.Gateways.Repositories.MenuItemGatewayTests;

public abstract class MenuItemGatewayTestsBase
{
    internal readonly IMenuItemMongoDbRepository _menuItemMongoDbRepository;
    internal readonly MenuItemGateway _sut;

    protected MenuItemGatewayTestsBase()
    {
        _menuItemMongoDbRepository = Substitute.For<IMenuItemMongoDbRepository>();

        _sut = new MenuItemGateway(_menuItemMongoDbRepository);
    }
}
