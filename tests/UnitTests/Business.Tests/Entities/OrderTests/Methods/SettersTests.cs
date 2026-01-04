using Business.Entities;
using Business.Entities.Enums;
using Business.Entities.Exceptions;
using Business.Exceptions;

namespace Business.Tests.Entities.OrderTests.Methods;

public class SettersTests
{
    [Fact]
    public void Have_ValidId_When_CallIdSetter_Then_PropertyChange()
    {
        #region Arrange
        var items = new List<OrderItem> { new OrderItem("item-1", "Item 1", ItemCategory.MainCourse, 10m, 1) };
        var order = new Order("order-1", "cust-1", "John", items, OrderStatus.Pending, new Payment { Method = PaymentMethod.None }, 10m);
        var newId = "order-2";
        #endregion

        // Act
        var exception = Record.Exception(() => order.Id = newId);

        // Assert
        Assert.Null(exception);
        Assert.Equal(newId, order.Id);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Have_InvalidTotalPrice_When_CallTotalPriceSetter_Then_ThrowOrderException(decimal newTotal)
    {
        #region Arrange
        var items = new List<OrderItem> { new OrderItem("item-1", "Item 1", ItemCategory.MainCourse, 10m, 1) };
        var order = new Order("order-1", "cust-1", "John", items, OrderStatus.Pending, new Payment { Method = PaymentMethod.None }, 10m);
        var expectedException = new OrderException(nameof(order.TotalPrice));
        #endregion

        // Act
        var exception = Record.Exception(() => order.TotalPrice = newTotal);

        // Assert
        Assert.NotNull(exception);
        var orderException = Assert.IsType<InvalidEntityPropertyException<Order>>(exception);
        Assert.Equal(expectedException.Message, orderException.Message);
    }

    [Fact]
    public void Have_ValidStatus_When_SetValidStatus_Then_PropertyChanged()
    {
        #region Arrange
        var items = new List<OrderItem> { new OrderItem("item-1", "Item 1", ItemCategory.MainCourse, 10m, 1) };
        var order = new Order("order-1", "cust-1", "John", items, OrderStatus.Pending, new Payment { Method = PaymentMethod.None }, 10m);
        #endregion

        // Act
        var exception = Record.Exception(() => order.Status = OrderStatus.InProgress);

        // Assert
        Assert.Null(exception);
        Assert.Equal(OrderStatus.InProgress, order.Status);
    }

    [Theory]
    [InlineData(OrderStatus.None)]
    [InlineData((OrderStatus)999)]
    public void Have_InvalidStatus_When_SetInvalidStatus_Then_ThrowOrderItemException(OrderStatus invalidOrderStatus)
    {
        #region Arrange
        var items = new List<OrderItem> { new OrderItem("item-1", "Item 1", ItemCategory.MainCourse, 10m, 1) };
        var order = new Order("order-1", "cust-1", "John", items, OrderStatus.Received, new Payment (), 10m);
        var expectedException = new OrderException(nameof(order.Status));
        #endregion

        // Act
        var exception = Record.Exception(() => order.Status = invalidOrderStatus);

        // Assert
        Assert.NotNull(exception);
        var orderItemException = Assert.IsType<OrderException>(exception);
        Assert.Equal(expectedException.Message, orderItemException.Message);
    }
}
