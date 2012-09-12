using System.Collections.Generic;

namespace EmployeesMvc.DataAccess
{
    public interface IEmployeeProvider
    {
        IList<Model.Employee> Find(string name, int jobTitleId);
        Model.Employee GetById(int userId);
        void Add(Model.Employee employee); 
        void Save(Model.Employee employee); 
    }
}
