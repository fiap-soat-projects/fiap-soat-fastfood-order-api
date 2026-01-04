using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Entities;
using NSubstitute;
using Xunit;

namespace Adapter.Tests.Gateways.Repositories.MenuItemGatewayTests.Methods;

public class GetByIdAsyncTests : MenuItemGatewayTestsBase
{
    [Fact]
    public async Task Have_GetByIdAsync_When_NotFound_Then_ReturnsNull()
    {
        #region Arrange
        var id = "menu-1";
        _menuItemMongoDbRepository
            .GetByIdAsync(
                id, 
                Arg.Any<CancellationToken>())
            .Returns(default(MenuItemMongoDb));
        #endregion

        // Act
        var result = await _sut.GetByIdAsync(id, CancellationToken.None);

        // Assert
        Assert.Null(result);
        await _menuItemMongoDbRepository.Received(1).GetByIdAsync(id, Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Have_GetByIdAsync_When_Found_Then_Returns_DomainMenuItem()
    {
        #region Arrange
        var id = "menu-1";

        var menuItemMongoDb = new MenuItemMongoDb
        {
            Id = id,
            Name = "Name",
            Price = 10m,
            Description = "Desc",
            IsActive = true,
            Category = Business.Entities.Enums.ItemCategory.MainCourse
        };

        _menuItemMongoDbRepository
            .GetByIdAsync(
                id,
                Arg.Any<CancellationToken>())
            .Returns(menuItemMongoDb);
        #endregion

        // Act
        var result = await _sut.GetByIdAsync(id, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(menuItemMongoDb.Id, result!.Id);
        Assert.Equal(menuItemMongoDb.Name, result.Name);
        Assert.Equal(menuItemMongoDb.Price, result.Price);
        Assert.Equal(menuItemMongoDb.Description, result.Description);
        Assert.Equal(menuItemMongoDb.IsActive, result.IsActive);
        Assert.Equal(menuItemMongoDb.Category, result.Category);
        await _menuItemMongoDbRepository.Received(1).GetByIdAsync(id, Arg.Any<CancellationToken>());
    }
}
