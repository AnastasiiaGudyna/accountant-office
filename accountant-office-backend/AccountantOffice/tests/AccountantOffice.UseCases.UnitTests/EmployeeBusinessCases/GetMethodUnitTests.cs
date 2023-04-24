using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using AutoMapper;

namespace AccountantOffice.UseCases.UnitTests.EmployeeBusinessCases;

public class GetMethodUnitTests
{
    private readonly Cases.EmployeeBusinessCases cases;
    private readonly IRepository<Employee> employeeRepository;
    private readonly IFixture fixture;

    public GetMethodUnitTests()
    {
        employeeRepository = Substitute.For<IRepository<Employee>>();
        var mapper = Substitute.For<IMapper>();
        var departmentRepository = Substitute.For<IRepository<Department>>();

        cases = new Cases.EmployeeBusinessCases(employeeRepository, departmentRepository, mapper);
        fixture = new Fixture();
        fixture.Register(() => fixture.Build<Employee>().Without(e => e.Department).Create());
    }
    
    [Fact]
    public void Get_Calls_GetFromRepo()
    {
        var employeeId = fixture.Create<Guid>();

        var actualEmployee = cases.Get(employeeId);

        employeeRepository.Received().GetItemById(employeeId);
    }
    
    [Fact]
    public void Get_Returns_EmployeeFromRepo()
    {
        var expectedEmployee = fixture.Create<Employee>();
        employeeRepository.GetItemById(Arg.Any<Guid>()).ReturnsForAnyArgs(expectedEmployee);
        var employeeId = fixture.Create<Guid>();

        var actualEmployee = cases.Get(employeeId);

        actualEmployee.Should().BeEquivalentTo(expectedEmployee);
    }
}