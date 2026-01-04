using Adapter.Gateways.Clients;
using Infrastructure.Clients.Interfaces;
using Business.Entities;
using NSubstitute;

namespace Adapter.Tests.Gateways.Clients.CustomerGatewayTests;

public abstract class CustomerGatewayTestsBase
{
    internal readonly IHttpCustomerClient _httpCustomerClient;
    internal readonly CustomerGateway _sut;

    protected CustomerGatewayTestsBase()
    {
        _httpCustomerClient = Substitute.For<IHttpCustomerClient>();

        _sut = new CustomerGateway(_httpCustomerClient);
    }
}
