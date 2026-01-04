using Business.Entities;
using Business.Exceptions;
using NSubstitute;

namespace Business.Tests.UseCases.MenuItemUseCaseTests.Methods;

public class GetByIdAsyncTests : MenuItemUseCaseTestsBase
{
    [Fact]
    public async Task Have_GetByIdAsync_When_EmptyId_Then_ThrowsArgumentException()
    {
        #region Arrange
        var id = string.Empty;
        #endregion

        // Act
        var exception = await Record.ExceptionAsync(() => _sut.GetByIdAsync(id, CancellationToken.None));

        // Assert
        Assert.NotNull(exception);
        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public async Task Have_GetByIdAsync_When_NotFound_Then_Throws_MenuItemNotFoundException()
    {
        #region Arrange
        var id = "menu-1";

        _menuItemRepository.GetByIdAsync(id, Arg.Any<CancellationToken>()).Returns((MenuItem?)null);
        var expected = new MenuItemNotFoundException(id);
        #endregion

        // Act
        var exception = await Record.ExceptionAsync(() => _sut.GetByIdAsync(id, CancellationToken.None));

        // Assert
        Assert.NotNull(exception);
        var menuItemNotFoundException = Assert.IsType<EntityNotFoundException<MenuItem>>(exception);
        Assert.Equal(expected.Message, menuItemNotFoundException.Message);
    }

    [Fact]
    public async Task Have_GetByIdAsync_When_Found_Then_Returns_Item()
    {
        #region Arrange
        var id = "menu-1";
        var returned = new MenuItem("Name", 10m, "Desc", Business.Entities.Enums.ItemCategory.MainCourse) { Id = id };

        _menuItemRepository.GetByIdAsync(id, Arg.Any<CancellationToken>()).Returns(returned);
        #endregion

        // Act
        var result = await _sut.GetByIdAsync(id, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
    }
}
