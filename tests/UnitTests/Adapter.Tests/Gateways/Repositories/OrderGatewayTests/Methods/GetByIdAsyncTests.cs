using Business.Entities.Enums;
using Infrastructure.Entities;
using NSubstitute;

namespace Adapter.Tests.Gateways.Repositories.OrderGatewayTests.Methods;

public class GetByIdAsyncTests : OrderGatewayTestsBase
{
    [Fact]
    public async Task Have_GetByIdAsync_When_NotFound_Then_ReturnsNull()
    {
        #region Arrange
        var id = "order-1";

        _orderMongoDbRepository
            .GetByIdAsync(
                id, 
                Arg.Any<CancellationToken>())
            .Returns(default(OrderMongoDb));
        #endregion

        // Act
        var result = await _sut.GetByIdAsync(id, CancellationToken.None);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Have_GetByIdAsync_When_Found_Then_Returns_DomainOrder()
    {
        #region Arrange
        var id = "order-1";

        var orderMongoDb = new OrderMongoDb
        {
            Id = id,
            CustomerId = "cust-1",
            CustomerName = "John",
            Items =
            [ 
                new OrderItemMongoDb
                { 
                    Id = "item-1", 
                    Name = "Item 1", 
                    Price = 10m, 
                    Amount = 1, 
                    Category = ItemCategory.MainCourse }
            ],
            Status = OrderStatus.Pending,
            Payment = null,
            TotalPrice = 10m
        };

        _orderMongoDbRepository
            .GetByIdAsync(
                id, 
                Arg.Any<CancellationToken>())
            .Returns(orderMongoDb);
        #endregion

        // Act
        var result = await _sut.GetByIdAsync(id, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(orderMongoDb.Id, result!.Id);
        Assert.Equal(orderMongoDb.CustomerId, result.CustomerId);
        Assert.Equal(orderMongoDb.TotalPrice, result.TotalPrice);
    }
}
