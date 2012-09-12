using NUnit.Framework;
using EmployeesMvc.Controllers;
using EmployeesMvc.DataAccess;
using EmployeesMvc.Model;
using Rhino.Mocks;

namespace EmployeesMvc_UnitTests.Controllers
{
    [TestFixture]
    public class EditController_Tests
    {
        private int _employeeId = 1;
        private Employee _employee;

        [SetUp]
        public void Setup()
        {
            _employee = new Employee { Id = 1, FirstName = "test" };
        }

        [Test]
        public void Index_validUserId_getsUserFromEmployeeProvider()
        {
            var employeeProvider = MockRepository.GenerateMock<IEmployeeProvider>();
            var jobTitleProvider = MockRepository.GenerateStub<IJobTitleProvider>(); 
            var controller = new EmployeeController(employeeProvider, jobTitleProvider);

            controller.Edit(_employeeId);

            employeeProvider.AssertWasCalled(p => p.GetById(_employeeId)); 
        }

        [Test]
        public void Index_validUserId_putsEmployeeIntoViewData()
        {
            var employeeProvider = MockRepository.GenerateStub<IEmployeeProvider>();
            employeeProvider.Stub(p => p.GetById(_employeeId)).Return(_employee);
            var jobTitleProvider = MockRepository.GenerateStub<IJobTitleProvider>();
            var controller = new EmployeeController(employeeProvider, jobTitleProvider);

            controller.Edit(_employeeId);

            Assert.That(controller.ViewData["Employee"] != null);
            Assert.That((controller.ViewData["Employee"] as Employee).Id > 0); 
        }
    }
}
