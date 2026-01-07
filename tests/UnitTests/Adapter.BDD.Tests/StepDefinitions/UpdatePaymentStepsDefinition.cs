using Adapter.Controllers.DTOs;
using Adapter.Exceptions;
using Business.Entities;
using Reqnroll;

namespace Adapter.Tests.Controllers.OrderControllerTests.BDD;

[Binding]
public class UpdatePaymentStepsDefinition : OrderControllerTestsBase
{
    private string _orderId = default!;
    private UpdatePaymentRequest _request = default!;
    private Exception? _caughtException;

    [Given(@"an order id ""(.*)""")]
    public void GivenAnOrderId(string orderId)
    {
        _orderId = orderId;
    }

    [Given(@"a payment request with method ""(.*)"" and status ""(.*)""")]
    public void GivenAPaymentRequest(string paymentMethod, string paymentStatus)
    {
        _request = new UpdatePaymentRequest(
            PaymentId: "pay-1",
            PaymentMethod: paymentMethod,
            PaymentStatus: paymentStatus);
    }

    [When(@"I update the payment")]
    public async Task WhenIUpdateThePayment()
    {
        try
        {
            await _sut.UpdatePaymentAsync(_orderId, _request, CancellationToken.None);
        }
        catch (Exception ex)
        {
            _caughtException = ex;
        }
    }

    [Then(@"the use case should be called once")]
    public async Task ThenTheUseCaseShouldBeCalledOnce()
    {
        await _orderUseCase
            .Received(1)
            .UpdatePaymentAsync(
                Arg.Any<string>(),
                Arg.Any<Payment>(),
                Arg.Any<CancellationToken>());
    }

    [Then(@"the use case should not be called")]
    public async Task ThenTheUseCaseShouldNotBeCalled()
    {
        await _orderUseCase
            .DidNotReceive()
            .UpdatePaymentAsync(
                Arg.Any<string>(),
                Arg.Any<Payment>(),
                Arg.Any<CancellationToken>());
    }

    [Then(@"an InvalidPaymentStatusException should be thrown")]
    public void ThenInvalidPaymentStatusExceptionShouldBeThrown()
    {
        Assert.NotNull(_caughtException);
        Assert.IsType<InvalidPaymentStatusException>(_caughtException);
    }

    [Then(@"an InvalidPaymentMethodException should be thrown")]
    public void ThenInvalidPaymentMethodExceptionShouldBeThrown()
    {
        Assert.NotNull(_caughtException);
        Assert.IsType<InvalidPaymentMethodException>(_caughtException);
    }
}
