using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LinqToTwitter;
using TeamworkProjects.Model.V1;
using TeamworkProjects.Requests.V1;
using TeamworkProjects.Security;
using TeamworkProjects.Utilities;
using TeamworkProjects.Utilities.Linq;

namespace TeamworkProjects
{
    /// <summary>
    /// Access Teamwork Projects API
    /// </summary>
    public partial class TeamworkProjectsContext : IDisposable
    {
        internal const string XRateLimitLimitKey = "x-rate-limit-limit";
        internal const string XRateLimitRemainingKey = "x-rate-limit-remaining";
        internal const string XRateLimitResetKey = "x-rate-limit-reset";
        internal const string RetryAfterKey = "Retry-After";
        internal const string XMediaRateLimitLimitKey = "x-mediaratelimit-limit";
        internal const string XMediaRateLimitRemainingKey = "x-mediaratelimit-remaining";
        internal const string XMediaRateLimitResetKey = "x-mediaratelimit-reset";
        internal const string DateKey = "Date";

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamworkProjectsContext" /> class.
        /// </summary>
        /// <param name="authorizer">The authorizer.</param>
        /// <param name="rootUrl">the teamwork installation root</param>
        public TeamworkProjectsContext(IAuthorization authorizer, Uri rootUrl) : this(new TeamworkProjectsHandler(authorizer),rootUrl){}

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamworkProjectsContext" /> class.
        /// </summary>
        /// <param name="handler">The <see cref="ITeamworkHandler" /> object to use.</param>
        public TeamworkProjectsContext(ITeamworkHandler handler, Uri rootUrl)
        {
            Handler = handler ?? throw new ArgumentNullException(nameof(handler), "Executor is required.");

            if (string.IsNullOrWhiteSpace(UserAgent)) UserAgent = "TWP_CCoreSDK";
            BaseUrl = rootUrl.ToString();
        }

        /// <summary>
        /// Customer Base URL
        /// </summary>
        public string BaseUrl { get; set; }


        /// <summary>
        /// Assign the Log to the context
        /// </summary>
        public TextWriter Log
        {
            get => TeamworkProjectsHandler.Log;
            set => TeamworkProjectsHandler.Log = value;
        }

        /// <summary>
        /// This contains the JSON string from the response to the recent query.
        /// </summary>
        public string RawResult { get; set; }

        public bool ExcludeRawJson { get; set; }


        /// <summary>
        /// Gets and sets HTTP UserAgent header
        /// </summary>
        public string UserAgent
        {
            get => Handler != null ? Handler.UserAgent : string.Empty;
            set
            {
                if (Handler != null)
                    Handler.UserAgent = value;
                if (Authorizer != null)
                    Authorizer.UserAgent = value;
            }
        }

        /// <summary>
        /// Gets or sets the read write timeout.
        /// </summary>
        /// <value>The read write timeout.</value>
        public int ReadWriteTimeout
        {
            get => Handler?.ReadWriteTimeout ?? TeamworkProjectsHandler.DefaultReadWriteTimeout;
            set
            {
                if (Handler != null) Handler.ReadWriteTimeout = value;
            }
        }

        /// <summary>
        ///     Gets and sets HTTP UserAgent header
        /// </summary>
        public int Timeout
        {
            get => Handler?.Timeout ?? TeamworkProjectsHandler.DefaultTimeout;
            set
            {
                if (Handler != null) Handler.Timeout = value;
            }
        }

        /// <summary>
        ///     Gets or sets the authorized client on the <see cref="ITwitterExecute" /> object.
        /// </summary>
        public IAuthorization Authorizer
        {
            get => Handler.Authorizer;
            set => Handler.Authorizer = value;
        }

        /// <summary>
        ///     Gets the most recent URL executed.
        /// </summary>
        /// <remarks>
        ///     Supports debugging.
        /// </remarks>
        public Uri LastUrl => Handler.LastUrl;

        /// <summary>
        ///     Methods for communicating with Twitter.
        /// </summary>
        internal ITeamworkHandler Handler { get; set; }

