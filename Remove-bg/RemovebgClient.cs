using Removebg.Exceptions;
using Removebg.Extensions;
using Removebg.Responses;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System;

namespace Removebg
{
  public class RemovebgClient
  {
    /// <summary>
    /// The HTTP client used for all the requests.
    /// </summary>
    private readonly HttpClient _httpClient;

    /// <summary>
    /// The Remove.bg API key.
    /// </summary>
    private readonly string _apiKey;

    /// <summary>
    /// Initializes a new instance of the <see cref="RemovebgClient"/> class.
    /// </summary>
    public RemovebgClient(string apiKey)
    {
      if (apiKey == null) throw new ArgumentNullException("Api key can't be null.");
      _apiKey = apiKey;
      _httpClient = new HttpClient();
    }

    /// <summary>
    /// Removes the image background.
    /// </summary>
    /// <param name="imagePath">The image path.</param>
    /// <param name="parameters">The removal background parameters.</param>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException">The image to be uploaded was not found in the path specified.</exception>
    /// <exception cref="HttpRequestException">Problems communicating with the api server.</exception>
    /// <exception cref="RemovebgAPIException">It is fired when the API returns an error.</exception>
    public async Task<RemoveBackgroundResponse> RemoveBackground(string imagePath, RemoveBackgroundParameters parameters)
    {
      string urlRequestAddress = $"{Endpoints.Server}{Endpoints.BackgroundRemoval}";
      MultipartFormDataContent formDataContent = new MultipartFormDataContent
      {
        { new ByteArrayContent(File.ReadAllBytes(imagePath)), "image_file", "file.jpg" },
        { new StringContent(parameters.ImageSize.GetDescription()), "size" },
        { new StringContent(parameters.ForegroundType.GetDescription()), "type" },
        { new StringContent(parameters.Crop.ToString()), "crop" }
      };
      RemoveBackgroundResponse bgRemovalResponse = await Send<RemoveBackgroundResponse>(urlRequestAddress, formDataContent);
      return bgRemovalResponse;
    }

    /// <summary>
    /// Removes the image background.
    /// </summary>
    /// <param name="imagePath">The image path.</param>
    /// <param name="parameters">The removal background parameters.</param>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException">The image to be uploaded was not found in the path specified.</exception>
    /// <exception cref="HttpRequestException">Problems communicating with the api server.</exception>
    /// <exception cref="RemovebgAPIException">It is fired when the API returns an error.</exception>
    public async Task<RemoveBackgroundResponse> RemoveBackground(Bitmap bitmap, RemoveBackgroundParameters parameters)
    {
      using (MemoryStream ms = new MemoryStream())
      {
        ImageFormat imageFormat = bitmap.GetImageFormat();
        if (imageFormat == ImageFormat.MemoryBmp)
        {
          ImageCodecInfo codec = ImageCodecInfo.GetImageEncoders().First(_ => _.FormatID == ImageFormat.Jpeg.Guid);
          Encoder qualityEncoder = Encoder.Quality;
          EncoderParameters encoderParams = new EncoderParameters(1);
          encoderParams.Param[0] = new EncoderParameter(qualityEncoder, 100L);
          bitmap.Save(ms, codec, encoderParams);
        }
        else bitmap.Save(ms, imageFormat);
        byte[] bitmapBytes = ms.ToArray();
        string urlRequestAddress = $"{Endpoints.Server}{Endpoints.BackgroundRemoval}";
        MultipartFormDataContent formDataContent = new MultipartFormDataContent
        {
          { new ByteArrayContent(bitmapBytes), "image_file", "file.jpg" },
          { new StringContent(parameters.ImageSize.GetDescription()), "size" },
          { new StringContent(parameters.ForegroundType.GetDescription()), "type" },
          { new StringContent(parameters.Crop.ToString()), "crop" }
        };
        RemoveBackgroundResponse bgRemovalResponse = await Send<RemoveBackgroundResponse>(urlRequestAddress, formDataContent);
        return bgRemovalResponse;
      }
    }

    /// <summary>
    /// Sends a post request to the specified endpoint.
    /// </summary>
    /// <param name="requestUri">The url to make the request.</param>
    /// <param name="content">The request content.</param>
    /// <returns></returns>
    private async Task<T> Send<T>(string requestUri, MultipartFormDataContent content)
    {
      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUri);
      request.Headers.TryAddWithoutValidation("X-Api-Key", _apiKey);
      request.Headers.TryAddWithoutValidation("accept", "application/json");
      request.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data");
      request.Content = content;
      HttpResponseMessage response = await _httpClient.SendAsync(request);
      if (response.StatusCode == HttpStatusCode.NotFound) throw new HttpRequestException("Resource not found");
      string jsonResponse = await response.Content.ReadAsStringAsync();
      JObject responseObject = JObject.Parse(jsonResponse);
      if (response.IsSuccessStatusCode)
      {
        T responseConcreteType = responseObject["data"].ToObject<T>();
        return responseConcreteType;
      }
      else
      {
        JArray errorsTokens = responseObject["errors"].Value<JArray>();
        IList<string> errors = new List<string>();
        foreach (JToken errorToken in errorsTokens)
        {
          JObject errorObject = errorToken.ToObject<JObject>();
          errors.Add(errorObject["title"].Value<string>());
        }
        throw new RemovebgAPIException(response.StatusCode, errors);
      }
    }
  }
}
