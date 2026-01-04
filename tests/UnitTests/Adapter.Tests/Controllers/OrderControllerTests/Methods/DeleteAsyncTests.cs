using NSubstitute;

namespace Adapter.Tests.Controllers.OrderControllerTests.Methods;

public class DeleteAsyncTests : OrderControllerTestsBase
{
    [Fact]
    public async Task Have_DeleteAsync_When_IdProvided_Then_Invokes_UseCase()
    {
        #region Arrange
        var id = "order-to-delete";
        #endregion

        // Act
        await _sut.DeleteAsync(id, CancellationToken.None);

        // Assert
        await _orderUseCase.Received(1).DeleteAsync(id, Arg.Any<CancellationToken>());
    }
}
