using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Removebg.CustomConverters
{
  internal class Base64ToBitmapConverter : JsonConverter
  {
    /// <summary>
    /// Determines whether this instance can convert the specified object type.
    /// </summary>
    /// <param name="objectType">Type of the object.</param>
    /// <returns>
    /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public override bool CanConvert(Type objectType)
    {
      return true;
    }

    /// <summary>
    /// Reads the JSON representation of the object.
    /// </summary>
    /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
    /// <param name="objectType">Type of the object.</param>
    /// <param name="existingValue">The existing value of object being read.</param>
    /// <param name="serializer">The calling serializer.</param>
    /// <returns>
    /// The object value.
    /// </returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      string imageBase64 = (string)reader.Value;
      byte[] byteBuffer = Convert.FromBase64String(imageBase64);
      MemoryStream memoryStream = new MemoryStream(byteBuffer);
      memoryStream.Position = 0;
      Bitmap bitmap = new Bitmap(memoryStream);
      return bitmap;
    }

    /// <summary>
    /// Writes the JSON representation of the object.
    /// </summary>
    /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
    /// <param name="value">The value.</param>
    /// <param name="serializer">The calling serializer.</param>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      Bitmap bitmap = (Bitmap)value;
      using (MemoryStream ms = new MemoryStream())
      {
        ImageFormat imageFormat = GetImageFormat(bitmap);
        bitmap.Save(ms, imageFormat);
        byte[] imageFile = ms.ToArray();
        string imageBase64 = Convert.ToBase64String(imageFile);
        writer.WriteValue(imageBase64);
      }
    }

    /// <summary>
    /// Detect the image format from a bitmap object.
    /// </summary>
    /// <param name="bitmap">The bitmap.</param>
    /// <returns></returns>
    public static ImageFormat GetImageFormat(Bitmap bitmap)
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
