using Adapter.Controllers;
using Adapter.Controllers.Interfaces;
using Adapter.Gateways.Clients;
using Adapter.Gateways.Logger;
using Adapter.Gateways.Repositories;
using Business.Gateways.Clients.Interfaces;
using Business.Gateways.Loggers.Interfaces;
using Business.Gateways.Repositories.Interfaces;
using Business.UseCases;
using Business.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Adapter;

[ExcludeFromCodeCoverage]
public static class AdapterExtensions
{
    public static IServiceCollection InjectAdapterDependencies(this IServiceCollection services)
    {
        return services
            .RegisterUseCases()
            .RegisterControllers()
            .RegisterGateways();
    }

    private static IServiceCollection RegisterUseCases(this IServiceCollection services)
    {

        return services
         .AddSingleton<IOrderUseCase, OrderUseCase>()
         .AddSingleton<IInventoryUseCase, InventoryUseCase>()
         .AddSingleton<IMenuItemUseCase, MenuItemUseCase>()
         .AddSingleton<ICustomerUseCase, CustomerUseCase>();

    }

    private static IServiceCollection RegisterControllers(this IServiceCollection services)
    {
        return services
             .AddSingleton<IOrderController, OrderController>()
             .AddSingleton<IMenuController, MenuController>();
    }

    public static IServiceCollection RegisterGateways(this IServiceCollection services)
    {
        services
            .AddSingleton<IInventoryLogger, InventoryLoggerGateway>()
            .AddSingleton<IOrderRepository, OrderGateway>()
            .AddSingleton<IMenuItemRepository, MenuItemGateway>()
            .AddSingleton<ICustomerClient, CustomerGateway>();

        return services;
    }
}
