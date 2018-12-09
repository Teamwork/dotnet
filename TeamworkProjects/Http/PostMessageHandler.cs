using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace TeamworkProjects.Http
{
    class PostMessageHandler : HttpClientHandler
    {
        readonly TeamworkProjectsHandler exe;
        readonly IDictionary<string, string> postData;
        readonly string url;

        public PostMessageHandler(TeamworkProjectsHandler exe, IDictionary<string, string> postData, string url)
        {
            this.exe = exe;
            this.postData = postData;
            this.url = url;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            exe.SetAuthorizationHeader(request.Method.ToString(), url, postData, request);
            request.Headers.Add("User-Agent", exe.UserAgent);
            request.Headers.ExpectContinue = false;
            request.Headers.CacheControl = new CacheControlHeaderValue { NoCache = true };

            if (SupportsAutomaticDecompression)
                AutomaticDecompression = DecompressionMethods.GZip;
            if (exe.Authorizer.Proxy != null && SupportsProxy)
                Proxy = exe.Authorizer.Proxy;

            //if (exe.ReadWriteTimeout != 0)
            //    ReadWriteTimeout = exe.ReadWriteTimeout;

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}