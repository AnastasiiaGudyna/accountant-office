using System.Linq.Expressions;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using AccountantOffice.UseCases.Models;
using AutoMapper;

namespace AccountantOffice.UseCases.UnitTests.EmployeeBusinessCases;

public class GetEmployeesMethodUnitTests
{
    private readonly Cases.EmployeeBusinessCases cases;
    private readonly IRepository<Employee> employeeRepository;
    private readonly IMapper mapper;
    private readonly IFixture fixture;

    public GetEmployeesMethodUnitTests()
    {
        employeeRepository = Substitute.For<IRepository<Employee>>();
        mapper = Substitute.For<IMapper>();
        var departmentRepository = Substitute.For<IRepository<Department>>();

        cases = new Cases.EmployeeBusinessCases(employeeRepository, departmentRepository, mapper);
        fixture = new Fixture();
        fixture.Register(() => fixture.Build<Employee>().Without(e => e.Department).Create());
    }
    
    [Fact]
    public void GetEmployees_Calls_GetListFromEmployeeRepo()
    {
        var expectedEmployees = fixture.Create<IEnumerable<Employee>>().AsQueryable();
        employeeRepository.GetList(Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(expectedEmployees);
        var showSalary = fixture.Create<bool>();
        var page = fixture.Create<int>();
        var items = fixture.Create<int>();

        var employees = cases.GetEmployees(showSalary, page, items);

        employeeRepository.Received().GetList(page, items);
        mapper.Received().ProjectTo<EmployeeModel>(expectedEmployees, Arg.Any<object>());
    }
    
    [Fact]
    public void GetEmployees_Returns_ListOfItemsMapped()
    {
        var expectedEmployees = fixture.Create<IEnumerable<Employee>>().AsQueryable();
        var expectedEmployeeModels = fixture.Create<IEnumerable<EmployeeModel>>().AsQueryable();
        employeeRepository.GetList(Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(expectedEmployees);
        mapper.ProjectTo<EmployeeModel>(Arg.Any<IQueryable<Employee>>(), Arg.Any<object>())
            .ReturnsForAnyArgs(expectedEmployeeModels);
        
        var showSalary = fixture.Create<bool>();
        var page = fixture.Create<int>();
        var items = fixture.Create<int>();

        var actualEmployees = cases.GetEmployees(showSalary, page, items);

        actualEmployees.Should().BeEquivalentTo(expectedEmployeeModels);
    }
    
    [Fact]
    public void GetEmployeesForDepartment_Calls_GetListFromEmployeeRepo()
    {
        var expectedEmployees = fixture.Create<IEnumerable<Employee>>().AsQueryable();
        employeeRepository.GetList(Arg.Any<Expression<Func<Employee, bool>>>(), Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(expectedEmployees);
        var departmentId = fixture.Create<Guid>(); 
        var showSalary = fixture.Create<bool>();
        var page = fixture.Create<int>();
        var items = fixture.Create<int>();
        
        var employees = cases.GetEmployees(departmentId, showSalary, page, items);

        employeeRepository.Received().GetList(Arg.Any<Expression<Func<Employee, bool>>>(), page, items);
        mapper.Received().ProjectTo<EmployeeModel>(expectedEmployees, Arg.Any<object>());
    }
    
    [Fact]
    public void GetEmployeesForDepartment_Returns_ListOfItemsMapped()
    {
        var expectedEmployees = fixture.Create<IEnumerable<Employee>>().AsQueryable();
        var expectedEmployeeModels = fixture.Create<IEnumerable<EmployeeModel>>().AsQueryable();
        employeeRepository.GetList(Arg.Any<Expression<Func<Employee, bool>>>(), Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(expectedEmployees);
        mapper.ProjectTo<EmployeeModel>(Arg.Any<IQueryable<Employee>>(), Arg.Any<object>())
            .ReturnsForAnyArgs(expectedEmployeeModels);
        var departmentId = fixture.Create<Guid>();
        var showSalary = fixture.Create<bool>();
        var page = fixture.Create<int>();
        var items = fixture.Create<int>();

        var actualEmployees = cases.GetEmployees(departmentId, showSalary, page, items);

        actualEmployees.Should().BeEquivalentTo(expectedEmployeeModels);
    }
}