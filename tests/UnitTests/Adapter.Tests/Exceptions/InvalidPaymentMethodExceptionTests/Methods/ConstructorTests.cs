using Xunit;

namespace Adapter.Tests.Exceptions.InvalidPaymentMethodExceptionTests.Methods;

public class ConstructorTests : InvalidPaymentMethodExceptionTestsBase
{
    [Fact]
    public void Have_Constructor_When_InvalidMethod_Then_MessageContainsMethod()
    {
        #region Arrange
        // Base created _method and _sut
        #endregion

        // Act
        var message = _sut.Message;

        // Assert
        Assert.Contains(_method, message);
        Assert.Equal($"The payment method '{_method}' is invalid.", message);
    }
}
