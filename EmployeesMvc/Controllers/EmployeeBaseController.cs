using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeesMvc.Controllers
{
    public abstract class EmployeeBaseController : Controller
    {
        protected void LoadJobTitlesList(DataAccess.IJobTitleProvider _jobTitleProvider, bool includeAnyListItem)
        {
            IList<Models.JobTitle> modelTitles = new List<Models.JobTitle>(from j in _jobTitleProvider.ListAll() select new Models.JobTitle(j));
            if (includeAnyListItem) modelTitles.Add(new Models.JobTitle { Id = 0, Name = "any" });
            var modelTitlesOrdered = from j in modelTitles orderby j.Id select j;
            var selectList = new SelectList(modelTitlesOrdered, "Id", "Name", string.Empty);
            ViewData.Add("JobTitles", selectList);
        }
    }
}
