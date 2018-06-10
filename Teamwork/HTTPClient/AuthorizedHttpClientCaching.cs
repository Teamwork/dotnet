using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamwork.HTTPClient
{
    using System.Net.Http;

    public partial class AuthorizedHttpClient : HttpClient
    {

        public ClientCache Cache { get; set; } = new ClientCache();





    }
}
