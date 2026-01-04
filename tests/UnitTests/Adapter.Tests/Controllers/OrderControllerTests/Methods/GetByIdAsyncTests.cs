using Adapter.Presenters;
using Business.Entities;
using Business.Entities.Enums;
using Business.UseCases.Exceptions;
using Business.Exceptions;
using NSubstitute;

namespace Adapter.Tests.Controllers.OrderControllerTests.Methods;

public class GetByIdAsyncTests : OrderControllerTestsBase
{
    [Fact]
    public async Task Have_GetByIdAsync_When_ExistingId_Then_Returns_OrderPresenter()
    {
        #region Arrange
        var id = "order-42";
        var orderItems = new List<OrderItem>
        {
            new OrderItem("menu-1", "Burger", ItemCategory.MainCourse, 10m, 2)
        };

        var order = new Order(id, "cust-1", "John", orderItems, OrderStatus.Pending, new Payment(), 20m);

        _orderUseCase
            .GetByIdAsync(id, Arg.Any<CancellationToken>())
            .Returns(order);
        #endregion

        // Act
        var presenter = await _sut.GetByIdAsync(id, CancellationToken.None);

        // Assert
        Assert.NotNull(presenter);
        Assert.IsType<OrderPresenter>(presenter);

        Assert.Equal(order.Id, presenter.ViewModel.Id);
        Assert.Equal(order.CustomerId, presenter.ViewModel.CustomerId);
        Assert.Equal(order.CustomerName, presenter.ViewModel.CustomerName);
        Assert.Equal(order.Status.ToString(), presenter.ViewModel.Status);
        Assert.Equal(order.TotalPrice, presenter.ViewModel.TotalPrice);
    }
}
