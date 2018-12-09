using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teamwork.Generic;

namespace Teamwork.Response
{
    public class BaseSingleResponse<T> : BaseResponse
    {

        public T Data { get; set; }

        public static BaseSingleResponse<T> Deserialize<T>(string json, string rootName)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CustomResolver(rootName)
            };
            return JsonConvert.DeserializeObject<BaseSingleResponse<T>>(json, settings);
        }

        string Serialize(object data, string rootName)
        {
            return Serialize(data, rootName);
        }

    }
}
