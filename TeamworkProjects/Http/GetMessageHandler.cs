using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeamworkProjects.Http
{
    class GetMessageHandler : HttpClientHandler
    {
        readonly TeamworkProjectsHandler handler;
        readonly IDictionary<string, string> parameters;
        readonly string url;

        public GetMessageHandler(TeamworkProjectsHandler exe, IDictionary<string, string> parameters, string url)
        {
            this.handler = exe;
            this.parameters = parameters;
            this.url = url;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            handler.SetAuthorizationHeader(HttpMethod.Get.ToString(), url, parameters, request);
            request.Headers.Add("User-Agent", handler.UserAgent);
            request.Headers.ExpectContinue = false;
            if (SupportsAutomaticDecompression)
                AutomaticDecompression = DecompressionMethods.GZip;
            if (handler.Authorizer.Proxy != null && SupportsProxy)
                Proxy = handler.Authorizer.Proxy;

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
