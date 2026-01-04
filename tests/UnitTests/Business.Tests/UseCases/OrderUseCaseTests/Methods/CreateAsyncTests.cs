using System.Threading;
using System.Threading.Tasks;
using Business.Entities;
using NSubstitute;
using Xunit;

namespace Business.Tests.UseCases.OrderUseCaseTests.Methods;

public class CreateAsyncTests : OrderUseCaseTestsBase
{
    [Fact]
    public async Task Have_CreateAsync_When_CallsRepository_Then_Returns_Id()
    {
        #region Arrange
        var order = new Order("cust-1", "John", new List<OrderItem> { new OrderItem("item-1", "Item 1", Business.Entities.Enums.ItemCategory.MainCourse, 10m, 1) });

        _orderRepository.CreateAsync(Arg.Any<Order>(), Arg.Any<CancellationToken>()).Returns("order-1");
        #endregion

        // Act
        var id = await _sut.CreateAsync(order, CancellationToken.None);

        // Assert
        Assert.Equal("order-1", id);
    }
}
