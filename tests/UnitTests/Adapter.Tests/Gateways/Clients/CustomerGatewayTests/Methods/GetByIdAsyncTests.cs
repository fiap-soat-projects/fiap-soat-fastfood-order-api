using System.Threading;
using System.Threading.Tasks;
using Adapter.Tests.Gateways.Clients.CustomerGatewayTests;
using Infrastructure.Entities;
using NSubstitute;
using Xunit;

namespace Adapter.Tests.Gateways.Clients.CustomerGatewayTests.Methods;

public class GetByIdAsyncTests : CustomerGatewayTestsBase
{
    [Fact]
    public async Task Have_GetByIdAsync_When_HttpClientReturnsNull_Then_ReturnsNull()
    {
        #region Arrange
        var id = "cust-1";
        _httpCustomerClient.GetByIdAsync(id, Arg.Any<CancellationToken>()).Returns((CustomerHttp?)null);
        #endregion

        // Act
        var result = await _sut.GetByIdAsync(id, CancellationToken.None);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Have_GetByIdAsync_When_HttpClientReturnsCustomer_Then_ReturnsDomainCustomer()
    {
        #region Arrange
        var id = "cust-2";
        var customerHttp = new CustomerHttp { Id = id, Name = "John", Cpf = "12345678901", Email = "john@test.com" };
        _httpCustomerClient.GetByIdAsync(id, Arg.Any<CancellationToken>()).Returns(customerHttp);
        #endregion

        // Act
        var result = await _sut.GetByIdAsync(id, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal(customerHttp.Name, result.Name);
        Assert.Equal(customerHttp.Cpf, result.Cpf);
        Assert.Equal(customerHttp.Email, result.Email);
    }
}
