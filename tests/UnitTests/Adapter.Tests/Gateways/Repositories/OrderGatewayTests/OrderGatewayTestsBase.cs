using Adapter.Gateways.Repositories;
using Infrastructure.Repositories.Interfaces;
using NSubstitute;

namespace Adapter.Tests.Gateways.Repositories.OrderGatewayTests;

public abstract class OrderGatewayTestsBase
{
    internal readonly IOrderMongoDbRepository _orderMongoDbRepository;
    internal readonly OrderGateway _sut;

    protected OrderGatewayTestsBase()
    {
        _orderMongoDbRepository = Substitute.For<IOrderMongoDbRepository>();

        _sut = new OrderGateway(_orderMongoDbRepository);
    }
}
