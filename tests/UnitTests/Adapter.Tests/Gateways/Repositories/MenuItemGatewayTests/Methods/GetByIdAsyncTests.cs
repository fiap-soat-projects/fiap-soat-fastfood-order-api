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
        _menuItemMongoDbRepository.GetByIdAsync(id, Arg.Any<CancellationToken>()).Returns((MenuItemMongoDb?)null);
        #endregion

        // Act
        var result = await _sut.GetByIdAsync(id, CancellationToken.None);

        // Assert
        Assert.Null(result);
    }
}
