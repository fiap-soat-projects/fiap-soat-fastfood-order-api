using Business.Entities;
using Business.Entities.Enums;
using Infrastructure.Entities;
using NSubstitute;

namespace Adapter.Tests.Gateways.Repositories.OrderGatewayTests.Methods;

public class UpdatePaymentAsyncTests : OrderGatewayTestsBase
{
    [Fact]
    public async Task Have_UpdatePaymentAsync_When_Success_Then_CallsRepository()
    {
        #region Arrange
        var id = "order-1";
        var status = OrderStatus.Received;

        var payment = new Payment
        {
            Id = "pay-1",
            Method = PaymentMethod.Pix,
            Status = PaymentStatus.Authorized
        };
        #endregion

        // Act
        await _sut.UpdatePaymentAsync(id, status, payment, CancellationToken.None);

        // Assert
        await _orderMongoDbRepository
            .Received(1)
            .UpdatePaymentAsync(
                id,
                status,
                Arg.Any<PaymentMongoDb>(),
                Arg.Any<CancellationToken>());
    }
}
