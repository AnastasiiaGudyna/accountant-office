using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using AutoMapper;

namespace AccountantOffice.UseCases.UnitTests.EmployeeBusinessCases;

public class DeleteMethodUnitTests
{
    private readonly Cases.EmployeeBusinessCases cases;
    private readonly IRepository<Employee> employeeRepository;
    private readonly IFixture fixture;

    public DeleteMethodUnitTests()
    {
        employeeRepository = Substitute.For<IRepository<Employee>>();
        var mapper = Substitute.For<IMapper>();
        var departmentRepository = Substitute.For<IRepository<Department>>();

        cases = new Cases.EmployeeBusinessCases(employeeRepository, departmentRepository, mapper);
        fixture = new Fixture();
        fixture.Register(() => fixture.Build<Employee>().Without(e => e.Department).Create());
    }
    
    [Fact]
    public void Delete_Calls_EmployeeRepoMethods()
    {
        var employee = fixture.Create<Employee>();
        var employeeId = fixture.Create<Guid>();
        employeeRepository.GetItemById(Arg.Any<Guid>()).ReturnsForAnyArgs(employee);
        employeeRepository.DeleteItem(Arg.Any<Employee>()).ReturnsForAnyArgs(employeeId);
        
        var deletedEmployeeId = cases.Delete(employeeId);

        employeeRepository.Received().GetItemById(employeeId);
        employeeRepository.Received().DeleteItem(employee);
    }
    
    [Fact]
    public void Delete_Returns_GuidFromDeleteItemMethod()
    {
        var employee = fixture.Create<Employee>();
        var expectedEmployeeId = fixture.Create<Guid>();
        employeeRepository.GetItemById(Arg.Any<Guid>()).ReturnsForAnyArgs(employee);
        employeeRepository.DeleteItem(Arg.Any<Employee>()).ReturnsForAnyArgs(expectedEmployeeId);
        
        var deletedEmployeeId = cases.Delete(fixture.Create<Guid>());

        deletedEmployeeId.Should().Be(expectedEmployeeId);
    }
}