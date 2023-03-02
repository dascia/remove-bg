namespace Removebg
{
  public class RemoveBackgroundParametersBuilder
  {
    private readonly RemoveBackgroundParameters _removeBgParameters;

    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveBackgroundParametersBuilder" /> class.
    /// </summary>
    public RemoveBackgroundParametersBuilder()
    {
      _removeBgParameters = new RemoveBackgroundParameters();
    }

    /// <summary>
    /// Whether to crop off all empty regions.
    /// </summary>
    /// <param name="crop">if set to <c>true</c> [crop].</param>
    /// <returns></returns>
    public RemoveBackgroundParametersBuilder SetCrop(bool crop)
    {
      _removeBgParameters.Crop = crop;
      return this;
    }

    /// <summary>
    /// Output image resolution.
    /// </summary>
    /// <param name="crop">if set to <c>true</c> [crop].</param>
    /// <returns></returns>
    public RemoveBackgroundParametersBuilder SetImageSize(ImageSize imageSize)
    {
      _removeBgParameters.ImageSize = imageSize;
      return this;
    }

    /// <summary>
    /// Detect kind of foreground.
    /// </summary>
    /// <param name="crop">if set to <c>true</c> [crop].</param>
    /// <returns></returns>
    public RemoveBackgroundParametersBuilder SetForegroundType(ForegroundType foregroundType)
    {
      _removeBgParameters.ForegroundType = foregroundType;
      return this;
    }

    /// <summary>
    /// Builds this instance.
    /// </summary>
    /// <returns></returns>
    public RemoveBackgroundParameters Build()
    {
      return _removeBgParameters;
    }
  }
}
