using System.ComponentModel;

namespace Business.Entities.Enums;
public enum OrderStatus
{
    [Description("None")]
    None = 0,
    [Description("Pending")]
    Pending = 1,
    [Description("Received")]
    Received = 2,
    [Description("InProgress")]
    InProgress = 3,
    [Description("Done")]
    Done = 4,
    [Description("Finished")]
    Finished = 5,
    [Description("Canceled")]
    Canceled = 6,
}
