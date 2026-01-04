using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Entities;
using NSubstitute;
using Xunit;

namespace Adapter.Tests.Gateways.Repositories.OrderGatewayTests.Methods;

public class GetByIdAsyncTests : OrderGatewayTestsBase
{
    [Fact]
    public async Task Have_GetByIdAsync_When_NotFound_Then_ReturnsNull()
    {
        #region Arrange
        var id = "order-1";
        _orderMongoDbRepository.GetByIdAsync(id, Arg.Any<CancellationToken>()).Returns((OrderMongoDb?)null);
        #endregion

        // Act
        var result = await _sut.GetByIdAsync(id, CancellationToken.None);

        // Assert
        Assert.Null(result);
    }
}
