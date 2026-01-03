using Adapter.Controllers.DTOs;
using Adapter.Presenters;
using Business.Entities;
using Business.Entities.Enums;
using NSubstitute;

namespace Adapter.Tests.Controllers.OrderControllerTests.Methods;

public class UpdateStatusAsyncTests : OrderControllerTestsBase
{
    [Fact]
    public async Task Have_UpdateStatusAsync_When_ValidStatus_Then_Returns_OrderPresenter_And_GenerateInventoryLog_When_Finished()
    {
        #region Arrange
        var id = "order-1";
        var request = new UpdateStatusRequest(Status: "Finished");
        var orderitems = new List<OrderItem>()
        {
            new("item-1", "Item 1", ItemCategory.MainCourse, 10.0m, 2),
        };

        var order = new Order(id, "cust-1", "John", orderitems, OrderStatus.Finished, new Payment(), 20m);

        _orderUseCase
            .UpdateStatusAsync(id, OrderStatus.Finished, Arg.Any<CancellationToken>())
            .Returns(order);
        #endregion

        // Act
        var presenter = await _sut.UpdateStatusAsync(id, request, CancellationToken.None);

        // Assert
        Assert.NotNull(presenter);
        Assert.IsType<OrderPresenter>(presenter);

        _inventoryUseCase.Received(1).GenerateAuditLog(order, Arg.Any<DateTime>());
    }
}
