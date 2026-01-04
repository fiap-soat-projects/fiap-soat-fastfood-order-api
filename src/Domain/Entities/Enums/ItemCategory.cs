using System.ComponentModel;

namespace Business.Entities.Enums;

public enum ItemCategory
{
    [Description("None")]
    None = 0,
    [Description("MainCourse")]
    MainCourse = 1,
    [Description("SideDish")]
    SideDish = 2,
    [Description("Beverage")]
    Beverage = 3,
    [Description("Dessert")]
    Dessert = 4,
}
