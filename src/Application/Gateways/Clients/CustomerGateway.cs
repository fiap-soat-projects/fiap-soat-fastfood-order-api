using Business.Entities;
using Business.Gateways.Clients.Interfaces;
using Infrastructure.Clients.Interfaces;

namespace Adapter.Gateways.Clients;

internal class CustomerGateway : ICustomerClient
{
    private readonly IHttpCustomerClient _httpCustomerClient;

    public CustomerGateway(IHttpCustomerClient httpCustomerClient)
    {
        _httpCustomerClient = httpCustomerClient;
    }

    public async Task<Customer?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var customerHttp = await _httpCustomerClient.GetByIdAsync(id, cancellationToken);

        return customerHttp?.ToDomain();
    }
}
