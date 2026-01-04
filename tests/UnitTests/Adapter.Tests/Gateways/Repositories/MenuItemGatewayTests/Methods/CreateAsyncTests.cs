using Business.Entities;
using Business.Entities.Enums;
using Business.Exceptions;
using Infrastructure.Entities;
using Infrastructure.Repositories.Exceptions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Adapter.Tests.Gateways.Repositories.MenuItemGatewayTests.Methods;

public class CreateAsyncTests : MenuItemGatewayTestsBase
{
    [Fact]
    public async Task Have_CreateAsync_When_Success_Then_Returns_DomainMenuItem()
    {
        #region Arrange
        var menuItem = new MenuItem("Name", 10m, "Desc", ItemCategory.MainCourse);

        var menuItemMongoDb = new MenuItemMongoDb
        {
            Id = "menu-1",
            Name = "Name",
            Price = 10m,
            Description = "Desc",
            IsActive = true,
            Category = ItemCategory.MainCourse
        };

        _menuItemMongoDbRepository
            .InsertOneAsync(
                Arg.Any<MenuItemMongoDb>(), 
                Arg.Any<CancellationToken>())
            .Returns(menuItemMongoDb);
        #endregion

        // Act
        var result = await _sut.CreateAsync(menuItem, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(menuItemMongoDb.Id, result.Id);
        Assert.Equal(menuItemMongoDb.Name, result.Name);
        Assert.Equal(menuItemMongoDb.Price, result.Price);
    }

    [Fact]
    public async Task Have_CreateAsync_When_DuplicateKeyException_Then_Returns_DuplicateItemException()
    {
        #region Arrange
        var menuItem = new MenuItem("Name", 10m, "Desc", ItemCategory.MainCourse);

        var menuItemMongoDb = new MenuItemMongoDb
        {
            Id = "menu-1",
            Name = "Name",
            Price = 10m,
            Description = "Desc",
            IsActive = true,
            Category = ItemCategory.MainCourse
        };
        var innerException = new RepositoryDuplicatedKeyException();

        var expectedException = new DuplicatedItemException<MenuItem>(nameof(MenuItem.Name), innerException);

        _menuItemMongoDbRepository
            .InsertOneAsync(
                Arg.Any<MenuItemMongoDb>(),
                Arg.Any<CancellationToken>())
            .Throws(innerException);
        #endregion

        // Act
        var exception = await Record.ExceptionAsync(() => _sut.CreateAsync(menuItem, CancellationToken.None));

        // Assert
        var repositoryDuplicatedKeyException = Assert.IsType<DuplicatedItemException<MenuItem>>(exception);
        Assert.Equal(expectedException.Message, repositoryDuplicatedKeyException.Message);
    }
}
