using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeesMvc.DataAccess;

namespace EmployeesMvc.Controllers
{
    public class EmployeeController : EmployeeBaseController
    {
        private DataAccess.IEmployeeProvider _employeeProvider;
        private DataAccess.IJobTitleProvider _jobTitleProvider; 

        public EmployeeController(DataAccess.IEmployeeProvider employeeProvider, DataAccess.IJobTitleProvider jobTitleProvider)
        {
            _employeeProvider = employeeProvider;
            _jobTitleProvider = jobTitleProvider; 
        }

        public EmployeeController()
            : this(new EmployeeProvider(), new JobTitleProvider())
        { }

        public ActionResult Index()
        {
            LoadJobTitlesList(_jobTitleProvider, false); 
            return View();
        }

        public ActionResult Edit(int employeeId)
        {
            LoadJobTitlesList(_jobTitleProvider, false); 
            ViewData.Add("Employee", _employeeProvider.GetById(employeeId)); 
            return View();
        }

        public ActionResult Add(string firstname, string surname, string jobTitles)
        {
            try
            {
                var jobTitleId = int.Parse(jobTitles);
                _employeeProvider.Add(new Model.Employee { FirstName = firstname, Surname = surname, JobTitle = _jobTitleProvider.GetById(jobTitleId) });
                ViewData.Add("message", "saved"); 
            }
            catch(Exception ex)
            {
                ViewData.Add("message", "error - " + ex.Message); 
            }

            return View("Complete"); 
        }

        public ActionResult Save(string firstname, string surname, string jobTitles, string id)
        {
            try
            {
                var employeeId = int.Parse(id); 
                var jobTitleId = int.Parse(jobTitles); 
                _employeeProvider.Add(new Model.Employee{FirstName = firstname, Surname = surname, JobTitle = _jobTitleProvider.GetById(jobTitleId), Id = employeeId });
                ViewData.Add("message", "saved"); 
            }
            catch(Exception ex)
            {
                ViewData.Add("message", "error - " + ex.Message); 
            }

            return View("Complete"); 
        }
    }
}
