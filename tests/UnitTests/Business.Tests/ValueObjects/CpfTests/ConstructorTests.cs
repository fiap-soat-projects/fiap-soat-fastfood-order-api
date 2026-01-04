using System;
using Business.ValueObjects.Exceptions;
using Domain.ValueObjects;

namespace Business.Tests.ValueObjects.CpfTests.Methods;

public class ConstructorTests
{
    [Fact]
    public void Have_ValidCpf_When_ConstructWithFormattedCpf_Then_CreatesAndConverts()
    {
        #region Arrange
        var formatted = "743.347.230-47";
        var digits = "74334723047";
        #endregion

        // Act
        var cpf = new Cpf(formatted);
        var asString = (string)cpf;

        // Assert
        Assert.Equal(digits, cpf.Number);
        Assert.Equal(digits, asString);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Have_WhiteSpace_When_Construct_Then_ThrowsArgumentException(string? invalid)
    {
        #region Arrange
        var expectedParamName = "Cpf cannot be null or white space";
        #endregion

        // Act
        var exception = Record.Exception(() => new Cpf(invalid));

        // Assert
        Assert.NotNull(exception);
        var argEx = Assert.IsType<ArgumentException>(exception);
        Assert.Equal(expectedParamName, argEx.ParamName);
    }

    [Fact]

    public void Have_Null_When_Construct_Then_ThrowsArgumentException()
    {
        #region Arrange
        var expectedParamName = "Cpf cannot be null or white space";
        string? invalid = null;
        #endregion

        // Act
        var exception = Record.Exception(() => new Cpf(invalid));

        // Assert
        Assert.NotNull(exception);
        var argEx = Assert.IsType<ArgumentNullException>(exception);
        Assert.Equal(expectedParamName, argEx.ParamName);
    }

    [Fact]
    public void Have_InvalidDigits_When_Construct_Then_ThrowsInvalidCpfException()
    {
        #region Arrange
        var invalid = "123";
        var expectedException = new InvalidCpfException(invalid);
        #endregion

        // Act
        var exception = Record.Exception(() => new Cpf(invalid));

        // Assert
        Assert.NotNull(exception);
        var invalidCpfException = Assert.IsType<InvalidCpfException>(exception);
        Assert.Equal(expectedException.Message, invalidCpfException.Message);
    }
}
