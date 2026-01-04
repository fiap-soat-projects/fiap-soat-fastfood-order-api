using Business.Entities.Enums;
using Infrastructure.Entities;
using Infrastructure.Entities.Page;
using NSubstitute;

namespace Adapter.Tests.Gateways.Repositories.OrderGatewayTests.Methods;

public class GetAllPaginateAsyncTests : OrderGatewayTestsBase
{
    [Fact]
    public async Task Have_GetAllPaginateAsync_When_Found_Then_Returns_PaginatedDomain()
    {
        #region Arrange
        var page = 1;
        var size = 10;

        var orderMongoDb = new OrderMongoDb
        {
            Id = "order-1",
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
            Status = OrderStatus.Pending,
            Payment = null,
            TotalPrice = 10m
        };

        var pagedResult = new PagedResult<OrderMongoDb>
        {
            Page = page,
            Size = size,
            TotalCount = 1,
            TotalPages = 1,
            Items = [orderMongoDb]
        };

        _orderMongoDbRepository
            .GetAllPaginateAsync(
                page, 
                size,
                Arg.Any<CancellationToken>())
            .Returns(pagedResult);
        #endregion

        // Act
        var result = await _sut.GetAllPaginateAsync(page, size, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(pagedResult.Page, result.Page);
        Assert.Equal(pagedResult.Size, result.Size);
        Assert.Equal(pagedResult.TotalCount, result.TotalCount);
        Assert.Equal(pagedResult.TotalPages, result.TotalPages);
        Assert.Single(result.Items);

        var item = result.Items.First();
        Assert.Equal(orderMongoDb.Id, item.Id);
    }
}
