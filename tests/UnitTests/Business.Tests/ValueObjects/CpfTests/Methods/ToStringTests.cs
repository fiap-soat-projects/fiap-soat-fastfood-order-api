using System;
using Business.ValueObjects.Exceptions;
using Domain.ValueObjects;

namespace Business.Tests.ValueObjects.CpfTests.Methods;

public class ToStringTests
{
    [Fact]
    public void Have_ToString_When_Called_Then_ReturnsDigitsOnly()
    {
        #region Arrange
        var formatted = "743.347.230-47";
        var expected = "74334723047";
        #endregion

        // Act
        var cpf = new Cpf(formatted);
        var str = cpf.ToString();

        // Assert
        Assert.Equal(expected, str);
    }
}
