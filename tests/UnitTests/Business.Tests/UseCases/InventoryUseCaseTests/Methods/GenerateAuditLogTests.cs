using Business.Entities;
using Business.Entities.Enums;
using Business.Exceptions;
using NSubstitute;

namespace Business.Tests.UseCases.InventoryUseCaseTests.Methods;

public class GenerateAuditLogTests : InventoryUseCaseTestsBase
{
    [Fact]
    public void Have_GenerateAuditLog_When_OrderNotFinished_Then_ThrowsInvalidInventoryOrderException()
    {
        #region Arrange
        var items = new List<OrderItem> { new OrderItem("item-1", "Item 1", ItemCategory.MainCourse, 10m, 1) };
        var order = new Order("order-1", "cust-1", "John", items, OrderStatus.InProgress, new Payment { Method = PaymentMethod.None }, 10m);
        var date = DateTime.UtcNow;
        #endregion

        // Act
        var exception = Record.Exception(() => _sut.GenerateAuditLog(order, date));

        // Assert
        Assert.NotNull(exception);
        Assert.IsType<InvalidInventoryOrderException>(exception);
    }

    [Fact]
    public void Have_GenerateAuditLog_When_OrderFinished_Then_CallsLoggerWithAuditLines()
    {
        #region Arrange
        var items = new List<OrderItem>
        {
            new OrderItem("item-1", "Item 1", ItemCategory.MainCourse, 10m, 2),
            new OrderItem("item-1", "Item 1", ItemCategory.MainCourse, 10m, 1),
            new OrderItem("item-2", "Item 2", ItemCategory.MainCourse, 5m, 1)
        };

        var order = new Order("order-1", "cust-1", "John", items, OrderStatus.Finished, new Payment { Method = PaymentMethod.None }, 25m);
        var date = new DateTime(2020, 1, 1, 12, 0, 0);

        var expectedLine1 = $"The order {order.Id} was finished in {date.ToString("yyyy-MM-dd HH:mm:ss")} with: Item: item-1 - Quantity: 3";
        var expectedLine2 = $"The order {order.Id} was finished in {date.ToString("yyyy-MM-dd HH:mm:ss")} with: Item: item-2 - Quantity: 1";
        #endregion

        // Act
        _sut.GenerateAuditLog(order, date);

        // Assert
        var expected = string.Join(Environment.NewLine, new[] { expectedLine1, expectedLine2, string.Empty });
        _inventoryLogger.Received(1).SendAuditLog(expected);
    }
}
