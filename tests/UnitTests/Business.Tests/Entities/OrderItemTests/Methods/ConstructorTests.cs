using Business.Entities;
using Business.Entities.Enums;

namespace Business.Tests.Entities.OrderItemTests.Methods;

public class ConstructorTests
{
    [Fact]
    public void Have_ValidParameters_When_CallConstructor_Then_ObjectCreated()
    {
        #region Arrange
        var id = "item-1";
        var name = "Item 1";
        var category = ItemCategory.MainCourse;
        var price = 10m;
        var amount = 2;
        #endregion

        // Act
        var orderItem = new OrderItem(id, name, category, price, amount);

        // Assert
        Assert.NotNull(orderItem);
        Assert.Equal(id, orderItem.Id);
        Assert.Equal(name, orderItem.Name);
        Assert.Equal(category, orderItem.Category);
        Assert.Equal(price, orderItem.Price);
        Assert.Equal(amount, orderItem.Amount);
    }
}
