using Business.Entities;

namespace Business.Gateways.Clients.Interfaces;

internal interface ICustomerClient
{
    Task<Customer?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
