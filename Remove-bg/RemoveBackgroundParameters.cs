using System.ComponentModel;

namespace Removebg
{
  public class RemoveBackgroundParameters
  {
    /// <summary>
    /// Maximum output image resolution.
    /// </summary>
    /// <value>
    /// The size of the image.
    /// </value>
    [Description("size")]
    public ImageSize ImageSize { get; set; }

    /// <summary>
    /// Type of foreground.
    /// </summary>
    /// <value>
    /// The type of the foreground.
    /// </value>
    [Description("type")]
    public ForegroundType ForegroundType { get; set; }

    /// <summary>
    /// Whether to crop off all empty regions.
    /// </summary>
    /// <value>
    ///   <c>true</c> if crop; otherwise, <c>false</c>.
    /// </value>
    [Description("crop")]
    public bool Crop { get; set; }
  }
}
