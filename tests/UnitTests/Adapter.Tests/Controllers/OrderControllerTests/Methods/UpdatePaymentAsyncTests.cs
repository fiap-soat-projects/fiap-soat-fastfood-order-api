using Adapter.Controllers.DTOs;
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
        await _orderUseCase.Received(1).UpdatePaymentAsync(Arg.Any<string>(), Arg.Any<Payment>(), Arg.Any<CancellationToken>());
    }
}
