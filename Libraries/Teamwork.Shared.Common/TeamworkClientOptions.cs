using System;
using System.Collections.Generic;
using System.Text;

namespace Teamwork.Shared.Common
{
   public class TeamworkClientOptions
   {
    
       /// <summary>
       /// Lazyloading for child objects and arrays. Like automatically load Tasklists and milestones for a project etc
       /// </summary>
       public bool LazyLoading { get; set; } = false;

       /// <summary>
       /// When an object does not have an ID set, .Update() will do a POST instead of Put to automatically create
       /// the item and get back the id. 
       /// </summary>
       public bool AutoPost { get; set; } = true;

   }
}
