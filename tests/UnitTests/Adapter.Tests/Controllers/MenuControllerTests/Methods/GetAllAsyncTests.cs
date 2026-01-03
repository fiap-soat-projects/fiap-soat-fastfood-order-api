using Adapter.Controllers.DTOs.Filters;
using Adapter.Presenters;
using Business.Entities;
using Business.Entities.Enums;
using Business.UseCases.DTOs;
using NSubstitute;

namespace Adapter.Tests.Controllers.MenuControllerTests.Methods;

public class GetAllAsyncTests : MenuControllerTestsBase
{
    [Fact]
    public async Task Have_GetAllAsync_When_FilterProvided_Then_Returns_MenuItemListPresenter()
    {
        #region Arrange
        var filter = new MenuFilter("a", ItemCategory.MainCourse, 0, 10);

        var items = new List<MenuItem>
        {
            new("X-Salad", price: 3.5m, "X-Salad", ItemCategory.MainCourse),
            new("X-Burger", 10.5m, "X-Burger", ItemCategory.MainCourse)
        };

        _menuItemUseCase
            .GetAllAsync(
                Arg.Any<MenuItemFilter>(), 
                Arg.Any<CancellationToken>())
            .Returns(items);
        #endregion

        // Act
        var presenter = await _sut.GetAllAsync(filter, CancellationToken.None);

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
