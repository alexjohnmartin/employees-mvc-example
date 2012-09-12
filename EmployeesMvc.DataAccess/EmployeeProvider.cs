using System.Collections.Generic;
using System.Linq;

namespace EmployeesMvc.DataAccess
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IJobTitleProvider _jobTitleProvider; 

        public EmployeeProvider()
            : this(new EmployeeRepository(), new JobTitleProvider())
        { }

        public EmployeeProvider(IEmployeeRepository employeeRepository, IJobTitleProvider jobTitleProvider)
        {
            _employeeRepository = employeeRepository;
            _jobTitleProvider = jobTitleProvider;
        }

        public IList<Model.Employee> Find(string name, int titleId)
        {
            IList<Model.Employee> employees;

            if (titleId < 1)
                employees = _employeeRepository.ListAll();
            else
            {
                var jobTitle = _jobTitleProvider.GetById(titleId);
                employees = _employeeRepository.FindByJobTitle(jobTitle); 
            }

            if (string.IsNullOrEmpty(name) || employees == null || employees.Count == 0)
                return employees;

            name = name.ToLower(); 
            return new List<Model.Employee>(
                from e in employees 
                    where e.FirstName.ToLower().Contains(name) 
                       || e.Surname.ToLower().Contains(name) 
                    select e);
        }
        
        public Model.Employee GetById(int employeeId)
        {
            return _employeeRepository.GetById(employeeId); 
        }


        public void Add(Model.Employee employee)
        {
            employee.SaveAndFlush(); 
        }

        public void Save(Model.Employee employee)
        {
            employee.SaveAndFlush();
        }
    }
}
