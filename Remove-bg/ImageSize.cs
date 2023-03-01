using System.ComponentModel;

namespace Removebg
{
  /// <summary>
  /// Enumeration to indicate the maximum output resolution when the background is removed from an image.
  /// </summary>
  public enum ImageSize
  {
    [Description("preview")]
    Preview,
    [Description("full")]
    Full,
    [Description("auto")]
    Auto
  }
}
