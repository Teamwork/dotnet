using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Teamwork;
using Teamwork.Model.Projects.V1;

namespace Teamwork.Response
{
  public class CategoriesResponse
  {
    [JsonProperty("categories")]
    public List<Category> Categories { get; set; }

    [JsonProperty("STATUS")]
    public string STATUS { get; set; }
  }

  public class CategoryResponse
  {
    [JsonProperty("category")]
    public Category Category { get; set; }

    [JsonProperty("STATUS")]
    public string STATUS { get; set; }
  }

}
