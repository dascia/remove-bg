namespace Removebg.Test
{
  /// <summary>
  /// Remove bg client tests
  /// </summary>
  public class RemovebgClientTest
  {
    /// <summary>
    /// The removebg client
    /// </summary>
    private RemovebgClient _removebgClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="RemovebgClientTest"/> class.
    /// </summary>
    public RemovebgClientTest()
    {
      _removebgClient = new RemovebgClient("ogJz6xJFUeBJcsFZXR7CYhF2");
    }

    /// <summary>
    /// Removes the background.
    /// </summary>
    /// <param name="imagePath">The image path.</param>
    /// <param name="requestParameter">The request parameter.</param>
    [Theory]
    [MemberData(nameof(GetRemoveBackgroundParameters))]
    public async void RemoveBackground(string imagePath, RemoveBackgroundParameters requestParameter)
    {
      await _removebgClient.RemoveBackground(imagePath, requestParameter);
    }

    /// <summary>
    /// Gets the remove background parameters.
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<object[]> GetRemoveBackgroundParameters()
    {
      yield return new object[]
      {
        @"C:\Users\dascia\Desktop\test_image.jpg", 
        new RemoveBackgroundParameters()
        {
          Crop  = true,
          ImageSize = ImageSize.Preview,
          ForegroundType = ForegroundType.Person
        }
      };
    }
  }
}