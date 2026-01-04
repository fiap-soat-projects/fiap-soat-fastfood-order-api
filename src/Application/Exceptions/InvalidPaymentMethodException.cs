namespace Adapter.Exceptions;

public class InvalidPaymentMethodException : Exception
{
    private const string DEFAULT_MESSAGE = "The payment method '{0}' is invalid.";

    public InvalidPaymentMethodException(string method)
        : base(string.Format(DEFAULT_MESSAGE, method))
    {
    }
}
