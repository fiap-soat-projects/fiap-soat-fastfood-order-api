using Xunit;

namespace Adapter.Tests.Exceptions.InvalidPaymentStatusExceptionTests.Methods;

public class ConstructorTests : InvalidPaymentStatusExceptionTestsBase
{
    [Fact]
    public void Have_Constructor_When_InvalidStatus_Then_MessageContainsStatus()
    {
        #region Arrange
        // Base created _status and _sut
        #endregion

        // Act
        var message = _sut.Message;

        // Assert
        Assert.Contains(_status, message);
        Assert.Equal($"The payment status '{_status}' is invalid.", message);
    }
}
