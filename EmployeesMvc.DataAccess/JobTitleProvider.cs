using System.Linq;
using System.Collections.Generic;
using Castle.ActiveRecord;
using EmployeesMvc.Model;

namespace EmployeesMvc.DataAccess
{
    public class JobTitleProvider : IJobTitleProvider
    {
        public IList<JobTitle> ListAll()
        {
            return new List<JobTitle>(JobTitle.FindAll());
        }


        public JobTitle GetByName(string title)
        {
            return JobTitle.FindAllByProperty("Name", title).First();
        }

        public JobTitle GetById(int titleId)
        {
            return JobTitle.Find(titleId);
        }
    }
}
