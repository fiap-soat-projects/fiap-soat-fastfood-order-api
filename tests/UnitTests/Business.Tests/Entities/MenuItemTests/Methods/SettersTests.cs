using Business.Entities;
using Business.Entities.Exceptions;
using Business.Exceptions;
using Business.Entities.Enums;

namespace Business.Tests.Entities.MenuItemTests.Methods;

public class SettersTests
{
    [Fact]
    public void Have_ValidInitialization_When_CreateWithValidValues_Then_PropertiesSet()
    {
        #region Arrange
        var name = "Burger";
        var price = 10m;
        var desc = "Tasty";
        #endregion

        // Act
        var menuItem = new MenuItem(name, price, desc, ItemCategory.MainCourse);

        // Assert
        Assert.Equal(name, menuItem.Name);
        Assert.Equal(price, menuItem.Price);
        Assert.Equal(desc, menuItem.Description);
        Assert.Equal(ItemCategory.MainCourse, menuItem.Category);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Have_InvalidName_When_CreateWithInvalidName_Then_ThrowInvalidEntityPropertyException(string? invalidName)
    {
        #region Arrange
        var expectedException = new MenuItemException(nameof(MenuItem.Name));
        #endregion

        // Act
        var exception = Record.Exception(() => new MenuItem(invalidName!, 10m, "desc", ItemCategory.MainCourse));

        // Assert
        Assert.NotNull(exception);
        var menuItemException = Assert.IsType<InvalidEntityPropertyException<MenuItem>>(exception);
        Assert.Equal(expectedException.Message, menuItemException.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Have_InvalidPrice_When_Create_Then_ThrowMenuItemException(decimal invalidPrice)
    {
        #region Arrange
        var expectedException = new MenuItemException(nameof(MenuItem.Price));
        #endregion

        // Act
        var exception = Record.Exception(() => new MenuItem("Burger", invalidPrice, "desc", ItemCategory.MainCourse));

        // Assert
        Assert.NotNull(exception);
        var menuItemException = Assert.IsType<MenuItemException>(exception);
        Assert.Equal(expectedException.Message, menuItemException.Message);
    }


    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Have_InvalidDescription_When_CreateWithInvalidDescription_Then_ThrowMenuItemException(string? invalidDescription)
    {
        #region Arrange
        var expectedException = new MenuItemException(nameof(MenuItem.Description));
        #endregion

        // Act
        var exception = Record.Exception(() => new MenuItem("Burger", 10m, invalidDescription!, ItemCategory.MainCourse));

        // Assert
        Assert.NotNull(exception);
        var menuItemException = Assert.IsType<InvalidEntityPropertyException<MenuItem>>(exception);
        Assert.Equal(expectedException.Message, menuItemException.Message);
    }
}
