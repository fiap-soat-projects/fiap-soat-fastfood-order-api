using System.Threading;
using System.Threading.Tasks;
using Business.Entities;
using Business.Entities.Page;
using NSubstitute;
using Xunit;

namespace Business.Tests.UseCases.OrderUseCaseTests.Methods;

public class GetActiveAsyncTests : OrderUseCaseTestsBase
{
    [Fact]
    public async Task Have_GetActiveAsync_When_CallsRepository_Then_Returns_Page()
    {
        #region Arrange
        var page = 1;
        var size = 10;
        var paged = new Pagination<Order> { Page = page, Size = size, TotalCount = 0, TotalPages = 0, Items = new List<Order>() };

        _orderRepository.GetActivePaginateAsync(page, size, Arg.Any<CancellationToken>()).Returns(paged);
        #endregion

        // Act
        var result = await _sut.GetActiveAsync(CancellationToken.None, page, size);

        // Assert
        Assert.Equal(paged, result);
    }
}
