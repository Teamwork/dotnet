using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LitJson;
using TeamworkProjects.Http;
using TeamworkProjects.Serialization;
using TeamworkProjects.Utilities;

namespace TeamworkProjects.Security
{
    public class ApiKeyAuthorizer : IAuthorization
    {
        public string BasicToken { get; set; }
        public string BearerToken { get; set; }


        public ApiKeyAuthorizer(){}

        public ApiKeyAuthorizer(string Token)
        {
            BearerToken = Token;
        }

        public async Task AuthorizeAsync(string Token)
        {
            EncodeCredentials();
            await GetBearerTokenAsync().ConfigureAwait(false);
        }

        public async Task AuthorizeAsync()
        {
            EncodeCredentials();
            await GetBearerTokenAsync().ConfigureAwait(false);
        }

        public string UserAgent { get; set; }
        public ICredentialStore CredentialStore { get; set; }
        public IWebProxy Proxy { get; set; }
        public bool SupportsCompression { get; set; }




        async Task GetBearerTokenAsync()
        {
            var req = new HttpRequestMessage(System.Net.Http.HttpMethod.Post, BearerToken);
            req.Headers.Add("Authorization", "Bearer " + BearerToken);
            req.Headers.Add("User-Agent", UserAgent);
            req.Headers.ExpectContinue = false;
            req.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
                handler.AutomaticDecompression = DecompressionMethods.GZip;
            if (Proxy != null && handler.SupportsProxy)
                handler.Proxy = Proxy;

            using (var client = new HttpClient(handler))
            {
                var msg = await client.SendAsync(req).ConfigureAwait(false);

                await TeamworkErrorHandler.ThrowIfErrorAsync(msg);

                string response = await msg.Content.ReadAsStringAsync().ConfigureAwait(false);

                var responseJson = JsonMapper.ToObject(response);
                BearerToken = responseJson.GetValue<string>("access_token");
            }
        }

        internal void EncodeCredentials()
        {
            string encodedConsumerKey = Url.PercentEncode(CredentialStore.ConsumerKey);
            string encodedConsumerSecret = Url.PercentEncode(CredentialStore.ConsumerSecret);

            string concatenatedCredentials = encodedConsumerKey + ":" + encodedConsumerSecret;

            byte[] credBytes = Encoding.UTF8.GetBytes(concatenatedCredentials);

            string base64Credentials = Convert.ToBase64String(credBytes);

            BasicToken = base64Credentials;
        }

        public string GetAuthorizationString(string method, string oauthUrl, IDictionary<string, string> parameters)
        {
            return "Bearer " + BearerToken;
        }
    }
}
