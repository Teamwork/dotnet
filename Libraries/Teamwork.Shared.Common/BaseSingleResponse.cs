using Newtonsoft.Json;
using Teamwork.Shared.Common.Generic;

namespace Teamwork.Shared.Common.Response
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
