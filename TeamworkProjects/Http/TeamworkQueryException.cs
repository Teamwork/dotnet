using System;
using System.Net;

namespace TeamworkProjects.Http
{
    public class TeamworkQueryException : InvalidQueryException
    {
        /// <summary>
        /// init exception with general message - 
        /// you should probably use one of the other
        /// constructors for a more meaninful exception.
        /// </summary>
        public TeamworkQueryException()
            : this("Twitter returned an error from your query.", null) { }

        /// <summary>
        /// init exception with custom message
        /// </summary>
        /// <param name="message">message to display</param>
        public TeamworkQueryException(string message)
            : base(message, null) { }

        /// <summary>
        /// init exception with custom message and chain to originating exception
        /// </summary>
        /// <param name="message">custom message</param>
        /// <param name="inner">originating exception</param>
        public TeamworkQueryException(string message, Exception inner)
            : base(message, inner) { }

        /// <summary>
        /// Error code assigned by Twitter
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Http status code from Twitter response
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Http status reason from Twitter response
        /// </summary>
        public string ReasonPhrase { get; set; }
    }
}