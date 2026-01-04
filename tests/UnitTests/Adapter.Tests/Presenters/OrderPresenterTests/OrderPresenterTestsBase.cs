using System.Collections.Generic;
using Adapter.Presenters;
using Business.Entities;
using Business.Entities.Enums;

namespace Adapter.Tests.Presenters.OrderPresenterTests;

public abstract class OrderPresenterTestsBase
{
    internal readonly Order _order;
    internal readonly OrderPresenter _sut;

    protected OrderPresenterTestsBase()
    {
        var orderItems = new List<OrderItem>
        {
            new OrderItem("menu-1", "Burger", ItemCategory.MainCourse, 10m, 2)
        };

        _order = new Order(
            id: "order-1",
            customerId: "cust-1",
            customerName: "John",
            items: orderItems,
            status: OrderStatus.Pending,
            payment: new Payment(),
            totalPrice: 20m);

        _sut = new OrderPresenter(_order);
    }
}
