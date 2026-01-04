using NSubstitute;

namespace Adapter.Tests.Gateways.Repositories.OrderGatewayTests.Methods;

public class DeleteAsyncTests : OrderGatewayTestsBase
{
    [Fact]
    public async Task Have_DeleteAsync_When_CallsRepository_Then_Completes()
    {
        #region Arrange
        var id = "order-1";
        #endregion

        // Act
        await _sut.DeleteAsync(id, CancellationToken.None);

        // Assert
        await _orderMongoDbRepository
            .Received(1)
            .DeleteAsync(
                id,
                Arg.Any<CancellationToken>());
    }
}
