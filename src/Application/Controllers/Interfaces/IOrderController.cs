using Adapter.Controllers.DTOs;
using Adapter.Controllers.DTOs.Filters;
using Adapter.Presenters;

namespace Adapter.Controllers.Interfaces;

public interface IOrderController
{
    Task<string> CreateAsync(CreateRequest request, CancellationToken cancellationToken);
    Task<OrderPresenter> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<OrderPaginatedPresenter> GetAllAsync(OrderFilter filter, CancellationToken cancellationToken);
    Task<OrderPaginatedPresenter> GetActiveAsync(OrderFilter filter, CancellationToken cancellationToken);
    Task<OrderPresenter> UpdateStatusAsync(string id, UpdateStatusRequest updateStatusRequest, CancellationToken cancellationToken);
    Task UpdatePaymentAsync(string id, UpdatePaymentRequest updatePaymentRequest, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
}
