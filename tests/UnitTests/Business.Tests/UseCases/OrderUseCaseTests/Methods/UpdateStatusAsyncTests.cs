using System.Threading;
using System.Threading.Tasks;
using Business.Entities;
using Business.Entities.Enums;
using NSubstitute;
using Xunit;

namespace Business.Tests.UseCases.OrderUseCaseTests.Methods;

public class UpdateStatusAsyncTests : OrderUseCaseTestsBase
{
    [Fact]
    public async Task Have_UpdateStatusAsync_When_CallsRepository_Then_Returns_Order()
    {
        #region Arrange
        var id = "order-1";
        var status = OrderStatus.InProgress;
        var returned = new Order(
            id,
            "cust-1",
            "John",
            new List<OrderItem>
            {
                new OrderItem("item-1", "Item 1", ItemCategory.MainCourse, 10m, 1)
            },
            status,
            new Payment(),
            10m);

        _orderRepository.UpdateStatusAsync(id, status, Arg.Any<CancellationToken>()).Returns(returned);
        #endregion

        // Act
        var result = await _sut.UpdateStatusAsync(id, status, CancellationToken.None);

        // Assert
        Assert.Equal(returned, result);
    }
}
