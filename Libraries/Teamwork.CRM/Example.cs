using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Teamwork.CRM
{
	public class Class1
	{
		public async void Init()
		{
			var http = new HttpClient();
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			http.BaseAddress = new System.Uri("baseUrl");
			http.DefaultRequestHeaders.Authorization =new AuthenticationHeaderValue("Bearer", "<AccessToken>");
			http.DefaultRequestHeaders.Accept.Clear();
			http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			var client = new TeamworkCRM(http, true);
			var data = await client.GET.ActivitiesCompletedAsync();
			var result = await client.POST.ActivitiesAsync(new Models.V1createActivityRequest());
		}

	}
}
