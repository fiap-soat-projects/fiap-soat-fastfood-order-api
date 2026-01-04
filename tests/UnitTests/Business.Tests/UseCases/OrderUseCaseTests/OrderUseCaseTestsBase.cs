using Business.Gateways.Repositories.Interfaces;
using Business.UseCases;
using NSubstitute;

namespace Business.Tests.UseCases.OrderUseCaseTests;

public abstract class OrderUseCaseTestsBase
{
    internal readonly IOrderRepository _orderRepository;
    internal readonly OrderUseCase _sut;

    protected OrderUseCaseTestsBase()
    {
        _orderRepository = Substitute.For<IOrderRepository>();

        _sut = new OrderUseCase(_orderRepository);
    }
}
