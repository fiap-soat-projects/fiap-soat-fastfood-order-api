using Business.Entities;
using Business.Entities.Enums;

namespace Business.Tests.Entities.MenuItemTests.Methods;

public class ConstructorTests
{
    [Fact]
    public void Have_ValidParameters_When_CallConstructor_Then_ObjectCreated()
    {
        #region Arrange
        var name = "Burger";
        var price = 10m;
        var desc = "Tasty";
        #endregion

        // Act
        var menuItem = new MenuItem(name, price, desc, ItemCategory.MainCourse);

        // Assert
        Assert.NotNull(menuItem);
        Assert.IsType<DateTime>(menuItem.CreatedAt);
        Assert.Equal(name, menuItem.Name);
        Assert.Equal(price, menuItem.Price);
        Assert.Equal(desc, menuItem.Description);
        Assert.Equal(ItemCategory.MainCourse, menuItem.Category);
    }
}
