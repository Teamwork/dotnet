using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TeamworkProjects.Security;
using TeamworkProjects.Utilities;

namespace TeamworkProjects
{
    /// <summary>
    /// Members for communicating with Twitter
    /// </summary>
    public interface ITeamworkHandler
    {
        /// <summary>
        /// Gets or sets the object that can send authorized requests to Twitter.
        /// </summary>
        IAuthorization Authorizer { get; set; }

        /// <summary>
        /// Gets the most recent URL executed
        /// </summary>
        /// <remarks>
        /// This is very useful for debugging
        /// </remarks>
        Uri LastUrl { get; }

        /// <summary>
        /// list of response headers from query
        /// </summary>
        IDictionary<string, string> ResponseHeaders { get; set; }

        /// <summary>
        /// Gets and sets HTTP UserAgent header
        /// </summary>
        string UserAgent { get; set; }

        /// <summary>
        /// Timeout (milliseconds) for writing to request 
        /// stream or reading from response stream
        /// </summary>
        int ReadWriteTimeout { get; set; }

        /// <summary>
        /// Timeout (milliseconds) to wait for a server response
        /// </summary>
        int Timeout { get; set; }

        Task<string> SendAsJsonAsync<T>(string method, string url, IDictionary<string, string> postData, T postObj, CancellationToken cancelToken);

        Task<string> SendFormURlEncoded<T>(string method, string url, IDictionary<string, string> postData, CancellationToken cancelToken);

        Task<string> PostFileAsync(string url, IDictionary<string, string> postData, byte[] data, string name, string fileName, string contentType, CancellationToken cancelToken);

        Task<string> QueryTeamworkAsync<T>(Request req, IRequestProcessor<T> reqProc);

        /// <summary>
        /// Set to true to close stream, false means stream is still open
        /// </summary>
        bool IsStreamClosed { get; }

        /// <summary>
        /// Allows callers to cancel operation (where applicable)
        /// </summary>
        CancellationToken CancellationToken { get; set; }

    }
}