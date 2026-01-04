using System.ComponentModel;

namespace Business.Entities.Enums;
public enum PaymentMethod
{
    [Description("None")]
    None = 0,
    [Description("Pix")]
    Pix = 1,
}
