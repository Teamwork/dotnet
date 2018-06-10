using System;
using System.Net;
using System.Net.Http.Headers;

namespace Teamwork.Response
{
  /// <summary>
  /// The service response.
  /// </summary>
  /// <typeparam name="T">
  /// Type of DTO to expect from service
  /// </typeparam>
  public class BaseResponse<T>
  {
    /// <summary>
    /// Gets the status code.
    /// </summary>
    public HttpStatusCode StatusCode { get; private set; }

    public HttpHeaders Headers { get; set; }


    /// <summary>
    /// Gets the value.
    /// </summary>
    public T Value { get; set; }

    /// <summary>
    /// Gets the content.
    /// </summary>
    public string Content { get; set; }


    /// <summary>
    /// Gets the content as Object
    /// </summary>
    public object ContentObj { get; set; }

    /// <summary>
    /// Gets the error.
    /// </summary>
    public Exception Error { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseResponse{T}"/> class.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    /// <param name="statusCode">
    /// The status code.
    /// </param>
    public BaseResponse(T value, HttpStatusCode statusCode)
    {
      this.Value = value;
      this.StatusCode = statusCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseResponse{T}"/> class.
    /// </summary>
    /// <param name="statusCode">
    /// The status code.
    /// </param>
    /// <param name="error">
    /// The error.
    /// </param>
    public BaseResponse(HttpStatusCode statusCode, Exception error = null)
    {
      this.StatusCode = statusCode;
      this.Error = error;
    }
  }
}
