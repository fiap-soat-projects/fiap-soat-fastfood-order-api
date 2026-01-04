using System.Collections.Generic;
using Adapter.Presenters;
using Business.Entities;
using Business.Entities.Enums;
using Business.Entities.Page;

namespace Adapter.Tests.Presenters.OrderPaginatedPresenterTests;

public abstract class OrderPaginatedPresenterTestsBase
{
    internal readonly Pagination<Order> _orderPagination;
    internal readonly OrderPaginatedPresenter _sut;

    protected OrderPaginatedPresenterTestsBase()
    {
        var orderItems = new List<OrderItem>
        {
            new OrderItem("menu-1", "Burger", ItemCategory.MainCourse, 10m, 2)
        };

        var order = new Order(
            id: "order-1",
            customerId: "cust-1",
            customerName: "John",
            items: orderItems,
            status: OrderStatus.Pending,
            payment: new Payment(),
            totalPrice: 20m);

        _orderPagination = new Pagination<Order>()
        {
            Page = 1,
            Size = 10,
            TotalCount = 1,
            TotalPages = 1,
            Items = new List<Order> { order }
        };

        _sut = new OrderPaginatedPresenter(_orderPagination);
    }
}
