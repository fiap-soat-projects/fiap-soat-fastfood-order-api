using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Tests.Controllers.MenuControllerTests.Methods;

public class SoftDeleteAsync : MenuControllerTestsBase
{
    [Fact]
    public async Task Have_SoftDeleteAsync_When_IdProvided_Then_Invokes_UseCase()
    {
        #region Arrange
        var id = "menu-to-delete";
        #endregion

        // Act
        await _sut.SoftDeleteAsync(id, CancellationToken.None);

        // Assert
        await _menuItemUseCase
            .Received(1)
            .SoftDeleteAsync(id, Arg.Any<CancellationToken>());
    }
}
