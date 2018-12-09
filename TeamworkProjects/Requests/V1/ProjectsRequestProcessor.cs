using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using LitJson;
using Newtonsoft.Json;
using Teamwork.Model.Projects.V1;
using TeamworkProjects.Model.V1;
using TeamworkProjects.Utilities;
using TeamworkProjects.Utilities.Linq;

namespace TeamworkProjects.Requests.V1
{
    class ProjectsRequestProcessor<T> : IRequestProcessor<T>, IRequestProcessorWantsJson
        where T : class
    {
        public string BaseUrl { get; set; }
        public Dictionary<string, string> GetParameters(LambdaExpression lambdaExpression)
        {
            return new ParameterFinder<Project>(
                    lambdaExpression.Body,
                    new List<string> {
                        "id",
                        "name"
                    })
                .Parameters;
        }

        public virtual Request BuildUrl(Dictionary<string, string> parameters)
        {
            var req = new Request(BaseUrl);
            var urlParams = req.RequestParameters;

            if (parameters.ContainsKey("id"))
            {
                var id = parameters["id"];
                req.Endpoint = string.Format($"{BaseUrl}\\{id}.json");
            }
            else
            {
                req.Endpoint = string.Format($"{BaseUrl}\\projects.json");
            }
         
            return req;
        }

        public List<T> ProcessResults(string projectsResponse)
        {
            if (string.IsNullOrWhiteSpace(projectsResponse)) return new List<T>();
            return JsonConvert.DeserializeObject<List<T>>(projectsResponse);

        }
    }
}
