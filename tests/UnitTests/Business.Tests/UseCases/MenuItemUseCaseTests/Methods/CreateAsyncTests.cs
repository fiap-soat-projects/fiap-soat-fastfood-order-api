using System.Threading;
using System.Threading.Tasks;
using Business.Entities;
using Business.UseCases.DTOs;
using NSubstitute;
using Xunit;

namespace Business.Tests.UseCases.MenuItemUseCaseTests.Methods;

public class CreateAsyncTests : MenuItemUseCaseTestsBase
{
    [Fact]
    public async Task Have_CreateAsync_When_CallsRepository_Then_Returns_Item()
    {
        #region Arrange
        var menuItem = new MenuItem("Name", 10m, "Desc", Business.Entities.Enums.ItemCategory.MainCourse);
        var returned = new MenuItem("Name", 10m, "Desc", Business.Entities.Enums.ItemCategory.MainCourse) { Id = "menu-1" };

        _menuItemRepository.CreateAsync(Arg.Any<MenuItem>(), Arg.Any<CancellationToken>()).Returns(returned);
        #endregion

        // Act
        var result = await _sut.CreateAsync(menuItem, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(returned.Id, result.Id);
    }
}
