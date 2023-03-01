using System;
using System.Collections.Generic;
using System.Net;

namespace Removebg.Exceptions
{
  internal class RemovebgAPIException : Exception
  {
    /// <summary>
    /// The http status code
    /// </summary>
    /// <value>
    /// The status code.
    /// </value>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// A collection of the errors returned from API.
    /// </summary>
    /// <value>
    /// The errors.
    /// </value>
    public IEnumerable<string> Errors { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RemovebgAPIException"/> class.
    /// </summary>
    public RemovebgAPIException()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="RemovebgAPIException"/> class.
    /// </summary>
    /// <param name="statusCode">The response status code.</param>
    /// <param name="errorMessages">The error messages.</param>
    public RemovebgAPIException(HttpStatusCode statusCode, IEnumerable<string> errorMessages)
    {
      StatusCode = statusCode;
      Errors = errorMessages;
    }
  }
}
