using Business.Entities;

namespace Business.UseCases.Interfaces;

public interface ICustomerUseCase
{
    Task<Customer> GetByIdAsync(string id, CancellationToken cancellationToken);
}
