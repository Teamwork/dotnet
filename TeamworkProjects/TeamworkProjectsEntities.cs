using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamworkProjects.Model.V1;
using TeamworkProjects.Utilities.Linq;

namespace TeamworkProjects
{
    public partial class TeamworkProjectsContext
    {
        /// <summary>
        /// Allow searching Teamwork Entities
        /// </summary>
        public TeamworkQueryable<Project> Projects => new TeamworkQueryable<Project>(this);

        public IEnumerable<Project> ProjectList
        {
            get
            {

            }
        }
 
        public TeamworkQueryable<Company> Companies => new TeamworkQueryable<Company>(this);
    }
}