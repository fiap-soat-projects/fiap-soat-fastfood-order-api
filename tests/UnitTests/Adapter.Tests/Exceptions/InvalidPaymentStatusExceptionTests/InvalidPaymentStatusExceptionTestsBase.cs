using Adapter.Exceptions;

namespace Adapter.Tests.Exceptions.InvalidPaymentStatusExceptionTests;

public abstract class InvalidPaymentStatusExceptionTestsBase
{
    internal readonly string _status = "InvalidStatus";
    internal readonly InvalidPaymentStatusException _sut;

    protected InvalidPaymentStatusExceptionTestsBase()
    {
        _sut = new InvalidPaymentStatusException(_status);
    }
}
