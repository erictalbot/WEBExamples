using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ui_base.Dto;

namespace ui_base.Controllers
{
    public class ProjectController : ApiController
    {
    
        public IEnumerable<Project> Get()
        {
            List<Project> allProjects = new List<Project>();
            allProjects.Add(new Project() { Id = 1, Name = "name1", Number = "number1" });
            allProjects.Add(new Project() { Id = 2, Name = "name2", Number = "number2" });
            allProjects.Add(new Project() { Id = 3, Name = "name3", Number = "number3" });
            return allProjects;
        }

    }
}
