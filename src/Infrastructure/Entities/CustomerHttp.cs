using Business.Entities;
using Domain.ValueObjects;

namespace Infrastructure.Entities;

public class CustomerHttp
{ 
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Cpf { get; set; }
    public string? Email { get; set; }

    public CustomerHttp()
    {
        
    }

    public Customer ToDomain()
    {
        var customer = new Customer(Id, Name, Cpf, Email);
        return customer;
    }
}
