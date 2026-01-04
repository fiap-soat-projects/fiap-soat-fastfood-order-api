using Business.Entities;
using Business.Exceptions;
using Business.Gateways.Clients.Interfaces;
using Business.UseCases.Interfaces;

namespace Business.UseCases;

internal class CustomerUseCase : ICustomerUseCase
{
    private readonly ICustomerClient _customerClient;
    public CustomerUseCase(ICustomerClient customerClient)
    {
        _customerClient = customerClient;
    }

    public async Task<Customer> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var customer = await _customerClient.GetByIdAsync(id, cancellationToken);

        CustomerNotFoundException.ThrowIfNull(customer, id);

        return customer!;
    }
}
