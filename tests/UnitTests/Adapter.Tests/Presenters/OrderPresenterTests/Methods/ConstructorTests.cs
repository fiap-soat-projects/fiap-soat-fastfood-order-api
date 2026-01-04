using System.Linq;
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
        #region Arrange
        var items = new List<OrderItem>
        {
            new OrderItem("menu-1", "Burger", ItemCategory.MainCourse, 10m, 2)
        };

        var order = new Order("order-1", "cust-1", "John", items, OrderStatus.Pending, new Payment(), 20m);
        #endregion

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

        // Assert item mapping
        var item = vm.Items.First();
        Assert.Equal(items[0].Name, item.Name);
        Assert.Equal(items[0].Category.ToString(), item.Category);
        Assert.Equal(items[0].Price, item.Price);
        Assert.Equal(items[0].Amount, item.Amount);
    }

    [Fact]
    public void Have_ConstructorValuesNull_When_OrderProvided_Then_Maps_ViewModel()
    {
        #region Arrange
        var items = new List<OrderItem>
        {
            new("menu-1", "Burger", ItemCategory.MainCourse, 10m, 2)
        };

        var order = new Order("order-1", null, null, items, OrderStatus.Pending, new Payment(), 20m);
        #endregion

        // Act
        var presenter = new OrderPresenter(order);

        // Assert
        Assert.NotNull(presenter);
        Assert.IsType<OrderPresenter>(presenter);

        var vm = presenter.ViewModel;
        Assert.Equal(order.Id, vm.Id);
        Assert.Equal(string.Empty, vm.CustomerId);
        Assert.Equal(string.Empty, vm.CustomerName);
        Assert.Equal(order.Status.ToString(), vm.Status);
        Assert.Equal(order.TotalPrice, vm.TotalPrice);

        // Assert item mapping
        var item = vm.Items.First();
        Assert.Equal(items[0].Name, item.Name);
        Assert.Equal(items[0].Category.ToString(), item.Category);
        Assert.Equal(items[0].Price, item.Price);
        Assert.Equal(items[0].Amount, item.Amount);
    }
}
