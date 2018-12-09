using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Teamwork.Response;

namespace Teamwork.Generic
{
   public class CustomResolver : DefaultContractResolver
    {
       readonly string _rootName;

        public CustomResolver(string rootName)
        {
            this._rootName = rootName;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(BaseListResponse<>))
            {
                JsonProperty prop = props.First(p => p.UnderlyingName == "List");
                prop.PropertyName = this._rootName;
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(BaseSingleResponse<>))
            {
                JsonProperty prop = props.First(p => p.UnderlyingName == "Data");
                prop.PropertyName = this._rootName;
            }

            return props;
        }
    }
}
