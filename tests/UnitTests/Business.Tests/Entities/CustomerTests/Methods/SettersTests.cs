using Business.Entities;
using Business.Entities.Exceptions;
using Business.Exceptions;
using Domain.ValueObjects;

namespace Business.Tests.Entities.CustomerTests.Methods;

public class SettersTests
{
    [Fact]
    public void Have_ValidId_When_CallIdSetter_Then_PropertyChange()
    {
        #region Arrange
        var id = "cust-1";
        var name = "John Doe";
        var cpf = new Cpf("74334723047");
        var email = new Email("teste@test.com");
        var customer = new Customer(id, name, cpf, email);
        var newId = "cust-2";
        #endregion

        // Act

        var exception = Record.Exception(() => customer.Id = newId);

        // Assert
        Assert.Null(exception);
        Assert.Equal(newId, customer.Id);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Have_InvalidId_When_CallIdSetter_Then_ThrowCustomerException(string? newId)
    {
        #region Arrange
        var id = "cust-1";
        var name = "John Doe";
        var cpf = new Cpf("74334723047");
        var email = new Email("teste@test.com");
        var customer = new Customer(id, name, cpf, email);
        var expectedException = new CustomerException(nameof(customer.Id));
        #endregion

        // Act

        var exception = Record.Exception(() => customer.Id = newId);

        // Assert
        Assert.NotNull(exception);
        var customerException = Assert.IsType<InvalidEntityPropertyException<Customer>>(exception);
        Assert.Equal(expectedException.Message, customerException.Message);
    }

    [Fact]
    public void Have_ValidName_When_CallNameSetter_Then_PropertyChange()
    {
        #region Arrange
        var id = "cust-1";
        var name = "John Doe";
        var cpf = new Cpf("74334723047");
        var email = new Email("teste@test.com");
        var customer = new Customer(id, name, cpf, email);
        var newName = "Doe John";
        #endregion

        // Act

        var exception = Record.Exception(() => customer.Name = newName);

        // Assert
        Assert.Null(exception);
        Assert.Equal(newName, customer.Name);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Have_InvalidName_When_CallNameSetter_Then_ThrowCustomerException(string? newName)
    {
        #region Arrange
        var id = "cust-1";
        var name = "John Doe";
        var cpf = new Cpf("74334723047");
        var email = new Email("teste@test.com");
        var customer = new Customer(id, name, cpf, email);
        var expectedException = new CustomerException(nameof(customer.Name));
        #endregion

        // Act

        var exception = Record.Exception(() => customer.Name = newName);

        // Assert
        Assert.NotNull(exception);
        var customerException = Assert.IsType<InvalidEntityPropertyException<Customer>>(exception);
        Assert.Equal(expectedException.Message, customerException.Message);
    }
}
