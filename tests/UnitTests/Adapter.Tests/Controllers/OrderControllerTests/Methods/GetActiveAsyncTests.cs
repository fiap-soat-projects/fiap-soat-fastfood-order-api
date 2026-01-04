using Adapter.Controllers.DTOs.Filters;
using Adapter.Presenters;
using Business.Entities;
using Business.Entities.Enums;
using Business.Entities.Page;
using NSubstitute;

namespace Adapter.Tests.Controllers.OrderControllerTests.Methods;

public class GetActiveAsyncTests : OrderControllerTestsBase
{
    [Fact]
    public async Task Have_GetActiveAsync_When_CallsUseCase_Then_Returns_Presenter()
    {
        #region Arrange
        var page = 1;
        var size = 10;

        var pagedDomain = new Pagination<Order>
        {
            Page = page,
            Size = size,
            TotalCount = 1,
            TotalPages = 1,
            Items = 
            [
                new Order
                (   
                    "order-1", 
                    "cust-1", 
                    "John", 
                    [
                        new OrderItem("item-1", "Item 1", ItemCategory.MainCourse, 10m, 1)
                    ],
                    OrderStatus.Pending,
                    new Payment(), 
                    10m
                )
            ]
        };

        _orderUseCase
            .GetActiveAsync(
                Arg.Any<CancellationToken>(),
                page,
                size)
            .Returns(pagedDomain);
        #endregion

        // Act
        var presenter = await _sut.GetActiveAsync(
            new OrderFilter(null, page, size),
            CancellationToken.None);

        // Assert
        Assert.NotNull(presenter);
        Assert.IsType<OrderPaginatedPresenter>(presenter);

        var vm = presenter.ViewModel;
        Assert.Equal(pagedDomain.Page, vm.Page);
        Assert.Equal(pagedDomain.Size, vm.Size);
        Assert.Equal(pagedDomain.TotalCount, vm.TotalCount);
        Assert.Equal(pagedDomain.TotalPages, vm.TotalPages);
        Assert.Single(vm.Items);

        var orderVm = vm.Items.First();
        Assert.Equal(pagedDomain.Items.First().Id, orderVm.Id);
    }
}
