using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamworkProjects;
using TeamworkProjects.Model.V1;
using TeamworkProjects.Security;
using TeamworkProjects.Utilities;

namespace TeamworkProjectsTest_NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


           var ok =  GetProjects().Result;


        }


        public static async Task<bool> GetProjects()
        {
            var ctx = new TeamworkProjectsContext(new ApiKeyAuthorizer("123456"), new Uri("http://www.google.de"));
            var projects = await ctx.Projects.Where(p=>p.Name.Contains("test")).ToListAsync();


            return false;
        }

    }




}
