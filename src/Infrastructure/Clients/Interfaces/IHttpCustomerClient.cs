using Infrastructure.Entities;

namespace Infrastructure.Clients.Interfaces;

public interface IHttpCustomerClient
{
    Task<CustomerHttp?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
