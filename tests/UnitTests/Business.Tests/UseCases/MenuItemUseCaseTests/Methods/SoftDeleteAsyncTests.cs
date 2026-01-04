using Business.Entities;
using Business.Exceptions;
using NSubstitute;

namespace Business.Tests.UseCases.MenuItemUseCaseTests.Methods;

public class SoftDeleteAsyncTests : MenuItemUseCaseTestsBase
{
    [Fact]
    public async Task Have_SoftDeleteAsync_When_ItemNotFound_Then_Throws_MenuItemNotFoundException()
    {
        #region Arrange
        var id = "menu-1";

        _menuItemRepository.GetByIdAsync(id, Arg.Any<CancellationToken>()).Returns((MenuItem?)null);
        #endregion

        // Act
        var exception = await Record.ExceptionAsync(() => _sut.SoftDeleteAsync(id, CancellationToken.None));

        // Assert
        Assert.NotNull(exception);
        Assert.IsType<EntityNotFoundException<MenuItem>>(exception);
    }

    [Fact]
    public async Task Have_SoftDeleteAsync_When_Found_Then_Calls_Update()
    {
        #region Arrange
        var id = "menu-1";
        var item = new MenuItem("Name", 10m, "Desc", Business.Entities.Enums.ItemCategory.MainCourse) { Id = id };

        _menuItemRepository.GetByIdAsync(id, Arg.Any<CancellationToken>()).Returns(item);
        _menuItemRepository.UpdateAsync(item.Id, Arg.Any<MenuItem>(), Arg.Any<CancellationToken>()).Returns(item);
        #endregion

        // Act
        await _sut.SoftDeleteAsync(id, CancellationToken.None);

        // Assert
        await _menuItemRepository.Received(1).UpdateAsync(item.Id, Arg.Any<MenuItem>(), Arg.Any<CancellationToken>());
    }
}
