using Newtonsoft.Json;
using Removebg.CustomConverters;
using System.Drawing;

namespace Removebg.Responses
{
  /// <summary>
  /// Response returned from API for backgroung remove request.
  /// </summary>
  public class RemoveBackgroundResponse
  {
    /// <summary>
    /// Image with the background removed.
    /// </summary>
    /// <value>
    /// The image.
    /// </value>
    [JsonConverter(typeof(Base64ToBitmapConverter))]
    [JsonProperty(PropertyName = "result_b64")]
    public Bitmap Image { get; set; }

    /// <summary>
    /// Gets or sets the foreground top relative to the original image dimensions.
    /// </summary>
    /// <value>
    /// The foreground top.
    /// </value>
    [JsonProperty(PropertyName = "foreground_top")]
    public int ForegroundTop { get; set; }

    /// <summary>
    /// Gets or sets the foreground left relative to the original image dimensions.
    /// </summary>
    /// <value>
    /// The foreground left.
    /// </value>
    [JsonProperty(PropertyName = "foreground_left")]
    public int ForegroundLeft { get; set; }

    /// <summary>
    /// Gets or sets the width of the foreground object.
    /// </summary>
    /// <value>
    /// The width of the foregroung.
    /// </value>
    [JsonProperty(PropertyName = "foreground_width")]
    public int ForegroundWidth { get; set; }

    /// <summary>
    /// Gets or sets the height of the foreground object.
    /// </summary>
    /// <value>
    /// The height of the foreground.
    /// </value>
    [JsonProperty(PropertyName = "foreground_height")]
    public int ForegroundHeight { get; set; }
  }
}
