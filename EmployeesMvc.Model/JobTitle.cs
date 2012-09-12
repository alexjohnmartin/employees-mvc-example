using Castle.ActiveRecord;
using System.Collections.Generic;

namespace EmployeesMvc.Model
{
    [ActiveRecord("JobTitles")]
    public class JobTitle : ActiveRecordBase<JobTitle>
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Property]
        public string Name { get; set; }

        //[HasMany(typeof(Employee))]
        //public IList<Employee> Employees { get; set; }
    }
}
