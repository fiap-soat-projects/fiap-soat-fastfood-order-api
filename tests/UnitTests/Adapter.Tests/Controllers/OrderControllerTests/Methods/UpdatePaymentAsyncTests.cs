using Adapter.Controllers.DTOs;
using Adapter.Exceptions;
using NSubstitute;
using Business.Entities;
using Business.Entities.Enums;

namespace Adapter.Tests.Controllers.OrderControllerTests.Methods;

public class UpdatePaymentAsyncTests : OrderControllerTestsBase
{
    [Fact]
    public async Task Have_UpdatePaymentAsync_When_ValidRequest_Then_Calls_UseCase()
    {
        #region Arrange
        var id = "order-pay-1";
        var request = new UpdatePaymentRequest(PaymentId: "pay-1", PaymentMethod: "Pix", PaymentStatus: "Authorized");
        #endregion

        // Act
        await _sut.UpdatePaymentAsync(id, request, CancellationToken.None);

        // Assert
        await _orderUseCase
            .Received(1)
            .UpdatePaymentAsync(
                Arg.Any<string>(), 
                Arg.Any<Payment>(),
                Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Have_UpdatePaymentAsync_When_InvalidPaymentStatus_Then_Throw_InvalidPaymentStatusException_And_Not_Call_UseCase()
    {
        #region Arrange
        var id = "order-pay-2";
        var request = new UpdatePaymentRequest(PaymentId: "pay-2", PaymentMethod: "Card", PaymentStatus: "InvalidStatus");
        #endregion

        // Act & Assert
        await Assert.ThrowsAsync<InvalidPaymentStatusException>(() => _sut.UpdatePaymentAsync(id, request, CancellationToken.None));

        await _orderUseCase
            .DidNotReceive()
            .UpdatePaymentAsync(
                Arg.Any<string>(), 
                Arg.Any<Payment>(), 
                Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Have_UpdatePaymentAsync_When_InvalidPaymentMethod_Then_Throw_InvalidPaymentMethodException_And_Not_Call_UseCase()
    {
        #region Arrange
        var id = "order-pay-3";
        var request = new UpdatePaymentRequest(PaymentId: "pay-3", PaymentMethod: "InvalidMethod", PaymentStatus: "Authorized");
        #endregion

        // Act & Assert
        await Assert.ThrowsAsync<InvalidPaymentMethodException>(() => _sut.UpdatePaymentAsync(id, request, CancellationToken.None));

        await _orderUseCase
            .DidNotReceive()
            .UpdatePaymentAsync(
                Arg.Any<string>(),
                Arg.Any<Payment>(), 
                Arg.Any<CancellationToken>());
    }
}
