using System.Drawing;
using System.Drawing.Imaging;

namespace Removebg.Extensions
{
  internal static class BitmapExtensions
  {
    /// <summary>
    /// Detect the image format from a bitmap object.
    /// </summary>
    /// <param name="bitmap">The bitmap.</param>
    /// <returns></returns>
    public static ImageFormat GetImageFormat(this Bitmap bitmap)
    {
      ImageFormat img = bitmap.RawFormat;
      if (img.Equals(ImageFormat.Jpeg))
        return ImageFormat.Jpeg;
      if (img.Equals(ImageFormat.Bmp))
        return ImageFormat.Bmp;
      if (img.Equals(ImageFormat.Png))
        return ImageFormat.Png;
      if (img.Equals(ImageFormat.Emf))
        return ImageFormat.Emf;
      if (img.Equals(ImageFormat.Exif))
        return ImageFormat.Exif;
      if (img.Equals(ImageFormat.Gif))
        return ImageFormat.Gif;
      if (img.Equals(ImageFormat.Icon))
        return ImageFormat.Icon;
      if (img.Equals(ImageFormat.MemoryBmp))
        return ImageFormat.MemoryBmp;
      if (img.Equals(ImageFormat.Tiff))
        return ImageFormat.Tiff;
      else
        return ImageFormat.Wmf;
    }
  }
}
