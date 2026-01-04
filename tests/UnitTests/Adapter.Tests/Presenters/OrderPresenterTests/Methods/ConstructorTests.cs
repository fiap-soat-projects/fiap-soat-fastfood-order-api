using Adapter.Presenters;
using Adapter.Presenters.DTOs;
using Business.Entities;
using Business.Entities.Enums;

namespace Adapter.Tests.Presenters.OrderPresenterTests.Methods;

public class ConstructorTests
{
    [Fact]
    public void Have_Constructor_When_OrderProvided_Then_Maps_ViewModel()
    {
        // Arrange
        var items = new List<OrderItem>
        {
            new OrderItem("menu-1", "Burger", ItemCategory.MainCourse, 10m, 2)
        };

        var order = new Order("order-1", "cust-1", "John", items, OrderStatus.Pending, new Payment(), 20m);

        // Act
        var presenter = new OrderPresenter(order);

        // Assert
        Assert.NotNull(presenter);
        Assert.IsType<OrderPresenter>(presenter);

        var vm = presenter.ViewModel;
        Assert.Equal(order.Id, vm.Id);
        Assert.Equal(order.CustomerId, vm.CustomerId);
        Assert.Equal(order.CustomerName, vm.CustomerName);
        Assert.Equal(order.Status.ToString(), vm.Status);
        Assert.Equal(order.TotalPrice, vm.TotalPrice);
    }
}
