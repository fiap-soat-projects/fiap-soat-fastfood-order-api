using Domain.ValueObjects;

namespace Business.Tests.ValueObjects.EmailTests.Methods;

public class ToStringTests
{
    [Fact]
    public void Have_ToString_When_Called_Then_ReturnsAddress()
    {
        #region Arrange
        var email = "teste@test.com";
        #endregion

        // Act
        var vo = new Email(email);
        var str = vo.ToString();

        // Assert
        Assert.Equal(email, str);
    }
}
