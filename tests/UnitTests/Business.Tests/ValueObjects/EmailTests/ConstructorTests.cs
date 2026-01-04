using System;
using Business.ValueObjects.Exceptions;
using Domain.ValueObjects;

namespace Business.Tests.ValueObjects.EmailTests.Methods;

public class ConstructorTests
{
    [Fact]
    public void Have_ValidEmail_When_ConstructWithValidEmail_Then_CreatesAndConverts()
    {
        #region Arrange
        var email = "teste@test.com";
        #endregion

        // Act
        var vo = new Email(email);
        var asString = (string)vo;

        // Assert
        Assert.Equal(email, vo.Adress);
        Assert.Equal(email, asString);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Have_WhiteSpace_When_Construct_Then_ThrowsArgumentException(string? invalid)
    {
        #region Arrange
        var expectedParamName = "Email address cannot be null or white space";
        #endregion

        // Act
        var exception = Record.Exception(() => new Email(invalid));

        // Assert
        Assert.NotNull(exception);
        var argEx = Assert.IsType<ArgumentException>(exception);
        Assert.Equal(expectedParamName, argEx.ParamName);
    }

    [Fact]
    public void Have_Null_When_Construct_Then_ThrowsArgumentNullException()
    {
        #region Arrange
        var expectedParamName = "Email address cannot be null or white space";
        string? invalid = null;
        #endregion

        // Act
        var exception = Record.Exception(() => new Email(invalid));

        // Assert
        Assert.NotNull(exception);
        var argEx = Assert.IsType<ArgumentNullException>(exception);
        Assert.Equal(expectedParamName, argEx.ParamName);
    }

    [Fact]
    public void Have_InvalidEmail_When_Construct_Then_ThrowsInvalidEmailException()
    {
        #region Arrange
        var invalid = "not-an-email";
        var expectedException = new InvalidEmailException(invalid);
        #endregion

        // Act
        var exception = Record.Exception(() => new Email(invalid));

        // Assert
        Assert.NotNull(exception);
        var invalidEmailException = Assert.IsType<InvalidEmailException>(exception);
        Assert.Equal(expectedException.Message, invalidEmailException.Message);
    }
}
