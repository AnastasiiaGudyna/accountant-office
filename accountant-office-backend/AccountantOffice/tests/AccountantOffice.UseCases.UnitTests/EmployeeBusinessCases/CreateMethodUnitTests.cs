using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using AutoMapper;

namespace AccountantOffice.UseCases.UnitTests.EmployeeBusinessCases;

public class CreateMethodUnitTests
{
    private readonly Cases.EmployeeBusinessCases cases;
    private readonly IRepository<Employee> employeeRepository;
    private readonly IRepository<Department> departmentRepository;
    private readonly IFixture fixture;

    public CreateMethodUnitTests()
    {
        employeeRepository = Substitute.For<IRepository<Employee>>();
        departmentRepository = Substitute.For<IRepository<Department>>();
        var mapper = Substitute.For<IMapper>();

        cases = new Cases.EmployeeBusinessCases(employeeRepository, departmentRepository, mapper);
        fixture = new Fixture();
        fixture.Register(() => fixture.Build<Employee>().Without(e => e.Department).Create());
    }
    
    [Fact]
    public void Create_Returns_CreatedItemGuidFromRepo()
    {
        var employee = fixture.Create<Employee>();
        var expectedEmployeeId = fixture.Create<Guid>();
        employeeRepository.CreateItem(Arg.Any<Employee>()).ReturnsForAnyArgs(expectedEmployeeId);
        departmentRepository.GetItemById(Arg.Any<Guid>()).ReturnsForAnyArgs(fixture.Create<Department>());
        
        var createdEmployeeId = cases.Create(employee);

        createdEmployeeId.Should().Be(expectedEmployeeId);
    }
    
    [Fact]
    public void Create_Calls_DepartmentRepoGetItemByIdMethod()
    {
        var employee = fixture.Create<Employee>();
        var expectedEmployeeId = fixture.Create<Guid>();
        employeeRepository.CreateItem(Arg.Any<Employee>()).ReturnsForAnyArgs(expectedEmployeeId);
        departmentRepository.GetItemById(Arg.Any<Guid>()).ReturnsForAnyArgs(fixture.Create<Department>());
        
        var createdEmployeeId = cases.Create(employee);

        departmentRepository.Received().GetItemById(employee.DepartmentId);
    }
    
    [Fact]
    public void Create_EmployeeDepartmentProperty_FilledFromDepartmentRepoGetItemByIdMethod()
    {
        var employee = fixture.Create<Employee>();
        var expectedEmployeeId = fixture.Create<Guid>();
        employeeRepository.CreateItem(Arg.Any<Employee>()).ReturnsForAnyArgs(expectedEmployeeId);
        var department = fixture.Create<Department>();
        departmentRepository.GetItemById(Arg.Any<Guid>()).ReturnsForAnyArgs(department);
        
        var createdEmployeeId = cases.Create(employee);

        employee.Department.Should().BeEquivalentTo(department);
    }
}