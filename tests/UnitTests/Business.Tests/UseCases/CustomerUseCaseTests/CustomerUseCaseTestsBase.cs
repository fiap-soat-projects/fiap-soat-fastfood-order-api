using Business.Gateways.Clients.Interfaces;
using Business.UseCases;
using NSubstitute;

namespace Business.Tests.UseCases.CustomerUseCaseTests;

public abstract class CustomerUseCaseTestsBase
{
    internal readonly ICustomerClient _customerClient;
    internal readonly CustomerUseCase _sut;

    protected CustomerUseCaseTestsBase()
    {
        _customerClient = Substitute.For<ICustomerClient>();

        _sut = new CustomerUseCase(_customerClient);
    }
}
