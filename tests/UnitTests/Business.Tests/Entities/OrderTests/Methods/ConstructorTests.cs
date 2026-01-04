using Business.Entities;
using Business.Entities.Enums;

namespace Business.Tests.Entities.OrderTests.Methods;

public class ConstructorTests
{
    [Fact]
    public void Have_ValidParameters_When_CallConstructor_Then_ObjectCreated()
    {
        #region Arrange
        var items = new List<OrderItem>
        {
            new OrderItem("item-1", "Item 1", ItemCategory.MainCourse, 10m, 2)
        };
        #endregion

        // Act
        var order = new Order("order-1", "cust-1", "John", items, OrderStatus.Pending, new Payment { Method = PaymentMethod.None }, 20m);

        // Assert
        Assert.NotNull(order);
        Assert.Equal("order-1", order.Id);
        Assert.Equal("cust-1", order.CustomerId);
        Assert.Equal("John", order.CustomerName);
        Assert.Equal(20m, order.TotalPrice);
        Assert.Equal(OrderStatus.Pending, order.Status);
        Assert.Equal(items, order.Items);
    }
}
