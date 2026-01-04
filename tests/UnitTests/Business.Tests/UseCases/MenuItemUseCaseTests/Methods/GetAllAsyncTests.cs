using System.Threading;
using System.Threading.Tasks;
using Business.Entities;
using Business.UseCases.DTOs;
using NSubstitute;
using Xunit;

namespace Business.Tests.UseCases.MenuItemUseCaseTests.Methods;

public class GetAllAsyncTests : MenuItemUseCaseTestsBase
{
    [Fact]
    public async Task Have_GetAllAsync_When_CallsRepository_Then_Returns_Items()
    {
        #region Arrange
        var filter = new MenuItemFilter(null, null, 0, 10);
        var items = new List<MenuItem> { new MenuItem("Name", 10m, "Desc", Business.Entities.Enums.ItemCategory.MainCourse) { Id = "menu-1" } };

        _menuItemRepository.GetAllAsync(filter, Arg.Any<CancellationToken>()).Returns(items);
        #endregion

        // Act
        var result = await _sut.GetAllAsync(filter, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(items.First().Id, result.First().Id);
    }
}
