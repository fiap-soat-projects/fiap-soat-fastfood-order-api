using Business.Entities;

namespace Business.Tests.Entities.ItemQuantityTests.Methods;

public class ConstructorTests
{
    [Fact]
    public void Have_ValidParameters_When_CallConstructor_Then_ObjectCreated()
    {
        #region Arrange
        var itemId = "item-1";
        var quantity = 2;
        #endregion

        // Act
        var itemQuantity = new ItemQuantity { ItemId = itemId, Quantity = quantity };

        // Assert
        Assert.NotNull(itemQuantity);
        Assert.Equal(itemId, itemQuantity.ItemId);
        Assert.Equal(quantity, itemQuantity.Quantity);
    }
}
