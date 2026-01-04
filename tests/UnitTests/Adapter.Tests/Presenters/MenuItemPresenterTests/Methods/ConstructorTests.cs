using Adapter.Presenters;
using Adapter.Presenters.DTOs;
using Business.Entities;
using Business.Entities.Enums;

namespace Adapter.Tests.Presenters.MenuItemPresenterTests.Methods;

public class ConstructorTests
{
    [Fact]
    public void Have_Constructor_When_MenuItemProvided_Then_Maps_ViewModel()
    {
        // Arrange
        var menuItem = new MenuItem("X-Salad", 3.5m, "Fresh", ItemCategory.MainCourse);
        menuItem.Id = "menu-1";
        menuItem.IsActive = true;

        // Act
        var presenter = new MenuItemPresenter(menuItem);

        // Assert
        Assert.NotNull(presenter);
        Assert.IsType<MenuItemPresenter>(presenter);

        var vm = presenter.ViewModel;
        Assert.Equal(menuItem.Id, vm.Id);
        Assert.Equal(menuItem.Name, vm.Name);
        Assert.Equal(menuItem.Price, vm.Price);
        Assert.Equal(menuItem.Category, vm.Category);
        Assert.Equal(menuItem.Description, vm.Description);
        Assert.Equal(menuItem.IsActive, vm.IsActive);
    }
}
