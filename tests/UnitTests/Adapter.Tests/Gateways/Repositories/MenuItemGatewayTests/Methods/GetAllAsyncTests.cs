using Business.Entities;
using Business.Entities.Enums;
using Business.UseCases.DTOs;
using Infrastructure.Entities;
using NSubstitute;

namespace Adapter.Tests.Gateways.Repositories.MenuItemGatewayTests.Methods;

public class GetAllAsyncTests : MenuItemGatewayTestsBase
{
    [Fact]
    public async Task Have_GetAllAsync_When_NoItems_Then_ReturnsEmpty()
    {
        #region Arrange
        var filter = new MenuItemFilter(null, null, 0, 10);
        
        _menuItemMongoDbRepository
            .GetAllAsync(
                filter, 
                Arg.Any<CancellationToken>())
            .Returns([]);
        #endregion

        // Act
        var result = await _sut.GetAllAsync(filter, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task Have_GetAllAsync_When_HasItems_Then_Returns_DomainItems()
    {
        #region Arrange
        var filter = new MenuItemFilter(null, null, Skip: 0, Limit: 10);

        var menuItemMongoDb = new MenuItemMongoDb
        { 
            Id = "menu-1", 
            Name = "Name",
            Price = 10m,
            Description = "Desc",
            IsActive = true,
            Category =
            ItemCategory.MainCourse 
        };

        _menuItemMongoDbRepository
            .GetAllAsync(
                filter, 
                Arg.Any<CancellationToken>())
            .Returns([menuItemMongoDb]);
        #endregion

        // Act
        var result = await _sut.GetAllAsync(filter, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        var item = result.First();
        Assert.Equal(menuItemMongoDb.Id, item.Id);
        Assert.Equal(menuItemMongoDb.Name, item.Name);
    }
}
