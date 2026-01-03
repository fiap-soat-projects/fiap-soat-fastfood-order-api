using Adapter.Controllers;
using Business.UseCases.Interfaces;
using Business.UseCases.Interfaces;
using Business.UseCases.Interfaces;
using NSubstitute;

namespace Adapter.Tests.Controllers.OrderControllerTests;

public abstract class OrderControllerTestsBase
{
    internal readonly IOrderUseCase _orderUseCase;
    internal readonly IMenuItemUseCase _menuItemUseCase;
    internal readonly IInventoryUseCase _inventoryUseCase;
    internal readonly ICustomerUseCase _customerUseCase;
    internal readonly OrderController _sut;

    protected OrderControllerTestsBase()
    {
        _orderUseCase = Substitute.For<IOrderUseCase>();
        _menuItemUseCase = Substitute.For<IMenuItemUseCase>();
        _inventoryUseCase = Substitute.For<IInventoryUseCase>();
        _customerUseCase = Substitute.For<ICustomerUseCase>();

        _sut = new OrderController(
            _orderUseCase,
            _menuItemUseCase,
            _inventoryUseCase,
            _customerUseCase);
    }
}
