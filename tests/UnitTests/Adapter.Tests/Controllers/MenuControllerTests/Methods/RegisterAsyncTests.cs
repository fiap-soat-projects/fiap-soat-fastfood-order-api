using Adapter.Controllers.DTOs;
using Adapter.Presenters;
using Adapter.Tests.Controllers.MenuControllerTests;
using Business.Entities;
using Business.Entities.Enums;
using NSubstitute;

namespace Adapter.Tests.Controllers.MenuControllerTests.Methods;

public class RegisterAsyncTests : MenuControllerTestsBase
{
    [Fact]
    public async Task Have_RegisterAsync_When_ValidInput_Then_Returns_MenuItemPresenter()
    {
        #region Arrange
        var request = new RegisterMenuItemRequest(
            Name: "Burger",
            Price: 9.5m,
            Category: ItemCategory.MainCourse,
            Description: "Tasty burger");

        var returned = new MenuItem(
            name: "Burger",
            price: 9.5m,
            description: "Tasty burger",
            category: ItemCategory.MainCourse);

        _menuItemUseCase
            .CreateAsync(
                Arg.Any<MenuItem>(), 
                Arg.Any<CancellationToken>())
            .Returns(returned);
        #endregion

        // Act
        var presenter = await _sut.RegisterAsync(request, CancellationToken.None);

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