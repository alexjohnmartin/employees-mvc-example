using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeesMvc.DataAccess;

namespace EmployeesMvc.Controllers
{
    public class EmployeesController : EmployeeBaseController
    {
        private IJobTitleProvider _jobTitleProvider;
        private IEmployeeProvider _employeeProvider;

        public EmployeesController()
            : this(new JobTitleProvider(), new EmployeeProvider())
        { }

        public EmployeesController(IJobTitleProvider jobTitleProvider, IEmployeeProvider employeeProvider)
        {
            _jobTitleProvider = jobTitleProvider;
            _employeeProvider = employeeProvider;
        }
        
        public ActionResult Index()
        {
            LoadJobTitlesList(_jobTitleProvider, true); 
            return View();
        }

        public ActionResult Search(string name, string jobTitles)
        {
            int titleId; 
            if (!ValidateSearchCriteria(name, jobTitles, out titleId))
                return View();

            FindEmployees(name, titleId);
            
            return View();
        }

        private void FindEmployees(string name, int titleId)
        {
            ViewData.Add("Results", _employeeProvider.Find(name, titleId));
        }

        private bool ValidateSearchCriteria(string name, string title, out int titleId)
        {
            int validatedTitleId = 0;
            int.TryParse(title, out validatedTitleId);
            titleId = validatedTitleId;
            if (string.IsNullOrEmpty(name) && titleId < 1)
            {
                ViewData.Add("ErrorMessage", "Please enter a name or job title to search for");
                return false;
            }

            return true;
        }
    }
}
