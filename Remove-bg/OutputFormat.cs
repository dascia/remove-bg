using System.ComponentModel;

namespace Removebg
{

  /// <summary>
  /// Enumeration to indicate the result image format.
  /// </summary>
  public enum OutputFormat
  {
    [Description("png")]
    PNG,
    [Description("jpg")]
    JPG,
    [Description("zip")]
    ZIP
  }
}
