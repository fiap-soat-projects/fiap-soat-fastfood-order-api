using Adapter.Exceptions;

namespace Adapter.Tests.Exceptions.InvalidPaymentMethodExceptionTests;

public abstract class InvalidPaymentMethodExceptionTestsBase
{
    internal readonly string _method = "InvalidMethod";
    internal readonly InvalidPaymentMethodException _sut;

    protected InvalidPaymentMethodExceptionTestsBase()
    {
        _sut = new InvalidPaymentMethodException(_method);
    }
}
