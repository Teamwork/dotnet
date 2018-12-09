using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkProjects.Security
{
    public interface IAuthorization
    {
        Task AuthorizeAsync();

        string UserAgent { get; set; }

        ICredentialStore CredentialStore { get; set; }

        IWebProxy Proxy { get; set; }

        bool SupportsCompression { get; set; }

        string GetAuthorizationString(string method, string oauthUrl, IDictionary<string, string> parameters);
    }
}
