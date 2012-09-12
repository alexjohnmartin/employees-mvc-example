using NUnit.Framework;
using Rhino.Mocks;
using EmployeesMvc.DataAccess;
using EmployeesMvc;
using System.Collections.Generic;
using EmployeesMvc.Model;

namespace EmployeesMvc_UnitTests.Controllers
{
    [TestFixture]
    public class SearchCrtieriaController_Tests
    {
        [Test]
        public void Index_noInputs_searchesForJobTitles()
        {
            var jobTitleProvider = MockRepository.GenerateMock<IJobTitleProvider>();
            jobTitleProvider.Stub(j => j.ListAll()).Return(new List<EmployeesMvc.Model.JobTitle> { new EmployeesMvc.Model.JobTitle { Id = 1, Name = "test" } });
            var employeeProvider = MockRepository.GenerateStub<IEmployeeProvider>();
            var controller = new EmployeesMvc.Controllers.EmployeesController(jobTitleProvider, employeeProvider);

            controller.Index();

            jobTitleProvider.AssertWasCalled(j => j.ListAll()); 
        }

        [Test]
        public void Search_nullNameAndNullJobTitle_emptySearchResultsAndErrorMessage()
        {
            var jobTitleProvider = MockRepository.GenerateStub<IJobTitleProvider>();
            var employeeProvider = MockRepository.GenerateMock<IEmployeeProvider>();
            var controller = new EmployeesMvc.Controllers.EmployeesController(jobTitleProvider, employeeProvider);
            string name = null;
            string title = null;

            var result = controller.Search(name, title);

            Assert.That(controller.ViewData["ErrorMessage"] != null);
            Assert.That(controller.ViewData["Results"] == null); 
        }

        [Test]
        public void Search_validNameAndNullJobTitle_1SearchResult()
        {
            string name = "alex";
            string title = null;
            int titleId = 0;
            IList<Employee> results = new List<Employee> { new Employee{ Id = 1, FirstName = "Alex", Surname = "Martin", JobTitle = new JobTitle{Id = 3, Name = "Senior Developer" }}};
            var jobTitleProvider = MockRepository.GenerateStub<IJobTitleProvider>();
            var employeeProvider = MockRepository.GenerateMock<IEmployeeProvider>();
            employeeProvider.Stub(e => e.Find(name, titleId)).Return(results);
            var controller = new EmployeesMvc.Controllers.EmployeesController(jobTitleProvider, employeeProvider);

            var result = controller.Search(name, title);

            Assert.That(controller.ViewData["ErrorMessage"] == null);
            employeeProvider.AssertWasCalled(e => e.Find(name, titleId));
            Assert.That(controller.ViewData["Results"] != null);
            Assert.That(((IList<Employee>)controller.ViewData["Results"]).Count == 1);
        }

        [Test]
        public void Search_emptyNameAndValidJobTitle_1SearchResult()
        {
            string name = null;
            string title = "Senior Developer";
            int titleId = 1;
            IList<Employee> results = new List<Employee> { new Employee { Id = 1, FirstName = "Alex", Surname = "Martin", JobTitle = new JobTitle { Id = 3, Name = "Senior Developer" } } };
            var jobTitleProvider = MockRepository.GenerateStub<IJobTitleProvider>();
            var employeeProvider = MockRepository.GenerateMock<IEmployeeProvider>();
            employeeProvider.Stub(e => e.Find(name, titleId)).Return(results);
            var controller = new EmployeesMvc.Controllers.EmployeesController(jobTitleProvider, employeeProvider);

            var result = controller.Search(name, titleId.ToString());

            Assert.That(controller.ViewData["ErrorMessage"] == null);
            employeeProvider.AssertWasCalled(e => e.Find(name, titleId));
            Assert.That(controller.ViewData["Results"] != null);
            Assert.That(((IList<Employee>)controller.ViewData["Results"]).Count == 1);
        }
    }
}
