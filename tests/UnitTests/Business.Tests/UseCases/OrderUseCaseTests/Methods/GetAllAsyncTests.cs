using System.Threading;
using System.Threading.Tasks;
using Business.Entities;
using Business.Entities.Enums;
using Business.Entities.Page;
using NSubstitute;
using Xunit;

namespace Business.Tests.UseCases.OrderUseCaseTests.Methods;

public class GetAllAsyncTests : OrderUseCaseTestsBase
{
    [Fact]
    public async Task Have_GetAllAsync_When_NoStatus_Then_Calls_GetAllPaginate()
    {
        #region Arrange
        var page = 1;
        var size = 10;
        var paged = new Pagination<Order> { Page = page, Size = size, TotalCount = 0, TotalPages = 0, Items = new List<Order>() };

        _orderRepository.GetAllPaginateAsync(page, size, Arg.Any<CancellationToken>()).Returns(paged);
        #endregion

        // Act
        var result = await _sut.GetAllAsync(CancellationToken.None, null, page, size);

        // Assert
        Assert.Equal(paged, result);
    }

    [Fact]
    public async Task Have_GetAllAsync_When_WithStatus_Then_Calls_GetAllByStatus()
    {
        #region Arrange
        var page = 1;
        var size = 10;
        var status = OrderStatus.Pending;
        var paged = new Pagination<Order> { Page = page, Size = size, TotalCount = 0, TotalPages = 0, Items = new List<Order>() };

        _orderRepository.GetAllByStatusAsync(status, page, size, Arg.Any<CancellationToken>()).Returns(paged);
        #endregion

        // Act
        var result = await _sut.GetAllAsync(CancellationToken.None, status, page, size);

        // Assert
        Assert.Equal(paged, result);
    }
}
