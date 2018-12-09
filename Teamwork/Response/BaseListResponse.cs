using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teamwork.Generic;

namespace Teamwork.Response
{
    public class BaseListResponse<T> : BaseResponse
    {
        public List<T> List { get; set; }

        public static BaseListResponse<T> Deserialize<T>(string json, string rootName)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CustomResolver(rootName)
            };
            return JsonConvert.DeserializeObject<BaseListResponse<T>>(json, settings);
        }

        public static string Serialize(object data, string rootName)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new CustomResolver(rootName)
            };
            return JsonConvert.SerializeObject(data, settings);
        }

    }
}
