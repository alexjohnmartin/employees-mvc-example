using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeesMvc.Model;

namespace EmployeesMvc.DataAccess
{
    public interface IJobTitleProvider
    {
        IList<JobTitle> ListAll();
        JobTitle GetByName(string title);
        JobTitle GetById(int titleId);
    }
}
