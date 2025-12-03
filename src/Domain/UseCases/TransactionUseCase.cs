using Business.Entities;
using Business.Entities.Enums;
using Business.Gateways.Repositories.Interfaces;
using Business.UseCases.Interfaces;

namespace Business.UseCases;
internal class TransactionUseCase : ITransactionUseCase
{
    // remover dependencias e chamar api de payment
    private readonly IOrderRepository _orderRepository;

    public TransactionUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<PaymentCheckout> CheckoutAsync(Order order, PaymentMethod method, CancellationToken cancellationToken)
    {
        var paymentCheckout = await ExecuteCheckoutAsync(order, method, cancellationToken);

        var payment = new Payment
        {
            Id = paymentCheckout.Id.ToString(),
            Method = method,
            Status = PaymentStatus.Pending
        };

        await _orderRepository.UpdatePaymentAsync(order.Id, OrderStatus.Pending, payment, cancellationToken);

        return paymentCheckout;
    }

    private async Task<PaymentCheckout> ExecuteCheckoutAsync(Order order, PaymentMethod method, CancellationToken cancellationToken)
    {
        // implementar api de payment aqui

        //if (!string.IsNullOrWhiteSpace(order?.CustomerId))
        //{
        //    return await ExecuteCustomerCheckoutAsync(order!, method, cancellationToken);
        //}

        //var orderPaymentCheckout = await ExecuteAnonymousCheckoutAsync(order!, method, cancellationToken);

        return default;
    }

    public async Task ConfirmPaymentAsync(string id, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id, nameof(id));

        await _orderRepository.UpdateStatusAsync(id, OrderStatus.Received, cancellationToken);
    }

    public async Task ProcessPaymentAsync(string orderId, Payment payment, CancellationToken cancellationToken)
    {
        var orderStatus = GetOrderStatusByPayment(payment.Status);

        await _orderRepository.UpdatePaymentAsync(orderId, orderStatus, payment, cancellationToken);
    }
    private static OrderStatus GetOrderStatusByPayment(PaymentStatus payment)
    {
        return payment switch
        {
            PaymentStatus.Pending => OrderStatus.Pending,
            PaymentStatus.Authorized => OrderStatus.Received,
            PaymentStatus.Refused => OrderStatus.Canceled,
            _ => OrderStatus.None
        };

    }
}
