using Removebg.Responses;
using System.Drawing;

namespace Removebg.Test
{
  /// <summary>
  /// Remove bg client tests
  /// </summary>
  public class RemovebgClientTest
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RemovebgClientTest"/> class.
    /// </summary>
    public RemovebgClientTest()
    { }

    /// <summary>
    /// Removes the background.
    /// </summary>
    /// <param name="imagePath">The image path.</param>
    /// <param name="requestParameter">The request parameter.</param>
    [Theory]
    [MemberData(nameof(GetRemoveBackgroundParameters))]
    public async void RemoveBackgroundTest(string apiKey, string imagePath, RemoveBackgroundParameters requestParameter)
    {
      RemovebgClient client = new RemovebgClient(apiKey);
      RemoveBackgroundResponse removeBackgroundResponse = await client.RemoveBackground(imagePath, requestParameter);
      string imageNoBackground = Path.Combine(Path.GetDirectoryName(imagePath), "bgremoved.png");
      removeBackgroundResponse.Image.Save(imageNoBackground);
      Assert.NotNull(removeBackgroundResponse);
    }

    /// <summary>
    /// Removes the background.
    /// </summary>
    /// <param name="imagePath">The image path.</param>
    /// <param name="requestParameter">The request parameter.</param>
    [Theory]
    [MemberData(nameof(GetRemoveBackgroundParameters))]
    public async void RemoveBackgroundFromBitmapTest(string apiKey, string imagePath, RemoveBackgroundParameters requestParameter)
    {
      RemovebgClient client = new RemovebgClient(apiKey);
      Bitmap imageBitmap = new Bitmap(imagePath);
      RemoveBackgroundResponse removeBackgroundResponse = await client.RemoveBackground(imageBitmap, requestParameter);
      string imageNoBackground = Path.Combine(Path.GetDirectoryName(imagePath), "bitmap-bgremoved.png");
      removeBackgroundResponse.Image.Save(imageNoBackground);
      Assert.NotNull(removeBackgroundResponse);
    }

    /// <summary>
    /// Gets the remove background parameters.
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<object[]> GetRemoveBackgroundParameters()
    {
      yield return new object[]
      {
        "ogJz6xJFUeBJcsFZXR7CYhF2",
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