using System.Threading;
using System.Threading.Tasks;
using Business.Entities;
using Business.Exceptions;
using NSubstitute;
using Xunit;

namespace Business.Tests.UseCases.OrderUseCaseTests.Methods;

public class GetByIdAsyncTests : OrderUseCaseTestsBase
{
    [Fact]
    public async Task Have_GetByIdAsync_When_NotFound_Then_Throws_OrderNotFoundException()
    {
        #region Arrange
        var id = "order-1";
        _orderRepository.GetByIdAsync(id, Arg.Any<CancellationToken>()).Returns((Order?)null);
        #endregion

        // Act
        var exception = await Record.ExceptionAsync(() => _sut.GetByIdAsync(id, CancellationToken.None));

        // Assert
        Assert.NotNull(exception);
        Assert.IsType<EntityNotFoundException<Order>>(exception);
    }

    [Fact]
    public async Task Have_GetByIdAsync_When_Found_Then_Returns_Order()
    {
        #region Arrange
        var id = "order-1";
        var order = new Order(id, "cust-1", "John", new List<OrderItem> { new OrderItem("item-1", "Item 1", Business.Entities.Enums.ItemCategory.MainCourse, 10m, 1) }, Business.Entities.Enums.OrderStatus.Pending, new Payment(), 10m);
        _orderRepository.GetByIdAsync(id, Arg.Any<CancellationToken>()).Returns(order);
        #endregion

        // Act
        var result = await _sut.GetByIdAsync(id, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
    }
}
