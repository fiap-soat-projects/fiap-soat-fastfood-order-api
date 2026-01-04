using Adapter.Presenters;
using Adapter.Presenters.DTOs;
using Business.Entities;
using Business.Entities.Enums;

namespace Adapter.Tests.Presenters.MenuItemListPresenterTests.Methods;

public class ConstructorTests
{
    [Fact]
    public void Have_Constructor_When_MenuItemsProvided_Then_Maps_ViewModel()
    {
        // Arrange
        var items = new List<MenuItem>
        {
            new("X-Salad", 3.5m, "Fresh", ItemCategory.MainCourse) { Id = "m1", IsActive = true },
            new("X-Burger", 10.5m, "Tasty", ItemCategory.MainCourse) { Id = "m2", IsActive = false }
        };

        // Act
        var presenter = new MenuItemListPresenter(items);

        // Assert
        Assert.NotNull(presenter);
        Assert.IsType<MenuItemListPresenter>(presenter);

        var vm = presenter.ViewModel.ToList();
        Assert.Equal(2, vm.Count);

        Assert.Equal(items[0].Id, vm[0].Id);
        Assert.Equal(items[0].Name, vm[0].Name);
        Assert.Equal(items[0].Price, vm[0].Price);
        Assert.Equal(items[0].Category, vm[0].Category);
        Assert.Equal(items[0].Description, vm[0].Description);
        Assert.Equal(items[0].IsActive, vm[0].IsActive);

        Assert.Equal(items[1].Id, vm[1].Id);
        Assert.Equal(items[1].Name, vm[1].Name);
        Assert.Equal(items[1].Price, vm[1].Price);
        Assert.Equal(items[1].Category, vm[1].Category);
        Assert.Equal(items[1].Description, vm[1].Description);
        Assert.Equal(items[1].IsActive, vm[1].IsActive);
    }
}
