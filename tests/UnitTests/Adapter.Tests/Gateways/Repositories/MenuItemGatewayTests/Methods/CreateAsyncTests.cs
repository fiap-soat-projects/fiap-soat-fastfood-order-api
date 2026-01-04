using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Entities;
using NSubstitute;
using Xunit;

namespace Adapter.Tests.Gateways.Repositories.MenuItemGatewayTests.Methods;

public class CreateAsyncTests : MenuItemGatewayTestsBase
{
    [Fact]
    public async Task Have_CreateAsync_When_Success_Then_Returns_DomainMenuItem()
    {
        #region Arrange
        var menuItem = new Business.Entities.MenuItem("Name", 10m, "Desc", Business.Entities.Enums.ItemCategory.MainCourse);

        var menuItemMongoDb = new MenuItemMongoDb
        {
            Id = "menu-1",
            Name = "Name",
            Price = 10m,
            Description = "Desc",
            IsActive = true,
            Category = Business.Entities.Enums.ItemCategory.MainCourse
        };

        _menuItemMongoDbRepository.InsertOneAsync(Arg.Any<MenuItemMongoDb>(), Arg.Any<CancellationToken>()).Returns(menuItemMongoDb);
        #endregion

        // Act
        var result = await _sut.CreateAsync(menuItem, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(menuItemMongoDb.Id, result.Id);
        Assert.Equal(menuItemMongoDb.Name, result.Name);
        Assert.Equal(menuItemMongoDb.Price, result.Price);
    }
}