        /// <summary>
        ///     Response headers from Twitter Queries
        /// </summary>
        public IDictionary<string, string> ResponseHeaders => Handler?.ResponseHeaders;

        /// <summary>
        ///     Max number of requests per minute
        ///     returned by the most recent query
        /// </summary>
        /// <remarks>
        ///     Returns -1 if information isn't available,
        ///     i.e. you haven't performed a query yet
        /// </remarks>
        public int RateLimitCurrent => GetResponseHeaderAsInt(XRateLimitLimitKey);

        /// <summary>
        ///     Number of requests available until reset
        ///     returned by the most recent query
        /// </summary>
        /// <remarks>
        ///     Returns -1 if information isn't available,
        ///     i.e. you haven't performed a query yet
        /// </remarks>
        public int RateLimitRemaining => GetResponseHeaderAsInt(XRateLimitRemainingKey);

        /// <summary>
        ///     UTC time in ticks until rate limit resets
        ///     returned by the most recent query
        /// </summary>
        /// <remarks>
        ///     Returns -1 if information isn't available,
        ///     i.e. you haven't performed a query yet
        /// </remarks>
        public int RateLimitReset => GetResponseHeaderAsInt(XRateLimitResetKey);

        /// <summary>
        ///     UTC time in ticks until rate limit resets
        ///     returned by the most recent search query
        ///     that fails with an HTTP 503
        /// </summary>
        /// <remarks>
        ///     Returns -1 if information isn't available,
        ///     i.e. you haven't exceeded search rate yet
        /// </remarks>
        public int RetryAfter => GetResponseHeaderAsInt(RetryAfterKey);

        /// <summary>
        ///     Max number of requests per window for
        ///     TweetWithMediaAsync and ReplyWithMediaAsync.
        /// </summary>
        public int MediaRateLimitCurrent => GetResponseHeaderAsInt(XMediaRateLimitLimitKey);

        /// <summary>
        ///     Number of requests available until reset
        ///     for TweetWithMediaAsync and ReplyWithMediaAsync.
        /// </summary>
        public int MediaRateLimitRemaining => GetResponseHeaderAsInt(XMediaRateLimitRemainingKey);

        /// <summary>
        ///     UTC time in ticks until rate limit resets
        ///     for TweetWithMediaAsync and ReplyWithMediaAsync.
        /// </summary>
        public int MediaRateLimitReset => GetResponseHeaderAsInt(XMediaRateLimitResetKey);

        /// <summary>
        ///     Gets the response header Date and converts to a nullable-DateTime
        /// </summary>
        /// <remarks>
        ///     Returns null if the headers don't contain a valid Date value
        ///     i.e. you haven't performed a query yet or not convertable
        /// </remarks>
        public DateTime? TwitterDate => GetResponseHeaderAsDateTime(DateKey);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     retrieves a specified response header, converting it to an int
        /// </summary>
        /// <param name="responseHeader">Response header to retrieve.</param>
        /// <returns>int value from response</returns>
        private int GetResponseHeaderAsInt(string responseHeader)
        {
            var headerVal = -1;
            var headers = ResponseHeaders;

            if (headers == null || !headers.ContainsKey(responseHeader)) return headerVal;
            var headerValAsString = headers[responseHeader];

            int.TryParse(headerValAsString, out headerVal);

            return headerVal;
        }

        /// <summary>
        ///     retrieves a specified response header, converting it to a DateTime
        /// </summary>
        /// <param name="responseHeader">Response header to retrieve.</param>
        /// <returns>DateTime value from response</returns>
        /// <remarks>Expects a string like: Sat, 26 Feb 2011 01:12:08 GMT</remarks>
        private DateTime? GetResponseHeaderAsDateTime(string responseHeader)
        {
            DateTime? headerVal = null;
            var headers = ResponseHeaders;

            if (headers != null &&
                headers.ContainsKey(responseHeader))
            {
                var headerValAsString = headers[responseHeader];

                if (DateTime.TryParse(headerValAsString,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal,
                    out var value))
                    headerVal = value;
            }

            return headerVal;
        }

