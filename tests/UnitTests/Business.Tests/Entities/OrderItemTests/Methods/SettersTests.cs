using Business.Entities;
using Business.Entities.Enums;
using Business.Entities.Exceptions;
using Business.Exceptions;

namespace Business.Tests.Entities.OrderItemTests.Methods;

public class SettersTests
{
    [Fact]
    public void Have_ValidInitialization_When_CreateWithValidValues_Then_PropertiesSet()
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
        Assert.Equal(id, orderItem.Id);
        Assert.Equal(name, orderItem.Name);
        Assert.Equal(category, orderItem.Category);
        Assert.Equal(price, orderItem.Price);
        Assert.Equal(amount, orderItem.Amount);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Have_InvalidPrice_When_CreateWithInvalidPrice_Then_ThrowOrderItemException(decimal invalidPrice)
    {
        #region Arrange
        var expectedException = new OrderItemException(nameof(OrderItem.Price));
        #endregion

        // Act
        var exception = Record.Exception(() => new OrderItem("item-1", "Item 1", ItemCategory.MainCourse, invalidPrice, 1));

        // Assert
        Assert.NotNull(exception);
        var orderItemException = Assert.IsType<InvalidEntityPropertyException<OrderItem>>(exception);
        Assert.Equal(expectedException.Message, orderItemException.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Have_InvalidAmount_When_CreateWithInvalidAmount_Then_ThrowOrderItemException(int invalidAmount)
    {
        #region Arrange
        var expectedException = new OrderItemException(nameof(OrderItem.Amount));
        #endregion

        // Act
        var exception = Record.Exception(() => new OrderItem("item-1", "Item 1", ItemCategory.MainCourse, 10m, invalidAmount));

        // Assert
        Assert.NotNull(exception);
        var orderItemException = Assert.IsType<InvalidEntityPropertyException<OrderItem>>(exception);
        Assert.Equal(expectedException.Message, orderItemException.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Have_InvalidId_When_CreateWithInvalidId_Then_ThrowOrderItemException(string? invalidId)
    {
        #region Arrange
        var expectedException = new OrderItemException(nameof(OrderItem.Id));
        #endregion

        // Act
        var exception = Record.Exception(() => new OrderItem(invalidId!, "Item 1", ItemCategory.MainCourse, 10m, 1));

        // Assert
        Assert.NotNull(exception);
        var orderItemException = Assert.IsType<InvalidEntityPropertyException<OrderItem>>(exception);
        Assert.Equal(expectedException.Message, orderItemException.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Have_InvalidName_When_CreateWithInvalidName_Then_ThrowOrderItemException(string? invalidName)
    {
        #region Arrange
        var expectedException = new OrderItemException(nameof(OrderItem.Name));
        #endregion

        // Act
        var exception = Record.Exception(() => new OrderItem("item-1", invalidName!, ItemCategory.MainCourse, 10m, 1));

        // Assert
        Assert.NotNull(exception);
        var orderItemException = Assert.IsType<InvalidEntityPropertyException<OrderItem>>(exception);
        Assert.Equal(expectedException.Message, orderItemException.Message);
    }

    [Theory]
    [InlineData((ItemCategory)0)]
    [InlineData((ItemCategory)999)]
    public void Have_InvalidCategory_When_CreateWithInvalidCategory_Then_ThrowOrderItemException(ItemCategory invalidCategory)
    {
        #region Arrange
        var expectedException = new OrderItemException(nameof(OrderItem.Category));
        #endregion

        // Act
        var exception = Record.Exception(() => new OrderItem("item-1", "Item 1", invalidCategory, 10m, 1));

        // Assert
        Assert.NotNull(exception);
        var orderItemException = Assert.IsType<OrderItemException>(exception);
        Assert.Equal(expectedException.Message, orderItemException.Message);
    }

    [Fact]
    public void Have_GetTotalPrice_When_Called_Then_ReturnsMultiplication()
    {
        #region Arrange
        var orderItem = new OrderItem("item-1", "Item 1", ItemCategory.MainCourse, 10m, 2);
        #endregion

        // Act
        var total = orderItem.GetTotalPrice();

        // Assert
        Assert.Equal(20m, total);
    }
}
