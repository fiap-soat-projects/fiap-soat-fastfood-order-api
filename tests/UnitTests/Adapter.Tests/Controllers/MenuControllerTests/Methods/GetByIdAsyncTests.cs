using Adapter.Presenters;
using Business.Entities;
using Business.Entities.Enums;
using NSubstitute;

namespace Adapter.Tests.Controllers.MenuControllerTests.Methods;

public class GetByIdAsyncTests : MenuControllerTestsBase
{
    [Fact]
    public async Task Have_GetByIdAsync_When_ExistingId_Then_Returns_MenuItemPresenter()
    {
        #region Arrange
        var id = "menu-42";
        var menuItem = new MenuItem("Fries", 3.5m, "Crispy", ItemCategory.MainCourse);

        _menuItemUseCase
            .GetByIdAsync(
                id,
                Arg.Any<CancellationToken>())
            .Returns(menuItem);
        #endregion

        // Act
        var presenter = await _sut.GetByIdAsync(id, CancellationToken.None);

        // Assert
        Assert.NotNull(presenter);
        Assert.IsType<MenuItemPresenter>(presenter);

        Assert.Equal(menuItem.Id, presenter.ViewModel.Id);
        Assert.Equal(menuItem.Name, presenter.ViewModel.Name);
        Assert.Equal(menuItem.Price, presenter.ViewModel.Price);
        Assert.Equal(menuItem.Category, presenter.ViewModel.Category);
        Assert.Equal(menuItem.Description, presenter.ViewModel.Description);
        Assert.Equal(menuItem.IsActive, presenter.ViewModel.IsActive);
    }
}
