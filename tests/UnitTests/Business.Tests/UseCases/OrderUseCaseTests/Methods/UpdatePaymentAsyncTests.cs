using System.Threading;
using System.Threading.Tasks;
using Business.Entities;
using Business.Entities.Enums;
using NSubstitute;
using Xunit;

namespace Business.Tests.UseCases.OrderUseCaseTests.Methods;

public class UpdatePaymentAsyncTests : OrderUseCaseTestsBase
{
    [Fact]
    public async Task Have_UpdatePaymentAsync_When_CallsRepository_Then_Completes()
    {
        #region Arrange
        var id = "order-1";
        var payment = new Payment { Id = "pay-1", Method = PaymentMethod.Pix, Status = PaymentStatus.Pending };
        #endregion

        // Act
        await _sut.UpdatePaymentAsync(id, payment, CancellationToken.None);

        // Assert
        await _orderRepository.Received(1).UpdatePaymentAsync(id, OrderStatus.Received, payment, Arg.Any<CancellationToken>());
    }
}
