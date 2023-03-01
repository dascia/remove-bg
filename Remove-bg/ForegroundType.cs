using System.ComponentModel;

namespace Removebg
{
  /// <summary>
  /// Indicates the kind of foreground.
  /// </summary>
  public enum ForegroundType
  {
    [Description("auto")]
    Auto,
    [Description("person")]
    Person,
    [Description("product")]
    Product
  }
}