        /// <summary>
        ///     Called by QueryProvider to execute queries
        /// </summary>
        /// <param name="expression">ExpressionTree to parse</param>
        /// <param name="isEnumerable">Indicates whether expression is enumerable</param>
        /// <returns>list of objects with query results</returns>
        public virtual async Task<object> ExecuteAsync<T>(Expression expression, bool isEnumerable)
            where T : class
        {
            // request processor is specific to request type (i.e. Status, User, etc.)
            var reqProc = CreateRequestProcessor<T>(expression);

            // get input parameters that go on the REST query URL
            var parameters = GetRequestParameters(expression, reqProc);

            // construct REST endpoint, based on input parameters
            var request = reqProc.BuildUrl(parameters);

            string results;

            results = await Handler.QueryTeamworkAsync(request, reqProc).ConfigureAwait(false);

            if (!ExcludeRawJson)
                RawResult = results;

            // Transform results into objects
            var queryableList = reqProc.ProcessResults(results);

            // Copy the IEnumerable entities to an IQueryable.
            var queryableItems = queryableList.AsQueryable();

            var treeCopier = new ExpressionTreeModifier<T>(queryableItems);
            var newExpressionTree = treeCopier.CopyAndModify(expression);

            // This step creates an IQueryable that executes by replacing Queryable methods with Enumerable methods.
            return isEnumerable
                ? queryableItems.Provider.CreateQuery(newExpressionTree)
                : queryableItems.Provider.Execute<object>(newExpressionTree);
        }

        /// <summary>
        ///     Search the where clause for query parameters
        /// </summary>
        /// <param name="expression">Input query expression tree</param>
        /// <param name="reqProc">Processor specific to this request type</param>
        /// <returns>Name/value pairs of query parameters</returns>
        private static Dictionary<string, string> GetRequestParameters<T>(Expression expression,
            IRequestProcessor<T> reqProc)
        {
            var parameters = new Dictionary<string, string>();

            // GHK FIX: Handle all wheres
            var whereExpressions = new WhereClauseFinder().GetAllWheres(expression);
            foreach (var whereExpression in whereExpressions)
            {
                var lambdaExpression = (LambdaExpression) ((UnaryExpression) whereExpression.Arguments[1]).Operand;

                // translate variable references in expression into constants
                lambdaExpression = (LambdaExpression) Evaluator.PartialEval(lambdaExpression);

                var newParameters = reqProc.GetParameters(lambdaExpression);
                foreach (var newParameter in newParameters)
                    if (!parameters.ContainsKey(newParameter.Key))
                        parameters.Add(newParameter.Key, newParameter.Value);
            }

            return parameters;
        }

        protected internal virtual IRequestProcessor<T> CreateRequestProcessor<T>()
            where T : class
        {
            var requestType = typeof(T).Name;

            var req = CreateRequestProcessor<T>(requestType);

            return req;
        }

        /// <summary>
        /// TestMethodory method for returning a request processor
        /// </summary>
        /// <typeparam name="T">type of request</typeparam>
        /// <returns>request processor matching type parameter</returns>
        internal IRequestProcessor<T> CreateRequestProcessor<T>(Expression expression)
            where T : class
        {
            if (expression == null)
            {
                const string nullExpressionMessage = "Expression passed to CreateRequestProcessor must not be null.";
                throw new ArgumentNullException(nameof(expression), nullExpressionMessage);
            }

            var requestType = new MethodCallExpressionTypeFinder().GetGenericType(expression).Name;

            var req = CreateRequestProcessor<T>(requestType);
            return req;
        }

        protected internal IRequestProcessor<T> CreateRequestProcessor<T>(string requestType)
            where T : class
        {
            var baseUrl = BaseUrl;
            IRequestProcessor<T> req;

            switch (requestType)
            {
                case nameof(Project):
                    req = new ProjectsRequestProcessor<T>();
                    break;
                default:
                    throw new ArgumentException($"Type, {requestType} isn't supported.", nameof(requestType));
            }

            if (baseUrl != null)
                req.BaseUrl = baseUrl;

            return req;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (Handler is IDisposable disposableExecutor)
                    disposableExecutor.Dispose();
        }
    }
}