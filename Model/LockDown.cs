using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkProjects.Model
{
    using Newtonsoft.Json;

    public class LockDown
    {
        public List<LockDownItems> items { get; set; }
        public List<Person> people { get; set; }

        [JsonProperty("grant-access-to", NullValueHandling = NullValueHandling.Ignore)]
        public string GrantAccessTo { get; set; }
         




    }


    public class LockDownItems
    {
        public string avatar { get; set; }
        public string name { get; set; }
        public string companyName { get; set; }
        public string id { get; set; }
        public string type { get; set; }
    }
}
