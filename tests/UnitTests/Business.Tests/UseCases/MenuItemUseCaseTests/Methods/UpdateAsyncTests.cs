using System.Threading;
using System.Threading.Tasks;
using Business.Entities;
using Business.Exceptions;
using NSubstitute;
using Xunit;

namespace Business.Tests.UseCases.MenuItemUseCaseTests.Methods;

public class UpdateAsyncTests : MenuItemUseCaseTestsBase
{
    [Fact]
    public async Task Have_UpdateAsync_When_ItemNotFound_Then_Throws_MenuItemNotFoundException()
    {
        #region Arrange
        var item = new MenuItem("Name", 10m, "Desc", Business.Entities.Enums.ItemCategory.MainCourse) { Id = "menu-1" };

        _menuItemRepository.GetByIdAsync(item.Id, Arg.Any<CancellationToken>()).Returns((MenuItem?)null);
        #endregion

        // Act
        var exception = await Record.ExceptionAsync(() => _sut.UpdateAsync(item, CancellationToken.None));

        // Assert
        Assert.NotNull(exception);
        Assert.IsType<EntityNotFoundException<MenuItem>>(exception);
    }

    [Fact]
    public async Task Have_UpdateAsync_When_Found_Then_Returns_Updated()
    {
        #region Arrange
        var item = new MenuItem("Name", 10m, "Desc", Business.Entities.Enums.ItemCategory.MainCourse) { Id = "menu-1" };
        var updated = new MenuItem("Name", 20m, "Desc", Business.Entities.Enums.ItemCategory.MainCourse) { Id = "menu-1" };

        _menuItemRepository.GetByIdAsync(item.Id, Arg.Any<CancellationToken>()).Returns(item);
        _menuItemRepository.UpdateAsync(item.Id, item, Arg.Any<CancellationToken>()).Returns(updated);
        #endregion

        // Act
        var result = await _sut.UpdateAsync(item, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(updated.Price, result.Price);
    }
}
