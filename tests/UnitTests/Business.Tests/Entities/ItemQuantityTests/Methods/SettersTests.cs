using Business.Entities;
using Business.Entities.Exceptions;
using Business.Exceptions;

namespace Business.Tests.Entities.ItemQuantityTests.Methods;

public class SettersTests
{
    [Fact]
    public void Have_ValidInitialization_When_CreateWithValidValues_Then_PropertiesSet()
    {
        #region Arrange
        var id = "item-1";
        var quantity = 1;
        #endregion

        // Act
        var itemQuantity = new ItemQuantity { ItemId = id, Quantity = quantity };

        // Assert
        Assert.Equal(id, itemQuantity.ItemId);
        Assert.Equal(quantity, itemQuantity.Quantity);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Have_InvalidQuantity_When_CreateWithInvalidQuantity_Then_ThrowItemQuantityException(int newQuantity)
    {
        #region Arrange
        var expectedMessage = string.Format("The property {0} of {1} is invalid", nameof(ItemQuantity.Quantity), nameof(ItemQuantity));
        #endregion

        // Act
        var exception = Record.Exception(() => new ItemQuantity { ItemId = "item-1", Quantity = newQuantity });

        // Assert
        Assert.NotNull(exception);
        var itemQuantityException = Assert.IsType<InvalidEntityPropertyException<ItemQuantity>>(exception);
        Assert.Equal(expectedMessage, itemQuantityException.Message);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Have_InvalidItemId_When_CreateWithInvalidItemId_Then_ThrowItemQuantityException(string? newItemId)
    {
        #region Arrange
        var expectedMessage = string.Format("The property {0} of {1} is invalid", nameof(ItemQuantity.ItemId), nameof(ItemQuantity));
        #endregion

        // Act
        var exception = Record.Exception(() => new ItemQuantity { ItemId = newItemId!, Quantity = 1 });

        // Assert
        Assert.NotNull(exception);
        var itemQuantityException = Assert.IsType<InvalidEntityPropertyException<ItemQuantity>>(exception);
        Assert.Equal(expectedMessage, itemQuantityException.Message);
    }

    [Fact]
    public void Have_ToString_When_Called_Then_ReturnsFormattedString()
    {
        #region Arrange
        var itemQuantity = new ItemQuantity { ItemId = "item-1", Quantity = 3 };
        #endregion

        // Act
        var str = itemQuantity.ToString();

        // Assert
        Assert.Equal("Item: item-1 - Quantity: 3", str);
    }
}
