using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamworkProjects.Common;
using TeamworkProjects.Http;
using TeamworkProjects.Security;
using TeamworkProjects.Utilities;

namespace TeamworkProjects
{

    internal partial class TeamworkProjectsHandler : ITeamworkHandler, IDisposable
    {

        internal const int DefaultReadWriteTimeout = 300000;
        internal const int DefaultTimeout = 100000;

        public TeamworkProjectsHandler(IAuthorization authorizer)
        {
            Authorizer = authorizer ?? throw new ArgumentNullException("authorizedClient");
            Authorizer.UserAgent = Authorizer.UserAgent ?? "TWP_C#SDK_1.0";
        }

        internal void SetAuthorizationHeader(string method, string url, IDictionary<string, string> parms, HttpRequestMessage req)
        {
            var authStringParms = parms.ToDictionary(parm => parm.Key, elm => elm.Value);
            authStringParms.Add("oauth_consumer_key", Authorizer.CredentialStore.ConsumerKey);
            authStringParms.Add("oauth_token", Authorizer.CredentialStore.OAuthToken);

            string authorizationString = Authorizer.GetAuthorizationString(method, url, authStringParms);

            req.Headers.Add("Authorization", authorizationString);
        }




        public async Task<string> SendAsJsonAsync<T>(string method, string url, IDictionary<string, string> postData, T postObj, CancellationToken cancelToken)
        {
            WriteLog(url, nameof(SendAsJsonAsync));

            var postJson = postObj == null ? "" : JsonConvert.SerializeObject(postObj, new DefaultJsonSerializer());
            var content = new StringContent(postJson, Encoding.UTF8, "application/json");

            var cleanPostData = postData.Where(pair => pair.Value != null).ToDictionary(pair => pair.Key, pair => pair.Value);
            var handler = new PostMessageHandler(this, cleanPostData, url);

            using (var client = new HttpClient(handler))
            {
                if (Timeout != 0)
                    client.Timeout = new TimeSpan(0, 0, 0, Timeout);

                HttpResponseMessage msg;

                if (method == HttpMethod.Post.ToString())
                    msg = await client.PostAsync(url, content, CancellationToken).ConfigureAwait(false);
                else if (method == HttpMethod.Delete.ToString())
                    msg = await client.DeleteAsync(url, cancelToken).ConfigureAwait(false);
                else
                    msg = await client.PutAsync(url, content, cancelToken).ConfigureAwait(false);

                return await HandleResponseAsync(msg);
            }
        }

        public async Task<string> SendFormURlEncoded<T>(string method, string url, IDictionary<string, string> postData, CancellationToken cancelToken)
        {
            WriteLog(url, nameof(SendFormURlEncoded));

            var cleanPostData = new Dictionary<string, string>();

            var dataString = new StringBuilder();

            foreach (var pair in postData)
            {
                if (pair.Value != null)
                {
                    dataString.AppendFormat("{0}={1}&", pair.Key, Url.PercentEncode(pair.Value));
                    cleanPostData.Add(pair.Key, pair.Value);
                }
            }

            var content = new StringContent(dataString.ToString().TrimEnd('&'), Encoding.UTF8, "application/x-www-form-urlencoded");
            var handler = new PostMessageHandler(this, cleanPostData, url);
            using (var client = new HttpClient(handler))
            {
                if (Timeout != 0)
                    client.Timeout = new TimeSpan(0, 0, 0, Timeout);

                HttpResponseMessage msg;
                if (method == HttpMethod.Delete.ToString())
                    msg = await client.DeleteAsync(url, CancellationToken).ConfigureAwait(false);
                else
                    msg = await client.PostAsync(url, content, CancellationToken).ConfigureAwait(false);

                return await HandleResponseAsync(msg);
            }
        }

        public async Task<string> PostFileAsync(string url, IDictionary<string, string> postData, byte[] data, string name, string fileName, string contentType,
            CancellationToken cancelToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string> QueryTeamworkAsync<T>(Request req, IRequestProcessor<T> reqProc)
        {
            throw new NotImplementedException();
        }


        HttpRequestMessage ConfigureRequest(Request request)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, request.Endpoint);

            var parameters =
                string.Join("&",
                    (from parm in request.RequestParameters
                        select parm.Name + "=" + Url.PercentEncode(parm.Value))
                    .ToList());
            var content = new StringContent(parameters, Encoding.UTF8, "application/x-www-form-urlencoded");
            httpRequest.Content = content;

            var parms = request.RequestParameters
                .ToDictionary(
                    key => key.Name,
                    val => val.Value);
            SetAuthorizationHeader(HttpMethod.Post.ToString(), request.FullUrl, parms, httpRequest);
            httpRequest.Headers.Add("User-Agent", UserAgent);
            httpRequest.Headers.ExpectContinue = false;

            if (Authorizer.SupportsCompression)
                httpRequest.Headers.AcceptEncoding.TryParseAdd("gzip");

            return httpRequest;
        }


        async Task<string> HandleResponseAsync(HttpResponseMessage msg)
        {
            LastUrl = msg.RequestMessage.RequestUri;

            ResponseHeaders =
                (from header in msg.Headers
                    select new
                    {
                        header.Key,
                        Value = string.Join(", ", header.Value)
                    })
                .ToDictionary(
                    pair => pair.Key,
                    pair => pair.Value);

            await TeamworkErrorHandler.ThrowIfErrorAsync(msg).ConfigureAwait(false);

            return await msg.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        void WriteLog(string content, string currentMethod)
        {
            if (Log != null)
            {
                Log.WriteLine("--Log Starts Here--");
                Log.WriteLine("Query:" + content);
                Log.WriteLine("Method:" + currentMethod);
                Log.WriteLine("--Log Ends Here--");
                Log.Flush();
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            Log?.Dispose();
        }


        public static TextWriter Log { get; set; }
        readonly object streamingCallbackLock = new object();
        public Func<StreamContent, Task> StreamingCallbackAsync { get; set; }
        internal HttpClient StreamingClient { get; set; }
        readonly object asyncCallbackLock = new object();
        public IAuthorization Authorizer { get; set; }
        public Uri LastUrl { get; set; }
        public IDictionary<string, string> ResponseHeaders { get; set; }
        /// <summary>
        /// Gets and sets HTTP UserAgent header
        /// </summary>
        public string UserAgent
        {
            get => Authorizer.UserAgent;
            set => Authorizer.UserAgent =
                string.IsNullOrWhiteSpace(value) ?
                    Authorizer.UserAgent :
                    value + ", " + Authorizer.UserAgent;
        }
        public int ReadWriteTimeout { get; set; }
        public int Timeout { get; set; }

        public bool IsStreamClosed { get; set; }
        public CancellationToken CancellationToken { get; set; }
    }
}