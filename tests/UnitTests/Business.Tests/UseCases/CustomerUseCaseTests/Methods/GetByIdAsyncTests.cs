using System.Threading;
using System.Threading.Tasks;
using Business.Entities;
using Business.Exceptions;
using NSubstitute;
using Xunit;

namespace Business.Tests.UseCases.CustomerUseCaseTests.Methods;

public class GetByIdAsyncTests : CustomerUseCaseTestsBase
{
    [Fact]
    public async Task Have_GetByIdAsync_When_Found_Then_Returns_Customer()
    {
        #region Arrange
        var id = "cust-1";
        var customer = new Customer(id, "John", new Domain.ValueObjects.Cpf("74334723047"), new Domain.ValueObjects.Email("teste@test.com"));

        _customerClient.GetByIdAsync(id, Arg.Any<CancellationToken>()).Returns(customer);
        #endregion

        // Act
        var result = await _sut.GetByIdAsync(id, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
    }

    [Fact]
    public async Task Have_GetByIdAsync_When_NotFound_Then_Throws_CustomerNotFoundException()
    {
        #region Arrange
        var id = "cust-1";

        _customerClient.GetByIdAsync(id, Arg.Any<CancellationToken>()).Returns((Customer?)null);
        var expectedException = new CustomerNotFoundException(id);
        #endregion

        // Act
        var exception = await Record.ExceptionAsync(() => _sut.GetByIdAsync(id, CancellationToken.None));

        // Assert
        Assert.NotNull(exception);
        var customerNotFoundException = Assert.IsType<EntityNotFoundException<Customer>>(exception);
        Assert.Equal(expectedException.Message, customerNotFoundException.Message);
    }
}
