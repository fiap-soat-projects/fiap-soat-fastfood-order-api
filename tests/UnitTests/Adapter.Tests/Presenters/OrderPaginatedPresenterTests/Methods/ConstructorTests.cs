using Adapter.Presenters;
using Adapter.Presenters.DTOs;
using Business.Entities;
using Business.Entities.Enums;
using Business.Entities.Page;

namespace Adapter.Tests.Presenters.OrderPaginatedPresenterTests.Methods;

public class ConstructorTests
{
    [Fact]
    public void Have_Constructor_When_PaginationProvided_Then_Maps_ViewModel()
    {
        // Arrange
        var orderItems = new List<OrderItem>
        {
            new OrderItem("menu-1", "Burger", ItemCategory.MainCourse, 10m, 2)
        };

        var page = new Pagination<Order>
        {
            Page = 1,
            Size = 10,
            TotalCount = 1,
            TotalPages = 1,
            Items = new List<Order>
            {
                new Order("order-1", "cust-1", "John", orderItems, OrderStatus.Pending, new Payment { Method = PaymentMethod.None }, 20m)
            }
        };

        // Act
        var presenter = new OrderPaginatedPresenter(page);

        // Assert
        Assert.NotNull(presenter);
        Assert.IsType<OrderPaginatedPresenter>(presenter);

        var vm = presenter.ViewModel;
        Assert.Equal(page.Page, vm.Page);
        Assert.Equal(page.Size, vm.Size);
        Assert.Equal(page.TotalCount, vm.TotalCount);
        Assert.Equal(page.TotalPages, vm.TotalPages);
        Assert.Equal(page.Items.Count(), vm.Items.Count());
    }
}
