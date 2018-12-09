using System;

namespace TeamworkProjects.Http
{
    /// <summary>
    /// custom exception for handling bad queries
    /// </summary>
    public class InvalidQueryException : Exception
    {
        /// <summary>
        /// init exception with general message - 
        /// you should probably use one of the other
        /// constructors for a more meaninful exception.
        /// </summary>
        public InvalidQueryException()
            : this("Invalid query: reason not specified.", null) { }

        /// <summary>
        /// init exception with custom message
        /// </summary>
        /// <param name="message">message to display</param>
        public InvalidQueryException(string message)
            : base(message, null) { }

        /// <summary>
        /// init exception with custom message and chain to originating exception
        /// </summary>
        /// <param name="message">custom message</param>
        /// <param name="inner">originating exception</param>
        public InvalidQueryException(string message, Exception inner)
            : base(message, inner) { }
    }
}