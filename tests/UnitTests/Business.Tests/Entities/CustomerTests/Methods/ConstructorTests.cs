using Business.Entities;
using Domain.ValueObjects;

namespace Business.Tests.Entities.CustomerTests.Methods;

public class ConstructorTests
{
    [Fact]
    public void Have_ValidParameters_When_CallConstructor_Then_ObjectCreated()
    {
        #region Arrange
        var id = "cust-1";
        var name = "John Doe";
        var cpf = new Cpf("74334723047");
        var email = new Email("teste@test.com");
        #endregion

        // Act
        var customer = new Customer(id, name, cpf, email);

        // Assert
        Assert.NotNull(customer);
        Assert.Equal(id, customer.Id);
        Assert.Equal(name, customer.Name);
        Assert.Equal(cpf, customer.Cpf);
        Assert.Equal(email, customer.Email);
    }
}
