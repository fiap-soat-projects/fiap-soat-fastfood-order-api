using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace Business.Tests.UseCases.OrderUseCaseTests.Methods;

public class DeleteAsyncTests : OrderUseCaseTestsBase
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
        await _orderRepository.Received(1).DeleteAsync(id, Arg.Any<CancellationToken>());
    }
}
