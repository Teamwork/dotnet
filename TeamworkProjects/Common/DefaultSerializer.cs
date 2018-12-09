using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TeamworkProjects.Common
{
    public class DefaultJsonSerializer : JsonSerializerSettings
    {
        public DefaultJsonSerializer()
        {
            NullValueHandling = NullValueHandling.Ignore;
        }
    }
}
