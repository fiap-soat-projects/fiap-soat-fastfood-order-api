using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Exceptions;

public class InvalidPaymentStatusException : Exception
{
    private const string DEFAULT_MESSAGE = "The payment status '{0}' is invalid.";

    public InvalidPaymentStatusException(string status)
        : base(string.Format(DEFAULT_MESSAGE, status))
    {
    }
}
