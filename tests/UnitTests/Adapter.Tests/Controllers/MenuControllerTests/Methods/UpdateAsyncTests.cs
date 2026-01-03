using Adapter.Controllers.DTOs;
using Adapter.Presenters;
using Business.Entities;
using Business.Entities.Enums;
using NSubstitute;

namespace Adapter.Tests.Controllers.MenuControllerTests.Methods;

public class UpdateAsyncTests : MenuControllerTestsBase
{
    [Fact]
    public async Task Have_UpdateAsync_When_ValidInput_Then_Returns_MenuItemPresenter()
    {
        #region Arrange
        var id = "menu-update-1";
        var request = new UpdateMenuItemRequest(
            Name: "Updated Burger",
            Price: 12.0m,
            Category: ItemCategory.MainCourse,
            Description: "Updated",
            IsActive: false);

        var returned = new MenuItem(
            name: request!.Name!,
            price: request.Price,
            category: request.Category,
            description: request!.Description!);

        _menuItemUseCase
            .UpdateAsync(
                Arg.Any<MenuItem>(), 
                Arg.Any<CancellationToken>())
            .Returns(returned);
        #endregion

        // Act
        var presenter = await _sut.UpdateAsync(id, request, CancellationToken.None);

        // Assert
        Assert.NotNull(presenter);
        Assert.IsType<MenuItemPresenter>(presenter);

        Assert.Equal(returned.Id, presenter.ViewModel.Id);
        Assert.Equal(returned.Name, presenter.ViewModel.Name);
        Assert.Equal(returned.Price, presenter.ViewModel.Price);
        Assert.Equal(returned.Category, presenter.ViewModel.Category);
        Assert.Equal(returned.Description, presenter.ViewModel.Description);
        Assert.Equal(returned.IsActive, presenter.ViewModel.IsActive);
    }
}
