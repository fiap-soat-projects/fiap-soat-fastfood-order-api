using Business.Entities;
using Business.Entities.Enums;
using Infrastructure.Entities;
using NSubstitute;

namespace Adapter.Tests.Gateways.Repositories.OrderGatewayTests.Methods;

public class CreateAsyncTests : OrderGatewayTestsBase
{
    [Fact]
    public async Task Have_CreateAsync_When_CallsRepository_Then_Returns_Id()
    {
        #region Arrange
        var order = new Order
        (
            "cust-1", 
            "John", 
            [
                new OrderItem
                (
                    "item-1", 
                    "1", 
                    ItemCategory.MainCourse, 
                    10m, 
                    1
                )
            ]
        );

        _orderMongoDbRepository
            .InsertOneAsync(
                Arg.Any<OrderMongoDb>(),
                Arg.Any<CancellationToken>())
            .Returns("order-1");
        #endregion

        // Act
        var id = await _sut.CreateAsync(order, CancellationToken.None);

        // Assert
        Assert.Equal("order-1", id);
    }
}
