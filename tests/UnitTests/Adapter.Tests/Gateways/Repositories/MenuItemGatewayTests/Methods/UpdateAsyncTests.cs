using System.Threading;
using System.Threading.Tasks;
using Business.Entities;
using Business.Entities.Enums;
using Infrastructure.Entities;
using NSubstitute;
using Xunit;

namespace Adapter.Tests.Gateways.Repositories.MenuItemGatewayTests.Methods;

public class UpdateAsyncTests : MenuItemGatewayTestsBase
{
    [Fact]
    public async Task Have_UpdateAsync_When_Success_Then_Returns_DomainMenuItem()
    {
        #region Arrange
        var id = "menu-1";
        var menuItem = new MenuItem("Name", 10m, "Desc", ItemCategory.MainCourse);

        var menuItemMongoDb = new MenuItemMongoDb {
            Id = id,
            Name = "Name",
            Price = 10m, 
            Description = "Desc", 
            IsActive = true,
            Category = ItemCategory.MainCourse };

        _menuItemMongoDbRepository
            .UpdateAsync(
                id, 
                Arg.Any<MenuItemMongoDb>(),
                Arg.Any<CancellationToken>())
            .Returns(menuItemMongoDb);
        #endregion

        // Act
        var result = await _sut.UpdateAsync(id, menuItem, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(menuItemMongoDb.Id, result.Id);
        Assert.Equal(menuItemMongoDb.Name, result.Name);
    }
}
