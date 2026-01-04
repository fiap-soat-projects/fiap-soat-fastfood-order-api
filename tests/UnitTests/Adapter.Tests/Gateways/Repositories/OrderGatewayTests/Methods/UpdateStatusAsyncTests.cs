using System.Threading;
using System.Threading.Tasks;
using Business.Entities.Enums;
using Infrastructure.Entities;
using NSubstitute;
using Xunit;

namespace Adapter.Tests.Gateways.Repositories.OrderGatewayTests.Methods;

public class UpdateStatusAsyncTests : OrderGatewayTestsBase
{
    [Fact]
    public async Task Have_UpdateStatusAsync_When_Success_Then_Returns_DomainOrder()
    {
        #region Arrange
        var id = "order-1";
        var status = OrderStatus.InProgress;

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
                    Category = ItemCategory.MainCourse 
                } 
            ],
            Status = status,
            Payment = null,
            TotalPrice = 10m
        };

        _orderMongoDbRepository
            .UpdateStatusAsync(
                id, 
                status, 
                Arg.Any<CancellationToken>())
            .Returns(orderMongoDb);
        #endregion

        // Act
        var result = await _sut.UpdateStatusAsync(id, status, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(orderMongoDb.Id, result.Id);
        Assert.Equal(orderMongoDb.Status, result.Status);
    }
}
