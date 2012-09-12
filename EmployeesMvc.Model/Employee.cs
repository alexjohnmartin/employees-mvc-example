using Castle.ActiveRecord;

namespace EmployeesMvc.Model
{
    [ActiveRecord("Employees")]
    public class Employee : ActiveRecordBase<Employee>
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Property]
        public string FirstName { get; set; }

        [Property]
        public string Surname { get; set; }

        [BelongsTo("JobTitleId")]
        public JobTitle JobTitle { get; set; }
    }
}
