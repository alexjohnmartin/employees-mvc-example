using System.Collections.Generic;

namespace EmployeesMvc.DataAccess
{
    public interface IEmployeeRepository
    {
        IList<EmployeesMvc.Model.Employee> FindByJobTitle(EmployeesMvc.Model.JobTitle jobTitle);
        IList<EmployeesMvc.Model.Employee> ListAll();
        EmployeesMvc.Model.Employee GetById(int EmployeeId);
    }
}
