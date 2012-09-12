using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeesMvc.Models
{
    public class JobTitle : Model.JobTitle
    {
        public JobTitle(Model.JobTitle domainJobTitle)
        {
            Id = domainJobTitle.Id;
            Name = domainJobTitle.Name;
        }

        public JobTitle()
        { }
    }
}