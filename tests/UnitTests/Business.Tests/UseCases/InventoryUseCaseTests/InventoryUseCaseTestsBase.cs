using Business.Gateways.Loggers.Interfaces;
using Business.UseCases;
using NSubstitute;

namespace Business.Tests.UseCases.InventoryUseCaseTests;

public abstract class InventoryUseCaseTestsBase
{
    internal readonly IInventoryLogger _inventoryLogger;
    internal readonly InventoryUseCase _sut;

    protected InventoryUseCaseTestsBase()
    {
        _inventoryLogger = Substitute.For<IInventoryLogger>();

        _sut = new InventoryUseCase(_inventoryLogger);
    }
}
