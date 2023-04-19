using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Cases;
using AccountantOffice.UseCases.Interfaces;
using AutoMapper;

namespace AccountantOffice.UseCases.UnitTests;

public class EmployeeBusinessCasesUnitTests
{
    private readonly EmployeeBusinessCases cases;
    private readonly IRepository<Employee> employeeRepository;
    private readonly IRepository<Department> departmentRepository;
    private readonly IMapper mapper;
    private readonly Fixture fixture;

    public EmployeeBusinessCasesUnitTests()
    {
        employeeRepository = Substitute.For<IRepository<Employee>>();
        departmentRepository = Substitute.For<IRepository<Department>>();
        mapper = Substitute.For<IMapper>();

        cases = new EmployeeBusinessCases(employeeRepository, departmentRepository, mapper);
        fixture = new Fixture();
    }
    [Fact]
    public void GetEmployees_()
    {
        var page = fixture.Create<int>();
        var items = fixture.Create<int>();

        var employees = cases.GetEmployees(page, items);

        employeeRepository.Received().GetList(page, items);
    }
}