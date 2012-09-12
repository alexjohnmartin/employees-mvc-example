using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeesMvc.DataAccess
{
    public class EmployeeRepository : EmployeesMvc.DataAccess.IEmployeeRepository
    {
        public IList<Model.Employee> FindByJobTitle(Model.JobTitle jobTitle)
        {
            return new List<Model.Employee>(Model.Employee.FindAllByProperty("JobTitle", jobTitle));
        }

        public IList<Model.Employee> ListAll()
        {
            return new List<Model.Employee>(Model.Employee.FindAll());
        }


        public Model.Employee GetById(int employeeId)
        {
            return Model.Employee.Find(employeeId);
        }
    }
}
