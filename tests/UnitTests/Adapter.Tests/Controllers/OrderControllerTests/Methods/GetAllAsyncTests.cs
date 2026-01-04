using Adapter.Controllers.DTOs.Filters;
using Adapter.Presenters;
using Business.Entities;
using Business.UseCases.DTOs;
using Business.Entities.Enums;
using Business.Entities.Page;
using NSubstitute;

namespace Adapter.Tests.Controllers.OrderControllerTests.Methods;

public class GetAllAsyncTests : OrderControllerTestsBase
{
    [Fact]
    public async Task Have_GetAllAsync_When_FilterProvided_Then_Returns_OrderPaginatedPresenter()
    {
        #region Arrange
        var filter = new OrderFilter("Pending", 1, 10);

        var page = new Pagination<Order>
        {
            Page = 1,
            Size = 10,
            TotalCount = 1,
            TotalPages = 1,
            Items = new List<Order>()
        };

        _orderUseCase
            .GetAllAsync(Arg.Any<CancellationToken>(), Arg.Any<OrderStatus>(), Arg.Any<int>(), Arg.Any<int>())
            .Returns(page);
        #endregion

        // Act
        var presenter = await _sut.GetAllAsync(filter, CancellationToken.None);

        // Assert
        Assert.NotNull(presenter);
        Assert.IsType<OrderPaginatedPresenter>(presenter);
    }
}
