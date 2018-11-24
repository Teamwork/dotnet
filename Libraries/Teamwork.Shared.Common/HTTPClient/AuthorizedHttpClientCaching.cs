namespace Teamwork
{
    using System.Net.Http;

    public partial class AuthorizedHttpClient : HttpClient
    {

        public ClientCache Cache { get; set; } = new ClientCache();





    }
}
