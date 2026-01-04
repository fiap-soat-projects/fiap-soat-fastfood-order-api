using Adapter.Controllers.DTOs;
using Business.Entities;
using Business.Entities.Enums;
using Domain.ValueObjects;
using NSubstitute;

namespace Adapter.Tests.Controllers.OrderControllerTests.Methods;

public class CreateAsyncTests : OrderControllerTestsBase
{
    [Fact]
    public async Task Have_CreateAsync_When_ValidRequest_Then_Returns_OrderId()
    {
        #region Arrange
        var request = new CreateRequest(
            CustomerId: "cust-1",
            Items: new[] { new OrderItemRequest("menu-1", 2) });

        var menuItem = new MenuItem("Burger", 10m, "Tasty", ItemCategory.MainCourse);
        menuItem.Id = "menu-1";

        _menuItemUseCase
            .GetByIdAsync(menuItem.Id, Arg.Any<CancellationToken>())
            .Returns(menuItem);

        var customer = new Customer("cust-1", "John", new Cpf("11144477735"), new Email("john@example.com"));

        _customerUseCase
            .GetByIdAsync(customer.Id!, Arg.Any<CancellationToken>())
            .Returns(customer);

        _orderUseCase
            .CreateAsync(Arg.Any<Order>(), Arg.Any<CancellationToken>())
            .Returns("order-123");
        #endregion

        // Act
        var orderId = await _sut.CreateAsync(request, CancellationToken.None);

        // Assert
        Assert.Equal("order-123", orderId);
    }
}
