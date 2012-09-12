using NUnit.Framework;
using Rhino.Mocks;
using EmployeesMvc.DataAccess;
using System.Collections.Generic;

namespace EmployeesMvc.DataAccess_Tests
{
    [TestFixture]
    public class EmployeeProvider_Tests
    {
        private const string Name = "Alex";           
        private const string Title = "Developer";
        private const int TitleId = 1; 
        private Model.JobTitle _jobTitle;
        private IJobTitleProvider _jobTitleProvider;
        private const int EmployeeId = 1;
        private Model.Employee _employee; 

        [SetUp]
        public void Setup()
        {
            _jobTitle = new Model.JobTitle { Id = TitleId, Name = Title };
            _jobTitleProvider = MockRepository.GenerateStub<IJobTitleProvider>();
            _jobTitleProvider.Stub(j => j.GetById(TitleId)).Return(_jobTitle);

            _employee = new Model.Employee { Id = EmployeeId, FirstName = "Alex", Surname = "Martin", JobTitle = _jobTitle };
        }

        [Test]
        public void Find_validNameAndNullTitle_CallsListAllRepositoryMethod()
        {
            var employeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            var jobTitleProvider = MockRepository.GenerateStub<IJobTitleProvider>();
            var provider = new EmployeeProvider(employeeRepository, jobTitleProvider);

            provider.Find(Name, 0);

            employeeRepository.AssertWasCalled(r => r.ListAll());
        }

        [Test]
        public void Find_emptyNameAndValidTitle_CallsFindByJobTitleRepositoryMethod()
        {
            var employeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            var provider = new EmployeeProvider(employeeRepository, _jobTitleProvider);
            
            provider.Find(null, TitleId);

            employeeRepository.AssertWasCalled(r => r.FindByJobTitle(_jobTitle));
        }

        [Test]
        public void Find_validNameAndNullTitle_FiltersResultsByName()
        {
            var employeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepository.Stub(e => e.ListAll()).Return(GenerateListOfEmployees());
            var jobTitleProvider = MockRepository.GenerateStub<IJobTitleProvider>();
            var provider = new EmployeeProvider(employeeRepository, jobTitleProvider);

            var results = provider.Find(Name, 0);

            Assert.That(results.Count == 2); 
        }

        [Test]
        public void GetById_validId_callsRepository()
        {
            var employeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepository.Stub(e => e.GetById(EmployeeId)).Return(_employee);
            var jobTitleProvider = MockRepository.GenerateStub<IJobTitleProvider>();
            var provider = new EmployeeProvider(employeeRepository, jobTitleProvider);

            var results = provider.GetById(EmployeeId);

            employeeRepository.AssertWasCalled(e => e.GetById(EmployeeId)); 
        }

        private System.Collections.Generic.IList<Model.Employee> GenerateListOfEmployees()
        {
            var employees = new List<Model.Employee>();
            employees.Add(new Model.Employee { Id = 1, FirstName = "Alex", Surname = "Martin", JobTitle = _jobTitle });
            employees.Add(new Model.Employee { Id = 2, FirstName = "Martin", Surname = "Alexander", JobTitle = _jobTitle });
            employees.Add(new Model.Employee { Id = 3, FirstName = "Joe", Surname = "Bloggs", JobTitle = _jobTitle });
            return employees;
        }
    }
}
